namespace DomainLayer.BusinessLogic.UnitTests.TranslationManagement.Translators.EnglishToLebaneseTranslator;

using Common.Interface.Enums;
using DomainLayer.BusinessLogic.TranslationManagement.Translators;

public class ConstructorMethod
{
    [Fact]
    public void ConstructorShouldSetCorrectLanguages()
    {
        // Act
        var translator = new EnglishToLebaneseTranslator();

        // Assert
        Assert.Equal(LanguageType.English, translator.SourceLanguage);
        Assert.Equal(LanguageType.Lebanese, translator.TargetLanguage);
    }
}