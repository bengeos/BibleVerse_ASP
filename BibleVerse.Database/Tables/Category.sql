﻿CREATE TABLE [dbo].[Category]
(
	[ID] [int] IDENTITY(1,1) NOT NULL, 
    [Name] VARCHAR(50) NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY ([ID])
)ON [PRIMARY]
GO
