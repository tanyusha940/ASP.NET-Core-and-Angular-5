using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Data.Model
{
    public class User
    {
        public User()
        {
            Conspects = new List<Conspect>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public bool Active { get; set; }

        public string IdentityId { get; set; }

        public UserIdentity Identity { get; set; }

        public ICollection<Conspect> Conspects { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
