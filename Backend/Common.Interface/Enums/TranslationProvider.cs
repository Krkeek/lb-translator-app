namespace Common.Interface.Enums;

/// <summary>
/// The source of translations.
/// </summary>
public enum TranslationProvider
{
    /// <summary>
    /// AI Translation.
    /// </summary>
    OpenAi = 0,

    /// <summary>
    /// Database.
    /// </summary>
    SqlDatabase = 1,

    /// <summary>
    /// Local Storage.
    /// </summary>
    Cache = 2,
}