using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseProject.Data.Model
{
    public class Rating
    {
        public Rating()
        {
            Conspects = new List<Conspect>();
        }

        [Required]
        public int Id { get; set; }

        public int Mark { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ConspectId { get; set; }

        public User User { get; set; }

        public ICollection<Conspect> Conspects { get; set; }
    }
}
