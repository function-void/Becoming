using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Becoming.Core.TaskManager.Infrastructure.Configurations;

sealed class SummaryTaskSaveModelConfiguration : IEntityTypeConfiguration<SummaryTaskSaveModel>
{
    public void Configure(EntityTypeBuilder<SummaryTaskSaveModel> builder)
    {
        builder.ToTable(Scheme.SummaryTaskTableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(Content.TitleMaxSize).IsRequired();
        builder.Property(x => x.GroupId);
        builder.Property(x => x.Description).HasMaxLength(Content.DescriptionMaxSize);
        builder.Property(x => x.IsComplete).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.IsArchive).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.OnlyDate).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate);

        builder.HasMany(x => x.Subtasks).WithOne(x => x.SummaryTask);
    }
}
