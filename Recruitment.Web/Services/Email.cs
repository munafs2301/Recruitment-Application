using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Recruitment.Web.Services
{
    public class Email
    {
        public static string SendEmail(string receiver, string subject, string message)
        {

            try
                {
                  
                    
                            var senderEmail = new MailAddress("marvelousfrank5@gmail.com", "Marvelous");
                            var receiverEmail = new MailAddress(receiver, "Receiver");
                            var password = "m4crystfs1998";
                            var sub = subject;
                            var body = message;
                            var smtp = new SmtpClient
                                {
                                    Host = "smtp.gmail.com",
                                    Port = 587,
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(senderEmail.Address, password)
                                };
                            using (var mess = new MailMessage(senderEmail, receiverEmail)
                                {
                                         Subject = subject,
                                                Body = body
                                            })
                                            {
                                                smtp.Send(mess);
                                            }
                                            return "Email sent successfully";
                                    
            
            }
            catch (Exception)
            {
                return "An error ocurred";
            }
            
        }

    //internal class Example
    //{
    //    private static void Main()
    //    {
    //        Execute().Wait();
    //    }

    //    static async Task Execute()
    //    {
    //        var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
    //        var client = new SendGridClient(apiKey);
    //        var from = new EmailAddress("test@example.com", "Example User");
    //        var subject = "Sending with SendGrid is Fun";
    //        var to = new EmailAddress("test@example.com", "Example User");
    //        var plainTextContent = "and easy to do anywhere, even with C#";
    //        var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
    //        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
    //        var response = await client.SendEmailAsync(msg);
    //    }
    //}
}
}