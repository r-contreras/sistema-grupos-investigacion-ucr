CREATE TABLE [dbo].[PublicationPartOfTesis]
(
	[PublicationId] VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Publication(Id)On Delete Cascade, 
    [ThesisId] INT NOT NULL FOREIGN KEY REFERENCES Thesis(Id)On Delete Cascade,
	PRIMARY KEY ([PublicationId],[ThesisId])
)
