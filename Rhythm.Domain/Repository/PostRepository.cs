using Rhythm.Domain.Entities;
using System.Data.Entity;
using System.Threading.Tasks;
using Rhythm.Domain.Context;
using Rhythm.Domain.Repository.Interfaces;
using System.Collections.Generic;

namespace Rhythm.Domain.Repository
{
    public class PostRepository : IPostRepository
    {
        DogCodingContext _db;

        public PostRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            _db.Entry(post).State = EntityState.Detached;
            var result = _db.Posts.Add(post);
            await _db.SaveChangesAsync();

            return result;
        }

        public async Task ChangePostAsync(Post post)
        {
            _db.Posts.Attach(post);
            _db.Entry(post).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Post post)
        {
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _db.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return _db.Posts;
        }
    }
}
