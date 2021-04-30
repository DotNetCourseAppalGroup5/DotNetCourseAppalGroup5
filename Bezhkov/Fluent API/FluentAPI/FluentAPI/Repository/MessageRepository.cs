using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class MessagesRepository : IRepository<Messages>
    {
        DbContext _context;
        DbSet<Messages> _dbSet;

        public MessagesRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Messages>();
        }

        public IQueryable<Messages> Get()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<Messages> Get(Func<Messages, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Messages FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(Messages item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(Messages item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Messages item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
