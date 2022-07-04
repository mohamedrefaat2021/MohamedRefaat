using Microsoft.EntityFrameworkCore;
using MohamedRefaat.Domain.IRepository;
using MohamedRefaat.Domain.Models.Paging;
using MohamedRefaat.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Infra.Data.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public RepositoryAsync(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await dbSet.AddRangeAsync(entity);
        }
        public async Task<T> GetAsync(int id, bool allowTracking = false)
        {
            if (!allowTracking)
            {
                dbSet.AsNoTracking();
            }
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }


        public async Task<PagedListResponse<T>> GetAllPagedListAsync(Expression<Func<T, bool>> filter, int pageNumber, int pageSize, string includeProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            int count = 0;
            IQueryable<T> query = dbSet.AsNoTracking();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            count = await query?.CountAsync();
            var PaggedData = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var returnModel = new PagedListResponse<T>(PaggedData, count, pageNumber, pageSize);
            return returnModel;
        }
        public async Task<IEnumerable<T>> GetAllPagedListAsync(Expression<Func<T, bool>> filter, string includeProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            int count = 0;
            IQueryable<T> query = dbSet.AsNoTracking();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            count = await query?.CountAsync();
            var data = await query.ToListAsync();
            return data;
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool allowTracking = false)
        {
            if (!allowTracking)
            {
                dbSet.AsNoTracking();
            }
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(int id)
        {
            T entity = await dbSet.FindAsync(id);
            await RemoveAsync(entity);
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
        public void Update(T entity)
        {
            _db.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        public void UpdateRange(IEnumerable<T> entity)
        {
            _db.AddRangeAsync(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            int count = 0;
            IQueryable<T> query = dbSet.AsNoTracking();
            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            count = await query?.CountAsync();
            var data = await query.ToListAsync();
            return data;
        }
    }
}
