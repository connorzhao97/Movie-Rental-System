CREATE TABLE [dbo].[BringAndReturn] (
    [BR_Id]  INT        IDENTITY (1, 1) NOT NULL,
    [U_Id]   NCHAR (10) NOT NULL,
    [M_Id]   NCHAR (10) NOT NULL,
    [B_Date] DATE       NOT NULL,
    [R_Date] DATE       NOT NULL,
    [B_Rent] FLOAT NOT NULL DEFAULT 0.0, 
    PRIMARY KEY CLUSTERED ([BR_Id] ASC)
);

