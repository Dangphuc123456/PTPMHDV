﻿--use master
--drop database if exists BTL_API
create database BTL_API
go
use  BTL_API
go

CREATE TABLE TaiKhoans(
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[LoaiTaiKhoan] [int] NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Email] [nvarchar](150) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

create table NhanVien
(
	MaNhanVien nvarchar(10) primary key not null,
	TenNhanVien nvarchar(50) not null,
	GioiTinh nvarchar(10) not null,
	DiaChi nvarchar(50) not null,
	DienThoai nvarchar(15) not null,
	NgaySinh Datetime not null
)


create table Monan
(
	Mamonan nvarchar(50) primary key not null,
	Tenmonan nvarchar(50) not null,
	Loaimonan Nvarchar (30) not null,
	Gia float (53) not null
)

create table Banan(
    Maban Nvarchar(10) primary key,
    Tinhtrang nvarchar(20)
)

create table Khach
(
	MaKhach nvarchar(10) primary key not null,
	TenKhach nvarchar(50) not null,
	DiaChi nvarchar(50) not null,
	DienThoai nvarchar(50) not null
)
go


create table Nguyenlieu
(
	MaNguyenlieu nvarchar(50) primary key not null,
	TenNguyenlieu nvarchar(50) not null,
	SoLuong float(53) not null,
	DonGiaNhap float(53) not null,
	GhiChu nvarchar(30) null,
)
	--Nhà cung cấp

create table NhaCC
(
	NhaCCID nvarchar(10) primary key not null,
	TenNCC nvarchar(30) not null,
	DiachiNCC nvarchar(50) NOT NULL,
	SdtNCC nvarchar(50)	
)

create table HDNhap
(
    MaHDNhap nvarchar(30) primary key not null,
	MaNhanVien nvarchar(10) not null,foreign key(MaNhanVien) references NhanVien(MaNhanVien),
	NhaCCID nvarchar(10)Not null,foreign key(NhaCCID) references NhaCC(NhaCCID),
	NgayNhap Datetime not null,
	TongTien float(53) not null
)

create table ChiTietHDNhap
(
    MaCTNhap nvarchar(50)primary key not null,
	MaHDNhap nvarchar(30) not null,foreign key(MaHDNhap) references HDNhap(MaHDNhap),
	MaNguyenlieu nvarchar(50) not null,foreign key(MaNguyenlieu) references Nguyenlieu(MaNguyenlieu),
	SoLuong int not null,
	Dongia float(53) not null,
	ThanhTien float(53) not null,
)

create table HDBan
(
	MaHDBan nvarchar(30) primary key not null,
	MaNhanVien nvarchar(10) not null,foreign key(MaNhanVien) references NhanVien(MaNhanVien),
	NgayBan Datetime not null,
	Maban nvarchar(10) not null,foreign key(Maban) references Banan(Maban),
	MaKhach nvarchar(10) not null,foreign key(MaKhach) references Khach(MaKhach),
	TongTien float(53) not null
)

create table ChiTietHDBan
(
    MaCTBan nvarchar(30) primary key not null, 
	MaHDBan nvarchar(30) not null,foreign key(MaHDBan) references HDBan(MaHDBan),
	Mamonan nvarchar(50)  not null,foreign key(Mamonan) references Monan(Mamonan),
	SoLuong int not null,
	GiamGia float(53) not null ,
	ThanhTien float(53) not null 	
)



-- Tạo dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai, NgaySinh)
VALUES
    ('NV001', 'Nguyen Van A', 'Nam', 'Hanoi', '0123456789', '1990-01-01'),
    ('NV002', 'Tran Thi B', 'Nữ', 'Ho Chi Minh City', '0987654321', '1995-05-10'),
    ('NV003', 'Pham Van C', 'Nam', 'Da Nang', '0369876543', '1992-09-15'),
    ('NV004', 'Hoang Thi D', 'Nữ', 'Hai Phong', '0909090909', '1988-07-20'),
    ('NV005', 'Le Van E', 'Nam', 'Can Tho', '0777777777', '1998-03-25');

-- Tạo dữ liệu cho bảng Monan
INSERT INTO Monan (Mamonan, Tenmonan, Loaimonan, Gia)
VALUES
    ('MA001', 'Pho Bo', 'Món phở', 50000),
    ('MA002', 'Bun Cha', 'Món bún', 45000),
    ('MA003', 'Com Tam', 'Món cơm', 40000),
    ('MA004', 'Banh Xeo', 'Món bánh', 35000),
    ('MA005', 'Ca Kho', 'Món cá', 60000);

-- Tạo dữ liệu cho bảng Banan
INSERT INTO Banan (Maban, Tinhtrang)
VALUES
    ('B01', N'Trống'),
    ('B02', N'Đã đặt'),
    ('B03', N'Đang sử dụng'),
    ('B04', N'Đã thanh toán'),
    ('B05', N'Trống'),
	('B06', N'Trống'),
    ('B07', N'Trống'),
    ('B08', N'Trống'),
    ('B09', N'Trống'),
    ('B10', N'Trống');

-- Tạo dữ liệu cho bảng Khach
INSERT INTO Khach (MaKhach, TenKhach, DiaChi, DienThoai)
VALUES
    ('KH001', 'Nguyen Thi F', 'Hanoi', '0123456789'),
    ('KH002', 'Tran Van G', 'Ho Chi Minh City', '0987654321'),
    ('KH003', 'Pham Thi H', 'Da Nang', '0369876543'),
    ('KH004', 'Hoang Van I', 'Hai Phong', '0909090909'),
    ('KH005', 'Le Thi J', 'Can Tho', '0777777777');

-- Tạo dữ liệu cho bảng Nguyenlieu
INSERT INTO Nguyenlieu (MaNguyenlieu, TenNguyenlieu, SoLuong, DonGiaNhap, GhiChu)
VALUES
    ('NL001', 'Gạo', 100, 20000, 'Nguyên liệu chính'),
    ('NL002', 'Thịt heo', 50, 50000, 'Nguyên liệu chính'),
    ('NL003', 'Cá', 30, 40000, 'Nguyên liệu chính'),
    ('NL004', 'Rau cải', 80, 10000, 'Nguyên liệu phụ'),
    ('NL005', 'Đường', 200, 15000, 'Nguyên liệu chính');

-- Tạo dữ liệu cho bảng NhaCC
INSERT INTO NhaCC (NhaCCID, TenNCC, DiachiNCC, SdtNCC)
VALUES
    ('NCC001', 'Nhà cung cấp A', 'Hanoi', '0123456789'),
    ('NCC002', 'Nhà cung cấp B', 'Ho Chi Minh City', '0987654321'),
    ('NCC003', 'Nhà cung cấp C', 'Da Nang', '0369876543'),
    ('NCC004', 'Nhà cung cấp D', 'Hai Phong', '0909090909'),
    ('NCC005', 'Nhà cung cấp E', 'Can Tho', '0777777777');

-- Tạo dữ liệu cho bảng HDNhap
INSERT INTO HDNhap (MaHDNhap, MaNhanVien, NhaCCID, NgayNhap, TongTien)
VALUES
    ('HDN001', 'NV001', 'NCC001', '2023-06-01', 1500000),
    ('HDN002', 'NV002', 'NCC002', '2023-06-02', 2000000),
    ('HDN003', 'NV003', 'NCC003', '2023-06-03', 1800000),
    ('HDN004', 'NV004', 'NCC004', '2023-06-04', 2200000),
    ('HDN005', 'NV005', 'NCC005', '2023-06-05', 1900000);

-- Tạo dữ liệu cho bảng ChiTietHDNhap
INSERT INTO ChiTietHDNhap (MaCTNhap, MaHDNhap, MaNguyenlieu, SoLuong, Dongia, ThanhTien)
VALUES
    ('CTN001', 'HDN001', 'NL001', 10, 15000, 150000),
    ('CTN002', 'HDN001', 'NL002', 5, 25000, 125000),
    ('CTN003', 'HDN002', 'NL003', 8, 30000, 240000),
    ('CTN004', 'HDN003', 'NL004', 6, 8000, 48000),
    ('CTN005', 'HDN004', 'NL005', 12, 10000, 120000);

-- Tạo dữ liệu cho bảng HDBan
INSERT INTO HDBan (MaHDBan, MaNhanVien, NgayBan, Maban, MaKhach, TongTien)
VALUES
    ('HDB001', 'NV001', '2023-06-01', 'B01', 'KH001', 500000),
    ('HDB002', 'NV002', '2023-06-02', 'B02', 'KH002', 700000),
    ('HDB003', 'NV003', '2023-06-03', 'B03', 'KH003', 550000),
    ('HDB004', 'NV004', '2023-06-04', 'B04', 'KH004', 800000),
    ('HDB005', 'NV005', '2023-06-05', 'B05', 'KH005', 650000);

-- Tạo dữ liệu cho bảng ChiTietHDBan
INSERT INTO ChiTietHDBan (MaCTBan, MaHDBan, Mamonan, SoLuong, GiamGia, ThanhTien)
VALUES
    ('CTB001', 'HDB001', 'MA001', 2, 10000, 90000),
    ('CTB002', 'HDB001', 'MA002', 3, 15000, 120000),
    ('CTB003', 'HDB002', 'MA003', 4, 20000, 180000),
    ('CTB004', 'HDB003', 'MA004', 1, 5000, 30000),
    ('CTB005', 'HDB004', 'MA005', 2, 10000, 110000);
-- Chèn dữ liệu mẫu vào bảng TaiKhoans
INSERT INTO TaiKhoans (LoaiTaiKhoan, TenTaiKhoan, MatKhau, Email)
VALUES
    (1, 'User1', 'password123', 'user1@example.com'),
    (2, 'User2', 'password456', 'user2@example.com'),
    (1, 'User3', 'password789', 'user3@example.com');

	select * from TaiKhoans
	select * from NhanVien
	select * from Khach
	select * from Nguyenlieu
	Select * from Monan
	Select * from Banan
	Select * from HDNhap
	Select * from ChiTietHDNhap
	Select * from HDBan
	Select * from ChiTietHDBan
go

--login
CREATE PROCEDURE [dbo].[sp_login]
    @taikhoan char(50),
	@matkhau char(50)
as
begin
	select * from dbo.TaiKhoans
	where TenTaiKhoan = @taikhoan
	and MatKhau =  @matkhau
END;
go
--nhân viên
CREATE PROCEDURE sp_nha_vien_get_by_id
    @MaNhanVien nvarchar(10)
AS
BEGIN
    SELECT *
    FROM NhanVien
    WHERE MaNhanVien = @MaNhanVien;
END;
--dấu kết thúc của một khối
go--kết thúc một tệp lệnh 

CREATE PROCEDURE sp_nhanvien_create
    @MaNhanVien nvarchar(10),
    @TenNhanVien nvarchar(50),
    @GioiTinh nvarchar(10),
    @DiaChi nvarchar(50),
    @DienThoai nvarchar(15),
    @NgaySinh Datetime
AS
BEGIN
    INSERT INTO NhanVien (MaNhanVien, TenNhanVien, GioiTinh, DiaChi, DienThoai, NgaySinh)
    VALUES (@MaNhanVien, @TenNhanVien, @GioiTinh, @DiaChi, @DienThoai, @NgaySinh);
END;
go

CREATE PROCEDURE sp_nhanvien_update
    @MaNhanVien nvarchar(10),
    @TenNhanVien nvarchar(50),
    @GioiTinh nvarchar(10),
    @DiaChi nvarchar(50),
    @DienThoai nvarchar(15),
    @NgaySinh Datetime
AS
BEGIN
    UPDATE NhanVien
    SET TenNhanVien = @TenNhanVien,
        GioiTinh = @GioiTinh,
        DiaChi = @DiaChi,
        DienThoai = @DienThoai,
        NgaySinh = @NgaySinh
    WHERE MaNhanVien = @MaNhanVien;
END;
go

CREATE PROCEDURE sp_nhanvien_search
    @TenNhanVien nvarchar(50)
AS
BEGIN
    SELECT *
    FROM NhanVien
    WHERE TenNhanVien LIKE '%' + @TenNhanVien + '%';
END;
go
---nhà cung cấp
CREATE PROCEDURE sp_nhacc_get_by_id
    @NhaCCID nvarchar(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT NhaCCID, TenNCC, DiachiNCC, SdtNCC
    FROM NhaCC
    WHERE NhaCCID = @NhaCCID;
END;
go


CREATE PROCEDURE sp_nhacc_create
    @NhaCCID nvarchar(10),
    @TenNCC nvarchar(30),
    @DiachiNCC nvarchar(50),
    @SdtNCC nvarchar(50)
AS
BEGIN
    INSERT INTO NhaCC (NhaCCID, TenNCC, DiachiNCC, SdtNCC)
    VALUES (@NhaCCID, @TenNCC, @DiachiNCC, @SdtNCC);
END;
go

CREATE PROCEDURE sp_nhacc_update
    @NhaCCID nvarchar(10),
    @TenNCC nvarchar(30),
    @DiachiNCC nvarchar(50),
    @SdtNCC nvarchar(50)
AS
BEGIN
    UPDATE NhaCC
    SET TenNCC = @TenNCC,
        DiachiNCC = @DiachiNCC,
        SdtNCC = @SdtNCC
    WHERE NhaCCID = @NhaCCID;
END;
go

CREATE PROCEDURE sp_nhacc_search
    @NhaCCID nvarchar(10) = NULL,
    @TenNCC nvarchar(30) = NULL
AS
BEGIN
    SELECT *
    FROM NhaCC
    WHERE (@NhaCCID IS NULL OR NhaCCID = @NhaCCID)
    AND (@TenNCC IS NULL OR TenNCC LIKE '%' + @TenNCC + '%');
END;
go
--Khách hàng
CREATE PROCEDURE sp_khach_get_by_id
    @MaKhach nvarchar(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT MaKhach, TenKhach, DiaChi, DienThoai
    FROM Khach
    WHERE MaKhach = @MaKhach;
END;--dấu kết thúc của một khối
go--kết thúc một tệp lệnh 

CREATE PROCEDURE sp_khach_create
    @MaKhach nvarchar(10),
    @TenKhach nvarchar(50),
    @DiaChi nvarchar(50),
    @DienThoai nvarchar(50)
AS
BEGIN
    INSERT INTO Khach (MaKhach, TenKhach, DiaChi, DienThoai)
    VALUES (@MaKhach, @TenKhach, @DiaChi, @DienThoai);
END;
go

CREATE PROCEDURE sp_khach_update
    @MaKhach nvarchar(10),
    @TenKhach nvarchar(50),
    @DiaChi nvarchar(50),
    @DienThoai nvarchar(50)
AS
BEGIN
    UPDATE Khach
    SET TenKhach = @TenKhach, DiaChi = @DiaChi, DienThoai = @DienThoai
    WHERE MaKhach = @MaKhach;
END;
go

CREATE PROCEDURE sp_khach_search
    @MaKhach nvarchar(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT MaKhach, TenKhach, DiaChi, DienThoai
    FROM Khach
    WHERE MaKhach = @MaKhach;
END;
go
--DROP PROCEDURE sp_hoadonnhap_get_by_id;
--hóa đơn nhập
CREATE PROCEDURE sp_hoadonnhap_get_by_id
    @MaHDNhap NVARCHAR(30)
AS
    BEGIN
        SELECT h.*, 
        (
            SELECT c.*
            FROM ChiTietHDNhap AS c
            WHERE h.MaHDNhap = c.MaHDNhap FOR JSON PATH
        ) AS list_json_chitiethoadonnhap
        FROM HDNhap AS h
        WHERE  h.MaHDNhap = @MaHDNhap;
    END;
	GO

--DROP PROCEDURE sp_hoadonnhap_create;
create PROCEDURE sp_hoadonnhap_create
(@MaHDNhap nvarchar(50),
@MaNhanVien nvarchar(50),
@NgayNhap Datetime,
@Maban nvarchar(50),
@NhaCCID nvarchar(50),
@Tongtien float,
@list_json_chitiethoadon nvarchar(max)
)
AS
    BEGIN
		DECLARE @MaHoaDon nvarchar;
        INSERT INTO HDNhap
                (MaHDNhap,
				 MaNhanVien,
				 NgayNhap,
				 NhaCCID,
				 TongTien
                )
                VALUES
                (
				@MaHDNhap,
				@MaNhanVien ,
				@NgayNhap ,
				@NhaCCID ,
				@Tongtien
                );

				SET @MaHoaDon = (SELECT SCOPE_IDENTITY());
                IF(@list_json_chitiethoadon IS NOT NULL)
                    BEGIN
                        INSERT INTO ChiTietHDBan
						 (MaCTNhap,
						 MaHDNhap,
						 Mamonan,
						 SoLuong,
						 GiamGia,
						 ThanhTien
                        )
                    SELECT JSON_VALUE(p.value, '$.maCTNhap'), 
                            @MaHoaDon, 
                            JSON_VALUE(p.value, '$.maMonan'), 
                            JSON_VALUE(p.value, '$.soLuong'), 
							JSON_VALUE(p.value, '$.giamGia'),
							JSON_VALUE(p.value, '$.thanhTien')
                    FROM OPENJSON(@list_json_chitiethoadon) AS p;
                END;
        SELECT '';
    END;









