using System.Collections.Generic;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System.Linq;
using System;
using System.Data.Entity;

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
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    post.Category1.CountCategory++;
                    post.PostedOn = DateTime.Now;
                    context.Posts.Add(post);
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                    contextDb.Rollback();
                }
            }
        }

        public void ChangePost(Post post)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    post.Modified = DateTime.Now;
                    context.Entry(post).State = EntityState.Modified;
                    context.SaveChanges();

                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                    contextDb.Rollback();
                }
            }
        }

        public void DeletePost(Post post)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Posts.Remove(post);
                    context.SaveChanges();
                    contextDb.Commit();
                }
                catch (System.Exception)
                {
                    //TODO: Nlog
                    contextDb.Rollback();
                }
            }
        }
    }
}
