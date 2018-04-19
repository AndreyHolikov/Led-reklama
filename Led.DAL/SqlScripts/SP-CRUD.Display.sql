CREATE PROCEDURE [dbo].GetDisplays
   -- @name nvarchar(50)
AS
	SELECT * FROM Displays
GO

CREATE PROCEDURE [dbo].GetDisplay
    @id int
AS
	SELECT * FROM Displays WHERE Id = @id
GO
