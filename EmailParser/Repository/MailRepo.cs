using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using EAGetMail;
using System;
using System.Net;
using System.Text;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using EmailParser.Models;

namespace EmailParser.Repository
{
    public class MailRepo : IMailRepo
    {
        public Email breakEmail(byte[] byteArr)
        {
            Email currEmail = new Email();

            try
            {
                

                Mail oMail = new Mail("Tryit");
                oMail.Load(byteArr);

                // Parse Mail From, Sender
                currEmail.from = oMail.From.ToString();

                // Parse Mail To, Recipient
                EAGetMail.MailAddress[] addrs = oMail.To;
                for (int i = 0; i < addrs.Length; i++)
                {
                    currEmail.to.Add(addrs[i].ToString());
                }

                // Parse Mail CC
                addrs = oMail.Cc;
                for (int i = 0; i < addrs.Length; i++)
                {
                    currEmail.cc.Add(addrs[i].ToString());
                }

                // Parse Mail Subject
                currEmail.subject = oMail.Subject;

                // Parse Mail Text/Plain body
                currEmail.textbody = oMail.TextBody;

                // Parse Mail Html Body
                currEmail.htmlbody = oMail.HtmlBody;

                // Parse Attachments, not working for global path.
                EAGetMail.Attachment[] atts = oMail.Attachments;
                for (int i = 0; i < atts.Length; i++)
                {
                    /*Console.WriteLine("Attachment: {0}", Encoding.UTF8.GetString(atts[i].Content));*/
                    /*file:///C:/Users/Nilanshu%20Yadav/Downloads/Prevention%20of%20Sexual%20Harassment%20Policy%20(PoSH)_IN.pdf*/
                    
                    string text = string.Empty;
                    var by = atts[i].Content;
                    PdfReader reader = new PdfReader(by);

                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        text += PdfTextExtractor.GetTextFromPage(reader, page);

                    }
                    reader.Close();

                    var byteArrayOfAttachment = Encoding.UTF8.GetBytes(text);
                    currEmail.attachments.Add(byteArrayOfAttachment);

                }

                return currEmail;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool checkSuccessRate(String text)
        {
            throw new NotImplementedException();
        }

        JsonResult IMailRepo.parseEmail()
        {
            throw new NotImplementedException();
        }

        JsonResult IMailRepo.validateEmail(byte[] byteArr = null)
        {
            //https://github.com/mikel/mail/blob/master/spec/fixtures/emails/plain_emails/basic_email.eml

            String emlFile = "C:\\Users\\Nilanshu Yadav\\Downloads\\Appointment Letter_ Nilanshu Yadav.eml";
            byteArr = File.ReadAllBytes(emlFile);

            var email = breakEmail(byteArr);

            if(email == null)
            {
                return null;
            }
            else if(email.attachments.Count>0 && checkSuccessRate(email.subject) && checkSuccessRate(email.textbody+email.htmlbody))
            {
                String pdf = null;

                
            }
            else
            {
                return null;
            }

            return new JsonResult("test");
        }

        
    }
}
