using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Domain.Servicios
{
    public class ServicioEmail
    {
        public bool EnviarEmail(DatosEmail datos)
        {
            string subject = datos.Asunto;
            string body = datos.Cuerpo;
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com", 587);
                mail.From = new MailAddress(string.IsNullOrEmpty(datos.Emisor) ? "mascotapp16@gmail.com" : datos.Emisor);
                mail.To.Add(datos.Receptor);
                mail.Subject = subject;
                mail.Body = body;
                smtpServer.Credentials = new NetworkCredential("mascotapp16@gmail.com", "NiphiajUk2h77NB");
                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

    }

    public class DatosEmail
    {
        public DatosEmail(string asunto, string cuerpo, string receptor, string emisor = null)
        {
            this.Asunto = asunto;
            this.Cuerpo = cuerpo;
            this.Receptor = receptor;
            this.Emisor = emisor;
        }

        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string Receptor { get; set; }
        public string Emisor { get; set; }
    }
}
