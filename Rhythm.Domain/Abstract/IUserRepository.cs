using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.Abstract
{
    public interface IUserRepository
    {
        Task<List<ChiefUser>> GetListChiefUsersAsync();
        Task<ChiefUser> GetUserAsync(int? chiefUser);

    }
}
