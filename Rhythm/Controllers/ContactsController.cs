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
        // GET: Contacts
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Contact with me";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ContactViewModel contact)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(contact.Email);
                    msz.To.Add("justadreampictures@gmail.com");
                    msz.Body = String.Format("Name: " + contact.Name + "\n\nE-mail: " + contact.Email + "\n\nMessage: " + contact.Message);
                    msz.Subject = "site - DogCoding";

                    SmtpClient smpt = new SmtpClient();
                    smpt.Host = "smtp.gmail.com";
                    smpt.Port = 587;
                    smpt.Credentials = new System.Net.NetworkCredential("justadreampictures", "q26s4hcxz23");

                    smpt.EnableSsl = true;
                    await smpt.SendMailAsync(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting me ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"Sorry we are facing Problem here {ex.Message}";
                }
            }
            else { ViewBag.MessageError = "you have entered invalid data"; }

            return View();
        }
    }
}