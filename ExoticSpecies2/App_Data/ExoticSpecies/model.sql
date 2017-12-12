CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL
);

GO
CREATE TABLE [dbo].[Homelands] (
    [HomelandId]   INT            IDENTITY (1, 1) NOT NULL,
    [HomelandName] NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[Species] (
    [SpeciesId]      INT            IDENTITY (1, 1) NOT NULL,
    [SpeciesName]    NVARCHAR (MAX) NULL,
    [DateIntroduced] DATETIME       NOT NULL,
    [HomelandId]     INT            NOT NULL
);

GO
ALTER TABLE [dbo].[Species]
    ADD CONSTRAINT [FK_dbo.Species_dbo.Homelands_HomelandId] FOREIGN KEY ([HomelandId]) REFERENCES [dbo].[Homelands] ([HomelandId]) ON DELETE CASCADE;

GO
ALTER TABLE [dbo].[__MigrationHistory]
    ADD CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC);

GO
ALTER TABLE [dbo].[Homelands]
    ADD CONSTRAINT [PK_dbo.Homelands] PRIMARY KEY CLUSTERED ([HomelandId] ASC);

GO
ALTER TABLE [dbo].[Species]
    ADD CONSTRAINT [PK_dbo.Species] PRIMARY KEY CLUSTERED ([SpeciesId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_HomelandId]
    ON [dbo].[Species]([HomelandId] ASC);

GO
