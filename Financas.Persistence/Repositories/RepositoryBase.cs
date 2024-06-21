using Financas.Persistence.Data;
using Financas.Persistence.Repositories.Interfaces;


namespace Financas.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDbContext Context;
        public RepositoryBase(AppDbContext context)
        {
            Context = context;
        }
        public async Task CreateAsync(T entity)
        {

            await Context.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Context.Remove(entity));
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Context.Update(entity));
        }

    }
}
