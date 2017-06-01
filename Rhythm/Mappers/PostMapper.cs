using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Entities;
using Rhythm.Models;
using AutoMapper;

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

            return new PostSingleViewModel { PostViewModel = postViewModel, CountPosts = count };
        }
    }
}