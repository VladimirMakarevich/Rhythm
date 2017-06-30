using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class ImageAdminViewModel
    {
        public int Id { get; set; }
        public HttpPostedFileBase FileBase { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMime { get; set; }
        public string ImagePath { get; set; }
    }
}