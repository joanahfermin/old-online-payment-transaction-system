using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Drawing.Imaging;
using System.Configuration;
using SampleRPT1.MODEL;
using SampleRPT1.DATABASE;

namespace SampleRPT1
{
    internal class GmailUtil
    {
        /*
         * Jo: for the purpose of this example, gumawa ako ng account sa gmail, ito ang details sa baba.
         * email address: juanitodelacruz1972@gmail.com
         * Password pag naglogin sa website gmail.com: KamoteGang12!@
         * Password pag C# program ang magsesend ng email: eqgywlbcfqqewssn
         * 
         * Note, naka hardcode na laging JPG ang format ng picture.
         */

        //EMAIL SENDER

        public static bool SendMail(string recipient, string subject, string body, Image atachImage)
        {
            EmailAccount emailAccount = EmailAccountDatabase.GetEmailAccount();

            string finalyEmailBody = body;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            try
            {
                using (SmtpClient smtpClient = new SmtpClient() // prepare connection to Gmail
                {
                    //Port = 587,
                    //Host = "smtp.gmail.com",
                    Port = GlobalConstants.GMAIL_PORT,
                    Host = GlobalConstants.GMAIL_HOST,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailAccount.UserName, emailAccount.PassWord),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                })
                using (MailMessage message = new MailMessage() // Prepare the email message we wish to send
                {
                    IsBodyHtml = true,
                    From = new MailAddress(emailAccount.UserName),
                    Subject = subject,
                    Body = finalyEmailBody
                })
                {
                    message.To.Add(new MailAddress(recipient));  // add recipient of the email message

                    if (atachImage != null)  // May attachment na picture
                    {
                        using (var altViewHtml = AlternateView.CreateAlternateViewFromString(finalyEmailBody, null, MediaTypeNames.Text.Html))
                        using (var pictureMemoryStream = new MemoryStream())
                        {
                            atachImage.Save(pictureMemoryStream, ImageFormat.Jpeg); // prepare picture

                            pictureMemoryStream.Position = 0;

                            message.AlternateViews.Add(altViewHtml);
                            Attachment att = new Attachment(pictureMemoryStream, "Attachment.jpg");
                            message.Attachments.Add(att);
                            smtpClient.Send(message); // padala na kasi naka attach na ang pix
                        }
                    }
                    else
                    {
                        smtpClient.Send(message); // wala attachment, send lang derecho ang email
                    }
                }

                return true; // walang error sa pag send ng email, return natin true -> which means success.
            }
            catch (Exception ex)
            {
                return false; // may error sa pag send ng email, return natin false -> which means failed.
            }

        }
    }
}

