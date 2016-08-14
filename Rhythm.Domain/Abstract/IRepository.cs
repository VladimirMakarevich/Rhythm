using Rhythm.Domain.Concrete;
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
        IQueryable<Post> Post { get; }
        IQueryable<Tag> Tag { get; }
        IQueryable<Category> Category { get; }
        IQueryable<Comment> Comment { get; }
        List<RecentComment> GetCommentsList();

    }
}
