using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using obsCommon.configFontIcon.commandDomain.Entities;
using obsCommon.configFontIcon.commandPersistence.Constants;

namespace obsCommon.configFontIcon.commandPersistence.Configurations
{
    public class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.HasKey(x => x.IdxKey);
            builder.ToTable(TableNames.SampleTable);
        }
    }
}
