using System.Web.Mvc;
using Rhythm.Models;
using System.Threading.Tasks;
using Rhythm.BL.Interfaces;
using Rhythm.Mappers;

namespace Rhythm.Controllers
{
    public class ContactsController : DefaultController
    {
        private readonly ContactsMapper _contactsMapper;
        public ContactsController(IUserProvider userProvider, ContactsMapper contactsMapper)
        {
            _userProvider = userProvider;
            _contactsMapper = contactsMapper;
        }

        public ActionResult Index()
        {
            var contactViewModel = _contactsMapper.ToGetHeaderViewModel();

            return View(contactViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var result = await _userProvider.SendMessage(contact.Name, contact.Email, contact.Message);
                //var contactViewModel = _contactsMapper.ToContactViewModel(result);

                ModelState.Clear();
                return View("Thanks");
            }
            else
            {
                var contactErrorViewModel = _contactsMapper.ToMessageErrorViewModel(contact);

                return View(contactErrorViewModel);
            }
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}