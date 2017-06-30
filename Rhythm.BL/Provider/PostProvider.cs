using System;
using System.Linq;
using System.Threading.Tasks;
using Rhythm.BL.Models;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.BL.Interfaces;
using System.Collections.Generic;
using Rhythm.Domain.UnitOfWork;
using System.Globalization;

namespace Rhythm.BL.Provider
{
    public class PostProvider : IPostProvider
    {
        private IUnitOfWork _uow;
        private Post _post;

        public PostProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Post> GetPostWidgetAsync()
        {
            int countArticle;
            var allPosts = await _uow.Post.GetPostsAsync();
            var count = allPosts.Max(p => p.Id);
            Random r = new Random();

            do
            {
                countArticle = r.Next(1, count + 1);
                _post = allPosts.SingleOrDefault(p => p.Id == countArticle && p.Published == true);
            }
            while (_post == null);

            return _post;
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            post.PostedOn = DateTime.Now;

            return await _uow.Post.AddPostAsync(post);
        }

        public async Task AddReferencedToPost(Post toPost, int[] tagsId, int categoryId)
        {
            var tags = new List<Tag>();

            foreach (var id in tagsId)
            {
                toPost.Tags.Add(await _uow.Tag.GetTagAsync(id));
            }

            var category = await _uow.Category.GetCategoryAsync(categoryId);
            category.CountCategory = category.CountCategory + 1;
            toPost.Category = category;

            await ChangePostAsync(toPost);
        }

        public async Task ChangePostAsync(Post post)
        {
            post.Modified = DateTime.Now;

            await _uow.Post.ChangePostAsync(post);
        }

        public async Task DeletePostAsync(Post post)
        {
            post.Category.CountCategory = post.Category.CountCategory - 1;

            await _uow.Post.DeletePostAsync(post);
        }

        public async Task<Post> GetPostWithConditionAsync(int post, bool? flag)
        {
            Post findPost = new Post();
            IEnumerable<Post> postList = await _uow.Post.GetPostsAsync();

            int newPost = 1;

            switch (flag)
            {
                case true:

                    do
                    {
                        newPost = post + 1;

                        findPost = postList.FirstOrDefault(m => m.Id == newPost && m.Published == true);
                    } while (findPost == null && newPost > 0);
                    break;

                case false:

                    var maxPost = postList.Where(p => p.Published == true).Max(m => m.Id);
                    do
                    {
                        newPost = post - 1;

                        findPost = postList.FirstOrDefault(m => m.Id == newPost && m.Published == true);
                    } while (findPost == null && newPost <= maxPost);
                    break;

                default:
                    findPost = postList.FirstOrDefault(m => m.Id == post && m.Published == true);
                    break;
            }

            return findPost;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _uow.Post.GetPostsAsync();

            return posts.Where(p => p.Published == true).ToList();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(int id)
        {
            var posts = await _uow.Post.GetPostsAsync();

            return posts.Where(p => p.CategoryId == id && p.Published == true).ToList();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(int id)
        {
            var tag = await _uow.Tag.GetTagAsync(id);
            var posts = await _uow.Post.GetPostsAsync();

            return (from p in posts
                    from t in p.Tags.Where(tg => tg.Id == tag.Id)
                    select p);
        }

        public async Task<IEnumerable<Post>> GetPostsByTextAsync(string searchText)
        {
            var posts = await _uow.Post.GetPostsAsync();

            return posts.Where(p => p.Title.Contains(searchText) ||
                p.ShortDescription.Contains(searchText) ||
                p.DescriptionPost.Contains(searchText) && p.Published == true).ToList();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _uow.Post.GetPostAsync(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return _uow.Post.GetPosts();
        }

        public Post GetPostWidget()
        {
            int countArticle;
            var allPosts = _uow.Post.GetPosts();
            // TODO!
            var count = allPosts.Max(p => p.Id);
            Random r = new Random();

            do
            {
                countArticle = r.Next(1, count + 1);
                _post = allPosts.SingleOrDefault(p => p.Id == countArticle && p.Published == true);
            }
            while (_post == null);

            return _post;
        }

        public async Task<IEnumerable<Post>> GetPostsByArchiveAsync(int year, int month)
        {
            var posts = await _uow.Post.GetPostsAsync();

            return posts.Where(m => m.PostedOn.Month == month && m.PostedOn.Year == year).ToList();
        }

        public async Task RemoveImageByPostAsync(Post post)
        {
            post.ImagePath = null;
            post.Modified = DateTime.Now;

            await _uow.Post.ChangePostAsync(post);
        }
    }
}
