using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class DialogsRepository : IRepository<Dialogs>
    {
        DbContext _context;
        DbSet<Dialogs> _dbSet;

        public DialogsRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Dialogs>();
        }

        public IQueryable<Dialogs> Get()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<Dialogs> Get(Func<Dialogs, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Dialogs FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(Dialogs item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(Dialogs item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Dialogs item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    
    }
}
