using AutoMapper;
using Rhythm.Domain.Entities;
using Rhythm.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rhythm.Mappers
{
    public class SearchResultMapper
    {
        private const string _titleCategory = "Search by categories";
        private const string _titleTag = "Search by tags";
        private const string _titleCommon = "Search result";
        private const string _titleArchive = "Archive result";
        private const int PageSize = 8;
        private IMapper _mapper;

        public SearchResultMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SearchResultViewModel ToCategoryResultViewModel(IEnumerable<Post> posts, int page, string categoryName)
        {
            var postsViewModel = posts.Select(ToPostViewModel).ToList();

            return new SearchResultViewModel
            {
                PostListViewModel = new PostListViewModel
                {
                    PostsViewModel = postsViewModel
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize).ToArray().Reverse(),

                    PagingView = new ListView
                    {
                        CurrentPage = page,
                        PostsPerPage = PageSize,
                        TotalPosts = posts.Count()
                    },

                    HeaderViewModel = new HeaderViewModel
                    {
                        Text = $"A list of posts by category - {categoryName}",
                        Title = _titleCategory,
                        FirstTagWord = "Category",
                        SecondTagWord = "Post",
                        ThirdTagWord = "Blog"
                    }
                },
            };
        }

        public SearchResultViewModel ToTagResultViewModel(IEnumerable<Post> posts, int page, string tagName)
        {
            var postsViewModel = posts.Select(ToPostViewModel).ToList();

            return new SearchResultViewModel
            {
                PostListViewModel = new PostListViewModel
                {
                    PostsViewModel = postsViewModel
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize).ToArray().Reverse(),

                    PagingView = new ListView
                    {
                        CurrentPage = page,
                        PostsPerPage = PageSize,
                        TotalPosts = posts.Count()
                    },

                    HeaderViewModel = new HeaderViewModel
                    {
                        Text = $"A list of posts by category - {tagName}",
                        Title = _titleTag,
                        FirstTagWord = "Tag",
                        SecondTagWord = "Post",
                        ThirdTagWord = "Blog"
                    }
                },
            };
        }

        public SearchResultViewModel ToSearchResultViewModel(IEnumerable<Post> posts, int page, string searchText)
        {
            var postsViewModel = posts.Select(ToPostViewModel).ToList();

            return new SearchResultViewModel
            {
                PostListViewModel = new PostListViewModel
                {
                    PostsViewModel = postsViewModel
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToArray()
                    .Reverse(),

                    PagingView = new ListView
                    {
                        CurrentPage = page,
                        PostsPerPage = PageSize,
                        TotalPosts = posts.Count()
                    },

                    HeaderViewModel = new HeaderViewModel
                    {
                        Text = $"A list of posts by search text - {searchText}",
                        Title = _titleCommon,
                        FirstTagWord = "Search",
                        SecondTagWord = "Post",
                        ThirdTagWord = "Blog"
                    }
                },
            };
        }

        public SearchResultViewModel ToArchiveResultViewModel(IEnumerable<Post> posts, int page, string yearModel, string monthModel)
        {
            var postsViewModel = posts.Select(ToPostViewModel).ToList();
            string text;

            if (yearModel != null && monthModel != null)
            {
                text = $"List of posts found for search archive year - {yearModel}, month - {monthModel}";
            }
            else
            {
                text = $"Your search did not match any documents.";
            }

            return new SearchResultViewModel
            {
                PostListViewModel = new PostListViewModel
                {
                    PostsViewModel = postsViewModel
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToArray()
                    .Reverse(),

                    PagingView = new ListView
                    {
                        CurrentPage = page,
                        PostsPerPage = PageSize,
                        TotalPosts = posts.Count()
                    },

                    HeaderViewModel = new HeaderViewModel
                    {
                        Text = text,
                        Title = _titleCommon,
                        FirstTagWord = "Archive",
                        SecondTagWord = "Post",
                        ThirdTagWord = "Blog"
                    }
                },
            };
        }

        public PostViewModel ToPostViewModel(Post post)
        {
            return _mapper.Map<Post, PostViewModel>(post);
        }

    }
}