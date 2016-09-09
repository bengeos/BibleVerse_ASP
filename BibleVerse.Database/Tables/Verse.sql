CREATE TABLE [dbo].[Verse]
(
	[ID] [int] IDENTITY(1,1) NOT NULL, 
    [CategoryID] INT NOT NULL, 
    [Body] TEXT NOT NULL, 
    [Verse] TEXT NOT NULL,
	CONSTRAINT [PK_Verse] PRIMARY KEY ([ID]),
	CONSTRAINT [FK_Verse_Category] FOREIGN KEY([CategoryID]) REFERENCES [dbo].[Category] ([ID])
)ON [PRIMARY]
GO
