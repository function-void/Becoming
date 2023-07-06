using Becoming.Core.Common.Infrastructure.Settings;
using Becoming.Core.TaskManager.Domain.Models;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Becoming.Core.TaskManager.Infrastructure.Configurations;

sealed class TaskManagerSaveModelConfiguration : IEntityTypeConfiguration<TaskManagerSaveModel>
{
    public void Configure(EntityTypeBuilder<TaskManagerSaveModel> builder)
    {
        builder.ToTable(Scheme.TaskManagerTableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(Content.TitleMaxSize).IsRequired();
        builder.Property(x => x.IsActive).HasDefaultValue(true).IsRequired();
        builder.Property(x => x.IsArchive).HasDefaultValue(false).IsRequired();

        builder.HasMany(x => x.SummaryTasks).WithOne(x => x.TaskManager);

        builder.OwnsOne(x => x.Category, buildAction =>
        {
            buildAction.ToTable(Scheme.TaskManagerCategoryTableName);
            buildAction.WithOwner(x => x.TaskManager);
            buildAction.Navigation(x => x.TaskManager).UsePropertyAccessMode(PropertyAccessMode.Property);
            buildAction.Property(x => x.Name).HasMaxLength(Category.MaxLength);
        });
    }
}
