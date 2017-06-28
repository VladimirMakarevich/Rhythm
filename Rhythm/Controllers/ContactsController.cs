using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Rhythm.Models;
using System.Threading.Tasks;

namespace Rhythm.Controllers
{
    public class ContactsController : DefaultController
    {
        public ContactsController()
        {
                
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {

                MailMessage msz = new MailMessage();
                msz.From = new MailAddress(contact.Email);
                msz.To.Add("justadreampictures@gmail.com");
                msz.Body = String.Format("Name: " + contact.Name + "\n\nE-mail: " + contact.Email + "\n\nMessage: " + contact.Message);
                msz.Subject = "site - DogCoding";

                SmtpClient smpt = new SmtpClient();
                smpt.Host = "smtp.gmail.com";
                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential("justadreampictures", "q26s4hcxz2332Q!@W");

                smpt.EnableSsl = true;
                await smpt.SendMailAsync(msz);

                ModelState.Clear();
                ViewBag.ThxMessage = "Thank you for Contacting me.";

                //ViewBag.MessageError = "Sorry, but a problem occured on the server, please try again after some time.";

            }
            else
            {
                ViewBag.MessageError = "You have entered invalid data.";
            }

            return View();
        }
    }
}