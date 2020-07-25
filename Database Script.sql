IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [BlogTypes] (
    [blogTypeId] int NOT NULL IDENTITY,
    [type] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_BlogTypes] PRIMARY KEY ([blogTypeId])
);

GO

CREATE TABLE [TalkTypes] (
    [TypeId] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TalkTypes] PRIMARY KEY ([TypeId])
);

GO

CREATE TABLE [Blogs] (
    [blogId] int NOT NULL IDENTITY,
    [name] nvarchar(100) NOT NULL,
    [body] text NOT NULL,
    [blogTypeId] int NOT NULL,
    [blogImageURL] nvarchar(max) NULL,
    [approved] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [userId] int NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([blogId]),
    CONSTRAINT [FK_Blogs_BlogTypes_blogTypeId] FOREIGN KEY ([blogTypeId]) REFERENCES [BlogTypes] ([blogTypeId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Talks] (
    [TalkId] int NOT NULL IDENTITY,
    [TypeId] int NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Body] text NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [userId] int NOT NULL,
    [TalkTypeTypeId] int NULL,
    CONSTRAINT [PK_Talks] PRIMARY KEY ([TalkId]),
    CONSTRAINT [FK_Talks_TalkTypes_TalkTypeTypeId] FOREIGN KEY ([TalkTypeTypeId]) REFERENCES [TalkTypes] ([TypeId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TalkComments] (
    [CommentID] int NOT NULL IDENTITY,
    [TalkId] int NOT NULL,
    [Comment] text NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [userId] int NOT NULL,
    CONSTRAINT [PK_TalkComments] PRIMARY KEY ([CommentID]),
    CONSTRAINT [FK_TalkComments_Talks_TalkId] FOREIGN KEY ([TalkId]) REFERENCES [Talks] ([TalkId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Blogs_blogTypeId] ON [Blogs] ([blogTypeId]);

GO

CREATE INDEX [IX_TalkComments_TalkId] ON [TalkComments] ([TalkId]);

GO

CREATE INDEX [IX_Talks_TalkTypeTypeId] ON [Talks] ([TalkTypeTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200526183657_initial', N'3.1.4');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200528022537_SecondRun', N'3.1.4');

GO

CREATE TABLE [ExpertQuestionTypes] (
    [id] int NOT NULL IDENTITY,
    [type] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ExpertQuestionTypes] PRIMARY KEY ([id])
);

GO

CREATE TABLE [Experts] (
    [id] int NOT NULL IDENTITY,
    [firstName] nvarchar(100) NOT NULL,
    [lastName] nvarchar(100) NOT NULL,
    [specialty] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Experts] PRIMARY KEY ([id])
);

GO

CREATE TABLE [ExpertAnswers] (
    [id] int NOT NULL IDENTITY,
    [answer] nvarchar(max) NOT NULL,
    [expertId] int NOT NULL,
    CONSTRAINT [PK_ExpertAnswers] PRIMARY KEY ([id]),
    CONSTRAINT [FK_ExpertAnswers_Experts_expertId] FOREIGN KEY ([expertId]) REFERENCES [Experts] ([id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ExpertQuestions] (
    [id] int NOT NULL IDENTITY,
    [question] nvarchar(max) NOT NULL,
    [typeId] int NOT NULL,
    [answerId] int NOT NULL,
    CONSTRAINT [PK_ExpertQuestions] PRIMARY KEY ([id]),
    CONSTRAINT [FK_ExpertQuestions_ExpertAnswers_answerId] FOREIGN KEY ([answerId]) REFERENCES [ExpertAnswers] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ExpertQuestions_ExpertQuestionTypes_typeId] FOREIGN KEY ([typeId]) REFERENCES [ExpertQuestionTypes] ([id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ExpertAnswers_expertId] ON [ExpertAnswers] ([expertId]);

GO

CREATE UNIQUE INDEX [IX_ExpertQuestions_answerId] ON [ExpertQuestions] ([answerId]);

GO

CREATE INDEX [IX_ExpertQuestions_typeId] ON [ExpertQuestions] ([typeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200529013758_ExpertData', N'3.1.4');

GO

ALTER TABLE [Experts] ADD [bio] text NOT NULL DEFAULT '';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200529020802_ExpertDataUpdate1', N'3.1.4');

GO

ALTER TABLE [Experts] ADD [imageURL] nvarchar(max) NULL;

GO

ALTER TABLE [ExpertQuestions] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200529201633_ExpertDataUpdate2', N'3.1.4');

GO

ALTER TABLE [ExpertQuestions] DROP CONSTRAINT [FK_ExpertQuestions_ExpertAnswers_answerId];

GO

DROP INDEX [IX_ExpertQuestions_answerId] ON [ExpertQuestions];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ExpertQuestions]') AND [c].[name] = N'answerId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ExpertQuestions] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ExpertQuestions] DROP COLUMN [answerId];

GO

ALTER TABLE [ExpertAnswers] ADD [questionId] int NOT NULL DEFAULT 0;

GO

CREATE UNIQUE INDEX [IX_ExpertAnswers_questionId] ON [ExpertAnswers] ([questionId]);

GO

ALTER TABLE [ExpertAnswers] ADD CONSTRAINT [FK_ExpertAnswers_ExpertQuestions_questionId] FOREIGN KEY ([questionId]) REFERENCES [ExpertQuestions] ([id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200529214730_ExpertDataUpdate3', N'3.1.4');

GO

ALTER TABLE [ExpertQuestions] ADD [answered] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200530013439_ExpertDataUpdate4', N'3.1.4');

GO

ALTER TABLE [ExpertQuestions] ADD [userId] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200530021643_ExpertDataUpdate5', N'3.1.4');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'blogTypeId', N'type') AND [object_id] = OBJECT_ID(N'[BlogTypes]'))
    SET IDENTITY_INSERT [BlogTypes] ON;
INSERT INTO [BlogTypes] ([blogTypeId], [type])
VALUES (1, N'Breastfeeding'),
(2, N'Eduction and Learning'),
(3, N'Hobbies');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'blogTypeId', N'type') AND [object_id] = OBJECT_ID(N'[BlogTypes]'))
    SET IDENTITY_INSERT [BlogTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'type') AND [object_id] = OBJECT_ID(N'[ExpertQuestionTypes]'))
    SET IDENTITY_INSERT [ExpertQuestionTypes] ON;
INSERT INTO [ExpertQuestionTypes] ([id], [type])
VALUES (1, N'Health Corner'),
(2, N'Nutrition Corner');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'type') AND [object_id] = OBJECT_ID(N'[ExpertQuestionTypes]'))
    SET IDENTITY_INSERT [ExpertQuestionTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TypeId', N'Type') AND [object_id] = OBJECT_ID(N'[TalkTypes]'))
    SET IDENTITY_INSERT [TalkTypes] ON;
INSERT INTO [TalkTypes] ([TypeId], [Type])
VALUES (1, N'Parenting'),
(2, N'Career'),
(3, N'Babycare'),
(4, N'Food and Nutrition');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TypeId', N'Type') AND [object_id] = OBJECT_ID(N'[TalkTypes]'))
    SET IDENTITY_INSERT [TalkTypes] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200602191508_SeedData', N'3.1.4');

GO

ALTER TABLE [Experts] ADD [userId] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Experts] ADD [userProfileId] nvarchar(450) NULL;

GO

CREATE TABLE [UserProfile] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [firstName] nvarchar(max) NOT NULL,
    [lastName] nvarchar(max) NOT NULL,
    [IsExpert] bit NOT NULL,
    [IsAdmin] bit NOT NULL,
    [IsBanned] bit NOT NULL,
    CONSTRAINT [PK_UserProfile] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Experts_userProfileId] ON [Experts] ([userProfileId]);

GO

ALTER TABLE [Experts] ADD CONSTRAINT [FK_Experts_UserProfile_userProfileId] FOREIGN KEY ([userProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200605030239_ExpertUpdate', N'3.1.4');

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'userId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Blogs] ALTER COLUMN [userId] nvarchar(max) NULL;

GO

ALTER TABLE [Blogs] ADD [userProfileId] nvarchar(450) NULL;

GO

CREATE INDEX [IX_Blogs_userProfileId] ON [Blogs] ([userProfileId]);

GO

ALTER TABLE [Blogs] ADD CONSTRAINT [FK_Blogs_UserProfile_userProfileId] FOREIGN KEY ([userProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200609152814_BlogUserUpdate', N'3.1.4');

GO

ALTER TABLE [Blogs] DROP CONSTRAINT [FK_Blogs_UserProfile_userProfileId];

GO

DROP INDEX [IX_Blogs_userProfileId] ON [Blogs];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'userProfileId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Blogs] DROP COLUMN [userProfileId];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200609161042_BlogUserUpdate2', N'3.1.4');

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Talks]') AND [c].[name] = N'userId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Talks] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Talks] ALTER COLUMN [userId] nvarchar(max) NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TalkComments]') AND [c].[name] = N'userId');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [TalkComments] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [TalkComments] ALTER COLUMN [userId] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200609162738_coreUpdate', N'3.1.4');

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Talks]') AND [c].[name] = N'CreatedDate');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Talks] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Talks] ALTER COLUMN [CreatedDate] datetime2 NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200609182740_talkdateissue', N'3.1.4');

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Experts]') AND [c].[name] = N'imageURL');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Experts] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Experts] DROP COLUMN [imageURL];

GO

ALTER TABLE [UserProfile] ADD [userImg] varbinary(max) NULL;

GO

ALTER TABLE [Experts] ADD [image] varbinary(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200610003619_AddExpertImage', N'3.1.4');

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ExpertQuestions]') AND [c].[name] = N'userId');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ExpertQuestions] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [ExpertQuestions] ALTER COLUMN [userId] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200610025431_updateExpertQuestion', N'3.1.4');

GO

