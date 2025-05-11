
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2025 13:42:54
-- Generated from EDMX file: C:\Users\TechnoRoom\source\repos\EntityFramework\ModelFirst\ModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'books'
CREATE TABLE [dbo].[books] (
    [book_id] int IDENTITY(1,1) NOT NULL,
    [book_name] nvarchar(max)  NOT NULL,
    [pages_count] int  NOT NULL,
    [author_author_id] int  NOT NULL,
    [language_language_id] int  NOT NULL
);
GO

-- Creating table 'authors'
CREATE TABLE [dbo].[authors] (
    [author_id] int IDENTITY(1,1) NOT NULL,
    [author_name] nvarchar(max)  NOT NULL,
    [author_surname] nvarchar(max)  NOT NULL,
    [age] int  NOT NULL
);
GO

-- Creating table 'languages'
CREATE TABLE [dbo].[languages] (
    [language_id] int IDENTITY(1,1) NOT NULL,
    [language_name] nvarchar(max)  NOT NULL,
    [country_countries_id] int  NOT NULL
);
GO

-- Creating table 'countries'
CREATE TABLE [dbo].[countries] (
    [countries_id] int IDENTITY(1,1) NOT NULL,
    [country_name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [book_id] in table 'books'
ALTER TABLE [dbo].[books]
ADD CONSTRAINT [PK_books]
    PRIMARY KEY CLUSTERED ([book_id] ASC);
GO

-- Creating primary key on [author_id] in table 'authors'
ALTER TABLE [dbo].[authors]
ADD CONSTRAINT [PK_authors]
    PRIMARY KEY CLUSTERED ([author_id] ASC);
GO

-- Creating primary key on [language_id] in table 'languages'
ALTER TABLE [dbo].[languages]
ADD CONSTRAINT [PK_languages]
    PRIMARY KEY CLUSTERED ([language_id] ASC);
GO

-- Creating primary key on [countries_id] in table 'countries'
ALTER TABLE [dbo].[countries]
ADD CONSTRAINT [PK_countries]
    PRIMARY KEY CLUSTERED ([countries_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [author_author_id] in table 'books'
ALTER TABLE [dbo].[books]
ADD CONSTRAINT [FK_authorbook]
    FOREIGN KEY ([author_author_id])
    REFERENCES [dbo].[authors]
        ([author_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_authorbook'
CREATE INDEX [IX_FK_authorbook]
ON [dbo].[books]
    ([author_author_id]);
GO

-- Creating foreign key on [language_language_id] in table 'books'
ALTER TABLE [dbo].[books]
ADD CONSTRAINT [FK_languagebook]
    FOREIGN KEY ([language_language_id])
    REFERENCES [dbo].[languages]
        ([language_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_languagebook'
CREATE INDEX [IX_FK_languagebook]
ON [dbo].[books]
    ([language_language_id]);
GO

-- Creating foreign key on [country_countries_id] in table 'languages'
ALTER TABLE [dbo].[languages]
ADD CONSTRAINT [FK_countrylanguage]
    FOREIGN KEY ([country_countries_id])
    REFERENCES [dbo].[countries]
        ([countries_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_countrylanguage'
CREATE INDEX [IX_FK_countrylanguage]
ON [dbo].[languages]
    ([country_countries_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------