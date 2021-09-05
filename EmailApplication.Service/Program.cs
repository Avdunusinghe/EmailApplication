using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace EmailApplication.Service
{
    class Program
    {
        static void Main(string[] args)
        {
           //Create a new MIME(Multipurpose internet Mail Extensions) Message Object Which we are going to use to fill  the message data.

           MimeMessage message = new MimeMessage();

            //add the sender info that will appear in the email message

            message.From.Add(new MailboxAddress("Ashen Dunusinghe", "theeventprojectg259@gmail.com"));

            //add the receiver email address

            message.To.Add(MailboxAddress.Parse("avdunusinghe@gmail.com"));

            //add the message Subject
            message.Subject = "This Testing Email";

            //add the message body as plain text String passed to the TextPart indicates that it's plain text 
            message.Body = new TextPart("plain")
            {
                Text = @"This email send by using SMTP Server"
            };
        }
    }
}
