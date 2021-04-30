using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI.Repository
{
    class FriendsRepository : IRepository<Friends>
    {
        DbContext _context;
        DbSet<Friends> _dbSet;

        public FriendsRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Friends>();
        }

        public IQueryable<Friends> Get()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<Friends> Get(Func<Friends, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Friends FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(Friends item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(Friends item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Friends item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
