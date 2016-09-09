using System.ComponentModel.DataAnnotations;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "the field are required!")]
        public string UrlSlug { get; set; }
        public string DescriptionCategory { get; set; }
    }
}