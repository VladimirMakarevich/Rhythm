using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface IUserProvider
    {
        Task<IEnumerable<ChiefUser>> GetChiefUsersAsync();
        Task<ChiefUser> GetUserAsync(int chiefUser);
        Task CreateUserAsync(ChiefUser chiefUser);
        Task EditUser(ChiefUser chiefUser);
        Task DeleteUserAsync(int id);
    }
}
