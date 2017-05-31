using Rhythm.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhythm.Domain.Repository.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<ChiefUser> GetUser { get; }
        Task<List<ChiefUser>> GetListChiefUsersAsync();
        Task<ChiefUser> GetUserAsync(int? chiefUser);
        Task CreateUserAsync(ChiefUser chiefUser);
        Task EditChangesUser(ChiefUser chiefUser);
        Task DeleteUserAsync(int id);
    }
}
