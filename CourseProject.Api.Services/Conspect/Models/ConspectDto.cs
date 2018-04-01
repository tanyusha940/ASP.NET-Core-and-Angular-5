using System.Collections.Generic;
using CourseProject.Api.Services.LookUps.Models;

namespace CourseProject.Api.Services.Conspect.Models
{
    public class ConspectDto
    {
        public int Id { get; set; }

        public IEnumerable<LookUp> Tags { get; set; }
    }
}