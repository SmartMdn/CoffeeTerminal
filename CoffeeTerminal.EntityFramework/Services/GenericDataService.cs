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
        protected CoffeeTerminalDbContext context;

        public GenericDataService(CoffeeTerminalDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            context = _contextFactory.CreateDbContext();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await context.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> Get(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<T> Create(T entity)
        {
            var createdEntity = context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;

            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
