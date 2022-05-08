using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CoffeeTerminal.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly CoffeeTerminalDbContextFactory _contextFactory;

        public GenericDataService(CoffeeTerminalDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (CoffeeTerminalDbContext context = _contextFactory.CreateDbContext())
            {
                var entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> Get(int id)
        {
            using (CoffeeTerminalDbContext context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                return entity;
            }
        }

        public async Task<T> Create(T entity)
        {
            using (CoffeeTerminalDbContext context = _contextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdEntity.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (CoffeeTerminalDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            await using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
