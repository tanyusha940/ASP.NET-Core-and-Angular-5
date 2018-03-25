using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseProject.Data.Model
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }

        public int ParentCommentId { get; set; }

        [Required]
        public string Text { get; set; }

        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public int ConspectId { get; set; }

        public Conspect Conspect { get; set; }

        public User User { get; set; }
    }
}
