using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace IhorsSlaves.Tools.Mail
{
    public class MailSender //: IMailSender
    {
        public MailSender()
        {
            From = new MailAddress("megacodersmail@gmail.com");
            DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        private MailMessage message = new MailMessage();

        private SmtpClient smtp = new SmtpClient();

        private string To { get; set; }

        private string Subject { get; set; }

        private string Body { get; set; }

        private MailAddress From { get; set; }

        public SmtpDeliveryMethod DeliveryMethod { get; set; }

        public void SendReportMessage(string to, string subject = "Report",
            string body = "Thank you for writing to us. Team MegaCoders=)")
        {
            this.To = to;
            this.Subject = subject;
            this.Body = body;

            Thread sendMessage = new Thread(this.Send);
            sendMessage.Start();
        }

        private void Send()
        {
            try
            {
                message.To.Add(new MailAddress(this.To));
                message.From = this.From;
                message.Subject = this.Subject;
                message.Body = this.Body;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("megacodersmail@gmail.com", "123qwerty123");
                smtp.PickupDirectoryLocation = "~/Logs/Mail";
                smtp.DeliveryMethod = this.DeliveryMethod;
                smtp.Send(message);
            }
            catch(Exception)
            {
                //To do exceptions in logfile
            }
        }
    }
}