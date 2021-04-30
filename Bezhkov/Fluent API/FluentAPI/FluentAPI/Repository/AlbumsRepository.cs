using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI
{

    public class AlbumsRepository : IRepository<Albums>
    {
        DbContext _context;
        DbSet<Albums> _dbSet;

        public AlbumsRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Albums>();
        }

        public IQueryable<Albums> Get()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<Albums> Get(Func<Albums, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Albums FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(Albums item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(Albums item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Albums item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
