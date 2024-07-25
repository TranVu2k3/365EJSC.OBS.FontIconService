﻿using obsCommon.configFontIcon.commandDomain.Abstractions.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace obsCommon.configFontIcon.commandDomain.Entities
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

        public void Update(string? description = null,string? type = null, string? version = null, bool? isActive = null)
        {
            UpdatedAt = DateTime.UtcNow;
            Description = description ?? Description;
            Type = type ?? Type;
            Version = version;
            IsActive = isActive ?? IsActive;
        }
        public override void Validate()
        {
           
        }

    }
}
