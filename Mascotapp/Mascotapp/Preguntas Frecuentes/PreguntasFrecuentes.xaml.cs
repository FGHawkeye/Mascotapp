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

namespace Mascotapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntasFrecuentes : ContentPage
    {/*
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
        */
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
                    Frame frameStack = new Frame 
                    {
                        Margin=0,
                        BorderColor=Color.LightGray,
                        VerticalOptions=LayoutOptions.FillAndExpand
                    };
                    StackLayout stack = new StackLayout
                    {
                        Padding = 0,
                        BackgroundColor = Color.LightGray,
                    };
                    var tgr = new TapGestureRecognizer();
                    tgr.Tapped += (s, e) => Title_Clicked(s, e);
                    StackLayout stackPreg = new StackLayout
                    {
                        Padding = 10,
                        BackgroundColor = Color.LightGray,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Spacing = 0
                    };
                    stack.GestureRecognizers.Add(tgr);
                    Grid grid = new Grid();
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                    Label ExpandableText = new Label
                    {
                        Margin = -15,
                        Text = item.Respuesta
                    };

                    Label lbPregunta = new Label
                    {
                        Text = item.Pregunta,
                        ClassId=ExpandableText.Height.ToString()
                    };
                    Label lbMostrar = new Label
                    {
                        //Text = "v",
                        Text = " +",
                        FontSize=20,
                        TextColor=Color.DarkBlue
                    };
                    grid.Children.Add(lbMostrar, 0, 0);
                    grid.Children.Add(lbPregunta, 1, 0);
                    stackPreg.Children.Add(grid);

                    StackLayout ExpandableLayout = new StackLayout
                    {
                        Padding = 0,
                        BackgroundColor = Color.LightGray,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Opacity = 0,
                        Spacing = 0
                    };

                    StackLayout ExpandableContent = new StackLayout
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Padding = 0,
                    };
                    
                    ExpandableLayout.HeightRequest = 0;
                    //ExpandableContent.Children.Add(ExpandableText);
                    frameStack.Content = ExpandableText;
                    //ExpandableLayout.Children.Add(ExpandableContent);
                    ExpandableLayout.Children.Add(frameStack);
                    stack.Children.Add(stackPreg);
                    stack.Children.Add(ExpandableLayout);
                    //frameStack.Content = stack;
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
            StackLayout preguntaLayout = (StackLayout)Content.Children[0];
            Grid grid = (Grid)preguntaLayout.Children[0];
            Label label1 = (Label)grid.Children[0];
            Label label2 = (Label)grid.Children[1];

            if (!_IsExpanding)
            {
                _IsExpanding = true;
                var height = Int32.Parse(label2.ClassId);
                if (ExpandableLayout.HeightRequest>0|| ExpandableLayout.HeightRequest==-1)
                {
                    label1.Text = " +";
                    label1.FontSize = 20;
                    var animation = new Animation(v => ExpandableLayout.HeightRequest = v, height, 0);
                    await ExpandableLayout.FadeTo(0, 250);
                    animation.Commit(this, "ExpandSize", 16, 250);
                }
                else
                {
                    label1.Text = " -";
                    label1.FontSize = 25;
                    var animation = new Animation(v => ExpandableLayout.HeightRequest = v, 0, height);
                    animation.Commit(this, "ExpandSize", 16, 250);
                    await ExpandableLayout.FadeTo(1, 250);
                }
                _IsExpanding = false;
            }
        }
    }
}