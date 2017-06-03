using System.Web;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class ImageAdminViewModel
    {
        public int PostId { get; set; }
        public HttpPostedFileBase ImageData { get; set; }
        public byte[] ImageDataByte { get; set; }
        public string ImageMime { get; set; }
    }
}