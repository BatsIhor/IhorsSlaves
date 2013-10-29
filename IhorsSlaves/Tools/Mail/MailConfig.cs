using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Configuration;
using System.Web;
using System.Net.Mail;

namespace IhorsSlaves.Tools.Mail
{
    public static class MailConfig
    {
        private static SmtpSection smtpSection = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;

        public static int Port 
        {
            get
            {
                return smtpSection.Network.Port;
            }
        }

        public static string Host
        {
            get
            {
                return smtpSection.Network.Host;
            }
        }

        public static bool DefaultCredentials
        {
            get
            {
                return smtpSection.Network.DefaultCredentials;
            }
        }

        public static bool EnableSsl
        {
            get
            {
                return smtpSection.Network.EnableSsl;
            }
        }

        public static string UserName
        {
            get
            {
                return smtpSection.Network.UserName;
            }
        }

        public static string Password
        {
            get
            {
                return smtpSection.Network.Password;
            }
        }

        public static string PickupDirectoryLocation
        {
            get
            {
                return smtpSection.SpecifiedPickupDirectory.PickupDirectoryLocation;
            }
        }

        public static SmtpDeliveryMethod DeliveryMethod
        {
            get
            {
                return smtpSection.DeliveryMethod;
            }
        }
    }
}