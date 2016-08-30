using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {

        public IQueryable<DogRole> Role
        {
            get
            {
                return context.DogRoles;
            }
        }
        public IQueryable<DogUser> User
        {
            get
            {
                return context.DogUsers;
            }
        }


        public DogUser GetUser(string email)
        {
            return context.DogUsers.FirstOrDefault(p => string.Compare(p.EmailUser, email, true) == 0);
        }

        public DogUser Login(string email, string password)
        {
            return context.DogUsers.FirstOrDefault(p => string.Compare(p.EmailUser, email, true) == 0 && p.PasswordUser == password);
        }
    }
}
