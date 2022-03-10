using Connxt.Core.Entities;

namespace Connxt.Core.Repository.Base
{
    public interface IReporsitory<T> where T : Entity
    {
        Task<T> Create(T entity);
        Task Save();

    }
}