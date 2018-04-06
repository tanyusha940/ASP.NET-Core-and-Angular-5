using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.Api.Services.User.Models
{
    public class UserDto
    {
        public string Id { get; set; }

        public bool Active { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}
