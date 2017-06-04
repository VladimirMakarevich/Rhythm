using System;
using System.Linq;
using System.Threading.Tasks;
using Rhythm.BL.Models;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.BL.Interfaces;
using System.Collections.Generic;

namespace Rhythm.BL.Provider
{
    public class PostProvider : IPostProvider
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private Post _post;

        public PostProvider(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public async Task<Post> GetPostWidgetAsync()
        {
            int countArticle;
            var allPosts = await _postRepository.GetPostsAsync();
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

        public async Task AddPostAsync(Post post)
        {
            post.Category.CountCategory++;
            post.PostedOn = DateTime.Now;

            await _postRepository.AddPostAsync(post);
        }

        public async Task ChangePostAsync(Post post)
        {
            post.Modified = DateTime.Now;

            await _postRepository.ChangePostAsync(post);
        }

        public async Task DeletePostAsync(Post post)
        {
            post.Category.CountCategory--;

            await _postRepository.DeletePostAsync(post);
        }

        public async Task<Post> GetPostWithConditionAsync(int post, bool? flag)
        {
            Post findPost = new Post();
            IEnumerable<Post> postList = await _postRepository.GetPostsAsync();

            int newPost = 1;

            switch (flag)
            {
                case true:
                    while (findPost == null && newPost > 0)
                    {
                        newPost = post;
                        findPost = postList.FirstOrDefault(m => m.Id == newPost && m.Published == true);
                        post = newPost - 1;
                    }
                    break;

                case false:
                    var maxPost = postList.Where(p => p.Published == true).Max(m => m.Id);
                    while (findPost == null && newPost < maxPost)
                    {
                        newPost = post;
                        findPost = postList.FirstOrDefault(m => m.Id == newPost && m.Published == true);
                        post = newPost + 1;
                    }
                    break;

                default:
                    findPost = postList.FirstOrDefault(m => m.Id == post && m.Published == true);
                    break;
            }

            //if (flag == false)
            //{
            //    while (findPost == null && newPost > 0)
            //    {
            //        newPost = post;
            //        findPost = postList.FirstOrDefault(m => m.ID == newPost && m.Published == true);
            //        post = newPost - 1;
            //    }
            //}
            //else if (flag == true)
            //{
            //    var maxPost = postList.Where(p => p.Published == true).Max(m => m.ID);
            //    while (findPost == null && newPost < maxPost)
            //    {
            //        newPost = post;
            //        findPost = postList.FirstOrDefault(m => m.ID == newPost && m.Published == true);
            //        post = newPost + 1;
            //    }
            //}
            //else
            //{
            //    findPost = postList.FirstOrDefault(m => m.ID == post && m.Published == true);
            //}

            return findPost;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _postRepository.GetPostsAsync();

            return posts.Where(p => p.Published == true).ToList();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(int id)
        {
            var posts = await _postRepository.GetPostsAsync();

            return posts.Where(p => p.CategoryId == id && p.Published == true).ToList();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(int id)
        {
            var tag = await _tagRepository.GetTagAsync(id);
            var posts = await _postRepository.GetPostsAsync();

            return posts.Where(p => p.Tags.Contains(tag));
        }

        public async Task<IEnumerable<Post>> GetPostsByTextAsync(string searchText)
        {
            var posts = await _postRepository.GetPostsAsync();

            return posts.Where(p => p.Title.Contains(searchText) ||
                p.ShortDescription.Contains(searchText) || 
                p.DescriptionPost.Contains(searchText) && p.Published == true).ToList();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _postRepository.GetPostAsync(id);
        }
    }
}
