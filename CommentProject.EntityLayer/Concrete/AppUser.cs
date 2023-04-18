using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.EntityLayer.Concrete
{
    public class AppUser:IdentityUser <int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Title> Titles { get; set; }
    }
}
