using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        T Get(Expression<Func<T, bool>> filter);//istediğimiz değere göre veriyi getirebilirim. (id yerine mail ile sorgu yapabilirim)

        T GetById(int id);
        //şartlı listeleme
        List<T> GetListAll();
    }
}
