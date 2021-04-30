using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class UserDialogRepository : IRepository<UserDialogs>
    {
        DbContext connection;
        DbSet<UserDialogs> dbSeter;

        public UserDialogRepository(DbContext context)
        {
            connection = context;
            dbSeter = context.Set<UserDialogs>();
        }

        public IQueryable<UserDialogs> Get()
        {
            return dbSeter.AsNoTracking().AsQueryable();
        }

        public IQueryable<UserDialogs> Get(Func<UserDialogs, bool> predicate)
        {
            return dbSeter.AsNoTracking().Where(predicate).AsQueryable();
        }
        public UserDialogs FindById(int id)
        {
            return dbSeter.Find(id);
        }

        public void Create(UserDialogs item)
        {
            dbSeter.Add(item);
            connection.SaveChanges();
        }
        public void Update(UserDialogs item)
        {
            connection.Entry(item).State = EntityState.Modified;
            connection.SaveChanges();
        }
        public void Remove(UserDialogs item)
        {
            dbSeter.Remove(item);
            connection.SaveChanges();
        }
    }
}
