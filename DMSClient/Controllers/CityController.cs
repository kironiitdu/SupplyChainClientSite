using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using DMSClient.Models;

namespace DMSClient.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/
        public ActionResult Index()
        {
            //string roleid = (string)Session["user_role_id"];
            //string userid = (string)Session["user_au_id"];

            //string ConName = "City";
            //string ActionName = "index";

            //if ((roleid == null || roleid == string.Empty) && (userid == null || userid == string.Empty))
            //{
            //    Response.Redirect("/Login/Index");
            //}
            //bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName);
            //if (!permission)
            //    Response.Redirect("/Error/Index");


            return View();
        }

        public ActionResult SendMail(string fromEmail, string toEmail, string mailSubject, string mailBody, string senderName, string senderPass)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("mrrconfirmation@gmail.com");
                mail.To.Add("dotnetkiron@gmail.com");
                mail.Subject = "Voda";
                mail.Body = "Facewash";
                mail.Attachments.Add(new Attachment(@"D:\Project_Resource\Aamra\GIFT_Promotion.png"));

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mrrconfirmation", "mrr123456");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MailMessage msg = new MailMessage();

                //msg.From = new MailAddress("");
                //msg.To.Add("dotnetkiron@gmail.com");
                //msg.Subject = "Bokachoda-amar akta facewash ase";
                //msg.Body = "Tobka mail";
                //msg.Priority = MailPriority.High;

                //SmtpClient client = new SmtpClient();

                //client.Credentials = new NetworkCredential("", "", "smtp.gmail.com");
                //client.Host = "smtp.gmail.com";
                //client.Port = 587;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.EnableSsl = true;
                //client.UseDefaultCredentials = true;

                //client.Send(msg);
                return Json("index");

            }
            catch (Exception ex)
            {
                return null;

            }


        }

        public ActionResult MailUIpage()
        {
            return View();
        }
    }
}