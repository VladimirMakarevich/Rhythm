using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhythm.Domain.Abstract
{
    public interface IRepository
    {
        IQueryable<Post> Posts { get; }
        IQueryable<Tag> Tags { get; }
        IQueryable<Category> Categories { get; }
        IQueryable<Comment> Comments { get; }

    }
}
