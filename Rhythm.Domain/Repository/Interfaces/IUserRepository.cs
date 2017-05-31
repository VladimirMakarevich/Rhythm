using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ChiefUser>> GetChiefUsersAsync();
        Task<List<ChiefUser>> GetListChiefUsersAsync();
        Task<ChiefUser> GetUserAsync(int chiefUser);
        Task CreateUserAsync(ChiefUser chiefUser);
        Task EditChangesUser(ChiefUser chiefUser);
        Task DeleteUserAsync(int id);
    }
}
