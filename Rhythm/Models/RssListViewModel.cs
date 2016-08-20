using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class RssListViewModel
    {
        public RssReader rssReader { get; set; }
        public ListView PagingView { get; set; }
    }
}