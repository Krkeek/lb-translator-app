-- Indexes for Identity.Users
CREATE UNIQUE INDEX IX_Users_Username ON [Identity].[Users] ([Username]);
CREATE INDEX IX_Users_Email ON [Identity].[Users] ([Email]);
-- Indexes for Identity.Subscriptions
CREATE INDEX IX_Subscriptions_UserId ON [Identity].[Subscriptions] ([UserId]);
CREATE INDEX IX_Subscriptions_IsActive ON [Identity].[Subscriptions] ([IsActive]);

-- Indexes for Configuration.Preferences
CREATE INDEX IX_Preferences_UserId ON [Configuration].[Preferences] ([UserId]);

-- Indexes for Core.Translations
CREATE INDEX IX_Translations_UserId ON [Core].[Translations] ([UserId]);
CREATE INDEX IX_Translations_RequestCount ON [Core].[Translations] ([RequestCount]);
CREATE INDEX IX_Translations_IsFavorite ON [Core].[Translations] ([IsFavorite]);

-- Indexes for Core.TopTranslations
CREATE INDEX IX_TopTranslations_UserId ON [Core].[TopTranslations] ([UserId]);
CREATE INDEX IX_TopTranslations_TranslationId ON [Core].[TopTranslations] ([TranslationId]);

-- Indexes for Log.LogEntries
CREATE INDEX IX_LogEntries_UserId ON [Log].[LogEntries] ([UserId]);
CREATE INDEX IX_LogEntries_TimeStamp ON [Log].[LogEntries] ([TimeStamp]);