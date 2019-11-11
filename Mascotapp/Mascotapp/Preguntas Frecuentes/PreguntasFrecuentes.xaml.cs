using System;
using Domain.Entidades;
using Domain.Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mascotapp.NavigationMenu;

/*

<StackLayout x:Name="PreguntasR" Padding="0" BackgroundColor="White" Spacing="0">
    <StackLayout x:Name="Test" Padding="10" BackgroundColor="Accent" HorizontalOptions="FillAndExpand">
        <StackLayout.GestureRecognizers>
            <TapGestureRecognizer NumberOfTapsRequired="1" Tapped="Title_Clicked" />
        </StackLayout.GestureRecognizers>
        <Label x:Name="TitleText" Text="{Binding Title}" />
    </StackLayout>
    <StackLayout x:Name="ExpandableLayout" Padding="0" HorizontalOptions="FillAndExpand" Opacity="0">
        <StackLayout x:Name="ExpandableContent" Padding="10">
            <Label x:Name="ExpandableText" Text="{Binding Text}" />
        </StackLayout>
    </StackLayout>
</StackLayout>

*/
namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntasFrecuentes : ContentPage
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: "Title",
            returnType: typeof(string),
            declaringType: typeof(PreguntasFrecuentes),
            defaultValue: default(string));
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(PreguntasFrecuentes),
            defaultValue: default(string));

        private bool _IsExpanding;
        private ServicioPreguntasFrecuentes servicioPreguntas = new ServicioPreguntasFrecuentes();
        public PreguntasFrecuentes()
        {
            InitializeComponent();
            CargarElementos();

        }
        public async void CargarElementos()
        {
            List<Preguntas> preguntas = servicioPreguntas.ObtenerPreguntas();
            if (preguntas.Count > 0)
            {
                foreach (Preguntas item in preguntas)
                {
                    StackLayout stack = new StackLayout
                    {
                        Padding = 0,
                        BackgroundColor = Color.Gray,
                        Spacing = 0
                    };
                    var tgr = new TapGestureRecognizer();
                    tgr.Tapped += (s, e) => Title_Clicked(s, e);
                    StackLayout stackPreg = new StackLayout
                    {
                        Padding = 10,
                        BackgroundColor = Color.Gray,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Spacing = 0
                    };
                    stack.GestureRecognizers.Add(tgr);
                    Label lbPregunta = new Label
                    {
                        Text = item.Pregunta
                    };
                    stackPreg.Children.Add(lbPregunta);

                    StackLayout ExpandableLayout = new StackLayout
                    {
                        Padding = 0,
                        BackgroundColor = Color.LightGray,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Opacity = 0,
                        Spacing = 0
                    };

                    StackLayout ExpandableContent = new StackLayout
                    {
                        Padding = 5,
                    };

                    Label ExpandableText = new Label
                    {
                        Text = item.Respuesta
                    };
                    ExpandableLayout.HeightRequest = 0;
                    ExpandableContent.Children.Add(ExpandableText);
                    ExpandableLayout.Children.Add(ExpandableContent);
                    stack.Children.Add(stackPreg);
                    stack.Children.Add(ExpandableLayout);
                    Mostrar.Children.Add(stack);
                }
            }
            else
            {
                await DisplayAlert("Preguntas", "No hay preguntas?!", "OK");
            }
        }

        private async void Title_Clicked(object sender, EventArgs e)
        {
            StackLayout Content = (StackLayout)sender;
            StackLayout ExpandableLayout = (StackLayout)Content.Children[1];
            if (!_IsExpanding)
            {
                _IsExpanding = true;
                var height = Content.Height;
                if (ExpandableLayout.HeightRequest>0)
                {
                    var animation = new Animation(v => ExpandableLayout.HeightRequest = v, height, 0);
                    await ExpandableLayout.FadeTo(0, 250);
                    animation.Commit(this, "ExpandSize", 16, 250);
                }
                else
                {
                    var animation = new Animation(v => ExpandableLayout.HeightRequest = v, 0, height);
                    animation.Commit(this, "ExpandSize", 16, 250);
                    await ExpandableLayout.FadeTo(1, 250);
                }
                _IsExpanding = false;
            }
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        /*protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TitleProperty.PropertyName)
            {
                TitleText.Text = Title;
            }
            else if (propertyName == TextProperty.PropertyName)
            {
                ExpandableText.Text = Text;
            }
        }*/
    }
}