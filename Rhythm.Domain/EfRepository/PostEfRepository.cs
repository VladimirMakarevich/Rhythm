using Rhythm.Domain.Model;
using System.Linq;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Rhythm.Domain.EfRepository
{
    public partial class EfRepository
    {
        public IQueryable<Post> Post
        {
            get { return context.Posts; }
        }

        public async Task<string> AddPostAsync(Post post)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    post.Category1.CountCategory++;
                    post.PostedOn = DateTime.Now;
                    context.Posts.Add(post);
                    await context.SaveChangesAsync();

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

        public async Task<string> ChangePostAsync(Post post)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    post.Modified = DateTime.Now;
                    context.Entry(post).State = EntityState.Modified;
                    await context.SaveChangesAsync();

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

        public async Task<string> DeletePostAsync(Post post)
        {
            using (var contextDb = context.Database.BeginTransaction())
            {
                try
                {
                    post.Category1.CountCategory--;
                    context.Posts.Remove(post);
                    await context.SaveChangesAsync();
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

        public async Task<Post> GetPostAsync(int? post, bool? flag)
        {
            var findPost = new Post();
            findPost = null;
            int? newPost = 1;
            using (DogCodingEntities db = new DogCodingEntities())
            {
                if (post != null)
                {
                    if (flag == false)
                    {
                        while (findPost == null && newPost > 0)
                        {
                            newPost = post;
                            findPost = await db.Posts.FirstOrDefaultAsync(m => m.ID == newPost && m.Published == true);
                            post = newPost - 1;
                        } 
                    }
                    else if (flag == true)
                    {
                        var maxPost = db.Posts.Where(p => p.Published == true).Max(m => m.ID);
                        while (findPost == null && newPost < maxPost)
                        {
                            newPost = post;
                            findPost = await db.Posts.FirstOrDefaultAsync(m => m.ID == newPost && m.Published == true);
                            post = newPost + 1;
                        } 
                    }
                    else
                    {
                        findPost = await db.Posts.FirstOrDefaultAsync(m => m.ID == post && m.Published == true);
                    }
                    return findPost;
                }
            }
            return null;
        }
    }
}
