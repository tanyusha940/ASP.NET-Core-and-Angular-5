﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CourseProject.Data.Model
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }

        public int Mark { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public int ConspectId { get; set; }

        public User User { get; set; }

        public Conspect Conspect { get; set; }
    }
}
