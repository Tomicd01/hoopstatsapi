using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hoopstatsapi.Infrastructure.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

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
            if (obj == null) return;
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
            return obj;
        }

        public async Task UpdateAsync(T enitity)
        {
            _context.Set<T>().Update(enitity);
            await _context.SaveChangesAsync();
        }
    }
}
