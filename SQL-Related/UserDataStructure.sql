-- Populate UserData table with fake data 20000 lines repeated using a for loop (T-SQL)

DECLARE @count INT;
SET @count = 1;
    
WHILE @count<= 20000
BEGIN
   INSERT INTO UserData -- Refer to UserData.bak for more diverse data
   VALUES ('Dina', 'Chess', 'dchess0@xinhuanet.com', 'Female', 'Azerbaijan', 'VP Product Management');
   SET @count = @count + 1;
END;

-- In case you want to reseed the identity field
DBCC CHECKIDENT('UserData', RESEED, 1);