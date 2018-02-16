using System.Globalization;
using System.IO;
using LargeDataEmailConsumer.Models.Entities;
using MailKit.Net.Smtp;
using MimeKit;

namespace LargeDataEmailConsumer.Models.Services
{
    public class Mailer
    {
        public bool SendNewsletterEmail(string path,string html,string mailSubject, AppUser appUser)
        {
            bool success = false;
                //From Address
                var FromAddress = "support@camerack.com";
                var FromAdressTitle = "Camerack Studio";
                //To Address
                var toVendor = appUser.Email;
                //var toCustomer = email;
                var ToAdressTitle = "Camerack Studio";
                var subject = mailSubject;
                //var BodyContent = message;

                //Smtp Server
                var smtpServer = new AppConfig().EmailServer;
                //Smtp Port Number
                var smtpPortNumber = new AppConfig().Port;

                var mimeMessageVendor = new MimeMessage();
                mimeMessageVendor.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessageVendor.To.Add(new MailboxAddress(ToAdressTitle, toVendor));
                mimeMessageVendor.Subject = subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                using (var data = File.OpenText(path))
                {
                    if (data.BaseStream != null)
                    {
                        //manage content

                        bodyBuilder.HtmlBody = data.ReadToEnd();
                        var body = bodyBuilder.HtmlBody;

                        var replace = body.Replace("URL", "https://camerack.com/?email=" + appUser.Email);
                        replace = replace.Replace("CONTENTBODY", html);
                        replace = replace.Replace("NAME", appUser.Name);
                        bodyBuilder.HtmlBody = replace;
                        mimeMessageVendor.Body = bodyBuilder.ToMessageBody();
                    }
                }
                using (var client = new SmtpClient())
                {
                    client.Connect(smtpServer, smtpPortNumber);
                    // Note: only needed if the SMTP server requires authentication
                    // Error 5.5.1 Authentication 
                    client.Authenticate(new AppConfig().Email, new AppConfig().Password);
                    client.Send(mimeMessageVendor);
                    if (client.IsConnected)
                    {
                        success = true;
                    }
                    client.Disconnect(true);
                    return success;
            }
        }
        public bool SendGeneralNoticeEmail(string path,string html, string mailSubject, AppUser appUser)
        {
            bool success = false;
                //From Address
                var FromAddress = "support@camerack.com";
                var FromAdressTitle = "Camerack Studio";
                //To Address
                var toVendor = appUser.Email;
                //var toCustomer = email;
                var ToAdressTitle = "Camerack Studio";
            var subject = mailSubject;
                //var BodyContent = message;

                //Smtp Server
                var smtpServer = new AppConfig().EmailServer;
                //Smtp Port Number
                var smtpPortNumber = new AppConfig().Port;

                var mimeMessageVendor = new MimeMessage();
                mimeMessageVendor.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessageVendor.To.Add(new MailboxAddress(ToAdressTitle, toVendor));
                mimeMessageVendor.Subject = subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                using (var data = File.OpenText(path))
                {
                    if (data.BaseStream != null)
                    {
                        //manage content

                        bodyBuilder.HtmlBody = data.ReadToEnd();
                        var body = bodyBuilder.HtmlBody;

                        var replace = body.Replace("CONTENTBODY", html);
                        replace = replace.Replace("NAME", appUser.Name);
                        bodyBuilder.HtmlBody = replace;
                        mimeMessageVendor.Body = bodyBuilder.ToMessageBody();
                    }
                }
                using (var client = new SmtpClient())
                {
                    client.Connect(smtpServer, smtpPortNumber);
                    // Note: only needed if the SMTP server requires authentication
                    // Error 5.5.1 Authentication 
                    client.Authenticate(new AppConfig().Email, new AppConfig().Password);
                    client.Send(mimeMessageVendor);
                    if (client.IsConnected)
                    {
                        success = true;
                    }
                    client.Disconnect(true);
                    return success;
            }
        }
    }
}