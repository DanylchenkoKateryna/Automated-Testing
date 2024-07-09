--Create Database TestData;
use TestData;

Create table IsOperatorData
(
	Id int IDENTITY(1,1) NOT NULL, 
	Symbol varchar(255),
	Result bit
);

Create table ReplaceSymbolData
(
	Id int IDENTITY(1,1) NOT NULL, 
	Input varchar(255),
	Symbol varchar(2),
	Position int,
	Result varchar(255)
);

INSERT INTO ReplaceSymbolData (Input, Symbol, Position, Result)
values
	('93+(3*8)','-','2','93-(3*8)'),
	('22/12+65','*','2','22*12+65'),
	('6*9+7-4','*','77','6*9+7-4');

INSERT INTO IsOperatorData (Symbol,Result)
values
	('dtufeyfd','false'),
	('+','true');
