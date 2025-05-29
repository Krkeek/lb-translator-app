namespace DomainLayer.BusinessLogic.TranslationManagement.Translators;

using Common.Interface.Enums;
using DomainLayer.BusinessLogic.Core;
using PersistenceLayer.DataAccess.Entities;

/// <inheritdoc />
public class EnglishToLebaneseTranslator : BaseTranslator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnglishToLebaneseTranslator"/> class.
    /// </summary>
    public EnglishToLebaneseTranslator()
        : base(LanguageType.English, LanguageType.Lebanese)
    {
    }

    /// <inheritdoc />
    public override Task<WordEntity> TranslateWordAsync(WordEntity word)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public override Task<string> TranslateSentenceAsync(string sentence)
    {
        throw new NotImplementedException();
    }
}