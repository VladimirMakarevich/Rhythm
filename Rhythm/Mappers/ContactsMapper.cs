using AutoMapper;
using Rhythm.Models;

namespace Rhythm.Mappers
{
    public class ContactsMapper
    {
        private IMapper _mapper;
        private string _message;

        public ContactsMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ContactViewModel ToGetHeaderViewModel()
        {
            return new ContactViewModel
            {
                Header = GetHeader(),
                ResultMessage = new ContactsResultViewModel
                {
                    Message = "Contact with me"
                }
            };
        }

        public ContactViewModel ToContactViewModel(bool result)
        {
            return new ContactViewModel
            {
                Header = GetHeader(),
                ResultMessage = GetMessageResult(result)
            };
        }

        private ContactsResultViewModel GetMessageResult(bool result)
        {
            if (result)
            {
                _message = "Thank you for Contacting me";
                return new ContactsResultViewModel { Message = _message };
            }
            else
            {
                _message = "Sorry, but a problem occured on the server, please try again after some time.";
                return new ContactsResultViewModel { Error = _message };
            }
        }

        public ContactViewModel ToMessageErrorViewModel(ContactViewModel contact)
        {
            return new ContactViewModel
            {
                Name = contact.Name,
                Email = contact.Email,
                AreLikeDogs = contact.AreLikeDogs,
                Header = GetHeader(),
                ResultMessage = new ContactsResultViewModel
                {
                    Message = "You have entered invalid data."
                }
            };
        }

        private HeaderViewModel GetHeader()
        {
            return new HeaderViewModel
            {
                Title = "Contact",
                Text = "DogBlog - Vladimir Makarevich - backend Developer ASP.NET MVC",
                FirstTagWord = "C#",
                SecondTagWord = "ASP.NET MVC",
                ThirdTagWord = "WEB"
            };
        }
    }
}