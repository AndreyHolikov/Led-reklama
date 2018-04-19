CREATE PROCEDURE [dbo].[DropAllProcedure]
	@sql nvarchar(250) = ''
AS
	SELECT @sql=@sql+'drop procedure ['+name +'];' FROM sys.objects
	WHERE type = 'p' AND  is_ms_shipped = 0
	exec(@sql);
RETURN 0