using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace IhorsSlaves.Tools.Mail
{
    public static class MailSender
    {
        private static MailMessage message = new MailMessage();

        private static SmtpClient smtp = new SmtpClient();

        private static string To { get; set; }

        private static string Subject { get; set; }

        private static string Body { get; set; }

        private static MailAddress From { get; set; }

        public static SmtpDeliveryMethod DeliveryMethod { get; set; }


        static MailSender()
        {
            From = new MailAddress("megacodersmail@gmail.com");
            DeliveryMethod = SmtpDeliveryMethod.Network; ;
        }

        public static void SendMessage(string to, string subject = "Report",
            string body = "Thank you for writing to us. Team MegaCoders=)")
        {
            To = to;
            Subject = subject;
            Body = body;

            ThreadPool.QueueUserWorkItem(t => Send());
        }

        private static void Send()
        {
            try
            {
                message.To.Add(new MailAddress(To));
                message.From = From;
                message.Subject = Subject;
                message.Body = Body;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("megacodersmail@gmail.com", "123qwerty123");
                smtp.PickupDirectoryLocation = @"D:\MailLogs";
                smtp.DeliveryMethod = DeliveryMethod;
                smtp.Send(message);
            }
            catch (Exception)
            {
                //To do exceptions in logfile
            }
        }
    }
}