using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Entities;
using Rhythm.Models.RssFeeds;
using Rhythm.Models;
using System.Threading.Tasks;

namespace Rhythm.Mappers
{
    public class RssMapper
    {
        private const int PageSize = 10;
        private IMapper _mapper;

        public RssMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RssListViewModel ToRssListViewModel(Rss rss, IEnumerable<RssViewModel> rssFeed, int page)
        {
            return new RssListViewModel
            {
                Theme = rss.Theme,
                Site = rss.Name,

                RssReaders = rssFeed.AsEnumerable()
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = rssFeed.Count()
                },

                HeaderViewModel = new HeaderViewModel
                {
                    Title = rss.Name,
                    FirstTagWord = "",
                    SecondTagWord = "",
                    ThirdTagWord = ""
                }
            };
        }

        public RssesViewModel ToRssesViewModel(IEnumerable<Rss> rsses, int page)
        {
            var rssesViewModel = rsses.Select(ToRssViewModel).ToList();

            return new RssesViewModel
            {
                RssEntity = rssesViewModel.AsEnumerable()
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingView = new ListView
                {
                    CurrentPage = page,
                    PostsPerPage = PageSize,
                    TotalPosts = rsses.Count()
                },

                HeaderViewModel = new HeaderViewModel
                {
                    Title = "RSS feeds",
                    FirstTagWord = "NEWS",
                    SecondTagWord = "IT",
                    ThirdTagWord = "WEB"
                }
            };
        }

        public RssEntityViewModel ToRssViewModel(Rss rsses)
        {
            return _mapper.Map<Rss, RssEntityViewModel>(rsses);
        }
    }
}