CREATE DATABASE QLCHBS
GO

-------------------------------------- Tạo bảng --------------------------------------

USE QLCHBS
GO

-- Bảng Thể loại
CREATE TABLE TheLoai 
(
	MaTheLoai NVARCHAR(10) PRIMARY KEY,
	TenTheLoai NVARCHAR(100) NOT NULL,
	MoTa NVARCHAR(255) NOT NULL
)
GO

-- Bảng Nhà cung cấp
CREATE TABLE NhaCungCap 
(
	MaNCC NVARCHAR(10) PRIMARY KEY,
	TenNCC NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL,
	SoDienThoai NVARCHAR(20) NOT NULL
)
GO

-- Bảng Sách
CREATE TABLE Sach 
(
	MaSach NVARCHAR(10) PRIMARY KEY,
	TenSach NVARCHAR(100) NOT NULL,
	TacGia NVARCHAR(100) NOT NULL,
	NXB NVARCHAR(100) NOT NULL,
	MaTheLoai NVARCHAR(10),
	MaNCC NVARCHAR(10),
	SoLuongTrenKe INT check (SoLuongTrenKe <= 50),
	DonGia DECIMAL(18,2) NOT NULL,
	CONSTRAINT FK_TheLoai_Sach FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai),
	CONSTRAINT FK_NCC_Sach FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
)
GO

-- Bảng Kho sách
CREATE TABLE KhoSach 
(
	MaSach NVARCHAR(10),
	SoLuong INT,
	CONSTRAINT FK_Sach_KhoSach FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
)
GO

-- Bảng Vị trí 
CREATE TABLE ViTriSach 
(
	MaViTri NVARCHAR(10) PRIMARY KEY,
	MaSach NVARCHAR(10),
	Ke INT,
	Tang INT check (Tang <= 3),
	Ngan INT check (Ngan <= 4),
	CONSTRAINT FK_ViTri_Sach FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
)
GO

-- Bảng Khách hàng
CREATE TABLE KhachHang 
(
	MaKhachHang NVARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL,
	SoDienThoai NVARCHAR(20) NOT NULL
)
GO

-- Bảng Phân loại nhân viên
CREATE TABLE PhanLoaiNhanVien 
(
	MaChucVu NVARCHAR(10) PRIMARY KEY,
	TenChucVu NVARCHAR(50) NOT NULL,
	MoTaCongViec NVARCHAR(200) NOT NULL,
	Luong DECIMAL(18,2) NOT NULL
)
GO

-- Bảng Nhân viên
CREATE TABLE NhanVien 
(
	MaNhanVien NVARCHAR(10) PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	MaChucVu NVARCHAR(10),
	DiaChi NVARCHAR(200) NOT NULL,
	SoDienThoai NVARCHAR(20) NOT NULL,
	HoatDong NVARCHAR(10),
	CONSTRAINT FK_ChucVu_NhanVien FOREIGN KEY (MaChucVu) REFERENCES PhanLoaiNhanVien(MaChucVu)
)
GO

-- Bảng Đăng nhập
CREATE TABLE DangNhap 
(
	MaNhanVien NVARCHAR(10) PRIMARY KEY,
	TenDangNhap NVARCHAR(30) UNIQUE NOT NULL,
	MatKhau NVARCHAR(30) NOT NULL check(len(MatKhau)>=5),
	CONSTRAINT FK_DangNhap_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
)
GO

-- Bảng Lương
CREATE TABLE Luong 
(
	MaNhanVien NVARCHAR(10) NOT NULL,
	SoNgayLamViec INT NOT NULL check (SoNgayLamViec <= 26),
	Thuong DECIMAL(18,2),
	TongLuong DECIMAL(18,2),
	CONSTRAINT FK_NhanVien_Luong FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
)
GO

-- Bảng Hóa đơn
CREATE TABLE HoaDon 
(
	MaHoaDon NVARCHAR(10) PRIMARY KEY,
	MaNhanVien NVARCHAR(10),
	MaKhachHang NVARCHAR(10) NOT NULL,
	ThoiGian DATETIME NOT NULL,
	ThanhTien DECIMAL(18,2),
	CONSTRAINT FK_NhanVien_HoaDon FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
	CONSTRAINT FK_KhachHang_HoaDon FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
)
GO

-- Bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon 
(
	MaHoaDon NVARCHAR(10) NOT NULL,
	MaSach NVARCHAR(10),
	SoLuong INT NOT NULL,
	DonGia INT NOT NULL,
	FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
	FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
)
GO

-- Bảng Phiếu nhập
CREATE TABLE PhieuNhap 
(
	MaPhieuNhap NVARCHAR(10) PRIMARY KEY,
	MaNCC NVARCHAR(10),
	NgayNhap DATETIME NOT NULL,
	ThanhTien DECIMAL(18,2),
	FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
)
GO

-- Bảng Chi tiết nhập sách
CREATE TABLE ChiTietNhapSach 
(
	MaPhieuNhap NVARCHAR(10),
	MaSach NVARCHAR(10),
	SoLuongNhap INT NOT NULL,
	DonGia INT NOT NULL,
	FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
	FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
)
GO

