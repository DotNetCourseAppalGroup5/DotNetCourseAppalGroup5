using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class MessageAvatarRepository : IRepository<MessageAvatars>
    {
        DbContext connection;
        DbSet<MessageAvatars> dbSeter;

        public MessageAvatarRepository(DbContext context)
        {
            connection = context;
            dbSeter = context.Set<MessageAvatars>();
        }

        public IQueryable<MessageAvatars> Get()
        {
            return dbSeter.AsNoTracking().AsQueryable();
        }

        public IQueryable<MessageAvatars> Get(Func<MessageAvatars, bool> predicate)
        {
            return dbSeter.AsNoTracking().Where(predicate).AsQueryable();
        }
        public MessageAvatars FindById(int id)
        {
            return dbSeter.Find(id);
        }

        public void Create(MessageAvatars item)
        {
            dbSeter.Add(item);
            connection.SaveChanges();
        }
        public void Update(MessageAvatars item)
        {
            connection.Entry(item).State = EntityState.Modified;
            connection.SaveChanges();
        }
        public void Remove(MessageAvatars item)
        {
            dbSeter.Remove(item);
            connection.SaveChanges();
        }
    }
}

