using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService:IGenericDal<Comment>
    {
        List<Comment> GetCommentListALL(int id);
        List<Comment> GetCommentList();
    }
}
