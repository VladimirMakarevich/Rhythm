using Rhythm.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rhythm.Models
{
    public class CommentViewModel
    {
        public int ID { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        [Required]
        [StringLength(50)]
        public string NameSender { get; set; }
        [Required]
        public bool IsHuman { get; set; }
        [Required]
        [EmailAddress]
        public string EmailSender { get; set; }
    }
}