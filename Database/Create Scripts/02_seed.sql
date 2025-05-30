-- Users
INSERT INTO [Identity].[Users] (Id, Username, Email, PasswordHash, CreatedAt)
VALUES
    (NEWID(), 'ahmad', 'ahmad@example.com', 'hashed_pw_1', GETDATE()),
    (NEWID(), 'lina', 'lina@example.com', 'hashed_pw_2', GETDATE()),
    (NEWID(), 'samer', 'samer@example.com', 'hashed_pw_3', GETDATE()),
    (NEWID(), 'dina', 'dina@example.com', 'hashed_pw_4', GETDATE()),
    (NEWID(), 'fadi', 'fadi@example.com', 'hashed_pw_5', GETDATE());

-- Preferences
INSERT INTO [Configuration].[Preferences] (UserId, Type, Value, CreatedAt)
VALUES
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'ahmad'), 'Language', 'en-lb', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'lina'), 'Language', 'lb-en', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'samer'), 'Language', 'en-lb', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'dina'), 'Language', 'lb-en', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'fadi'), 'Language', 'en-lb', GETDATE());

-- Translations
INSERT INTO [Core].[Translations] (UserId, OriginalText, TranslatedText, SourceLanguage, TargetLanguage, CreatedAt)
VALUES
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'ahmad'), 'Hello', 'marhaba', 'en', 'lb', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'lina'), 'kifak', 'How are you', 'lb', 'en', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'samer'), 'Goodbye', 'ma3 el saleme', 'en', 'lb', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'dina'), 'shukran', 'Thanks', 'lb', 'en', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'fadi'), 'Welcome', 'ahla w sahla', 'en', 'lb', GETDATE());

-- TopTranslations
INSERT INTO [Core].[TopTranslations] (UserId, TranslationId, OriginalText, SourceLanguage, TargetLanguage, CreatedAt)
VALUES
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'ahmad'), 1, 'Good morning', 'en', 'lb', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'lina'), 2, 'shukran', 'lb', 'en', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'samer'), 3, 'Please', 'en', 'lb', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'dina'), 4, 'Yes', 'en', 'lb', GETDATE()),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'fadi'), 5, 'No', 'en', 'lb', GETDATE());

-- LogEntries
INSERT INTO [Log].[LogEntries] (UserId, Level, Source, Message, Exception)
VALUES
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'ahmad'), 'Info', 'AuthService', 'User logged in.', NULL),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'lina'), 'Info', 'TranslationService', 'Translated kifak → How are you', NULL),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'samer'), 'Info', 'TranslationService', 'Translated Goodbye → ma3 el saleme', NULL),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'dina'), 'Info', 'PreferenceService', 'Changed language preferences', NULL),
    ((SELECT Id FROM [Identity].[Users] WHERE Username = 'fadi'), 'Info', 'AuthService', 'User logged in.', NULL);