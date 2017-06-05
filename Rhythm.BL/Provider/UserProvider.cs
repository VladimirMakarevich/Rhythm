using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rhythm.BL.Provider
{
    public class UserProvider : IUserProvider
    {
        private IUnitOfWork _uow;

        public UserProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CreateUserAsync(ChiefUser chiefUser)
        {
            await _uow.User.CreateUserAsync(chiefUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var chiefUser = await _uow.User.GetUserAsync(id);

            await _uow.User.DeleteUserAsync(chiefUser);
        }

        public async Task EditUser(ChiefUser chiefUser)
        {
            await _uow.User.EditUser(chiefUser);
        }

        public async Task<IEnumerable<ChiefUser>> GetChiefUsersAsync()
        {
            return await _uow.User.GetChiefUsersAsync();
        }

        public async Task<ChiefUser> GetUserAsync(int chiefUser)
        {
            return await _uow.User.GetUserAsync(chiefUser);
        }
    }
}
