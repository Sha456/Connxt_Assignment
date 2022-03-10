using Connxt.Core.Entities;
using Connxt.Core.Entities.Interface;
using Connxt.Core.Repository.Base;
using Connxt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Connxt.Infrastructure.Repository.Base
{
    public class Repository<T> : IReporsitory<T> where T : Entity
    {
        protected readonly DatabaseContext _dbContext;

        public Repository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<T> Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public async Task Save()
        {
            ApplyAuditInformation();
            await _dbContext.SaveChangesAsync();
        }
        private void ApplyAuditInformation()
        {
            var modifiedEntities = _dbContext.ChangeTracker.Entries<IAuditable>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entity in modifiedEntities)
            {
                entity.Property("ModifiedDate").CurrentValue = DateTime.Now.ToString("MM/dd/yyyy");

                if (entity.State == EntityState.Added)
                {
                    entity.Property("CreatedDate").CurrentValue = DateTime.Now.ToString("MM/dd/yyyy");
                }
            }
        }
    }
}