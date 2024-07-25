using obsCommon.configFontIcon.queryDomain.Abstractions.Aggregates;

namespace obsCommon.configFontIcon.queryDomain.Entities
{
    public class FontIcon : AggregateRoot<string>
    {
        public string? Description { get; set; }

        public string? Type { get; set; }

        public string? Version { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public override void Validate()
        {
            
        }
    }
}
