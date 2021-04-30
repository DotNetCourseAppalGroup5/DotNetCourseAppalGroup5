using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FluentAPI.RepositoryInterfeice;

namespace FluentAPI
{

    public class UserRepository : IRepository<Users> 
    {
        DbContext _context;
        DbSet<Users> _dbSet;

        public UserRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Users>();
        }

        public IQueryable<Users> Get()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<Users> Get(Func<Users, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }
        public Users FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(Users item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(Users item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Users item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
