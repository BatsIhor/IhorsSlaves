using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Configuration;

namespace IhorsSlaves.Tools.Mail
{
    public  class MailSender
    {
        private  MailMessage message = new MailMessage();

        private  SmtpClient smtp = new SmtpClient();

        private  string To { get; set; }

        private  string Subject { get; set; }

        private  string Body { get; set; }

        private  MailAddress From { get; set; }

        public  SmtpDeliveryMethod DeliveryMethod { get; set; }

        public MailSender()
        {
            From = new MailAddress("megacodersmail@gmail.com");
        }

        public  void SendMessage(string to, string subject = "Report",
            string body = "Thank you for writing to us. Team MegaCoders=)")
        {
            To = to;
            Subject = subject;
            Body = body;

            ThreadPool.QueueUserWorkItem(t => Send());
        }

        private  void Send()
        {
            try
            {
                message.To.Add(new MailAddress(To));
                message.From = From;
                message.Subject = Subject;
                message.Body = Body;

                smtp.Port = MailConfig.Port;
                smtp.Host = MailConfig.Host;
                smtp.EnableSsl = MailConfig.EnableSsl;
                smtp.UseDefaultCredentials = MailConfig.DefaultCredentials;
                smtp.Credentials = new NetworkCredential(MailConfig.UserName, MailConfig.Password);
                smtp.PickupDirectoryLocation = MailConfig.PickupDirectoryLocation;
                smtp.DeliveryMethod = MailConfig.DeliveryMethod;
                smtp.Send(message);
            }
            catch (Exception)
            {
                //To do exceptions in logfile
            }
        }
    }
}