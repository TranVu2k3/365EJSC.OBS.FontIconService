using obsCommon.configFontIcon.queryContract.Validators;
using obsCommon.configFontIcon.queryDomain.Abstractions.Aggregates;

namespace obsCommon.configFontIcon.queryDomain.Entities
{
    public class FontIcon : AggregateRoot<string>
    {
        public string Description { get; set; }

        public string Type { get; set; }

        public string? Version { get; set; }

        public bool IsActived { get; set; }

        public override void Validate()
        {
            var validator = Validator.Create(this);
            validator.RuleFor(x => x.Id).MustBeValidKey();
            validator.Validate();

        }
    }
}
