using ActionMailer.Net.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IhorsSlaves.Models;

namespace IhorsSlaves.Controllers
{
    public class EmailController : MailerBase
    {
        public EmailResult SendMail(Feedback model)
        {
            EmailModel email = new EmailModel();
            To.Add(model.Email);
            email.Body = "This is a text in body!:)";
            From = "Test@test.com";
            Subject = "test";
            return Email("SendMail");
        }
    }
}
