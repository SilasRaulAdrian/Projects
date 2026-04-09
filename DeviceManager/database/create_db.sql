USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DeviceManager')
BEGIN
    CREATE DATABASE DeviceManager;
    PRINT 'Database DeviceManager created.';
END
ELSE
BEGIN
    PRINT 'Database DeviceManager already exists.';
END
GO

USE DeviceManager;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
BEGIN
    CREATE TABLE Users (
        Id           INT IDENTITY(1,1) PRIMARY KEY,
        Name         NVARCHAR(100)  NOT NULL,
        Email        NVARCHAR(150)  NOT NULL UNIQUE,
        PasswordHash NVARCHAR(255)  NOT NULL,
        Role         NVARCHAR(50)   NOT NULL DEFAULT 'Employee',
        Location     NVARCHAR(100)  NOT NULL,
        CreatedAt    DATETIME       NOT NULL DEFAULT GETDATE()
    );
    PRINT 'Table Users created.';
END
ELSE
BEGIN
    PRINT 'Table Users already exists.';
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Devices' AND xtype='U')
BEGIN
    CREATE TABLE Devices (
        Id               INT IDENTITY(1,1) PRIMARY KEY,
        Name             NVARCHAR(100)  NOT NULL,
        Manufacturer     NVARCHAR(100)  NOT NULL,
        Type             NVARCHAR(20)   NOT NULL CHECK (Type IN ('phone', 'tablet')),
        OperatingSystem  NVARCHAR(50)   NOT NULL,
        OsVersion        NVARCHAR(50)   NOT NULL,
        Processor        NVARCHAR(100)  NOT NULL,
        RamAmount        NVARCHAR(20)   NOT NULL,
        Description      NVARCHAR(500)  NULL,
        AssignedToUserId INT            NULL,
        CreatedAt        DATETIME       NOT NULL DEFAULT GETDATE(),
        UpdatedAt        DATETIME       NOT NULL DEFAULT GETDATE(),
        FOREIGN KEY (AssignedToUserId) REFERENCES Users(Id) ON DELETE SET NULL
    );
    PRINT 'Table Devices created.';
END
ELSE
BEGIN
    PRINT 'Table Devices already exists.';
END
GO