
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2020 20:16:16
-- Generated from EDMX file: C:\Users\Anuarito\source\repos\ADO.NET\AdoExamVacancies\AdoExamVacancies\VacancyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdoExamVacancies];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Vacancies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vacancies];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Vacancies'
CREATE TABLE [dbo].[Vacancies] (
    [VacancyId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Link] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PubDate] datetime  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [CategoryId] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [VacancyId] in table 'Vacancies'
ALTER TABLE [dbo].[Vacancies]
ADD CONSTRAINT [PK_Vacancies]
    PRIMARY KEY CLUSTERED ([VacancyId] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'Vacancies'
ALTER TABLE [dbo].[Vacancies]
ADD CONSTRAINT [FK_VacancyCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VacancyCategory'
CREATE INDEX [IX_FK_VacancyCategory]
ON [dbo].[Vacancies]
    ([CategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------