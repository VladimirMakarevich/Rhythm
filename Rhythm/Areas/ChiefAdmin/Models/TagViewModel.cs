﻿using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class TagViewModel
    {
        [Required(ErrorMessage = "fthe field are required!")]
        public int ID { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string UrlSlug { get; set; }
        public string DescriptionTag { get; set; }
    }
}