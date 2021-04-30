using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class PhotoMessageRepository : IRepository<PhotoMessages>
    {
        DbContext connection;
        DbSet<PhotoMessages> dbSeter;

        public PhotoMessageRepository(DbContext context)
        {
            connection = context;
            dbSeter = context.Set<PhotoMessages>();
        }

        public IQueryable<PhotoMessages> Get()
        {
            return dbSeter.AsNoTracking().AsQueryable();
        }

        public IQueryable<PhotoMessages> Get(Func<PhotoMessages, bool> predicate)
        {
            return dbSeter.AsNoTracking().Where(predicate).AsQueryable();
        }
        public PhotoMessages FindById(int id)
        {
            return dbSeter.Find(id);
        }

        public void Create(PhotoMessages item)
        {
            dbSeter.Add(item);
            connection.SaveChanges();
        }
        public void Update(PhotoMessages item)
        {
            connection.Entry(item).State = EntityState.Modified;
            connection.SaveChanges();
        }
        public void Remove(PhotoMessages item)
        {
            dbSeter.Remove(item);
            connection.SaveChanges();
        }
    }
}
