using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rhythm.Domain.Entities;
using Rhythm.Areas.ChiefAdmin.Models;

namespace Rhythm.Mappers.ChiefAdmin
{
    public class RssAdminMapper
    {
        private IMapper _mapper;

        public RssAdminMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<RssAdminViewModel> ToRssesViewModel(IEnumerable<Rss> rsses)
        {
            return rsses.Select(ToRssViewModel).ToList();
        }

        public RssAdminViewModel ToRssViewModel(Rss rss)
        {
            return _mapper.Map<Rss, RssAdminViewModel>(rss);
        }

        public Rss ToRss(RssAdminViewModel rssViewModel)
        {
            return _mapper.Map<RssAdminViewModel, Rss>(rssViewModel);
        }
    }
}