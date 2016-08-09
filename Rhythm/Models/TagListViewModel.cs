using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class TagListViewModel
    {
        public IEnumerable<Tag> Tag { get; set; }
        public TagView TagView { get; set; }
    }
}