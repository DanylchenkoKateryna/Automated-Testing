CREATE DATABASE TestData;

USE TestData;

CREATE TABLE IsOperatorData (
    Symbol nvarchar(255),
    Result bit
);
CREATE TABLE ReplaceSymbolData (
    Input nvarchar(255),
	Symbol nvarchar(255),
	Position int,
    Result nvarchar(255)
);

INSERT INTO IsOperatorData (Symbol, Result)
VALUES 
('(','true'),
('+','true'),
('%','true'),
('p','true'),
('m','true'),
('sdfghjkl','false'),
('[','false');

INSERT INTO ReplaceSymbolData (Input, Symbol,Position,Result)
VALUES 
('(5+3)*5','-','2','(5-3)*5'),
('25-20+4*6','+','7','25-20+4+6'),
('25-20+4*6','+','77','25-20+4*6');

