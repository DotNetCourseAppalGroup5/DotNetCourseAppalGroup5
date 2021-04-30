using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class PhotosRepository : IRepository<Photos>
    {
        DbContext connection;
        DbSet<Photos> dbSeter;

        public PhotosRepository(DbContext context)
        {
            connection = context;
            dbSeter = context.Set<Photos>();
        }

        public IQueryable<Photos> Get()
        {
            return dbSeter.AsNoTracking().AsQueryable();
        }

        public IQueryable<Photos> Get(Func<Photos, bool> predicate)
        {
            return dbSeter.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Photos FindById(int id)
        {
            return dbSeter.Find(id);
        }

        public void Create(Photos item)
        {
            dbSeter.Add(item);
            connection.SaveChanges();
        }
        public void Update(Photos item)
        {
            connection.Entry(item).State = EntityState.Modified;
            connection.SaveChanges();
        }
        public void Remove(Photos item)
        {
            dbSeter.Remove(item);
            connection.SaveChanges();
        }
    }
}
