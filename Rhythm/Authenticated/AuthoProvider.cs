using System.Web;
using System.Web.Security;

namespace Rhythm.Authenticated
{
    public class AuthoProvider : IAuthoProvider
    {
        public bool IsLoggedIn
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public bool Login(string username, string password)
        {
            bool result = Membership.ValidateUser(username, password);

            if (result)
                FormsAuthentication.SetAuthCookie(username, false);

            return result;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
