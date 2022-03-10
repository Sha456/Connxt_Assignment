namespace Connxt.Core.Entities.Interface
{
    internal interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}