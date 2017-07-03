using Rhythm.Domain.Entities;

namespace Rhythm.Areas.ChiefAdmin.Models
{
    public class RssAdminViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public TypeRss Type { get; set; }
    }
}