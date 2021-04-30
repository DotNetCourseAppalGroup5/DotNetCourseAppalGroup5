using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class LikesRepository : IRepository<Likes>
    {
        DbContext connection;
        DbSet<Likes> dbSeter;

        public LikesRepository(DbContext context)
        {
            connection = context;
            dbSeter = context.Set<Likes>();
        }

        public IQueryable<Likes> Get()
        {
            return dbSeter.AsNoTracking().AsQueryable();
        }

        public IQueryable<Likes> Get(Func<Likes, bool> predicate)
        {
            return dbSeter.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Likes FindById(int id)
        {
            return dbSeter.Find(id);
        }

        public void Create(Likes item)
        {
            dbSeter.Add(item);
            connection.SaveChanges();
        }
        public void Update(Likes item)
        {
            connection.Entry(item).State = EntityState.Modified;
            connection.SaveChanges();
        }
        public void Remove(Likes item)
        {
            dbSeter.Remove(item);
            connection.SaveChanges();
        }
    }
}
