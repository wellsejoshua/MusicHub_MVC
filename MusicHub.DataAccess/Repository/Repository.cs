using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicHub.DataAccess.Data;
using MusicHub.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace MusicHub.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
            //db.Class == dbset so no need for _context.Categories
            //_context.Products.Include(u => u.Category);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();

        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _context.RemoveRange(entity);
        }
    }
}
