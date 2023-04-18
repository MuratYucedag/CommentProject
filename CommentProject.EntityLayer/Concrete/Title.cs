using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.EntityLayer.Concrete
{
    public class Title
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
