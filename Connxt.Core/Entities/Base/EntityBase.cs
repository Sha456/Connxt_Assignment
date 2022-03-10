using Connxt.Core.Entities.Interface;

namespace Connxt.Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId? Id { get; protected set; }
    }
}