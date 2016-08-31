using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;
using System;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Post> Post
        {
            get { return context.Posts; }
        }

        public void AddPost(Post post)
        {
            post.Modified = DateTime.Now;
            post.CountComments = 0;
            post.PostedOn = DateTime.Now;
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
