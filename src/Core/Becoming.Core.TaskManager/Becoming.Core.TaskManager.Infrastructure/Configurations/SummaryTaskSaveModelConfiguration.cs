﻿using Becoming.Core.Common.Infrastructure.Persistence.Constants;
using Becoming.Core.TaskManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Becoming.Core.TaskManager.Infrastructure.Configurations;

internal sealed class SummaryTaskSaveModelConfiguration : IEntityTypeConfiguration<SummaryTaskSaveModel>
{
    public void Configure(EntityTypeBuilder<SummaryTaskSaveModel> builder)
    {
        builder.ToTable(DbConstants.SummaryTaskTableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(256).IsRequired();
        builder.Property(x => x.GroupId);
        builder.Property(x => x.Description).HasMaxLength(3072);
        builder.Property(x => x.IsComplete).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.IsArchive).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.OnlyDate).HasDefaultValue(false).IsRequired();
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate);

        builder.HasMany(x => x.Subtasks).WithOne(x => x.SummaryTask);
    }
}