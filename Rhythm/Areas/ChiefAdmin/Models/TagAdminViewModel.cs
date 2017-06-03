using System.ComponentModel.DataAnnotations;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class TagAdminViewModel
    {
        [Required(ErrorMessage = "the field are required!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string UrlSlug { get; set; }
        public string DescriptionTag { get; set; }
        public bool Assigned { get; set; }
    }
}