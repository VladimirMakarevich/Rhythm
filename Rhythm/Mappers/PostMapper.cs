using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Entities;
using Rhythm.Models;
using AutoMapper;
using Rhythm.Models.RecentViewModel;

namespace Rhythm.Mappers
{
    public class PostMapper
    {
        private const int PageSize = 8;
        private IMapper _mapper;

        public PostMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PostListViewModel ToHomePostListViewModel(IEnumerable<Post> posts, int page)
        {
            var postsViewModel = posts.Select(ToPostViewModel).ToList();

            return new PostListViewModel
            {
                PostsViewModel = postsViewModel
                    .OrderBy(p => p.Id)
                    .Where(m => m.Published == true)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = posts.Count()
                },

                HeaderViewModel = new HeaderViewModel
                {
                    Title = "DogCoding blog by Vladimir Makarevich",
                    Text = "DogBlog - Vladimir Makarevich - backend developer ASP.NET MVC",
                    FirstTagWord = "C#",
                    SecondTagWord = "ASP.NET MVC",
                    ThirdTagWord = "WEB"
                }
            };
        }

        public PostListViewModel ToPostListViewModel(IEnumerable<Post> posts, int page)
        {
            var postsViewModel = posts.Select(ToPostViewModel).ToList();

            return new PostListViewModel
            {
                PostsViewModel = postsViewModel
                    .OrderBy(p => p.Id)
                    .Where(m => m.Published == true)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = posts.Count()
                },

                HeaderViewModel = new HeaderViewModel
                {
                    Title = "Posts",
                    Text = "",
                    FirstTagWord = "C#",
                    SecondTagWord = "PROGRAMMING",
                    ThirdTagWord = "WEB"
                }
            };
        }

        public PostViewModel ToPostViewModel(Post post)
        {
            return _mapper.Map<Post, PostViewModel>(post);
        }

        public PostSingleViewModel ToPostSingleViewModel(Post post, int count)
        {
            var postViewModel = _mapper.Map<Post, PostViewModel>(post);

            return new PostSingleViewModel
            {
                PostViewModel = postViewModel,
                CountPosts = count,
                HeaderViewModel = new HeaderViewModel
                {
                    Title = postViewModel.Title,
                    Text = postViewModel.NameSenderPost,
                    FirstTagWord = "",
                    SecondTagWord = "",
                    ThirdTagWord = ""
                }
            };
        }

        public List<PostRecentViewModel> ToPostsRecentViewModel(IEnumerable<Post> posts)
        {
            var lastFivePosts = posts.OrderBy(m => m.Id).Take(5);

            return lastFivePosts.Select(ToPostRecentViewModel).ToList();
        }

        public PostRecentViewModel ToPostRecentViewModel(Post post)
        {
            return _mapper.Map<Post, PostRecentViewModel>(post);
        }

        public ArticleWidgetViewModel ToArticleWidget(Post post)
        {
            return new ArticleWidgetViewModel()
            {
                ArticleContent = post.ShortDescription,
                Title = post.Title,
                Id = post.Id,
                ImagePath = post.ImagePath
            };
        }
    }
}