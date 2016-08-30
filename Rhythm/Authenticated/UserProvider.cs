using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Rhythm.Authenticated
{
    public class UserProvider : IPrincipal
    {
        private UserIdentity userIdentity { get; set; }
        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            return userIdentity.InRoles(role);
        }

        public UserProvider(string name, IRepository repository)
        {
            userIdentity = new UserIdentity();
            userIdentity.Init(name, repository);
        }

        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}