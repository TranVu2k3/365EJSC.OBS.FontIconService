using obsCommon.configFontIcon.queryDomain.Abstractions.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace obsCommon.configFontIcon.queryDomain.Entities
{
    [Table("ConfigFonticon")]
    public class Sample : AggregateRoot<string>
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
