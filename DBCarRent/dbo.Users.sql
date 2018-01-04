CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  NVARCHAR (50) NULL,
    [Password]  NVARCHAR (50) NULL,
    [FullName] NVARCHAR (50) NULL,
    [Email]     NVARCHAR (50) NULL,
    [Sex]       NCHAR (10)    NULL,
    [Passport]  NCHAR (10)    NULL,
    [IsAdmin] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

