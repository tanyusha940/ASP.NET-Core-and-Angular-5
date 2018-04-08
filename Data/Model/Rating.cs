using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.Data.Model
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }

        public int Mark { get; set; }

        [Required]
        [ForeignKey("Identity")]
        public string IdentityId { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public int ConspectId { get; set; }

        public UserIdentity Identity { get; set; }

        public Conspect Conspect { get; set; }
    }
}
