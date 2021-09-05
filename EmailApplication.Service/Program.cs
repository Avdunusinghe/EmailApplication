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

            //add the message body as plain text String passed to the TextPart indicates that it's plain text and Not Html 
            message.Body = new TextPart("plain")
            {
                Text = @"This email send by using SMTP Server"
            };

            //input as the user to enter the email
            Console.WriteLine("Enter email:");
            string emailAddress = Console.ReadLine();

            //input as the user to enter the email
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            //Create a new SMTP Client
            SmtpClient smtpClient = new SmtpClient();

            try
            {
                //Connect to the gmail SMTP server using port 465 with SSL enabled
                //Establish a connection to the specified mail server
                smtpClient.Connect("smtp.gmail.com", 456, true);

                //Authentication SMTP Server Requires 
                smtpClient.Authenticate(emailAddress, password);
                smtpClient.Send(message);

                Console.WriteLine("Email Send has been Succssfull!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Disconnect the service
                smtpClient.Disconnect(true);

                //dispose client object
                smtpClient.Dispose();
            }

            Console.ReadLine();
        }
    }
}
