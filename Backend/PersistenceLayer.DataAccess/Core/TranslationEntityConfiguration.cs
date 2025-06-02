namespace PersistenceLayer.DataAccess.Mapping.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersistenceLayer.DataAccess.Entities.Core;

/// <summary>
/// Mapping for <see cref="TranslationEntity"/>.
/// </summary>
public class TranslationEntityConfiguration : IEntityTypeConfiguration<TranslationEntity>
{
       /// <inheritdoc />
       public void Configure(EntityTypeBuilder<TranslationEntity> builder)
       {
              builder.ToTable("Translations", "Core");

              builder.HasKey(t => t.Id);
              builder.Property(t => t.OriginalText).HasMaxLength(200);
              builder.Property(t => t.TranslatedText).HasMaxLength(200);
              builder.Property(t => t.SourceLanguage).HasMaxLength(10);
              builder.Property(t => t.TargetLanguage).HasMaxLength(10);
              builder.Property(t => t.IsAiGenerated).HasDefaultValue(true);
              builder.Property(t => t.IsVerified).HasDefaultValue(false);
              builder.Property(t => t.IsDeleted).HasDefaultValue(false);
              builder.Property(t => t.IsFavorite).HasDefaultValue(false);
              builder.Property(t => t.LastRequestedAt).IsRequired(false);
              builder.Property(t => t.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
       }
}