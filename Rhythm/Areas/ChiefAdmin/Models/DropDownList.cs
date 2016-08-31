using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class CategoryDropDownList
    {
        public IEnumerable<Category> Category { get; internal set; }

    }

    public class TagDropDownList
    {
        public IEnumerable<Tag> Tag { get; internal set; }
    }
}