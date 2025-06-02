namespace PersistenceLayer.DataAccess.Mapping.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistenceLayer.DataAccess.Entities.Identity;

/// <summary>
/// Mapping for <see cref="UserEntity"/>.
/// </summary>
public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users", "Identity");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).HasMaxLength(100);
        builder.Property(u => u.LastName).HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20).IsRequired(false);
        builder.Property(u => u.Email).HasMaxLength(100);
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Country).HasMaxLength(100);
        builder.Property(u => u.PasswordHash).HasMaxLength(200);
        builder.Property(u => u.Role).HasMaxLength(50);
        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(u => u.BirthDate);
        builder.Property(u => u.LastLogin);
        builder.Property(u => u.DenyLoginUntil).IsRequired(false);

        builder.HasIndex(u => u.Username).IsUnique().HasDatabaseName("IX_Users_Username");
        builder.HasIndex(u => u.Email).HasDatabaseName("IX_Users_Email");
    }
}