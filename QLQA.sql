-- Tạo database QuanLyQuanAn
CREATE DATABASE QuanLyQuanAn;
USE QuanLyQuanAn;

-- Tạo bảng ThucDon
CREATE TABLE ThucDon (
    id INT PRIMARY KEY IDENTITY(1,1),
    tenMon VARCHAR(100) NOT NULL,
    giaMon DECIMAL(10, 2) NOT NULL,
    ghiChu TEXT,
    loaiMonAn VARCHAR(50)
);
DROP TABLE IF EXISTS DSBan;
-- Tạo bảng DSBan
CREATE TABLE DSBan (
    idBan INT PRIMARY KEY IDENTITY(1,1),
    tenBan NVARCHAR(100) NOT NULL,
    trangThai NVARCHAR(50) DEFAULT N'Trống'
);

-- Tạo bảng ChiTietGoiMon
CREATE TABLE ChiTietGoiMon (
    id INT PRIMARY KEY IDENTITY(1,1),
    tenMonDaChon VARCHAR(100) NOT NULL,
    soLuong INT NOT NULL,
    giaMon DECIMAL(10, 2) NOT NULL
);

-- Tạo bảng TaiKhoan
CREATE TABLE TaiKhoan (
    id INT PRIMARY KEY IDENTITY(1,1),
    tenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    tenHienThi VARCHAR(100),
    matKhau VARCHAR(255) NOT NULL,
    chucVu VARCHAR(50)
);

-- Thêm cột idMon vào ChiTietGoiMon và thiết lập khóa ngoại
ALTER TABLE ChiTietGoiMon
ADD idMon INT;

-- Xóa cột tenMonDaChon nếu không cần thiết
ALTER TABLE ChiTietGoiMon
DROP COLUMN tenMonDaChon;

-- Thêm khóa ngoại từ idMon của ChiTietGoiMon tham chiếu đến id của ThucDon
ALTER TABLE ChiTietGoiMon
ADD CONSTRAINT FK_ChiTietGoiMon_ThucDon
FOREIGN KEY (idMon) REFERENCES ThucDon(id);

INSERT INTO TaiKhoan (tenDangNhap, tenHienThi, matKhau, chucVu)
VALUES ('admin', 'Admin', '123456', 'Quản lý');


USE QuanLyQuanAn;

-- Thêm các món vào bảng ThucDon với các loại món ăn tương ứng
INSERT INTO ThucDon (tenMon, giaMon, ghiChu, loaiMonAn)
VALUES 
-- Đồ ăn
('Phở Bò', 45000, 'Món ăn truyền thống Việt Nam', 'Đồ ăn'),
('Bún Chả', 50000, 'Bún chả Hà Nội', 'Đồ ăn'),
('Nem Rán', 35000, 'Nem rán giòn', 'Đồ ăn'),
('Súp Cua', 25000, 'Súp cua bổ dưỡng', 'Đồ ăn'),

-- Đồ uống
('Cà Phê Sữa', 20000, 'Cà phê pha sữa đá', 'Đồ uống'),
('Trà Chanh', 15000, 'Trà chanh mát lạnh', 'Đồ uống'),
('Soda Chanh', 18000, 'Soda pha với chanh', 'Đồ uống'),

-- Ăn vặt - tráng miệng
('Bánh Mì', 25000, 'Bánh mì thịt nướng', 'Ăn vặt - tráng miệng'),
('Chè Thái', 30000, 'Chè thái lan với thạch', 'Ăn vặt - tráng miệng'),
('Gỏi Cuốn', 30000, 'Gỏi cuốn tôm thịt', 'Ăn vặt - tráng miệng');


DELETE FROM ChiTietGoiMon;
INSERT INTO ThucDon (tenMon, giaMon, ghiChu, loaiMonAn)
VALUES 
(N'Phở Bò', 45000, N'Món ăn truyền thống Việt Nam', N'Đồ ăn'),
(N'Bún Chả', 50000, N'Bún chả Hà Nội', N'Đồ ăn'),
(N'Nem Rán', 35000, N'Nem rán giòn', N'Đồ ăn'),
(N'Súp Cua', 25000, N'Súp cua bổ dưỡng', N'Đồ ăn'),
(N'Cà Phê Sữa', 20000, N'Cà phê pha sữa đá', N'Đồ uống'),
(N'Trá Chanh', 15000, N'Trá chanh mát lạnh', N'Đồ uống'),
(N'Soda Chanh', 18000, N'Soda pha với chanh', N'Đồ uống'),
(N'Bánh Mì', 25000, N'Bánh mì thịt nướng', N'Ăn vặt - tráng miệng'),
(N'Chè Thái', 30000, N'Chè thái lan vị thơm ngọt', N'Ăn vặt - tráng miệng'),
(N'Gỏi Cuốn', 30000, N'Gỏi cuốn tôm thịt', N'Ăn vặt - tráng miệng');

DELETE FROM DSBan;
INSERT INTO DSBan (tenBan, trangThai) VALUES 
(N'Bàn 1', N'Đã đặt'),
(N'Bàn 2', N'Trống'),
(N'Bàn 3', N'Đang dùng'),
(N'Bàn 4', N'Trống'),
(N'Bàn 5', N'Đã đặt'),
(N'Bàn 6', N'Đang dùng'),
(N'Bàn 7', N'Trống'),
(N'Bàn 8', N'Đã đặt'),
(N'Bàn 9', N'Đang dùng'),
(N'Bàn 10', N'Trống');

ALTER TABLE ChiTietGoiMon
ALTER COLUMN tenMonDaChon NVARCHAR(100);

ALTER TABLE ChiTietGoiMon
ADD idBan INT;

ALTER TABLE TaiKhoan
ALTER COLUMN tenHienThi NVARCHAR(50);

UPDATE TaiKhoan
SET chucVu = N'Quản lý'
WHERE tenDangNhap = 'admin';

