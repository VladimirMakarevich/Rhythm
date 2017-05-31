using Rhythm.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhythm.Domain.Model;
using System.Data.Entity;

namespace Rhythm.Domain.Repository
{
    public class UserRepository : ContextDb, IUserRepository
    {
        public IQueryable<ChiefUser> GetUser
        {
            get
            {
                return db.ChiefUsers;
            }
        }

        public async Task CreateUserAsync(ChiefUser chiefUser)
        {
            db.ChiefUsers.Add(chiefUser);
            await db.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var chiefUser = await db.ChiefUsers.FindAsync(id);
            db.ChiefUsers.Remove(chiefUser);
            await db.SaveChangesAsync();
        }

        public async Task EditChangesUser(ChiefUser chiefUser)
        {
            db.Entry(chiefUser).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<List<ChiefUser>> GetListChiefUsersAsync()
        {
            var chiefUsers = db.ChiefUsers.Include(c => c.Portfolio);
            return await chiefUsers.ToListAsync();
        }

        public async Task<ChiefUser> GetUserAsync(int? chiefUser)
        {
            return await db.ChiefUsers.FindAsync(chiefUser);
        }
    }
}
