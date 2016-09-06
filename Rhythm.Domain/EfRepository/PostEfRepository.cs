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

        public string AddPost(Post post)
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
                catch (System.Exception ex)
                {
                    string src = String.Format("Error AddPost: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public string ChangePost(Post post)
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
                catch (System.Exception ex)
                {
                    string src = String.Format("Error ChangePost: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }

        public string DeletePost(Post post)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    context.Posts.Remove(post);
                    context.SaveChanges();
                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    string src = String.Format("Error DeletePost: {0}", ex.Message);
                    contextDb.Rollback();
                    return src;
                }
                return null;
            }
        }
    }
}
