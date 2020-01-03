using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Web;
using System.Text;
using System.Collections;

namespace WebPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        
        public void OnPost()
        {

               String name = Request.Form["name"];
               String email = Request.Form["email"];
               String subject = Request.Form["subject"];
               String messageBody = Request.Form["message"];

            //   MailMessage message = new MailMessage();
            //   message.From = new MailAddress(email);
            //   message.To.Add(new MailAddress("udaramliyanage@gmail.com"));
            //  // message.CC.Add(new MailAddress("copy@domain.com"));
            //   message.Subject = "Message via My Site from " + subject.ToString();
            //   message.IsBodyHtml = true;
            //   message.Body = "<html><body>" + messageBody.ToString() + "</body></html>";  
            //   SmtpClient client = new SmtpClient();
            //   client.Host = "smtp.gmail.com";
            //   client.Port = 587;
            //   client.UseDefaultCredentials = false;
            ////   client.Credentials = new System.Net.NetworkCredential
            ////       (email, "lifebuoy951021113v");
            //   client.EnableSsl = true;
            //   client.Send(message);
            if (!name.Equals("") && !email.Equals("") && !subject.Equals("") && !messageBody.Equals(""))
            {
                ArrayList list = new ArrayList();
                list.Add(name);
                list.Add(email);
                list.Add(subject);
                list.Add(messageBody);

                string root = "data";
                // If directory does not exist, create it. 
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                String file = "messageData.csv";

                String filePath = System.IO.Path.Combine("data/", file);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < list.Count; i++)
                {
                    //   sb.AppendLine(String.Join("feffff0c", list[i]));
                    sb.AppendJoin(",", list[i]);
                    sb.Append(",");
                }
                sb.Append("\n\n");
                //  string sb = string.Join(",", list);

                // System.IO.File.WriteAllText(filePath, sb.ToString());
                System.IO.File.AppendAllText(filePath, sb.ToString());


            }
        }
    }
}
