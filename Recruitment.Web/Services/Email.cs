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


}
}