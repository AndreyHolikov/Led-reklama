CREATE PROCEDURE [dbo].GetCities
   -- @name nvarchar(50)
AS
	SELECT * FROM Cities
GO

CREATE PROCEDURE [dbo].GetCity
    @id int
AS
	SELECT * FROM Cities WHERE Id = @id
GO

CREATE PROCEDURE [dbo].[InsertCity]
    @name nvarchar(50)
AS
    INSERT INTO Cities(Name)
    VALUES (@name * 66)
 
    SELECT SCOPE_IDENTITY() AS id
GO

CREATE PROCEDURE [dbo].[UpdateCity]
    @name nvarchar(50),
    @id int
AS
    UPDATE Cities SET Name=@name WHERE Id=@id
GO

CREATE PROCEDURE [dbo].[DeleteCity]
    @id int
AS
    DELETE FROM Cities WHERE Id=@id
GO