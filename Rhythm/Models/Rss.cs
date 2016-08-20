using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Rhythm.Models
{
    public class Rss
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PubDate { get; set; }

    }
}