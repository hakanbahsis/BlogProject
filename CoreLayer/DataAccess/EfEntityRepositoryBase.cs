using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DataAccess
{
    public abstract class EfEntityRepositoryBase<TEntity, TContext> : IGenericDal<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public void Delete(TEntity t)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(t);//entityleri eşleştiriyorum
                addedEntity.State = EntityState.Deleted;//silme işlemi olduğunu belirtiyorum
                context.SaveChanges();//kaydediyorum
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

     

        public List<TEntity> GetListAll(Expression<Func<TEntity, bool>> filter=null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Insert(TEntity t)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(t);//entityleri eşleştiriyorum
                addedEntity.State = EntityState.Added;//ekleme işlemi olduğunu belirtiyorum
                context.SaveChanges();//kaydediyorum
            }
        }

        public void Update(TEntity t)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(t);//entityleri eşleştiriyorum
                addedEntity.State = EntityState.Modified;//güncelleme işlemi olduğunu belirtiyorum
                context.SaveChanges();//kaydediyorum
            }
        }
    }
}
