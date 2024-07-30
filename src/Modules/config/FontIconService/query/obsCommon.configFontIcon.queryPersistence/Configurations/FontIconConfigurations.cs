using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using obsCommon.configFontIcon.queryDomain.Entities;
using obsCommon.configFontIcon.queryPersistence.Constants;

namespace obsCommon.configFontIcon.queryPersistence.Configurations
{
    public class FontIconConfigurations : IEntityTypeConfiguration<FontIcon>
    {
        public void Configure(EntityTypeBuilder<FontIcon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("idx_key");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Type).HasColumnName("type");
            builder.Property(x => x.Version).HasColumnName("version");
            builder.Property(x => x.IsActived).HasColumnName("is_actived");
            builder.ToTable(TableName.FontIconTable);
        }
    }
}
