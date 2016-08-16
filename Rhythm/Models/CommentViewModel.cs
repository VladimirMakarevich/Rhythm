using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class CommentViewModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public string NameSender { get; set; }
        public bool IsHuman { get; set; }
        public string EmailSender { get; set; }
    }
}