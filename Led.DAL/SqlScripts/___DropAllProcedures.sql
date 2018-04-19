/* 
Удалить все хранимые процедуры сразу в базе данных SQL Server.
http://qaru.site/questions/126060/how-to-drop-all-stored-procedures-at-once-in-sql-server-database

https://docs.microsoft.com/ru-ru/previous-versions/sql/sql-server-2008/ms174969(v=sql.100)
*/

DECLARE @sql VARCHAR(MAX)
SET @sql=''
SELECT @sql=@sql+'drop procedure ['+name +'];' FROM sys.objects
WHERE type = 'p' AND  is_ms_shipped = 0
exec(@sql);

