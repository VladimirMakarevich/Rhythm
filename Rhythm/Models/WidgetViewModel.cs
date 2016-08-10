using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class WidgetViewModel
    {
        public WidgetViewModel(IRepository repository)
        {
            Tags = repository.Tag.OrderBy(p => p.Name);
        }

        public IQueryable<Tag> Tags { get; private set; }
    }
}