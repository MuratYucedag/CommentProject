using CommenProject.DataAccessLayer.Abstract;
using CommenProject.DataAccessLayer.Concrete;
using CommenProject.DataAccessLayer.Repositories;
using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommenProject.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsByTitle(int id)
        {
            var context = new Context();
            return context.Comments.Where(x => x.TitleID == id).ToList();
        }
    }
}
