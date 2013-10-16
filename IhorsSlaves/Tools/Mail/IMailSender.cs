using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace IhorsSlaves.Tools.Mail
{
    public interface IMailSender
    {
        string To 
        { 
            get; 
            set; 
        }

        string Subject 
        { 
            get; 
            set; 
        }

        string Body 
        { 
            get; 
            set; 
        }

        MailAddress From 
        { 
            get; 
            set; 
        }

        SmtpDeliveryMethod DeliveryMethod 
        { 
            get; 
            set; 
        }

        void SendReportMessage(string To, string Subject = "", string Body = "");

        void Send();
    }
}
