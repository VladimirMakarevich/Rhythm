using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rhythm.Authenticated
{
    /// <summary>
    /// Контекст, получаем доступ к запросу и кукису
    /// </summary>
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }
        DogUser Login(string login, string password, bool isPersistent);
        //DogUser Login(string login);
        void LogOut();
        IPrincipal CurrentUser { get; }
    }
}
