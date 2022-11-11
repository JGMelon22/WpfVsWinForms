-- Create Mock DB 

CREATE DATABASE FakeData;
GO

USE FakeData;
GO

-- Create Mock Table
CREATE TABLE UserData 
(
    Id INT IDENTITY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Gender VARCHAR(20) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    JobTitle NVARCHAR(100) NOT NULL
);

-- Create Index
CREATE INDEX idx_id
    ON UserData (Id); 