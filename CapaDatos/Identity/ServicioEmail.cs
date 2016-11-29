using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Identity
{
    public class ServicioEmail : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            //client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("scrafy26@gmail.com", "compaq7501");

            return client.SendMailAsync("scrafy26@gmail.com", message.Destination, message.Subject, message.Body);
        }
    }
}
