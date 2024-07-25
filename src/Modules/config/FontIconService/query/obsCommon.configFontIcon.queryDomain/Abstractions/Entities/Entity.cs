namespace obsCommon.configFontIcon.queryDomain.Abstractions.Entities
{
    /// <summary>
    /// Domain entity
    /// </summary>
    public abstract class Entity<TKey> : IEntity
    {
        /// <summary>
        /// Primary key of entity
        /// </summary>
        public TKey IdxKey { get; set; }

        public abstract void Validate();
    }
}
