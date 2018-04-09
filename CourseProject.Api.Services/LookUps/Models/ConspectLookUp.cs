using System;
using System.Linq;

namespace CourseProject.Api.Services.LookUps.Models
{
  public class ConspectLookUp: LookUp
  {
      public int SpecialityNumberId { get; set; }

      public DateTime CreatedDate { get; set; }

      public string UserName { get; set; }

      public string Content { get; set; }

      public IQueryable<LookUp> Tags { get; set; }
  }
}