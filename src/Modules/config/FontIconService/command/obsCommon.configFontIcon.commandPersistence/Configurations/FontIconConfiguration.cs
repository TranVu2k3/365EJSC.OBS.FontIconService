using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using obsCommon.configFontIcon.commandDomain.Entities;
using obsCommon.configFontIcon.commandPersistence.Constants;

namespace obsCommon.configFontIcon.commandPersistence.Configurations
{
    public class FontIconConfiguration : IEntityTypeConfiguration<FontIcon>
    {
        public void Configure(EntityTypeBuilder<FontIcon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(TableNames.FontIconTable);
        }
    }
}
