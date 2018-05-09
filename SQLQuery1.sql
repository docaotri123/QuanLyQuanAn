/*
	1-Admin
	0-Nhan Vien
*/
INSERT INTO dbo.Account
(
    userName,
    passWordUser,
    style
)
VALUES
(   'trido113',  -- userName - varchar(50)
    '123456',  -- passWordUser - varchar(50)
    1 -- style - bit
)

INSERT INTO dbo.Account
(
    userName,
    passWordUser,
    style
)
VALUES
(   'trido123',  -- userName - varchar(50)
    '123456',  -- passWordUser - varchar(50)
    2 -- style - bit
)

--Insert foodTable

DECLARE @i INT=0
WHILE @i<=8
BEGIN
	Insert INTO dbo.TableFood VALUES
	(
		N'Bàn'+CAST(@i AS varchar(10)),
		N'Trống'
	)
	SET @i=@i+1
END



SELECT *FROM dbo.TableFood