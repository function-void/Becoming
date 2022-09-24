using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Becoming.Core.TaskManager.Infrastructure.Configurations;

sealed class TaskManagerSaveModelConfiguration : IEntityTypeConfiguration<TaskManagerSaveModel>
{
    public void Configure(EntityTypeBuilder<TaskManagerSaveModel> builder)
    {
        builder.ToTable(DatebaseSettingConstants.TaskManagerTableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(256).IsRequired();
        builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired();
        builder.Property(x => x.IsArchive).HasDefaultValue(false).IsRequired();

        builder.HasMany(x => x.SummaryTasks).WithOne(x => x.TaskManager);

        builder.OwnsOne(x => x.Category, buildAction =>
        {
            buildAction.ToTable(DatebaseSettingConstants.TaskManagerCategoryTableName);
            buildAction.WithOwner(x => x.TaskManager);
            buildAction.Navigation(x => x.TaskManager).UsePropertyAccessMode(PropertyAccessMode.Property);
        });
    }
}
