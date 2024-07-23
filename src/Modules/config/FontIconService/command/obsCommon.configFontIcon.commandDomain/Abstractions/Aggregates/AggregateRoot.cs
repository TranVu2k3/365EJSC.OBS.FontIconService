using obsCommon.configFontIcon.commandDomain.Abstractions.Entities;

namespace obsCommon.configFontIcon.commandDomain.Abstractions.Aggregates
{
    /// <summary>
    /// Aggregate root
    /// </summary>
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}
