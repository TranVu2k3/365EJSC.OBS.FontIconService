using obsCommon.configFontIcon.commandContract.Validators;
using obsCommon.configFontIcon.commandDomain.Abstractions.Aggregates;

namespace obsCommon.configFontIcon.commandDomain.Entities
{
    public class FontIcon : AggregateRoot<string>
    {
        public string Description { get; set; }

        public string Type { get; set; }

        public string? Version { get; set; }

        public bool IsActived { get; set; }

        public void Update(string? description = null,string? type = null, string? version = null, bool? isActived = null)
        {
            Description = description ?? Description;
            Type = type ?? Type;
            Version = version;
            IsActived = isActived ?? IsActived;
        }
        public override void Validate()
        {
            var validator = Validator.Create(this);
            validator.RuleFor(x => x.Id).MustBeValidKey();
            validator.Validate();
        }
    }
}
