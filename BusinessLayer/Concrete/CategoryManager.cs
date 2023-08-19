using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public List<Category> CategoryList()
        {
            return _categoryDAL.GetListAll(p => p.CategoryStatus == true);
        }

        public void Delete(Category t)
        {
            _categoryDAL.Delete(t);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDAL.Get(filter);
        }

        public Category GetById(int id)
        {
            return _categoryDAL.GetById(id);
        }

        public List<Category> GetListAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDAL.GetListAll();
        }

        public void Insert(Category t)
        {
            _categoryDAL.Insert(t);
        }

        public void Update(Category t)
        {
            _categoryDAL.Update(t);
        }
    }
}
