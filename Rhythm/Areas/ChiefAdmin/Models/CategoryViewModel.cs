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
    public class CategoryViewModel
    {
        public IEnumerable<Category> Category { get; internal set; }

        //private IRepository repository;

        //public CategoryViewModel(IRepository repository)
        //{
        //    this.repository = repository;
        //}

        //private List<Category> category { get; set; }
        //public List<Category> Category
        //{
        //    get
        //    {
        //        return repository.Category
        //          .OrderBy(c => c.Name)
        //          .ToList();
        //    }
        //    set { category = value; }
        //}
    }
}