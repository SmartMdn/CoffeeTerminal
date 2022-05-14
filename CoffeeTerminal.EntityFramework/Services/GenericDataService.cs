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
        protected CoffeeTerminalDbContext Context;

        public GenericDataService(CoffeeTerminalDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            Context = _contextFactory.CreateDbContext();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await Context.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> Get(int id)
        {
            var entity = await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<T> Create(T entity)
        {
            var createdEntity = Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;

            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
