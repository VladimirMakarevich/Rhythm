using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;


namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Comment> Comment
        {
            get { return context.Comments; }
        }
    }
}
