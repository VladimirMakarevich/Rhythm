using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class CommentViewModel
    {

        public int ID { get; set; }
        public int PostID { get; set; }
        public string NameUserSender { get; set; }
        public string EmailUserSender { get; set; }
        public bool DescriptionComment { get; set; }
        public string Comment1 { get; set; }
        public DateTime PostedOn { get; set; }
    }
}