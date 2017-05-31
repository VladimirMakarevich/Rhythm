using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.BL.Provider
{
    public class UserProvider : IUserProvider
    {
        private IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(ChiefUser chiefUser)
        {
            await _userRepository.CreateUserAsync(chiefUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var chiefUser = await _userRepository.GetUserAsync(id);

            await _userRepository.DeleteUserAsync(chiefUser);
        }

        public async Task EditChangesUser(ChiefUser chiefUser)
        {
            await _userRepository.EditChangesUser(chiefUser);
        }

        public async Task<IEnumerable<ChiefUser>> GetChiefUsersAsync()
        {
            return await _userRepository.GetChiefUsersAsync();
        }

        public async Task<ChiefUser> GetUserAsync(int chiefUser)
        {
            return await _userRepository.GetUserAsync(chiefUser);
        }
    }
}
