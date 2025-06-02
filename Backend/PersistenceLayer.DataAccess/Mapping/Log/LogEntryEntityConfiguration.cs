namespace PersistenceLayer.DataAccess.Mapping.Log;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistenceLayer.DataAccess.Entities.Log;

/// <summary>
/// Mapping for <see cref="LogEntryEntity"/>.
/// </summary>
public class LogEntryEntityConfiguration : IEntityTypeConfiguration<LogEntryEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<LogEntryEntity> builder)
    {
        builder.ToTable("LogEntries", "Log");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Level).HasMaxLength(20);
        builder.Property(l => l.Source).HasMaxLength(200);
        builder.Property(l => l.Message).HasMaxLength(200);
        builder.Property(l => l.Exception).HasMaxLength(200);
        builder.Property(l => l.IsDeleted).HasDefaultValue(false);
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.LogEntries)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("FK_LogEntryEntity_UserId_UserEntity_Id")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(p => p.UserId)
            .HasDatabaseName("IX_LogEntryEntity_UserId_UserEntity_Id");
    }
}