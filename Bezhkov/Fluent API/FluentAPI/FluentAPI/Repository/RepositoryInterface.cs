using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
   public class RepositoryInterfeice
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            void Create(TEntity item);
            TEntity FindById(int id);
            IQueryable<TEntity> Get();
            IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
            void Remove(TEntity item);
            void Update(TEntity item);
        }
    }
}
