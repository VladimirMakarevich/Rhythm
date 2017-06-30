using Rhythm.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Interfaces
{
    public interface IUserProvider
    {
        Task<IEnumerable<ChiefUser>> GetChiefUsersAsync();
        Task<ChiefUser> GetUserAsync(int chiefUser);
        Task CreateUserAsync(ChiefUser chiefUser, int portfolioId);
        Task EditUser(ChiefUser chiefUser, int portfolioId);
        Task DeleteUserAsync(int id);
        Task<bool> SendMessage(string name, string email, string message);
    }
}
