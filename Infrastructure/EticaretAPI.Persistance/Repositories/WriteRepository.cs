using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities.Common;
using EticaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
          var entityEntry =  await Table.AddAsync(model);
          return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            var entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entityEntry = await Table.FirstOrDefault(data => data.Id == Guid.Parse(id));
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }


       
    }
}
