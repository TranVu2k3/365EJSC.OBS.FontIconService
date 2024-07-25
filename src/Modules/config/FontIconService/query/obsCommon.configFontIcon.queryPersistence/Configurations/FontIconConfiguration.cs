using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using obsCommon.configFontIcon.queryDomain.Entities;
using obsCommon.configFontIcon.queryPersistence.Constants;

namespace obsCommon.configFontIcon.queryPersistence.Configurations
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
