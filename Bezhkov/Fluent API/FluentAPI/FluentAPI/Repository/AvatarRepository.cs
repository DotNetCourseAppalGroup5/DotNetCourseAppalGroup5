using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI
{

    public class AvatarRepository : IRepository<Avatars>
    {
        DbContext _context;
        DbSet<Avatars> _dbSet;

        public AvatarRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Avatars>();
        }

        public IQueryable<Avatars> Get()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<Avatars> Get(Func<Avatars, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Avatars FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(Avatars item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(Avatars item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Avatars item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
