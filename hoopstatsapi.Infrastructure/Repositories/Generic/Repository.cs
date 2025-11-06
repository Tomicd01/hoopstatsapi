using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoopstatsapi.Application.Exceptions;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hoopstatsapi.Infrastructure.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Set<T>().FindAsync(id);
            if (obj == null)
            {
                throw new NotFoundException($"Resource with id {id} not found.");
            };
            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var obj = await _context.Set<T>().FindAsync(id);
            if (obj == null)
            {
                throw new NotFoundException($"Resource with id {id} not found.");
            };
            return obj;
        }

        public async Task UpdateAsync(T enitity)
        {
            _context.Set<T>().Update(enitity);
            await _context.SaveChangesAsync();
        }
    }
}
