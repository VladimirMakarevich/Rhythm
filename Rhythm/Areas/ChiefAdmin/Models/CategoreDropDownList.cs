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
    public class CategoreDropDownList
    {
        public IEnumerable<Category> Category { get; internal set; }

    }
}