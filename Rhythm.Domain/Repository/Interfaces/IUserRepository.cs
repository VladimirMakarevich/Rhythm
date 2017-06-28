using Rhythm.Domain.Entities;
using Rhythm.Domain.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ChiefUser>> GetChiefUsersAsync();
        Task<ChiefUser> GetUserAsync(int chiefUser);
        Task CreateUserAsync(ChiefUser chiefUser);
        Task EditUser(ChiefUser chiefUser);
        Task DeleteUserAsync(ChiefUser chiefUser);
        DogUserManager GetUserManagerAsync();
    }
}
