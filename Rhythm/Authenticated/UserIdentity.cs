using Ninject;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Rhythm.Authenticated
{
    public class UserIdentity : IIdentity, IUserProvider
    {
        [Inject]
        public IRepository repository;
        public DogUser User { get; set; }
        public string AuthenticationType
        {
            get
            {
                return typeof(DogUser).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.EmailUser;
                }
                return "anonym";
            }
        }


        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }


        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var r in rolesArray)
            {
                var hasRole = repository.Role.Any(p => string.Compare(p.Code, r, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }
    }
}