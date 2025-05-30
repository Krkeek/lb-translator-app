-- =============================================
-- SCHEMAS
-- =============================================
CREATE SCHEMA [Identity];
GO
CREATE SCHEMA [Configuration];
GO
CREATE SCHEMA [Core];
GO
CREATE SCHEMA [Log];
GO
CREATE SCHEMA [Enum];
GO

-- =============================================
-- Identity.Users
-- =============================================
CREATE TABLE [Identity].[Users] (
                                    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
                                    [FirstName] NVARCHAR(50),
                                    [LastName] NVARCHAR(50),
                                    [Phone] NVARCHAR(30),
                                    [Email] NVARCHAR(100),
                                    [LastLogin] DATETIME2,
                                    [Username] NVARCHAR(50) NOT NULL,
                                    [DenyLoginUntil] DATETIME2,
                                    [BirthDate] DATETIME2,
                                    [Country] NVARCHAR(50),
                                    [CreatedAt] DATETIME2 NOT NULL,
                                    [IsActive] BIT NOT NULL DEFAULT 1,
                                    [PasswordHash] NVARCHAR(500),
                                    [Role] NVARCHAR(50)
);
GO

-- =============================================
-- Configuration.Preferences
-- =============================================
CREATE TABLE [Configuration].[Preferences] (
                                               [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                               [UserId] UNIQUEIDENTIFIER NOT NULL,
                                               [Type] NVARCHAR(50) NOT NULL,
                                               [Value] NVARCHAR(50) NOT NULL,
                                               [CreatedAt] DATETIME2 NOT NULL,
                                               [IsDeleted] BIT NOT NULL DEFAULT 0,
                                               FOREIGN KEY ([UserId]) REFERENCES [Identity].[Users]([Id])
);
GO

-- =============================================
-- Identity.Subscriptions
-- =============================================
CREATE TABLE [Identity].[Subscriptions] (
                                            [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                            [UserId] UNIQUEIDENTIFIER NOT NULL,
                                            [Type] NVARCHAR(50) NOT NULL,
                                            [StartDate] DATE NOT NULL,
                                            [ExpirationDate] DATE NOT NULL,
                                            [PlanName] NVARCHAR(50) NOT NULL,
                                            [IsActive] BIT NOT NULL DEFAULT 1,
                                            [AutoRenew] BIT NOT NULL DEFAULT 1,
                                            FOREIGN KEY ([UserId]) REFERENCES [Identity].[Users]([Id])
);
GO

-- =============================================
-- Core.Translations
-- =============================================
CREATE TABLE [Core].[Translations] (
                                       [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                       [UserId] UNIQUEIDENTIFIER NOT NULL,
                                       [OriginalText] NVARCHAR(500) NOT NULL,
                                       [TranslatedText] NVARCHAR(500),
                                       [SourceLanguage] NVARCHAR(10) NOT NULL,
                                       [TargetLanguage] NVARCHAR(10) NOT NULL,
                                       [LastRequestedAt] DATETIME2,
                                       [RequestCount] INT DEFAULT 0,
                                       [Ranking] FLOAT,
                                       [CreatedAt] DATETIME2 NOT NULL,
                                       [UpdatedAt] DATETIME2,
                                       [IsAIGenerated] BIT DEFAULT 1,
                                       [IsVerified] BIT DEFAULT 0,
                                       [IsDeleted] BIT DEFAULT 0,
                                       [IsFavorite] BIT DEFAULT 0,
                                       FOREIGN KEY ([UserId]) REFERENCES [Identity].[Users]([Id])
);
GO

-- =============================================
-- Core.TopTranslations
-- =============================================
CREATE TABLE [Core].[TopTranslations] (
                                          [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                          [UserId] UNIQUEIDENTIFIER NOT NULL,
                                          [TranslationId] INT NOT NULL,
                                          [OriginalText] NVARCHAR(500) NOT NULL,
                                          [SourceLanguage] NVARCHAR(10) NOT NULL,
                                          [TargetLanguage] NVARCHAR(10) NOT NULL,
                                          [CreatedAt] DATETIME2 NOT NULL,
                                          [UpdatedAt] DATETIME2,
                                          FOREIGN KEY ([UserId]) REFERENCES [Identity].[Users]([Id]),
                                          FOREIGN KEY ([TranslationId]) REFERENCES [Core].[Translations]([Id])
);
GO

-- =============================================
-- Log.LogEntries
-- =============================================
CREATE TABLE [Log].[LogEntries] (
                                    [Id] INT IDENTITY(1,1) PRIMARY KEY,
                                    [UserId] UNIQUEIDENTIFIER NOT NULL,
                                    [TimeStamp] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
                                    [Level] NVARCHAR(20),
                                    [Source] NVARCHAR(100),
                                    [Message] NVARCHAR(500),
                                    [Exception] NVARCHAR(MAX),
                                    [IsDeleted] BIT DEFAULT 0,
                                    FOREIGN KEY ([UserId]) REFERENCES [Identity].[Users]([Id])
);
GO