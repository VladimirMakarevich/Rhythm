using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Authenticated
{
    public interface IUserProvider
    {
        DogUser User { get; set; }
    }
}
