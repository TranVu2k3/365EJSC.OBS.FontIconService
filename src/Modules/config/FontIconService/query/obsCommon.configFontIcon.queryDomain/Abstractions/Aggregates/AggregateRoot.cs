using obsCommon.configFontIcon.queryDomain.Abstractions.Entities;

namespace obsCommon.configFontIcon.queryDomain.Abstractions.Aggregates
{
    /// <summary>
    /// Aggregate root
    /// </summary>
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}
