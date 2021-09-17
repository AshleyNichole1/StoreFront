using StoreFront1.Models;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Web.Mvc;


namespace StoreFrontApp.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
           

            string body = $"Message received from MVC2 Secured. From {cvm.Name} - Subject: {cvm.Subject}<br />Message: {cvm.Message}";

            string emailUser = WebConfigurationManager.AppSettings["EmailUser"];
            string emailTo = WebConfigurationManager.AppSettings["EmailTo"];
            string emailClient = WebConfigurationManager.AppSettings["EmailClient"];
            string emailPassword = WebConfigurationManager.AppSettings["EmailPass"];


            //Create the MailMessage object & customize            
                 MailMessage msg = new MailMessage(emailUser, emailTo, "Message from you contact form", body);


            msg.IsBodyHtml = true;

            //Create the SmtpClient object -> supply mail server, username and PW
            SmtpClient client = new SmtpClient(emailClient);
            client.Credentials = new NetworkCredential(emailUser, emailPassword);
            client.Port = 8889;//AT&T internet

            //Attempt to send the email
            try
            {
                client.Send(msg);
                return View("EmailConfirmation", cvm);
            }
            catch (System.Exception ex)
            {
                //ViewBag.ErrorMessage = "Something went wrong - try again or contact an administrator.";
                ViewBag.ErrorMessage = $"Error: { ex.Message} <br/>StackTrace: {ex.StackTrace}" +
                      $"<br/>Inner: {ex.InnerException}"; 
                return View(cvm);
            }

            //return View();
        }


    }
}
