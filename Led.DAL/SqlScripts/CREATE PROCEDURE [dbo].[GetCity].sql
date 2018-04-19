--DROP PROCEDURE [dbo].[GetCity];

--Go

CREATE PROCEDURE [dbo].[GetCity]
	@id int = 1
	-- @name str
AS
	SELECT * FROM City
RETURN 0