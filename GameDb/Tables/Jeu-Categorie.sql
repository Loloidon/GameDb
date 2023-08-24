CREATE TABLE [dbo].[Jeu-Categorie]
(
    [Categorie_ID] INT PRIMARY KEY NOT NULL, 
    [Jeu_ID] INT IDENTITY , 
    CONSTRAINT [FK_Jeu-Categorie_Jeu] FOREIGN KEY ([Jeu_ID]) REFERENCES [Jeu]([Id]), 
    CONSTRAINT [FK_Jeu-Categorie_Categorie] FOREIGN KEY ([Categorie_ID]) REFERENCES [Categorie]([Id]), 
     
    
)
