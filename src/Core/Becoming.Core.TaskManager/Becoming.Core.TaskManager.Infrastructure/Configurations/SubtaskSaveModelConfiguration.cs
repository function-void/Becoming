using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Becoming.Core.TaskManager.Infrastructure.Configurations;

sealed class SubtaskSaveModelConfiguration : IEntityTypeConfiguration<SubtaskSaveModel>
{
    public void Configure(EntityTypeBuilder<SubtaskSaveModel> builder)
    {
        builder.ToTable(DatebaseSettingConstants.SubtaskTableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(3072);
        builder.Property(x => x.IsComplete).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.IsArchive).HasDefaultValue(false).IsRequired();
    }
}
