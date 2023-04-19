using CommenProject.DataAccessLayer.Abstract;
using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(Comment t)
        {
           _commentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetCommentsByTitle(int id)
        {
            return _commentDal.GetCommentsByTitle(id);
        }

        public List<Comment> TGetCommentsByTitleWithUser(int id)
        {
            return _commentDal.GetCommentsByTitleWithUser(id);
        }

        public List<Comment> TGetCommentsByUserWithTitle(int id)
        {
            return _commentDal.GetCommentsByUserWithTitle(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter)
        {
           return _commentDal.GetListByFilter(filter);
        }

        public void TInsert(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
