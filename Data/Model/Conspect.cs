using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseProject.Data.Model
{
    public class Conspect
    {
        public Conspect()
        {
            ConspectTags = new List<ConspectTag>();
            Comments = new List<Comment>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SpecialityNumberId { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool Active { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }

        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<ConspectTag> ConspectTags { get; set; }
    }
}
