USE DeviceManager;
GO

IF NOT EXISTS (SELECT 1
FROM Users
WHERE Email = 'admin@company.com')
BEGIN
    INSERT INTO Users
        (Name, Email, PasswordHash, Role, Location)
    VALUES
        ('Admin User', 'admin@company.com',
            '$2a$11$rADdZ6hUf3CjNQQXqRh8.uMGhwTvxlAaP2KqHuHJGvLbI5lJT1ovi',
            'Admin', 'HQ - Floor 1');
END

IF NOT EXISTS (SELECT 1
FROM Users
WHERE Email = 'john.doe@company.com')
BEGIN
    INSERT INTO Users
        (Name, Email, PasswordHash, Role, Location)
    VALUES
        ('John Doe', 'john.doe@company.com',
            '$2a$11$rADdZ6hUf3CjNQQXqRh8.uMGhwTvxlAaP2KqHuHJGvLbI5lJT1ovi',
            'Developer', 'HQ - Floor 2');
END

IF NOT EXISTS (SELECT 1
FROM Users
WHERE Email = 'jane.smith@company.com')
BEGIN
    INSERT INTO Users
        (Name, Email, PasswordHash, Role, Location)
    VALUES
        ('Jane Smith', 'jane.smith@company.com',
            '$2a$11$rADdZ6hUf3CjNQQXqRh8.uMGhwTvxlAaP2KqHuHJGvLbI5lJT1ovi',
            'QA Engineer', 'HQ - Floor 2');
END

IF NOT EXISTS (SELECT 1
FROM Users
WHERE Email = 'bob.wilson@company.com')
BEGIN
    INSERT INTO Users
        (Name, Email, PasswordHash, Role, Location)
    VALUES
        ('Bob Wilson', 'bob.wilson@company.com',
            '$2a$11$rADdZ6hUf3CjNQQXqRh8.uMGhwTvxlAaP2KqHuHJGvLbI5lJT1ovi',
            'Manager', 'Remote - London');
END
GO

IF NOT EXISTS (SELECT 1
FROM Devices
WHERE Name = 'iPhone 15 Pro')
BEGIN
    INSERT INTO Devices
        (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedToUserId)
    VALUES
        ('iPhone 15 Pro', 'Apple', 'phone', 'iOS', '17.4', 'A17 Pro', '8GB',
            'A high-performance Apple smartphone running iOS, ideal for daily business use.',
            (SELECT Id
            FROM Users
            WHERE Email = 'john.doe@company.com'));
END

IF NOT EXISTS (SELECT 1
FROM Devices
WHERE Name = 'Samsung Galaxy S24')
BEGIN
    INSERT INTO Devices
        (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedToUserId)
    VALUES
        ('Samsung Galaxy S24', 'Samsung', 'phone', 'Android', '14.0', 'Snapdragon 8 Gen 3', '12GB',
            'A flagship Android smartphone with a large display and long battery life.',
            (SELECT Id
            FROM Users
            WHERE Email = 'jane.smith@company.com'));
END

IF NOT EXISTS (SELECT 1
FROM Devices
WHERE Name = 'iPad Pro 12.9')
BEGIN
    INSERT INTO Devices
        (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedToUserId)
    VALUES
        ('iPad Pro 12.9', 'Apple', 'tablet', 'iPadOS', '17.4', 'M2', '16GB',
            'A powerful Apple tablet designed for professional productivity and creative work.',
            (SELECT Id
            FROM Users
            WHERE Email = 'bob.wilson@company.com'));
END

IF NOT EXISTS (SELECT 1
FROM Devices
WHERE Name = 'Google Pixel 8')
BEGIN
    INSERT INTO Devices
        (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedToUserId)
    VALUES
        ('Google Pixel 8', 'Google', 'phone', 'Android', '14.0', 'Google Tensor G3', '8GB',
            'A pure Android experience with advanced AI features and excellent camera capabilities.',
            NULL);
END

IF NOT EXISTS (SELECT 1
FROM Devices
WHERE Name = 'Samsung Galaxy Tab S9')
BEGIN
    INSERT INTO Devices
        (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedToUserId)
    VALUES
        ('Samsung Galaxy Tab S9', 'Samsung', 'tablet', 'Android', '14.0', 'Snapdragon 8 Gen 2', '12GB',
            'A versatile Android tablet with an AMOLED display and S Pen support.',
            NULL);
END

IF NOT EXISTS (SELECT 1
FROM Devices
WHERE Name = 'OnePlus 12')
BEGIN
    INSERT INTO Devices
        (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedToUserId)
    VALUES
        ('OnePlus 12', 'OnePlus', 'phone', 'Android', '14.0', 'Snapdragon 8 Gen 3', '16GB',
            'A fast-charging flagship Android device with premium performance at a competitive price.',
            NULL);
END
GO

PRINT 'Seed data inserted successfully.';
GO