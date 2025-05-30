namespace DomainLayer.BusinessLogic.UnitTests.TranslationManagement.Translators.EnglishToLebaneseTranslator;

using Common.Interface.Enums;
using DomainLayer.BusinessLogic.TranslationManagement.Translators;

public class ConstructorMethod
{
    private EnglishToLebaneseTranslator _translator;

    [Fact]
    public void ConstructorShouldSetCorrectLanguages()
    {
        // Act
        this._translator = new EnglishToLebaneseTranslator();

        // Assert
        Assert.Equal(LanguageType.English, this._translator.SourceLanguage);
        Assert.Equal(LanguageType.Lebanese, this._translator.TargetLanguage);
    }
}