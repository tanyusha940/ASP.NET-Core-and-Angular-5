using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseProject.Data.Model
{
    public class Tag
    {
        public Tag()
        {
            ConspectTags = new List<ConspectTag>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public string Text { get; set; }

        public ICollection<ConspectTag> ConspectTags { get; set; }
    }
}
