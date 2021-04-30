using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class UserRepository : IRepository<Users>
    {
        DbContext connection;
        DbSet<Users> dbSeter;

        public UserRepository(DbContext context)
        {
            connection = context;
            dbSeter = context.Set<Users>();
        }

        public IQueryable<Users> Get()
        {
            return dbSeter.AsNoTracking().AsQueryable();
        }

        public IQueryable<Users> Get(Func<Users, bool> predicate)
        {
            return dbSeter.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Users FindById(int id)
        {
            return dbSeter.Find(id);
        }

        public void Create(Users item)
        {
            dbSeter.Add(item);
            connection.SaveChanges();
        }
        public void Update(Users item)
        {
            connection.Entry(item).State = EntityState.Modified;
            connection.SaveChanges();
        }
        public void Remove(Users item)
        {
            dbSeter.Remove(item);
            connection.SaveChanges();
        }
    }
}
