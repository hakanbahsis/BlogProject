﻿using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDAL : IGenericDal<About>
    {
       // List<About> GetListAll(Expression<Func<Category, bool>> filter);
    }
}
