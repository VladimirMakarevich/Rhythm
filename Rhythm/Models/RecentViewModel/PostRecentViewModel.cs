using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models.RecentViewModel
{
    public class PostRecentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NameSenderPost { get; set; }
        public DateTime PostedOn { get; set; }
    }
}