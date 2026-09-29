-- Khởi tạo Database
CREATE DATABASE ProductDB;
GO

USE ProductDB;
GO

-- Tạo Table Product (Yêu cầu 3)
CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);
GO

-- Thêm dữ liệu mẫu vào table
INSERT INTO Product (Name, Price) VALUES
(N'Laptop Dell XPS 15', 35000000),
(N'Bàn phím cơ Keychron', 2500000),
(N'Chuột Logitech G Pro', 1800000),
(N'Màn hình LG 27 inch 4K', 8500000),
(N'Tai nghe Sony WH-1000XM5', 7200000);
GO
