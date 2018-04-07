using System;
using System.Collections.Generic;
using CourseProject.Api.Services.LookUps.Models;

namespace CourseProject.Api.Services.Conspect.Models
{
    public class ConspectDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SpecialityNumberId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public ICollection<LookUp> Tags { get; set; }
    }
}