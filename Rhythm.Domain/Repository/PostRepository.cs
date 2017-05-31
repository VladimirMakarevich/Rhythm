using Rhythm.Domain.Entities;
using System.Linq;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Rhythm.Domain.Context;

namespace Rhythm.Domain.Repository
{
    public class PostRepository
    {
        DogCodingContext _db;
        public PostRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task AddPostAsync(Post post)
        {
            post.Category.CountCategory++;
            post.PostedOn = DateTime.Now;
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
        }

        public async Task ChangePostAsync(Post post)
        {
            post.Modified = DateTime.Now;
            _db.Entry(post).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Post post)
        {
            post.Category.CountCategory--;
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<Post> GetPostAsync(int? post, bool? flag)
        {
            var findPost = new Post();

            findPost = null;
            int? newPost = 1;

            if (post != null)
            {
                if (flag == false)
                {
                    while (findPost == null && newPost > 0)
                    {
                        newPost = post;
                        findPost = await _db.Posts.FirstOrDefaultAsync(m => m.ID == newPost && m.Published == true);
                        post = newPost - 1;
                    }
                }
                else if (flag == true)
                {
                    var maxPost = _db.Posts.Where(p => p.Published == true).Max(m => m.ID);
                    while (findPost == null && newPost < maxPost)
                    {
                        newPost = post;
                        findPost = await _db.Posts.FirstOrDefaultAsync(m => m.ID == newPost && m.Published == true);
                        post = newPost + 1;
                    }
                }
                else
                {
                    findPost = await _db.Posts.FirstOrDefaultAsync(m => m.ID == post && m.Published == true);
                }

                return findPost;
            }

            return null;
        }
    }
}
