using System.ComponentModel.DataAnnotations;

namespace Rhythm.Models
{
    public class ProjectViewModel
    {
        [Display(Name = "Project")]
        public string NameProject { get; set; }
        public string Framework { get; set; }
        public string Database { get; set; }
        public string IDE { get; set; }
        [Display(Name = "Stack technologies")]
        public string StackTechnologies { get; set; }
        public string Url { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}