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


-------------------------------------- Procedure Function --------------------------------------

USE QLCHBS
GO

-------------- FUNCTION --------------

--- 2 Function thống kê tìm code trong BaoCaoThongKe
-- Function mới thay thế cho View_RevenueStatistics
CREATE FUNCTION dbo.ThongKeHoaDon()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        CONVERT(DATE, hd.ThoiGian) AS Ngay, 
        SUM(ct.SoLuong) AS SoLuongSachBan, 
        SUM(ct.SoLuong * ct.DonGia) AS TongTien
    FROM HoaDon hd
    INNER JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
    GROUP BY CONVERT(DATE, hd.ThoiGian)
)
GO
-- Function mới thay thế cho View_PaymentStatistics
CREATE FUNCTION fn_PaymentStatistics ()
RETURNS TABLE
AS
RETURN
(
    SELECT
        CONVERT(date, pn.NgayNhap) AS Ngay,
        SUM(ct.SoLuongNhap) AS SoLuongNhap,
        SUM(ct.SoLuongNhap * ct.DonGia) AS TongTien
    FROM PhieuNhap pn
    JOIN ChiTietNhapSach ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
    GROUP BY CONVERT(date, pn.NgayNhap)
)
GO

--- 3 Function phân loại và 1 function hiển thị tìm code C# trong bảng Sach
-- Function Phân loại sách theo mã NCC đã chọn (thay thế cho procedure phân loại)
CREATE FUNCTION ClassifiedBySupplier(@MaNCC NVARCHAR(10))
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Sach WHERE MaNCC = @MaNCC
)
GO

-- Function Phân loại sách theo mã thể loại đã chọn (thay thế cho procedure phân loại)
CREATE FUNCTION ClassifiedByGenre(@MaTheLoai NVARCHAR(10))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM Sach WHERE MaTheLoai = @MaTheLoai
)
GO

-- Function Phân loại sách theo NXB đã chọn (thay thế cho procedure phân loại)
CREATE FUNCTION ClassifiedByPublishing(@NXB NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM Sach WHERE NXB = @NXB
)
GO

-- Function Hiển thị chi tiết toàn bộ Sách (thay thế cho procedure hiển thị)
CREATE FUNCTION ShowBookDetails (@MaSach NVARCHAR(10))
RETURNS TABLE
AS
RETURN
    SELECT Sach.MaSach AS MaSach, Sach.TenSach, Sach.TacGia, Sach.NXB, Sach.MaTheLoai, Sach.MaNCC, Sach.SoLuongTrenKe,
	Sach.DonGia, KhoSach.SoLuong
    FROM Sach 
    JOIN KhoSach ON Sach.MaSach = KhoSach.MaSach 
    WHERE Sach.MaSach = @MaSach
GO

-- Function Hiển thị chi tiết toàn bộ khách hàng (thay thế cho procedure hiển thị, code nằm trong bảng khách hàng)
CREATE FUNCTION ShowCustomerDetails(@MaKhachHang NVARCHAR(10))
RETURNS TABLE
AS
RETURN
    SELECT * FROM KhachHang WHERE MaKhachHang=@MaKhachHang
GO

-- Function Hiển thị chi tiết toàn bộ NCC (thay thế cho procedure hiển thị, code nằm trong bảng NCC)
CREATE FUNCTION ShowSupplierDetails(@MaNCC NVARCHAR(10))
RETURNS TABLE
AS RETURN
(
    SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC
)
GO

-- FUNCTION Kiểm tra số lượng sách còn lại trong kho của cửa hàng
CREATE FUNCTION CheckInventory
	(@MaSach NVARCHAR(10))
	RETURNS table
AS
	RETURN(SELECT * FROM KhoSach 
			WHERE MaSach = @MaSach )
GO

-- FUNCTION GetBestSellers: Trả về danh sách các cuốn sách bán chạy nhất trong một khoảng thời gian nhất định
CREATE FUNCTION GetBestSellers( @start_date DATE, @end_date DATE) 
	RETURNS TABLE 
AS
	RETURN (SELECT TOP 10 TenSach, SUM(SoLuong) AS TongSoLuong
			FROM Sach
			JOIN ChiTietHoaDon ON Sach.MaSach = ChiTietHoaDon.MaSach
			JOIN HoaDon ON ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon
			WHERE ThoiGian BETWEEN @start_date AND @end_date
			GROUP BY TenSach
			ORDER BY TongSoLuong DESC )
GO

-- FUNCTION SearchCustomer: Tìm kiếm thông tin khách hàng trong hệ thống dựa trên tên 
CREATE FUNCTION SearchCustomer
    (@MaKhachHang nvarchar(10),
	@TenKhachHang nvarchar(100))
RETURNS TABLE
AS
RETURN
    SELECT * FROM KhachHang
    WHERE HoTen LIKE @TenKhachHang or MaKhachHang LIKE @MaKhachHang 
GO

-- FUNCTION SearchEmployee: Tìm kiếm thông tin nhân viên trong hệ thống dựa trên tên hoặc mã nhân viên
CREATE FUNCTION SearchEmployee
    (@TenNhanVien nvarchar(100),
	@MaNhanVien nvarchar(10) )
RETURNS TABLE
AS
RETURN
    SELECT * FROM NhanVien
    WHERE HoTen LIKE @TenNhanVien or MaNhanVien LIKE @MaNhanVien 
GO

-- FUNCTION SearchSupplier: Tìm kiếm thông tin nhà cung cấp trong hệ thống dựa trên tên
CREATE FUNCTION SearchSupplier
    (@TenNCC nvarchar(100),
	 @MaNCC nvarchar(10))
RETURNS TABLE
AS
RETURN
    SELECT * FROM NhaCungCap
    WHERE TenNCC LIKE @TenNCC OR MaNCC LIKE @MaNCC
GO

-- FUNCTION Tìm kiếm thông tin của đơn hàng trong hệ thống dựa trên mã đơn hàng hoặc thông tin khách hàng
CREATE FUNCTION SearchOrder ( @MaDonHang NVARCHAR(10), @TenKhachHang NVARCHAR(100), @MaKhachHang NVARCHAR(10), @SDT NVARCHAR(20)) RETURNS TABLE 
AS
	RETURN (SELECT HoaDon.MaHoaDon, MaNhanVien, KhachHang.MaKhachHang, ThoiGian, MaSach,SoLuong,DonGia
			FROM HoaDon join ChiTietHoaDon on HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon 
						join KhachHang on KhachHang.MaKhachHang = HoaDon.MaKhachHang
			WHERE HoaDon.MaHoaDon = @MaDonHang or HoTen = @TenKhachHang or KhachHang.MaKhachHang = @MaKhachHang or SoDienThoai = @SDT )
GO
-- FUNCTION tìm kiếm thông tin dựa trên thể loại
CREATE FUNCTION SearchGenre (@TenTheLoai NVARCHAR(100) ) RETURNS TABLE
AS 
	RETURN
	SELECT * FROM TheLoai
    WHERE TenTheLoai LIKE @TenTheLoai
GO


-------------- PROCEDURE --------------

-- PROCEDURE kiểm tra đăng nhập
create function scalarfDangNhap(@TenDangNhap nvarchar(30), @MatKhau NVARCHAR(30))
returns nvarchar(30)
as
begin
	declare @result nvarchar(30)
	set @result = ''
	if exists (select * from DangNhap where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau)
	begin 
		select @result = MaNhanVien from DangNhap where TenDangNhap = @TenDangNhap;
	end
	return @result
end
go

-- PROCEDURE kiểm tra xem TaiKhoan và SĐT có tồn tại không
CREATE PROCEDURE CheckAccount_Phone
	@SDT NVARCHAR(20),
	@TenDangNhap NVARCHAR(30)
AS
BEGIN
	SELECT COUNT(*) FROM NhanVien JOIN DangNhap ON NhanVien.MaNhanVien = DangNhap.MaNhanVien WHERE SoDienThoai = @SDT AND TenDangNhap = @TenDangNhap
END
GO

-- PROCEDURE Kiểm tra xem TaiKhoan và MatKhau có tồn tại
CREATE PROCEDURE CheckAccount_Password
	@MatKhau NVARCHAR(20),
	@TenDangNhap NVARCHAR(30)
AS
BEGIN
	SELECT count(*) FROM DangNhap WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau
END
GO

-- PROCEDURE Cập nhật mật khẩu mới
CREATE PROCEDURE UpdateAccount
	@MatKhauMoi NVARCHAR(30),
	@TenDangNhap NVARCHAR(30)
AS
BEGIN
		DECLARE @command NVARCHAR(MAX) = '';
		SET @command = '';
		SELECT @command = @command + 'ALTER LOGIN [' + name + '] WITH PASSWORD = '''+@MatKhauMoi+''';'
		FROM sys.syslogins
		WHERE name LIKE @TenDangNhap;
		EXEC (@command);
		UPDATE DangNhap SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap
END
GO

-- PROCEDURE hiển thị thông tin nhân viên
CREATE PROCEDURE ShowStaffInformation
	@TenDangNhap NVARCHAR(30)
AS
BEGIN
	SELECT * FROM NhanVien INNER JOIN DangNhap ON NhanVien.MaNhanVien = DangNhap.MaNhanVien 
	WHERE DangNhap.TenDangNhap = @TenDangNhap
END
GO

-- PROCEDURE thêm sách
CREATE PROCEDURE AddBook 
    @TenSach nvarchar(100),
    @TacGia nvarchar(100),
    @NXB nvarchar(100),
    @MaTheLoai nvarchar(10),
	@MaNCC nvarchar(10),
    @SoLuongTrenKe int,
	@DonGia decimal(18,2)
AS
BEGIN
	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaSach) FROM Sach)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT

	SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	SET @NewCode = 'MS' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
    INSERT INTO Sach (MaSach, TenSach, TacGia, NXB, MaTheLoai, MaNCC, SoLuongTrenKe, DonGia)
    VALUES (@NewCode, @TenSach, @TacGia, @NXB, @MaTheLoai, @MaNCC, @SoLuongTrenKe, @DonGia)
END
GO

-- PROCEDURE cập nhật sách
CREATE PROCEDURE UpdateBook
    @MaSach nvarchar(10),
    @TenSach nvarchar(100),
    @TacGia nvarchar(100),
    @NXB nvarchar(100),
    @MaTheLoai nvarchar(10),
	@MaNCC nvarchar(10),
    @SoLuongTrenKe int,
	@DonGia decimal(18,2)
AS
BEGIN
    UPDATE Sach
    SET MaSach = @MaSach, TenSach = @TenSach, TacGia = @TacGia, NXB = @NXB, MaTheLoai = @MaTheLoai, MaNCC = @MaNCC, SoLuongTrenKe = @SoLuongTrenKe, DonGia = @DonGia
    WHERE MaSach = @MaSach
END
GO

-- PROCEDURE tìm kiếm sách theo Tên sách và tác giả
CREATE FUNCTION SearchBook
    (@TenSach nvarchar(100),
	 @TacGia nvarchar(100))
RETURNS TABLE
AS
RETURN
    SELECT * FROM Sach
    WHERE TenSach LIKE @TenSach OR TacGia LIKE @TacGia
GO

-- PROCEDURE thêm số lượng sách vào kho của cửa hàng
CREATE PROCEDURE AddInventory
	@MaSach nvarchar(10),
	@SoLuong int
AS
BEGIN
	Insert INTO KhoSach(MaSach, SoLuong)
	Values (@MaSach, @SoLuong )
END
GO

-- PROCEDURE thêm số lượng sách vào kho của cửa hàng
CREATE PROCEDURE UpdateInventory
	@MaSach nvarchar(10),
	@SoLuong int
AS
BEGIN
	Update KhoSach SET SoLuong = @SoLuong WHERE MaSach = @MaSach
END
GO

-- PROCEDURE tìm kiếm sách theo Tên sách và tác giả
CREATE FUNCTION SearchInventory
    (@TenSach nvarchar(100))
RETURNS TABLE
AS
RETURN
    SELECT KhoSach.MaSach, Sach.TenSach, KhoSach.SoLuong FROM KhoSach JOIN Sach ON KhoSach.MaSach = Sach.MaSach
    WHERE TenSach LIKE @TenSach
GO

-- PROCEDURE AddCustomer: Thêm thông tin khách hàng mới vào hệ thống
CREATE PROCEDURE AddCustomer
	@MaKhachHang NVARCHAR(10),
	@HoTen NVARCHAR(100),
	@DiaChi NVARCHAR(200) ,
	@SoDienThoai NVARCHAR(20)
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaKhachHang) FROM KhachHang)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'KH' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		INSERT INTO KhachHang (MaKhachHang, HoTen, DiaChi, SoDienThoai) 
		VALUES (@NewCode, @HoTen, @DiaChi, @SoDienThoai)
	END
GO

-- PROCEDURE UpdateCustomer: Cập nhật thông tin khách hàng trong hệ thống
CREATE PROCEDURE UpdateCustomer
    @MaKhachHang NVARCHAR(10),
	@HoTen NVARCHAR(100),
	@DiaChi NVARCHAR(200) ,
	@SoDienThoai NVARCHAR(20)
AS
BEGIN
    UPDATE KhachHang
    SET MaKhachHang = @MaKhachHang, HoTen = @HoTen, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai
    WHERE MaKhachHang = @MaKhachHang
END
GO

-- PROCEDURE AddEmployee: Thêm thông tin nhân viên mới vào hệ thống
--drop procedure AddEmployee
CREATE PROCEDURE AddEmployee
	@HoTen NVARCHAR(100),
	@NgaySinh DATE,
	@GioiTinh NVARCHAR(10),
	@MaChucVu NVARCHAR(10),
	@DiaChi NVARCHAR(200) ,
	@SoDienThoai NVARCHAR(20),
	@HoatDong NVARCHAR(10)
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaNhanVien) FROM NhanVien)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT
		DECLARE @TongLuong DECIMAL(18,2)

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'NV' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		
		--Thêm vào Nhân Viên
		INSERT INTO NhanVien(MaNhanVien, HoTen, NgaySinh, GioiTinh, MaChucVu, DiaChi, SoDienThoai,HoatDong) 
		VALUES (@NewCode, @HoTen, @NgaySinh, @GioiTinh, @MaChucVu, @DiaChi, @SoDienThoai,@HoatDong)

		declare @MaNV nvarchar(10) = (SELECT MAX(MaNhanVien) FROM NhanVien)
		declare @command nvarchar(max) = ''
		set @command = N'exec AddAccount '+'"'+@MaNV+'"'+', '+'"'+@MaNV+'"'+', '+'"'+@MaNV+'"'
		exec(@command)
	END
GO

create procedure AddAccount
	@MaNhanVien		varchar(10),
	@TenDangNhap	nvarchar(10),
	@MatKhau		nvarchar(30)
as
	begin
		insert into DangNhap values (@MaNhanVien, @TenDangNhap, @MatKhau)
	end
go

-- PROCEDURE UpdateEmployee: Cập nhật thông tin nhân viên trong hệ thống
--drop procedure UpdateEmployee
CREATE PROCEDURE UpdateEmployee
    @MaNhanVien NVARCHAR(10),
	@HoTen NVARCHAR(100),
	@NgaySinh DATE,
	@GioiTinh NVARCHAR(10),
	@MaChucVu NVARCHAR(10),
	@DiaChi NVARCHAR(200) ,
	@SoDienThoai NVARCHAR(20),
	@HoatDong nvarchar(10)
AS
BEGIN
-- cập nhật nhân viên
    UPDATE NhanVien
    SET HoTen = @HoTen, NgaySinh = @NgaySinh,
	GioiTinh = @GioiTinh, MaChucVu = @MaChucVu, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai,HoatDong = @HoatDong
    WHERE MaNhanVien = @MaNhanVien

	-- kiểm tra trạng thái hoạt động của nhân viên
	IF @HoatDong = N'Nghỉ việc'
	BEGIN
		DECLARE @TenDangNhap varchar(10)
		SELECT @TenDangNhap = DangNhap.TenDangNhap FROM DangNhap WHERE MaNhanVien = @MaNhanVien
		DECLARE @command nvarchar(max) = ''
		SET @command = 'EXEC DeleteAccountEmployee ' + '"' + @TenDangNhap + '"'
		EXEC(@command)
	END
END
GO

-- Xóa tài khoản nhân viên
create procedure DeleteAccountEmployee
	@TenDangNhap varchar(10)
as
begin
	declare @command nvarchar(max) = ''
	set @command = '';
	SELECT @command = @command + 'KILL ' + CONVERT(varchar(5), session_id) + ';'
	FROM sys.dm_exec_sessions
	WHERE login_name = @TenDangNhap
	EXEC (@command);
	--
	set @command = ''
	select @command = @command + 'DROP login ['+name+'];'
	from sys.syslogins where name like @TenDangNhap
	exec(@command)
	--
	set @command = ''
	select @command = @command + 'DROP user ['+name+'];'
	from sys.sysusers where name like @TenDangNhap
	exec(@command)
	-- Xóa nhân viên khỏi phân nhóm
	DELETE FROM DangNhap WHERE TenDangNhap = @TenDangNhap;	
end
go

-- PROCEDURE AddSupplier: Thêm thông tin nhà cung cấp mới vào hệ thống
CREATE PROCEDURE AddSupplier
	@MaNCC NVARCHAR(10),
	@TenNCC NVARCHAR(100),
	@DiaChi NVARCHAR(200) ,
	@SoDienThoai NVARCHAR(20)
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaNCC) FROM NhaCungCap)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'NCC' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		INSERT INTO NhaCungCap(MaNCC, TenNCC, DiaChi, SoDienThoai) 
		VALUES (@NewCode, @TenNCC, @DiaChi, @SoDienThoai)
	END
GO

-- PROCEDURE UpdateSupplier: Cập nhật thông tin nhà cung cấp trong hệ thống
CREATE PROCEDURE UpdateSupplier
    @MaNCC NVARCHAR(10),
	@TenNCC NVARCHAR(100),
	@DiaChi NVARCHAR(200) ,
	@SoDienThoai NVARCHAR(20)
AS
BEGIN
    UPDATE NhaCungCap
    SET MaNCC = @MaNCC, TenNCC = @TenNCC, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai
    WHERE MaNCC = @MaNCC
END
GO

-- PROCEDURE Nhận sách từ nhà cung cấp và cập nhật số lượng sách trong kho
CREATE PROCEDURE ReceiveShipment
	@MaSach NVARCHAR(10),
	@SoLuong INT
AS
	UPDATE KhoSach SET MaSach = @MaSach, SoLuong = SoLuong + @SoLuong
GO

-- PROCEDURE hóa đơn
CREATE PROCEDURE AddOrder 
		@MaDonHang NVARCHAR(10),
		@TenKhachHang NVARCHAR(100),
		@MaKhachHang NVARCHAR(10),
		@MaNhanVien NVARCHAR(10),
		@MaSach NVARCHAR(10),
		@SoLuong INT,
		@DonGia FLOAT,
		@ThoiGian DATETIME,
		@SDT NVARCHAR(20)
AS
BEGIN 
	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaHoaDon) FROM HoaDon)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT
	SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	SET @NewCode = 'MS' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)

	INSERT INTO HoaDon (MaHoaDon, MaNhanVien, MaKhachHang, ThoiGian) 
	VALUES 
	(@NewCode,@MaNhanVien,@MaKhachHang, @ThoiGian)
	INSERT INTO dbo.ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia)
	VALUES 
	(@NewCode,@MaSach,@SoLuong,@DonGia)
END
GO

-- PROCEDURE Cập nhật thông tin của đơn hàng trong hệ thống
CREATE PROCEDURE UpdateOrder 
		@MaDonHang NVARCHAR(10),
		@TenKhachHang NVARCHAR(100),
		@MaKhachHang NVARCHAR(10),
		@MaNhanVien NVARCHAR(10),
		@MaSach NVARCHAR(10),
		@SoLuong INT,
		@DonGia FLOAT,
		@SDT NVARCHAR(20)
AS
BEGIN
	UPDATE HoaDon SET MaHoaDon = @MaDonHang, MaNhanVien = @MaNhanVien, MaKhachHang = @MaKhachHang
	UPDATE ChiTietHoaDon SET  MaHoaDon = @MaDonHang, MaSach = @MaSach, SoLuong = @SoLuong, DonGia = @DonGia
END
GO

-- PROCEDURE Thêm thể loại mới vào hệ thống
CREATE PROCEDURE AddGenre
		@MaTheLoai NVARCHAR(10),
		@TenTheLoai NVARCHAR(100),
		@MoTa NVARCHAR(255)
AS
BEGIN 
	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaTheLoai) FROM TheLoai)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT
	SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	SET @NewCode = 'TL' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)

	INSERT INTO TheLoai (MaTheLoai, TenTheLoai, MoTa )
	VALUES
	(@NewCode, @TenTheLoai, @MoTa) 
END
GO

-- PROCEDURE Cập nhật thông tin thể loại trong hệ thống
CREATE PROCEDURE UpdateGenre  
		@TenTheLoai NVARCHAR(100), 
		@MaTheLoai NVARCHAR(10)  ,
		@MoTa NVARCHAR (255) 
AS
	UPDATE TheLoai SET
	TenTheLoai = @TenTheLoai, 
	MoTa = @MoTa
	Where MaTheLoai = @MaTheLoai
GO

-- PROCEDURE sửa vị trí sách
CREATE PROCEDURE UpdateBookLocation
	@MaViTri nvarchar(10),
    @MaSach nvarchar(10),
	@Ke int,
	@Tang int,
	@Ngan int
AS
BEGIN
    UPDATE ViTriSach
    SET MaSach = @MaSach, Ke = @Ke, Tang = @Tang, Ngan = @Ngan
    WHERE MaViTri = @MaViTri
END
GO

-- PROCEDURE tìm kiếm vị trí sách
CREATE FUNCTION SearchBookLocation
    (@MaSach nvarchar(10))
RETURNS TABLE
AS
RETURN
    SELECT * FROM ViTriSach
    WHERE MaSach LIKE @MaSach
GO

-- PROCEDURE thêm phiếu nhập
CREATE PROCEDURE AddReceipt
    @MaNCC NVARCHAR(10)
AS
BEGIN
	DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaPhieuNhap) FROM PhieuNhap)
	DECLARE @NewCode VARCHAR(10)
	DECLARE @Suffix INT

	SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
	SET @NewCode = 'PN' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
    INSERT INTO PhieuNhap (MaPhieuNhap, MaNCC, NgayNhap, ThanhTien)
    VALUES (@NewCode, @MaNCC, GETDATE(), 0)
END
GO

-- PROCEDURE Thêm chi tiết Phiếu Nhập
CREATE PROCEDURE AddReceiptDetails
	@MaPhieuNhap NVARCHAR(10),
	@MaSach NVARCHAR(10),
	@SoLuongNhap INT,
	@DonGia int 
AS
BEGIN
	INSERT INTO ChiTietNhapSach (MaPhieuNhap, MaSach, SoLuongNhap, DonGia)
	VALUES (@MaPhieuNhap, @MaSach, @SoLuongNhap , @DonGia)

	UPDATE PhieuNhap
	SET ThanhTien = (
    SELECT SUM(SoLuongNhap * DonGia)
    FROM ChiTietNhapSach
    WHERE PhieuNhap.MaPhieuNhap = ChiTietNhapSach.MaPhieuNhap)
END
GO

-- PROCEDURE Cập nhập Phiếu Nhập
CREATE PROCEDURE UpdateReceipt
	@MaPhieuNhap nvarchar(10),
	@MaNCC nvarchar(10)
AS
BEGIN
	Update PhieuNhap
	SET MaNCC = @MaNCC
	WHERE MaPhieuNhap = @MaPhieuNhap
END
GO

-- PROCEDURE Cập nhật chi tiết Phiếu Nhập
CREATE PROCEDURE UpdateReceiptDetails
	@MaPhieuNhap nvarchar(10),
	@MaSach nvarchar(10),
	@SoLuongNhap int,
	@DonGia int
AS
BEGIN
	Update ChiTietNhapSach 
	SET SoLuongNhap = @SoLuongNhap, DonGia = @DonGia 
	WHERE MaPhieuNhap = @MaPhieuNhap AND MaSach = @MaSach

	UPDATE PhieuNhap
	SET ThanhTien = (
    SELECT SUM(SoLuongNhap * DonGia)
    FROM ChiTietNhapSach
    WHERE PhieuNhap.MaPhieuNhap = ChiTietNhapSach.MaPhieuNhap)
END
GO

-- PROCEDURE Tìm kiếm Phiếu nhập
CREATE FUNCTION SearchReceipt
    (@MaPhieuNhap nvarchar(10))
RETURNS TABLE
AS
RETURN
    SELECT * FROM PhieuNhap
    WHERE MaPhieuNhap = @MaPhieuNhap
GO

-- PROCEDURE Tìm kiếm chi tiết phiếu nhập
CREATE FUNCTION SearchReceiptDetails
    (@MaPhieuNhap nvarchar(10))
RETURNS TABLE
AS
RETURN
    SELECT * FROM ChiTietNhapSach
    WHERE MaPhieuNhap = @MaPhieuNhap
GO

-- PROCEDURE Hiển thị chi tiết toàn bộ thể loại
CREATE PROCEDURE ShowGenreDetails
@MaTheLoai NVARCHAR(10)
AS
	SELECT * FROM TheLoai WHERE TheLoai.MaTheLoai =@MaTheLoai
GO

-- PROCEDURE Hiển thị chi tiết toàn bộ vị trí sách
CREATE PROCEDURE ShowBookLocationDetails
@MaViTri NVARCHAR(10)
AS
	SELECT * FROM ViTriSach WHERE ViTriSach.MaViTri =@MaViTri
GO

-- PROCEDURE Hiển thị chi tiết kho sách
CREATE PROCEDURE ShowInventoryDetails
@MaSach NVARCHAR(10)
AS
	SELECT KhoSach.MaSach, Sach.TenSach, KhoSach.SoLuong FROM KhoSach JOIN Sach ON KhoSach.MaSach = Sach.MaSach WHERE KhoSach.MaSach=@MaSach
GO

-- PROCEDURE Hiển thị chi tiết của Phiếu Nhập
CREATE PROCEDURE ShowReceipt
@MaPhieuNhap NVARCHAR(10)
AS
	SELECT * FROM PhieuNhap Join ChiTietNhapSach on PhieuNhap.MaPhieuNhap = ChiTietNhapSach.MaPhieuNhap 
	WHERE PhieuNhap.MaPhieuNhap=@MaPhieuNhap
	order by PhieuNhap.MaPhieuNhap
GO

-- PROCEDURE Hiển thị chi tiết của Chi Tiêt Phiếu Nhập
CREATE PROCEDURE ShowReceiptDetails
@MaPhieuNhap NVARCHAR(10),
@MaSach NVARCHAR(10)
AS
	SELECT * FROM PhieuNhap Join ChiTietNhapSach on PhieuNhap.MaPhieuNhap = ChiTietNhapSach.MaPhieuNhap 
	WHERE ChiTietNhapSach.MaPhieuNhap=@MaPhieuNhap AND ChiTietNhapSach.MaSach = @MaSach
	order by PhieuNhap.MaPhieuNhap
GO

-- PROCEDURE Phân loại sách theo giá tiền đã chọn
CREATE PROCEDURE ClassifiedByPrice
	@MinPrice int,
	@MaxPrice int
AS
	SELECT * FROM Sach WHERE DonGia >= @MinPrice AND DonGia <= @MaxPrice
GO

-- PROCEDURE Phân loại vị trí sách theo kệ đã chọn
CREATE PROCEDURE ClassifiedByShelf
	@Ke int
AS
	SELECT * FROM ViTriSach WHERE Ke = @Ke
GO

--Hiển thị chi tiết của Phiếu Nhập
CREATE PROCEDURE ShowAllBills
@MaHoaDon NVARCHAR(10)
AS
	SELECT * FROM HoaDon WHERE HoaDon.MaHoaDon=@MaHoaDon
GO

--Hiển thị chi tiết của Chi Tiêt Phiếu Nhập
CREATE PROCEDURE ShowAllBillDetails
@MaHoaDon NVARCHAR(10),
@MaSach NVARCHAR(10)
AS
	SELECT * FROM ChiTietHoaDon WHERE ChiTietHoaDon.MaHoaDon=@MaHoaDon AND MaSach = @MaSach
GO

CREATE FUNCTION SearchBill
    (@MaHoaDon NVARCHAR(10),
    @MaKhachHang NVARCHAR(10))
RETURNS TABLE
AS
RETURN 
(
    SELECT DISTINCT hd.MaHoaDon, hd.MaNhanVien, hd.MaKhachHang, hd.ThoiGian, hd.ThanhTien
    FROM HoaDon hd
    JOIN ChiTietHoaDon cthd ON hd.MaHoaDon = cthd.MaHoaDon
    WHERE hd.MaHoaDon LIKE '%' + @MaHoaDon + '%' OR hd.MaKhachHang LIKE '%' + @MaKhachHang + '%'
)
GO

CREATE FUNCTION SearchBillDetails
    (@MaHoaDon NVARCHAR(10),
     @MaKhachHang NVARCHAR(10))
RETURNS TABLE
AS
RETURN 
(
    SELECT cthd.MaHoaDon, cthd.MaSach, cthd.SoLuong, cthd.DonGia
    FROM ChiTietHoaDon cthd
    JOIN HoaDon hd ON cthd.MaHoaDon = hd.MaHoaDon
    WHERE cthd.MaHoaDon LIKE '%' + @MaHoaDon + '%' OR hd.MaKhachHang LIKE '%' + @MaKhachHang + '%'
)
GO

CREATE PROCEDURE AddBill
    @MaNhanVien NVARCHAR(50),
    @MaKhachHang NVARCHAR(50)
AS
BEGIN
	DECLARE @MaHoaDon NVARCHAR(50)
    DECLARE @MaHoaDonMax NVARCHAR(50)
    SELECT @MaHoaDonMax = MAX(MaHoaDon) FROM HoaDon

    -- Tăng giá trị mã hóa đơn lên 1
    SET @MaHoaDon = 'HD' + RIGHT('000' + CAST(CAST(SUBSTRING(@MaHoaDonMax, 3, 3) AS INT) + 1 AS NVARCHAR(50)), 3)

	-- Lấy thời gian thực
    DECLARE @ThoiGian DATETIME = GETDATE()

	INSERT INTO HoaDon (MaHoaDon, MaNhanVien, MaKhachHang, ThoiGian, ThanhTien)
    VALUES (@MaHoaDon, @MaNhanVien, @MaKhachHang, @ThoiGian, 0)
END
GO

-- PROCEDURE Thêm chi tiết Hóa Đơn
CREATE PROCEDURE AddBillDetails
	@MaHoaDon NVARCHAR(10),
	@MaSach NVARCHAR(10),
	@SoLuong INT
AS
BEGIN
	-- Lấy đơn giá từ bảng Sách
	DECLARE @DonGia DECIMAL(18, 2)
	SELECT @DonGia = DonGia FROM Sach WHERE MaSach = @MaSach

	INSERT INTO ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia)
	VALUES (@MaHoaDon, @MaSach, @SoLuong , @DonGia)

	UPDATE HoaDon
	SET ThanhTien = (
    SELECT SUM(SoLuong * DonGia)
    FROM ChiTietHoaDon
    WHERE HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon)
END
GO

-- PROCEDURE Cập nhập Phiếu Nhập
CREATE PROCEDURE UpdateBill
	@MaHoaDon nvarchar(10),
	@MaNhanVien nvarchar(10),
	@MaKhachHang nvarchar (10)
AS
BEGIN
	Update HoaDon
	SET MaNhanVien = @MaNhanVien, MaKhachHang = @MaKhachHang
	WHERE MaHoaDon = @MaHoaDon
END
GO

-- PROCEDURE Cập nhật chi tiết Hoa don
CREATE PROCEDURE UpdateBillDetails
	@MaHoaDon nvarchar(10),
	@MaSach nvarchar(10),
	@SoLuong int,
	@DonGia int
AS
BEGIN
	Update ChiTietHoaDon 
	SET SoLuong = @SoLuong, DonGia = @DonGia 
	WHERE MaHoaDon = @MaHoaDon AND MaSach = @MaSach

	UPDATE HoaDon
	SET ThanhTien = (
    SELECT SUM(SoLuong * DonGia)
    FROM ChiTietHoaDon
    WHERE HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon)
END
GO

-- PROCEDURE Phân loại hóa đơn theo mã nhân viên
CREATE PROCEDURE ClassifiedBillByStaff
	@MaNhanVien NVARCHAR(10)
AS
	SELECT * FROM HoaDon WHERE HoaDon.MaNhanVien = @MaNhanVien
GO

-- PROCEDURE Hiển thị chi tiết Nhân Viên
CREATE PROCEDURE ShowStaff
@MaNhanVien NVARCHAR(10)
AS
	SELECT * FROM NhanVien
	WHERE MaNhanVien=@MaNhanVien
GO

--PROCEDURE Phân loại Nhân Viên theo chức vụ đã chọn
CREATE PROCEDURE ClassifiedByDuty
	@MaChucVu NVARCHAR(10)
AS
	SELECT * FROM NhanVien  
	WHERE NhanVien.MaChucVu = @MaChucVu
GO

--PROCEDURE Phân loại Nhân Viên theo Tình Trạng Hoạt Động đã chọn
CREATE PROCEDURE ClassifiedByActivity
	@HoatDong NVARCHAR(100)
AS
	SELECT * FROM NhanVien 
	JOIN PhanLoaiNhanVien ON NhanVien.MaChucVu = PhanLoaiNhanVien.MaChucVu
	JOIN Luong ON NhanVien.MaNhanVien = Luong.MaNhanVien  
	WHERE NhanVien.HoatDong = @HoatDong
GO

--PROCEDURE Phân loại Nhân Viên theo Giới tính đã chọn
CREATE PROCEDURE ClassifiedBySex
	@GioiTinh nvarchar(10)
AS
	SELECT * FROM NhanVien 
	JOIN PhanLoaiNhanVien ON NhanVien.MaChucVu = PhanLoaiNhanVien.MaChucVu
	JOIN Luong ON NhanVien.MaNhanVien = Luong.MaNhanVien  
	WHERE NhanVien.GioiTinh = @GioiTinh
GO

--PROCCEDURE Hiển thị phân loại nhân viên
CREATE PROCEDURE ShowClassifiedStaff
@MaChucVu NVARCHAR(10)
AS
	SELECT * FROM PhanLoaiNhanVien
	WHERE MaChucVu=@MaChucVu
GO
----PROCEDURE Phân loại Nhân Viên theo chức vụ đã chọn
--drop procedure FindDuty
CREATE PROCEDURE FindDuty
	@TenChucVu NVARCHAR(100)
AS
	SELECT * FROM PhanLoaiNhanVien  
	WHERE TenChucVu = @TenChucVu
GO
-- PROCEDURE Phân loại  theo Lương đã chọn
CREATE PROCEDURE ClassifiedBySalary
	@MinPrice int,
	@MaxPrice int
AS
	SELECT * FROM PhanLoaiNhanVien WHERE Luong >= @MinPrice AND Luong <= @MaxPrice
GO

-- PROCEDURE AddClassifiedStaff: Thêm thông tin nhân viên mới vào hệ thống
--drop procedure AddClassifiedStaff
CREATE PROCEDURE AddClassifiedStaff
	@MaChucVu NVARCHAR(10),
	@TenChucVu NVARCHAR(50),
	@MoTaCongViec NVARCHAR(200),
	@Luong DECIMAL(18,2)
AS
	BEGIN
		DECLARE @OldCode VARCHAR(10) = (SELECT MAX(MaChucVu) FROM PhanLoaiNhanVien)
		DECLARE @NewCode VARCHAR(10)
		DECLARE @Suffix INT

		SET @Suffix = CAST(RIGHT(@OldCode, 3) AS INT) + 1
		SET @NewCode = 'CV' + RIGHT('00' + CAST(@Suffix AS VARCHAR(3)), 3)
		
		--Thêm vào Phân Loại Nhân Viên
		INSERT INTO PhanLoaiNhanVien (MaChucVu, TenChucVu, MoTaCongViec, Luong) 
		VALUES (@NewCode, @TenChucVu, @MoTaCongViec, @Luong)

	END
GO

-- PROCEDURE UpdateClassifiedStaff Cập nhật thông tin nhân viên trong hệ thống
--drop procedure UpdateClassifiedStaff
CREATE PROCEDURE UpdateClassifiedStaff
    @MaChucVu NVARCHAR(10),
	@TenChucVu NVARCHAR(50),
	@MoTaCongViec NVARCHAR(200),
	@Luong DECIMAL(18,2)
AS
BEGIN
-- cập nhật nhân viên
    UPDATE PhanLoaiNhanVien
    SET TenChucVu = @TenChucVu, MoTaCongViec = @MoTaCongViec, Luong = @Luong
    WHERE MaChucVu = @MaChucVu
END
GO

--PROCCEDURE Hiển thị Lương
CREATE PROCEDURE ShowSalary
@MaNhanVien NVARCHAR(10)
AS
	SELECT * FROM Luong
	WHERE MaNhanVien=@MaNhanVien
GO
--PROCEDURE Phân loại Nhân Viên theo Số ngày làm việc đã chọn
CREATE PROCEDURE ClassifiedByDayOfWork
	@SoNgayLamViec int
AS
	SELECT * FROM Luong 
	WHERE SoNgayLamViec = @SoNgayLamViec
GO
-- PROCEDURE Phân loại Nhân Viên theo lương đã chọn
CREATE PROCEDURE ClassifiedBySumSalary
	@MinPrice int,
	@MaxPrice int
AS
	SELECT * FROM Luong 
	WHERE TongLuong >= @MinPrice AND TongLuong <= @MaxPrice
GO

-- PROCEDURE AddSalarry: Thêm thông tin nhân viên mới vào hệ thống
--drop procedure AddSalarry
CREATE PROCEDURE AddSalary
	@MaNhanVien NVARCHAR(10),
	@SoNgayLamViec INT ,
	@Thuong DECIMAL(18,2)
AS
	BEGIN
		--Thêm vào Lương
		INSERT INTO Luong(MaNhanVien, SoNgayLamViec, Thuong) 
		VALUES (@MaNhanVien, @SoNgayLamViec, @Thuong)

		UPDATE Luong
		SET TongLuong = (
			SELECT (Luong / 26 * SoNgayLamViec + Thuong)
			FROM PhanLoaiNhanVien join NhanVien on PhanLoaiNhanVien.MaChucVu = NhanVien.MaChucVu
			WHERE NhanVien.MaNhanVien = Luong.MaNhanVien)

	END
GO

-- PROCEDURE UpdateSalary Cập nhật thông tin Lương
--drop procedure UpdateSalary
CREATE PROCEDURE UpdateSalary
    @MaNhanVien NVARCHAR(10),
	@SoNgayLamViec INT ,
	@Thuong DECIMAL(18,2)
AS
BEGIN
	UPDATE Luong
	SET SoNgayLamViec = @SoNgayLamViec, Thuong = @Thuong,
		TongLuong = (
			SELECT (Luong / 26 * SoNgayLamViec + Thuong)
			FROM PhanLoaiNhanVien join NhanVien on PhanLoaiNhanVien.MaChucVu = NhanVien.MaChucVu
			WHERE NhanVien.MaNhanVien = Luong.MaNhanVien)
	WHERE MaNhanVien = @MaNhanVien
END
GO

-------------------------------------- Trigger View --------------------------------------

USE QLCHBS
GO

-------------------- View --------------------

-- View thông tin Sách
CREATE VIEW View_Book AS
	SELECT * FROM Sach
GO

-- View thông tin Kho Sách
CREATE VIEW View_Inventory AS
	SELECT KhoSach.MaSach, Sach.TenSach, KhoSach.SoLuong FROM KhoSach JOIN Sach ON KhoSach.MaSach = Sach.MaSach
GO

-- View thông tin vị trí sách
CREATE VIEW View_BookLocation AS
	SELECT * FROM ViTriSach
GO

-- View thông tin Thể Loại
CREATE VIEW View_Genre AS
	SELECT * FROM TheLoai
GO

-- View thông tin Nhân viên
CREATE VIEW View_Staff AS
	SELECT * FROM NhanVien
GO

-- View thông tin phân loại Nhân viên
CREATE VIEW View_ClassifiedStaff AS
	SELECT * FROM PhanLoaiNhanVien
GO

-- View thông tin Lương
CREATE VIEW View_Salary AS
	SELECT * FROM Luong
GO

-- View thông tin Khách hàng
CREATE VIEW View_Customer AS
	SELECT * FROM KhachHang
GO

--View thông tin Hóa Đơn
CREATE VIEW View_Bill AS
	SELECT * FROM HoaDon
GO

--View thông tin chi tiết Hóa Đơn
CREATE VIEW View_BillDetails AS
	SELECT * FROM ChiTietHoaDon
GO

-- View thông tin phiếu nhập
CREATE VIEW View_Receipt AS
	SELECT * FROM PhieuNhap
GO

-- View thông tin chi tiết phiếu nhập
CREATE VIEW View_ReceiptDetails AS
	SELECT * FROM ChiTietNhapSach
GO

-- View thông tin Nhà Cung Cấp
CREATE VIEW View_Supplier AS
	SELECT * FROM NhaCungCap
GO

-- View thông tin tài khoản đăng nhập
CREATE VIEW View_Account AS
	SELECT * FROM DangNhap
GO

-- View Doanh thu của cửa hàng từ việc bán sách
CREATE VIEW View_RevenueStatistics AS
	SELECT
		CONVERT(date, hd.ThoiGian) AS Ngay,
		SUM(ct.SoLuong) AS SoLuongSachDaBan,
		SUM(ct.SoLuong * ct.DonGia) AS TongTien
	FROM HoaDon hd
	JOIN ChiTietHoaDon ct ON hd.MaHoaDon = ct.MaHoaDon
	GROUP BY CONVERT(date, hd.ThoiGian)
GO

-- View Doanh thu của cửa hàng từ việc bán sách tính theo tuần
CREATE VIEW View_RevenueStatistics_Week AS
	SELECT DATEPART(WEEK, Ngay) AS Tuan, SUM(SoLuongSachDaBan) AS TongSoLuong, SUM(TongTien) AS TongDoanhThu
	FROM View_RevenueStatistics
	GROUP BY DATEPART(WEEK, Ngay)
GO

-- View Thanh toán của cửa hàng từ việc nhập sách
CREATE VIEW View_PaymentStatistics AS
	SELECT
		CONVERT(date, pn.NgayNhap) AS Ngay,
		SUM(ct.SoLuongNhap) AS SoLuongNhap,
		SUM(ct.SoLuongNhap * ct.DonGia) AS TongTien
	FROM PhieuNhap pn
	JOIN ChiTietNhapSach ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
	GROUP BY CONVERT(date, pn.NgayNhap)
GO

-- View Thanh toán của cửa hàng từ việc nhập sách tính theo tuần
CREATE VIEW View_PaymentStatistics_Week AS
	SELECT DATEPART(MONTH, Ngay) AS Thang, SUM(SoLuongNhap) AS TongSoLuong, SUM(TongTien) AS TongTien
	FROM View_PaymentStatistics
	GROUP BY DATEPART(MONTH, Ngay)
GO

-- View top 10 sách bán chạy nhất
CREATE VIEW View_BookBestSell AS
	SELECT TOP 10 Sach.MaSach, Sach.TenSach, SUM(ChiTietHoaDon.SoLuong) AS TongSoLuongBan
	FROM Sach JOIN ChiTietHoaDon ON Sach.MaSach = ChiTietHoaDon.MaSach
	GROUP BY Sach.TenSach, Sach.MaSach
	ORDER BY TongSoLuongBan DESC
GO

-- View top 10 sách bán chậm nhất
CREATE VIEW View_BookWorstSell AS
	SELECT TOP 10 Sach.MaSach, Sach.TenSach, SUM(ChiTietHoaDon.SoLuong) AS TongSoLuongBan
	FROM Sach JOIN ChiTietHoaDon ON Sach.MaSach = ChiTietHoaDon.MaSach
	GROUP BY Sach.TenSach, Sach.MaSach
	ORDER BY TongSoLuongBan ASC
GO

-- View top 5 thể loại có số lượng sách trên kệ và trong kho nhiều nhất
CREATE VIEW View_GenreHighestNumber AS
	SELECT TOP 5
		tl.MaTheLoai,
		tl.TenTheLoai,
		SUM(ks.SoLuong + s.SoLuongTrenKe) AS TongSoLuong
	FROM TheLoai tl
	JOIN Sach s ON tl.MaTheLoai = s.MaTheLoai
	JOIN KhoSach ks ON s.MaSach = ks.MaSach
	GROUP BY tl.TenTheLoai, tl.MaTheLoai
	ORDER BY TongSoLuong DESC
GO

-- View top 5 thể loại có số lượng sách trên kệ và trong kho ít nhất
CREATE VIEW View_GenreLeastNumber AS
	SELECT TOP 5
		tl.MaTheLoai,
		tl.TenTheLoai,
		SUM(ks.SoLuong + s.SoLuongTrenKe) AS TongSoLuong
	FROM TheLoai tl
	JOIN Sach s ON tl.MaTheLoai = s.MaTheLoai
	JOIN KhoSach ks ON s.MaSach = ks.MaSach
	GROUP BY tl.TenTheLoai, tl.MaTheLoai
	ORDER BY TongSoLuong ASC
GO

-- View top 5 thể loại có lượng sách bán nhiều nhất
CREATE VIEW View_GenreBestSell AS
	SELECT TOP 5
		tl.MaTheLoai,
		tl.TenTheLoai,
		SUM(cthd.SoLuong) AS TongSoLuongBan
	FROM TheLoai tl
	JOIN Sach s ON tl.MaTheLoai = s.MaTheLoai
	JOIN ChiTietHoaDon cthd ON s.MaSach = cthd.MaSach
	GROUP BY tl.TenTheLoai, tl.MaTheLoai
	ORDER BY TongSoLuongBan DESC
GO

-- View top 5 thể loại có lượng sách bán ít nhất
CREATE VIEW View_GenreWorstSell AS
	SELECT TOP 5
		tl.MaTheLoai,
		tl.TenTheLoai,
		SUM(cthd.SoLuong) AS TongSoLuongBan
	FROM TheLoai tl
	JOIN Sach s ON tl.MaTheLoai = s.MaTheLoai
	JOIN ChiTietHoaDon cthd ON s.MaSach = cthd.MaSach
	GROUP BY tl.TenTheLoai, tl.MaTheLoai
	ORDER BY TongSoLuongBan ASC
GO

-- View 10 khách hàng mua nhiều nhất
CREATE VIEW View_CustomerMostBuy AS
	SELECT TOP 20 KhachHang.MaKhachHang, KhachHang.HoTen, COUNT(*) AS TongSoHoaDon, SUM(ChiTietHoaDon.SoLuong) AS TongSoLuongMua
	FROM KhachHang
	JOIN HoaDon ON KhachHang.MaKhachHang = HoaDon.MaKhachHang
	JOIN ChiTietHoaDon ON HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon
	GROUP BY KhachHang.MaKhachHang, KhachHang.HoTen
	ORDER BY TongSoLuongMua DESC
GO

-- View 10 khách hàng mua ít nhất nhất
CREATE VIEW View_CustomerLeastBuy AS
	SELECT TOP 20 KhachHang.MaKhachHang, KhachHang.HoTen, COUNT(*) AS TongSoHoaDon, SUM(ChiTietHoaDon.SoLuong) AS TongSoLuongMua
	FROM KhachHang
	JOIN HoaDon ON KhachHang.MaKhachHang = HoaDon.MaKhachHang
	JOIN ChiTietHoaDon ON HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon
	GROUP BY KhachHang.MaKhachHang, KhachHang.HoTen
	ORDER BY TongSoLuongMua ASC
GO

-- View 10 sách tồn kho nhiều nhất
CREATE VIEW View_MostInStock AS
	SELECT TOP 10 Sach.MaSach, TenSach, SUM(SoLuong) AS TongSoLuongTrongKho
	FROM Sach
	JOIN KhoSach ON Sach.MaSach = KhoSach.MaSach
	GROUP BY Sach.MaSach, TenSach
	ORDER BY TongSoLuongTrongKho DESC
GO

-- View 10 sách tồn kho ít nhất
CREATE VIEW View_LeastInStock AS
	SELECT TOP 10 Sach.MaSach, TenSach, SUM(SoLuong) AS TongSoLuongTrongKho
	FROM Sach
	JOIN KhoSach ON Sach.MaSach = KhoSach.MaSach
	GROUP BY Sach.MaSach, TenSach
	ORDER BY TongSoLuongTrongKho ASC
GO

-- view những nhân viên không vắng làm
CREATE VIEW View_NoAbsence AS
	SELECT * FROM Luong
	WHERE SoNgayLamViec = 26
GO

-- view top 5 nhân viên có tổng lương cao nhất
CREATE VIEW View_Top5HighSalary AS
	SELECT TOP 5 * FROM Luong
	ORDER BY TongLuong DESC
GO

-- View top 3 nhân viên có thưởng cao nhất
CREATE VIEW View_Top3Bonus AS
	SELECT TOP 3 *
	FROM Luong
	ORDER BY Thuong DESC
GO

-------------------- Trigger --------------------

-- Trigger để cập nhật số lượng trên kệ của Sach
CREATE TRIGGER CapNhatSoLuongKe_Kho ON ChiTietHoaDon
INSTEAD OF INSERT
AS
BEGIN
	-- Kiểm tra số lượng sách
	DECLARE @MaSach NVARCHAR(10)
	DECLARE @SoLuong INT
	DECLARE @SoLuongKho INT
	DECLARE @SoLuongTrenKe INT
	-- Lấy giá trị từ bảng inserted
	SELECT @MaSach = MaSach, @SoLuong = SoLuong
	FROM inserted
	-- Lấy giá trị từ bảng Kho
	SELECT @SoLuongKho = SoLuong
	FROM KhoSach
	WHERE MaSach = @MaSach
	-- Lấy giá trị từ bảng Sach
	SELECT @SoLuongTrenKe = SoLuongTrenKe
	FROM Sach
	WHERE MaSach = @MaSach
	IF (SELECT COUNT(*) FROM inserted WHERE SoLuong < 0 OR DonGia < 0) > 0
	BEGIN
		RAISERROR('Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.', 16, 1)
	END
	-- Điều kiện nếu số lượng sách mua lớn hơn tổng số lượng trên kệ và trong kho
	ELSE IF @SoLuong > (@SoLuongKho + @SoLuongTrenKe)
	BEGIN
		RAISERROR ('Số lượng sách trong hóa đơn vượt quá số lượng trong kho và số lượng trên kệ', 16, 1)
	END
	-- Điều kiện nếu số lượng sách mua lớn hơn số lượng trên kệ nhưng nhỏ hơn tổng số lượng trên kệ và trong kho
	ELSE IF (@SoLuong > @SoLuongTrenKe AND @SoLuong <= (@SoLuongKho + @SoLuongTrenKe))
    BEGIN
        -- Cập nhật số lượng trên kệ và số lượng kho
        UPDATE Sach
        SET SoLuongTrenKe = 0
        WHERE MaSach = @MaSach
        
        UPDATE KhoSach
        SET SoLuong = (SELECT SoLuongKhoTrenKe FROM (
            SELECT (@SoLuongKho + @SoLuongTrenKe - @SoLuong) AS SoLuongKhoTrenKe
            FROM KhoSach ks
            INNER JOIN Sach s ON ks.MaSach = s.MaSach
            WHERE ks.MaSach = @MaSach
        ) t)
        WHERE MaSach = @MaSach

		INSERT INTO ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia)
        SELECT MaHoaDon, MaSach, SoLuong, DonGia
        FROM inserted
    END
	-- Điều kiện nếu số lượng sách mua nhỏ hơn hoặc bằng số lượng trên kệ 
	ELSE
	BEGIN
		UPDATE Sach
		SET SoLuongTrenKe = SoLuongTrenKe - @SoLuong
		WHERE MaSach = @MaSach

		INSERT INTO ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia)
        SELECT MaHoaDon, MaSach, SoLuong, DonGia
        FROM inserted
	END
END
GO

-- Trigger tăng số lượng sách khi thêm đơn nhập sách mới
CREATE TRIGGER TangSoLuongSachKho ON ChiTietNhapSach
AFTER INSERT AS
BEGIN
    DECLARE @MaSach NVARCHAR(10)
    DECLARE @SoLuong INT

    SELECT @MaSach = MaSach, @SoLuong = SoLuongNhap FROM inserted

    UPDATE KhoSach SET SoLuong = SoLuong + @SoLuong WHERE MaSach = @MaSach
END
GO

-- Check insert dữ liệu âm
CREATE TRIGGER CheckChiTietPhieuNhap ON ChiTietNhapSach
INSTEAD OF INSERT AS
	BEGIN
	IF (SELECT COUNT(*) FROM inserted WHERE SoLuongNhap < 0 OR DonGia < 0) > 0
	BEGIN
		RAISERROR('Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.', 16, 1)
	END
	ELSE
	BEGIN
		INSERT INTO ChiTietNhapSach(MaPhieuNhap, MaSach, SoLuongNhap, DonGia)
        SELECT MaPhieuNhap, MaSach, SoLuongNhap, DonGia
        FROM inserted
	END
END
GO

-- Trigger hạn chế sự trùng lặp dữ liệu của khách hàng
CREATE TRIGGER TrungLapKhachHang ON dbo.KhachHang
INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON;
    INSERT INTO KhachHang(MaKhachHang, HoTen, DiaChi, SoDienThoai)
    SELECT i.MaKhachHang, i.HoTen, i.DiaChi, i.SoDienThoai
    FROM inserted i
    LEFT JOIN KhachHang kh ON i.HoTen = kh.HoTen AND i.SoDienThoai = kh.SoDienThoai
    WHERE kh.HoTen IS NULL;
    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Khách hàng này đã tồn tại trong bảng Sách!', 16, 1);
    END
END
GO

-- Trigger hạn chế sự trùng lặp dữ liệu của Sach
CREATE TRIGGER TrungLapSach ON dbo.Sach
INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON;
    INSERT INTO Sach(MaSach, TenSach, TacGia, NXB, MaTheLoai, MaNCC, SoLuongTrenKe, DonGia)
    SELECT i.MaSach, i.TenSach, i.TacGia, i.NXB, i.MaTheLoai, i.MaNCC, i.SoLuongTrenKe, i.DonGia
    FROM inserted i
    LEFT JOIN Sach s ON i.TenSach=s.TenSach AND i.TacGia=s.TacGia
    WHERE s.TenSach IS NULL;
    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Sách này đã tồn tại trong bảng Sách!', 16, 1);
    END
	ELSE IF (SELECT COUNT(*) FROM inserted WHERE SoLuongTrenKe < 0 OR DonGia < 0) > 0
	BEGIN
		RAISERROR('Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.', 16, 1)
	END
END
GO

CREATE TRIGGER trgThemViTriSach
ON Sach
AFTER INSERT
AS
BEGIN
    DECLARE @MaViTri NVARCHAR(10)
    DECLARE @MaSach NVARCHAR(10)
    DECLARE @Ke INT
    DECLARE @Tang INT
    DECLARE @Ngan INT

    --SELECT TOP 1 @MaViTri = MaViTri FROM ViTriSach ORDER BY MaViTri DESC

    -- Tách lấy số cuối cùng trong mã vị trí sách để tăng lên 1
    --SET @MaViTri = 'VT' + RIGHT('000' + CAST(RIGHT(@MaViTri, 3) AS INT) + 1, 4)

	DECLARE @MaxMaViTri NVARCHAR(10) = (SELECT MAX(MaViTri) FROM ViTriSach)
	DECLARE @NextMaViTri NVARCHAR(10) = FORMAT(CAST(RIGHT(@MaxMaViTri, 3) AS INT) + 1, 'VT000')

	-- Nếu không có bản ghi nào trong bảng ViTriSach, thì gán mã vị trí đầu tiên là VT001
	IF @MaxMaViTri IS NULL SET @NextMaViTri = 'VT001'

    SELECT @MaSach = MaSach FROM inserted

    -- Giá trị tầng cao nhất là 3 và ngăn cao nhất là 4
    IF (@Tang > 3)
    BEGIN
        SET @Tang = 1
        SET @Ngan = 1
        SET @Ke = @Ke + 1
    END
	SET @Ke = (SELECT MAX(Ke) FROM ViTriSach)
	SET @Tang = (SELECT MAX(Tang) FROM ViTriSach WHERE Ke = @Ke)
	SET @Ngan = (SELECT MAX(Ngan) FROM ViTriSach WHERE Ke = @Ke AND Tang = @Tang)

	IF @Ke IS NULL
	BEGIN
		SET @Ke = 1
		SET @Tang = 1
		SET @Ngan = 1
	END
	ELSE IF @Tang < 3 AND @Ngan < 4
	BEGIN
		SET @Ngan = @Ngan + 1
	END
	ELSE IF @Tang < 3 AND @Ngan = 4
	BEGIN
		SET @Tang = @Tang + 1
		SET @Ngan = 1
	END
	ELSE IF @Tang = 3 AND @Ngan = 4
	BEGIN
		SET @Ke = @Ke + 1
		SET @Tang = 1
		SET @Ngan = 1
	END

	INSERT INTO ViTriSach(MaViTri, MaSach, Ke, Tang, Ngan)
	VALUES (@NextMaViTri, @MaSach, @Ke, @Tang, @Ngan)
END
GO

-------------------------------------- User Phân Quyền --------------------------------------

USE QLCHBS
GO

------------------- Tạo Phân quyền ----------------------------
-- Tư vấn
CREATE ROLE TuVan
GRANT SELECT, REFERENCES ON Sach TO TuVan
GRANT SELECT, REFERENCES ON TheLoai TO TuVan
GRANT SELECT, REFERENCES ON KhoSach TO TuVan
GRANT SELECT, REFERENCES ON ViTriSach TO TuVan
GRANT SELECT, REFERENCES ON KhachHang TO TuVan
GRANT SELECT, REFERENCES ON NhaCungCap TO TuVan

REVOKE EXECUTE TO TuVan
REVOKE SELECT TO TuVan

-- SÁCH
GRANT SELECT ON View_Book TO TuVan
GRANT SELECT ON ShowBookDetails TO TuVan
GRANT SELECT ON SearchBook TO TuVan
GRANT SELECT ON ClassifiedByGenre TO TuVan
GRANT EXECUTE ON ClassifiedByPrice TO TuVan
GRANT SELECT ON ClassifiedBySupplier TO TuVan
GRANT SELECT ON ClassifiedByPublishing TO TuVan

-- THỂ LOẠI
GRANT SELECT ON View_Genre TO TuVan
GRANT EXECUTE ON ShowGenreDetails TO TuVan
GRANT SELECT ON SearchGenre TO TuVan
GRANT SELECT ON View_GenreHighestNumber TO TuVan
GRANT SELECT ON View_GenreLeastNumber TO TuVan
GRANT SELECT ON View_GenreBestSell TO TuVan
GRANT SELECT ON View_GenreWorstSell TO TuVan

-- KHO SÁCH
GRANT SELECT ON View_Inventory TO TuVan
GRANT EXECUTE ON ShowInventoryDetails TO TuVan
GRANT SELECT ON SearchInventory TO TuVan
GRANT SELECT ON View_MostInStock TO TuVan
GRANT SELECT ON View_LeastInStock TO TuVan

-- VỊ TRÍ
GRANT SELECT ON View_BookLocation TO TuVan
GRANT EXECUTE ON ShowBookLocationDetails TO TuVan
GRANT SELECT ON SearchBookLocation TO TuVan
GRANT EXECUTE ON ClassifiedByShelf TO TuVan
GRANT SELECT ON View_BookBestSell TO TuVan
GRANT SELECT ON View_BookWorstSell TO TuVan

-- KHÁCH HÀNG
GRANT SELECT ON View_Customer TO TuVan
GRANT SELECT ON ShowCustomerDetails TO TuVan
GRANT SELECT ON SearchCustomer TO TuVan
GRANT SELECT ON View_CustomerMostBuy TO TuVan
GRANT SELECT ON View_CustomerLeastBuy TO TuVan

-- NHÀ CUNG CẤP
GRANT SELECT ON View_Supplier TO TuVan
GRANT SELECT ON ShowSupplierDetails TO TuVan
GRANT SELECT ON SearchSupplier TO TuVan

GRANT EXECUTE ON CheckAccount_Phone TO TuVan
GRANT EXECUTE ON CheckAccount_Password TO TuVan
GRANT EXECUTE ON UpdateAccount TO TuVan
GRANT EXECUTE ON updateEmployee TO TuVan
GRANT EXECUTE ON ShowStaffInformation TO TuVan
GO


--------------------------------------------------
-- Thu Ngân
CREATE ROLE ThuNgan
GRANT SELECT, REFERENCES ON Sach TO ThuNgan
GRANT SELECT, REFERENCES ON TheLoai TO ThuNgan
GRANT SELECT, REFERENCES ON KhoSach TO ThuNgan
GRANT SELECT, REFERENCES ON ViTriSach TO ThuNgan
GRANT SELECT, REFERENCES ON KhachHang TO ThuNgan
GRANT SELECT, REFERENCES ON NhaCungCap TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON HoaDon TO ThuNgan
GRANT SELECT, INSERT, UPDATE, REFERENCES ON ChiTietHoaDon TO ThuNgan

REVOKE EXECUTE TO ThuNgan
REVOKE SELECT TO ThuNgan

-- SÁCH
GRANT SELECT ON View_Book TO ThuNgan
GRANT SELECT ON ShowBookDetails TO ThuNgan
GRANT SELECT ON SearchBook TO ThuNgan
GRANT SELECT ON ClassifiedByGenre TO ThuNgan
GRANT EXECUTE ON ClassifiedByPrice TO ThuNgan
GRANT SELECT ON ClassifiedBySupplier TO ThuNgan
GRANT SELECT ON ClassifiedByPublishing TO ThuNgan

-- THỂ LOẠI
GRANT SELECT ON View_Genre TO ThuNgan
GRANT EXECUTE ON ShowGenreDetails TO ThuNgan
GRANT SELECT ON SearchGenre TO ThuNgan
GRANT SELECT ON View_GenreHighestNumber TO ThuNgan
GRANT SELECT ON View_GenreLeastNumber TO ThuNgan
GRANT SELECT ON View_GenreBestSell TO ThuNgan
GRANT SELECT ON View_GenreWorstSell TO ThuNgan

-- KHO SÁCH
GRANT SELECT ON View_Inventory TO ThuNgan
GRANT EXECUTE ON ShowInventoryDetails TO ThuNgan
GRANT SELECT ON SearchInventory TO ThuNgan
GRANT SELECT ON View_MostInStock TO ThuNgan
GRANT SELECT ON View_LeastInStock TO ThuNgan
 
-- VỊ TRÍ
GRANT SELECT ON View_BookLocation TO ThuNgan
GRANT EXECUTE ON ShowBookLocationDetails TO ThuNgan
GRANT SELECT ON SearchBookLocation TO ThuNgan
GRANT EXECUTE ON ClassifiedByShelf TO ThuNgan
GRANT SELECT ON View_BookBestSell TO ThuNgan
GRANT SELECT ON View_BookWorstSell TO ThuNgan
 
-- KHÁCH HÀNG
GRANT SELECT ON View_Customer TO ThuNgan
GRANT SELECT ON ShowCustomerDetails TO ThuNgan
GRANT SELECT ON SearchCustomer TO ThuNgan
GRANT SELECT ON View_CustomerMostBuy TO ThuNgan
GRANT SELECT ON View_CustomerLeastBuy TO ThuNgan

-- NHÀ CUNG CẤP
GRANT SELECT ON View_Supplier TO ThuNgan
GRANT SELECT ON ShowSupplierDetails TO ThuNgan
GRANT SELECT ON SearchSupplier TO ThuNgan

-- HÓA ĐƠN VÀ CHI TIẾT HÓA ĐƠN
GRANT SELECT ON View_Bill TO ThuNgan
GRANT SELECT ON View_BillDetails TO ThuNgan
GRANT EXECUTE ON ShowAllBills TO ThuNgan
GRANT EXECUTE ON ShowAllBillDetails TO ThuNgan
GRANT SELECT ON SearchBill TO ThuNgan
GRANT SELECT ON SearchBillDetails TO ThuNgan
GRANT EXECUTE ON ClassifiedBillByStaff TO ThuNgan
GRANT EXECUTE ON AddBill TO ThuNgan
GRANT EXECUTE ON UpdateBill TO ThuNgan
GRANT EXECUTE ON AddBillDetails TO ThuNgan
GRANT EXECUTE ON UpdateBillDetails TO ThuNgan

GRANT EXECUTE ON CheckAccount_Phone TO ThuNgan
GRANT EXECUTE ON CheckAccount_Password TO ThuNgan
GRANT EXECUTE ON UpdateAccount TO ThuNgan
GRANT EXECUTE ON updateEmployee TO ThuNgan
GRANT EXECUTE ON ShowStaffInformation TO ThuNgan
GO


--------------------------------------------------
-- Thủ kho
CREATE ROLE ThuKho
GRANT SELECT, INSERT, UPDATE, REFERENCES ON Sach TO ThuKho
GRANT SELECT, INSERT, UPDATE, REFERENCES ON KhoSach TO ThuKho
GRANT SELECT, INSERT, UPDATE, REFERENCES ON TheLoai TO ThuKho
GRANT SELECT, UPDATE, REFERENCES ON ViTriSach TO ThuKho
GRANT SELECT, REFERENCES ON NhaCungCap TO ThuKho
GRANT SELECT, REFERENCES ON PhieuNhap TO ThuKho
GRANT SELECT, REFERENCES ON ChiTietNhapSach TO ThuKho

REVOKE EXECUTE TO ThuKho
REVOKE SELECT TO ThuKho

-- SÁCH
GRANT SELECT ON View_Book TO ThuKho
GRANT SELECT ON ShowBookDetails TO ThuKho
GRANT SELECT ON SearchBook TO ThuKho
GRANT SELECT ON ClassifiedByGenre TO ThuKho
GRANT EXECUTE ON ClassifiedByPrice TO ThuKho
GRANT SELECT ON ClassifiedBySupplier TO ThuKho
GRANT SELECT ON ClassifiedByPublishing TO ThuKho
GRANT EXECUTE ON AddBook TO ThuKho
GRANT EXECUTE ON AddInventory TO ThuKho
GRANT EXECUTE ON UpdateBook TO ThuKho
GRANT EXECUTE ON UpdateInventory TO ThuKho

-- THỂ LOẠI
GRANT SELECT ON View_Genre TO ThuKho
GRANT EXECUTE ON ShowGenreDetails TO ThuKho
GRANT SELECT ON SearchGenre TO ThuKho
GRANT SELECT ON View_GenreHighestNumber TO ThuKho
GRANT SELECT ON View_GenreLeastNumber TO ThuKho
GRANT SELECT ON View_GenreBestSell TO ThuKho
GRANT SELECT ON View_GenreWorstSell TO ThuKho
GRANT EXECUTE ON AddGenre TO ThuKho
GRANT EXECUTE ON UpdateGenre TO ThuKho

-- KHO SÁCH
GRANT SELECT ON View_Inventory TO ThuKho
GRANT EXECUTE ON ShowInventoryDetails TO ThuKho
GRANT SELECT ON SearchInventory TO ThuKho
GRANT SELECT ON View_MostInStock TO ThuKho
GRANT SELECT ON View_LeastInStock TO ThuKho
GRANT EXECUTE ON UpdateInventory TO ThuKho
GRANT EXECUTE ON AddInventory TO ThuKho

-- VỊ TRÍ
GRANT SELECT ON View_BookLocation TO ThuKho
GRANT EXECUTE ON ShowBookLocationDetails TO ThuKho
GRANT SELECT ON SearchBookLocation TO ThuKho
GRANT EXECUTE ON ClassifiedByShelf TO ThuKho
GRANT SELECT ON View_BookBestSell TO ThuKho
GRANT SELECT ON View_BookWorstSell TO ThuKho
GRANT EXECUTE ON UpdateBookLocation TO ThuKho

-- NHÀ CUNG CẤP
GRANT SELECT ON View_Supplier TO ThuKho
GRANT SELECT ON ShowSupplierDetails TO ThuKho
GRANT SELECT ON SearchSupplier TO ThuKho

-- PHIẾU NHẬP VÀ CHI TIẾT PHIẾU NHẬP
GRANT SELECT ON View_Receipt TO ThuKho
GRANT SELECT ON View_ReceiptDetails TO ThuKho
GRANT EXECUTE ON ShowReceipt TO ThuKho
GRANT EXECUTE ON ShowReceiptDetails TO ThuKho
GRANT SELECT ON SearchReceipt TO ThuKho
GRANT SELECT ON SearchReceiptDetails TO ThuKho

GRANT EXECUTE ON CheckAccount_Phone TO ThuKho
GRANT EXECUTE ON CheckAccount_Password TO ThuKho
GRANT EXECUTE ON UpdateAccount TO ThuKho
GRANT EXECUTE ON updateEmployee TO ThuKho
GRANT EXECUTE ON ShowStaffInformation TO ThuKho
GO

-------------------------------------- Thêm dữ liệu vào bảng --------------------------------------

USE QLCHBS
GO

-- Thêm dữ liệu vào bảng thể loại
INSERT INTO TheLoai (MaTheLoai, TenTheLoai, MoTa)
VALUES
	('TL001', N'Truyện thiếu nhi', N'Sách dành cho trẻ em'),
	('TL002', N'Tiểu thuyết', N'Sách tường thuật một câu chuyện'),
	('TL003', N'Sách tự phát triển', N'Sách giúp độc giả phát triển bản thân'),
	('TL004', N'Truyện tranh', N'Truyện được tường thuật bằng hình ảnh'),
	('TL005', N'Sách học tập', N'Sách giúp độc giả học tập tốt hơn'),
	('TL006', N'Văn học Phương Đông', N'Sách về văn học của các quốc gia châu Á'),
	('TL007', N'Văn học', N'Sách về văn học nói chung'),
	('TL008', N'Tự truyện', N'Sách tường thuật câu chuyện cuộc đời của người viết'),
	('TL009', N'Lịch sử', N'Sách về lịch sử thế giới'),
	('TL010', N'Sách kinh doanh', N'Sách về kinh doanh'),
	('TL011', N'Tâm lý học', N'Sách về tâm lý'),
	('TL012', N'Văn học Pháp', N'Sách về văn học của Pháp'),
	('TL013', N'Văn học Nga', N'Sách về văn học của Nga')

GO

-- Thêm dữ liệu vào bảng Nhà cung cấp
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai) 
VALUES 
	('NCC001', N'Nhà sách Trẻ', N'50 Lê Văn Việt, Quận 9, TP. Hồ Chí Minh', '0909123456'),
	('NCC002', N'Nhà sách Kim Đồng', N'123 Nguyễn Văn Cừ, Quận 5, TP. Hồ Chí Minh', '0909987654'),
	('NCC003', N'Nhà sách Phương Nam', N'456 Nguyễn Tri Phương, Quận 10, TP. Hồ Chí Minh', '0909123456'),
	('NCC004', N'Nhà sách Đại Học', N'Khu phố 6, Linh Trung, Thủ Đức, TP. Hồ Chí Minh', '0909887766'),
	('NCC005', N'Nhà sách Fahasa', N'40-42 Hai Bà Trưng, Quận 1, TP. Hồ Chí Minh', '0909887766'),
	('NCC006', N'Nhà sách Tiki', N'235 Điện Biên Phủ, Quận Bình Thạnh, TP. Hồ Chí Minh', '0909988777')
GO

-- Thêm dữ liệu vào bảng Sách
INSERT INTO Sach (MaSach, TenSach, TacGia, NXB, MaTheLoai, MaNCC, SoLuongTrenKe, DonGia)
VALUES
	('MS001', N'Dế Mèn Phiêu Lưu Ký', N'Tô Hoài', N'Kim Đồng', 'TL001', 'NCC001', 20, 45000.00),
	('MS002', N'Nhà Giả Kim', N'Paulo Coelho', N'Nhã Nam', 'TL002', 'NCC002', 30, 90000.00),
	('MS003', N'Đắc Nhân Tâm', N'Dale Carnegie', N'NXB Thế Giới', 'TL003', 'NCC003', 40, 110000.00),
	('MS004', N'Tôi Tài Giỏi, Bạn Cũng Thế', N'Adam Khoo', N'NXB Trẻ', 'TL003', 'NCC003', 25, 75000.00),
	('MS005', N'Mắt Biếc', N'Nguyễn Nhật Ánh', N'Kim Đồng', 'TL002', 'NCC001', 50, 55000.00),
	('MS006', N'Chú bé loài khỉ', N'Edgar Rice Burroughs', N'NXB Thế Giới', 'TL004', 'NCC004', 15, 65000.00),
	('MS007', N'Tôi là người bị thương', N'Hwang Chul Soon', N'NXB Văn hóa Thông tin', 'TL005', 'NCC005', 35, 120000.00),
	('MS008', N'Nghìn lẻ một đêm', N'Antoine Galland', N'NXB Tổng Hợp TPHCM', 'TL006', 'NCC006', 10, 95000.00),
	('MS009', N'Bí mật của người giàu', N'T. Harv Eker', N'NXB Thế Giới', 'TL003', 'NCC006', 20, 85000.00),
	('MS010', N'Chú chó thông minh', N'John Grogan', N'NXB Hội Nhà Văn', 'TL002', 'NCC005', 45, 60000.00),
	('MS011', N'Tắt đèn', N'Ngô Tất Tố', N'Kim Đồng', 'TL007', 'NCC002', 30, 40000.00),
	('MS012', N'Nhật ký của Anne Frank', N'Anne Frank', N'NXB Thế Giới', 'TL008', 'NCC001', 15, 45000.00),
	('MS013', N'Lược sử thế giới', N'Will Durant', N'NXB Văn học', 'TL009', 'NCC001', 25, 125000.00),
	('MS014', N'Cuốn theo chiều gió', N'Margaret Mitchell', N'NXB Hội Nhà Văn', 'TL002', 'NCC003', 25, 95000.00),
	('MS015', N'Phía đông vườn địa đàng', N'Nguyễn Nhật Ánh', N'NXB Trẻ', 'TL002', 'NCC004', 20, 60000.00),
	('MS016', N'Truyền Kỳ Về Mỹ', N'Alex Haley', N'NXB Hội Nhà Văn', 'TL008', 'NCC005', 10, 70000.00),
	('MS017', N'Tự tin để thành công', N'Brian Tracy', N'NXB Thế Giới', 'TL003', 'NCC001', 40, 95000.00),
	('MS018', N'Đắc nhân tâm - Bản dịch và chú giải mới', N'Dale Carnegie', N'NXB Hồng Đức', 'TL003', 'NCC002', 50, 125000.00),
	('MS019', N'Truyện Kiều', N'Nguyễn Du', N'NXB Văn học', 'TL007', 'NCC003', 15, 45000.00),
	('MS020', N'Sự im lặng của con bọ', N'Jerry Spinelli', N'NXB Trẻ', 'TL002', 'NCC004', 25, 70000.00),
	('MS021', N'Cô gái đến từ hôm qua', N'Jude Deveraux', N'Nhã Nam', 'TL002', 'NCC004', 30, 85000.00),
	('MS022', N'Thành công không phải là tình cờ', N'Malcolm Gladwell', N'NXB Lao động', 'TL003', 'NCC005', 20, 90000.00),
	('MS023', N'Tội ác và hình phạt', N'Fyodor Dostoevsky', N'NXB Văn học', 'TL013', 'NCC006', 10, 110000.00),
	('MS024', N'Phản bội', N'Scott Turow', N'NXB Văn học', 'TL002', 'NCC006', 15, 65000.00),
	('MS025', N'Tắt đèn và chỉ là thế thôi', N'Nguyễn Ngọc Tư', N'NXB Văn học', 'TL007', 'NCC001', 20, 60000.00),
	('MS026', N'Đi tìm lẽ sống', N'Viktor E. Frankl', N'NXB Trẻ', 'TL011', 'NCC004', 25, 85000.00),
	('MS027', N'Nỗi buồn chiến tranh', N'Bảo Ninh', N'Kim Đồng', 'TL007', 'NCC001', 15, 55000.00),
	('MS028', N'Sự im lặng của Bầy cừu', N'Thomas Harris', N'Nhã Nam', 'TL002', 'NCC002', 20, 80000.00),
	('MS029', N'Giải mã giấc mơ', N'Sigmund Freud', N'NXB Hồng Đức', 'TL011', 'NCC003', 30, 95000.00),
	('MS030', N'Những người khốn khổ', N'Victor Hugo', N'NXB Văn học', 'TL012', 'NCC001', 10, 120000.00),
	('MS031', N'Đừng lùi bước trước khó khăn', N'Jack Canfield', N'NXB Thế giới', 'TL003', 'NCC005', 25, 95000.00),
	('MS032', N'Cô gái đến từ hôm qua', N'Nguyễn Nhật Ánh', N'NXB Trẻ', 'TL002', 'NCC003', 30, 60000.00),
	('MS033', N'Phía trước là bầu trời', N'Alice Sebold', N'NXB Thế giới', 'TL002', 'NCC006', 35, 75000.00),
	('MS034', N'Cẩm nang sống tốt trong công việc', N'Stephen Covey', N'NXB Lao động', 'TL003', 'NCC002', 25, 105000.00),
	('MS035', N'Sức mạnh của ngôn từ', N'Dale Carnegie', N'NXB Thế giới', 'TL003', 'NCC001', 30, 90000.00),
	('MS036', N'Đi tìm lẽ sống 2', N'Viktor E. Frankl', N'NXB Thế giới', 'TL011', 'NCC001', 15, 100000.00),
	('MS037', N'Hai số phận', N'Charles Dickens', N'NXB Văn học', 'TL007', 'NCC004', 20, 65000.00),
	('MS038', N'Bố già 2', N'Mario Puzo', N'NXB Văn học', 'TL002', 'NCC005', 15, 90000.00),
	('MS039', N'Phong Cách Cá Nhân Hóa', N'Nguyễn Minh Thắng', N'NXB Thế Giới', 'TL010', 'NCC006', 15, 125000.00),
	('MS040', N'Làm Giàu Không Khó', N'Phạm Thành Long', N'NXB Kim Đồng', 'TL003', 'NCC001', 20, 89000.00),
	('MS041', N'Khởi Nghiệp Cùng Cha Mẹ', N'Nguyễn Văn Nam', N'NXB Trẻ', 'TL010', 'NCC002', 25, 95000.00),
	('MS042', N'Chúa tể những chiếc nhẫn', N'J.R.R. Tolkien', N'NXB Hội Nhà Văn', 'TL007', 'NCC003', 20, 120000.00),
	('MS043', N'Số đỏ', N'Vũ Trọng Phụng', N'NXB Hội Nhà Văn', 'TL007', 'NCC002', 30,25000.00),
	('MS044', N'Tôi Tài Giỏi Bạn Cũng Thế ', N'Adam khoo', N'NXB Kim Đồng','TL012', 'NCC006',20 ,50000.00 ),
	('MS045', N'Những người khốn khổ', N'Victor Hugo', N'NXB trẻ','TL012', 'NCC001',25, 75000.00 ),
	('MS046', N'Bí mật của người giàu', N'T. Harv Eker', N'NXB Kim Đồng','TL012','NCC005',35,50000.00),
	('MS047', N'Đời ngắn đừng ngủ dài', N'Robin Sharma', N'NXB Thế giới','TL013','NCC006',35,80000.00),
	('MS048', N'Người giàu nhất thành Babylon', N' George S. Clason', N'NXB Lao động','TL013', 'NCC002',20, 120000.00),
	('MS049', N'Tâm lý học đám đông', N' Gustave Le Bon', N'NXB Trẻ','TL011', 'NCC002',20, 120000.00),
	('MS050', N'Thuật giải quyết khó khăn', N' David J. Schwartz', N'NXB Lao động','TL010','NCC002',25 ,100000.00 ),
	('MS051', N'Tuổi trẻ đáng giá bao nhiêu', N' Jack Ma', N'NXB Hội Nhà Văn','TL008','NCC005',35 ,89000.00 ),
	('MS052', N'Sức mạnh của giới hạn', N'Robert Greene', N'NXB Kim Đồng','TL009','NCC002', 15 , 120000.00),
	('MS053', N'Đất rừng phương Nam', N'Tôi đưa em đi chơi', N'NXB Hội Nhà Văn','TL006', 'NCC004',15 ,90000.00 ),
	('MS054', N'Dế Mèn phiêu lưu ký', N'Tô Hoài', N'NXB Thế Giới', 'TL007', 'NCC003',20 , 86000.00),
	('MS055', N'Dumb Luck', N'Vũ Trọng Phụng', N'NXB Lao động', 'TL006', 'NCC002', 35,74000.00 ),
	('MS056', N'Tôi thấy hoa vàng trên cỏ xanh', N'Bảo Ninh', N'NXB Hội Nhà Văn','TL006', 'NCC005', 25 ,79000.00 ),
	('MS057', N'Cho tôi xin một vé đi tuổi thơ', N'Nguyễn Nhật Ánh', N'','TL008', 'NCC005', 30 ,89000.00 ),
	('MS058', N'Tôi đưa em đi chơi', N'Nguyễn Nhật Ánh', N'','TL002', 'NCC004', 15, 50000.00),
	('MS059', N'Mắt biếc', N'Nguyễn Nhật Ánh', N'NXB Hồng Đức','TL006', 'NCC006', 20 ,680000.00 ),
	('MS060', N'Truyện Kiều', N' Nguyễn Du', N'NXB Kim Đồng','TL007', 'NCC001',20 , 81000.00)
GO

-- Thêm dữ liệu vào bảng Kho sách
INSERT INTO KhoSach(MaSach, SoLuong)
VALUES
	('MS001', 40),
	('MS002', 32),
	('MS003', 41),
	('MS004', 25),
	('MS005', 27),
	('MS006', 29),
	('MS007', 33),
	('MS008', 45),
	('MS009', 21),
	('MS010', 19),
	('MS011', 28),
	('MS012', 22),
	('MS013', 25),
	('MS014', 18),
	('MS015', 15),
	('MS016', 22),
	('MS017', 29),
	('MS018', 31),
	('MS019', 32),
	('MS020', 35),
	('MS021', 41),
	('MS022', 44),
	('MS023', 24),
	('MS024', 25),
	('MS025', 21),
	('MS026', 17),
	('MS027', 16),
	('MS028', 36),
	('MS029', 37),
	('MS030', 21),
	('MS031', 29),
	('MS032', 28),
	('MS033', 43),
	('MS034', 45),
	('MS035', 25),
	('MS036', 18),
	('MS037', 12),
	('MS038', 14),
	('MS039', 11),
	('MS040', 23),
	('MS041', 26),
	('MS042', 13),
	('MS043', 26),
	('MS044', 16),
	('MS045', 18),
	('MS046', 29),
	('MS047', 30),
	('MS048', 31),
	('MS049', 17),
	('MS050', 43),
	('MS051', 24),
	('MS052', 26),
	('MS053', 45),
	('MS054', 37),
	('MS055', 38),
	('MS056', 26),
	('MS057', 21),
	('MS058', 22),
	('MS059', 19),
	('MS060', 18)

GO

-- Thêm dữ liệu vào bảng vị trí thể loại 
INSERT INTO ViTriSach(MaViTri, MaSach, Ke, Tang, Ngan)
VALUES 
--	('VT001','MS001', 1, 1, 1),
	('VT002','MS002', 1, 1, 2),
	('VT003','MS003', 1, 1, 3),
	('VT004','MS004', 1, 1, 4),
	('VT005','MS005', 1, 2, 1),
	('VT006','MS006', 1, 2, 2),
	('VT007','MS007', 1, 2, 3),
	('VT008','MS008', 1, 2, 4),
	('VT009','MS009', 1, 3, 1),
	('VT010','MS010', 1, 3, 2),
	('VT011','MS011', 1, 3, 3),
	('VT012','MS012', 1, 3, 4),
	('VT013','MS013', 2, 1, 1), 
	('VT014','MS014', 2, 1, 2),
	('VT015','MS015', 2, 1, 3),
	('VT016','MS016', 2, 1, 4),
	('VT017','MS017', 2, 2, 1),
	('VT018','MS018', 2, 2, 2),
	('VT019','MS019', 2, 2, 3),
	('VT020','MS020', 2, 2, 4),
	('VT021','MS021', 2, 3, 1),
	('VT022','MS022', 2, 3, 2),
	('VT023','MS023', 2, 3, 3),
	('VT024','MS024', 2, 3, 4),
	('VT025','MS025', 3, 1, 1),
	('VT026','MS026', 3, 1, 2),
	('VT027','MS027', 3, 1, 3),
	('VT028','MS028', 3, 1, 4),
	('VT029','MS029', 3, 2, 1),
	('VT030','MS030', 3, 2, 2),
	('VT031','MS031', 3, 2, 3),
	('VT032','MS032', 3, 2, 4),
	('VT033','MS033', 3, 3, 1),
	('VT034','MS034', 3, 3, 2),
	('VT035','MS035', 3, 3, 3),
	('VT036','MS036', 3, 3, 4),
	('VT037','MS037', 4, 1, 1),
	('VT038','MS038', 4, 1, 2),
	('VT039','MS039', 4, 1, 3),
	('VT040','MS040', 4, 1, 4),
	('VT041','MS041', 4, 2, 1), 
	('VT042','MS042', 4, 2, 2)
GO

-- Thêm dữ liệu vào bảng Phân loại nhân viên
INSERT INTO PhanLoaiNhanVien (MaChucVu, TenChucVu, MoTaCongViec, Luong) 
VALUES 
	('CV001', N'Quản lý', N'Quản lý nhân viên và hoạt động của cửa hàng', 13000000),
	('CV002', N'Nhân viên thu ngân', N'Tính tiền cho khách hàng mua sách', 10400000),
	('CV003', N'Nhân viên quản lý kho', N'Quản lý kho sách và nhập xuất hàng hóa', 9100000),
	('CV004', N'Nhân viên tư vấn', N'Giúp đỡ khách hàng khi lựa chọn sách', 7800000),
	('CV005', N'Nhân viên bảo vệ', N'Trông coi xe và giữ gìn trật tự cửa hàng', 5200000)
GO

-- Thêm dữ liệu vào bảng Nhân viên
INSERT INTO NhanVien (MaNhanVien, HoTen, NgaySinh, GioiTinh, MaChucVu, DiaChi, SoDienThoai, HoatDong) 
VALUES 
	('NV001', N'Trần Quang Xuân', '1990-01-01', N'Nam', 'CV001', N'Hà Nội', '0123456789', N'Làm việc'),
	('NV002', N'Trần Thị Á Tiên', '1995-05-10', N'Nữ', 'CV002', N'Hồ Chí Minh', '0987654321', N'Làm việc'),
	('NV003', N'Trịnh Trần Minh Tuấn', '1988-08-08', N'Nam', 'CV002', N'Đà Nẵng', '0912345678', N'Làm việc'),
	('NV004', N'Nguyễn Quang Huy', '1985-05-10', N'Nam', 'CV002', N'Hồ Chí Minh', '0987654321', N'Làm việc'),
	('NV005', N'Lê Thị Riêng', '1998-08-08', N'Nữ', 'CV002', N'Đà Nẵng', '0912345678', N'Làm việc'),
	('NV006', N'Phạm Tuấn Minh', '1995-01-09', N'Nam', 'CV002', N'Hà Nội', '0563259876', N'Làm việc'),
	('NV007', N'Lê Nguyễn Thiên Tứ', '1995-05-10', N'Nam', 'CV002', N'Hồ Chí Minh', '0945319851', N'Làm việc'),
	('NV008', N'Trịnh Yến Lan', '1988-08-08', N'Nữ', 'CV003', N'Đà Nẵng', '0231985647', N'Làm việc'),
	('NV009', N'Phạm Minh Huy', '1985-05-10', N'Nam', 'CV003', N'Hồ Chí Minh', '0251032689', N'Làm việc'),
	('NV010', N'Lê Văn Điểu', '1998-08-08', N'Nam', 'CV003', N'Đà Nẵng', '0351265987', N'Làm việc'),
    ('NV011', N'Trần Thị Mai', '1995-03-15', N'Nữ', 'CV003', N'Hà Nội', '0987654321', N'Làm việc'),
    ('NV012', N'Lê Văn An', '1988-09-10', N'Nam', 'CV004', N'TP.HCM', '0123456789', N'Làm việc'),
    ('NV013', N'Nguyễn Thị Hằng', '1992-07-25', N'Nữ', 'CV004', N'Hải Phòng', '0967891234', N'Làm việc'),
    ('NV014', N'Phạm Đức Tuấn', '1993-11-20', N'Nam', 'CV005', N'Đà Nẵng', '0912345678', N'Làm việc'),
    ('NV015', N'Trần Thanh Tùng', '1991-05-05', N'Nam', 'CV005', N'Hà Nội', '0987123456', N'Làm việc'),
    ('NV016', N'Đỗ Thị Thúy', '1994-08-08', N'Nữ', 'CV004', N'TP.HCM', '0978123456', N'Làm việc'),
    ('NV017', N'Nguyễn Đức Huy', '1990-12-25', N'Nam', 'CV005', N'Hà Nội', '0945123456', N'Làm việc'),
    ('NV018', N'Vũ Thị Minh Anh', '1996-01-30', N'Nữ', 'CV004', N'Hải Phòng', '0909123456', N'Làm việc'),
    ('NV019', N'Hoàng Văn Nam', '1989-06-18', N'Nam', 'CV005', N'TP.HCM', '0918123456', N'Làm việc'),
    ('NV020', N'Lương Thị Loan', '1997-04-12', N'Nữ', 'CV003', N'Đà Nẵng', '0989123456', N'Làm việc')
GO

-- Thêm dữ liệu vào bảng Đăng nhập
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV001','NV001', 'NV001')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV002','NV002', 'NV002')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV003','NV003', 'NV003')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV004','NV004', 'NV004')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV005','NV005', 'NV005')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV006','NV006', 'NV006')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV007','NV007', 'NV007')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV008','NV008', 'NV008')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV009','NV009', 'NV009')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV010','NV010', 'NV010')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV011','NV011', 'NV011')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV012','NV012', 'NV012')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV013','NV013', 'NV013')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV016','NV016', 'NV016')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV018','NV018', 'NV018')
INSERT INTO DangNhap (MaNhanVien, TenDangNhap, MatKhau) VALUES ('NV020','NV020', 'NV020')

-- Thêm dữ liệu vào bảng lương
INSERT INTO Luong(MaNhanVien, SoNgayLamViec, Thuong)
VALUES 
	('NV001', 26, 500000),
	('NV002', 20, 200000),
	('NV003', 26, 100000),
	('NV004', 23, 500000),
	('NV005', 26, 100000),
	('NV006', 26, 100000),
	('NV007', 21, 200000),
	('NV008', 26, 100000),
	('NV009', 26, 100000),
	('NV010', 25, 300000),
    ('NV011', 22, 500000),
    ('NV012', 24, 700000),
    ('NV013', 26, 100000),
    ('NV014', 20, 400000),
    ('NV015', 22, 550000),
    ('NV016', 24, 650000),
    ('NV017', 26, 800000),
    ('NV018', 20, 350000),
    ('NV019', 22, 450000),
    ('NV020', 24, 550000)
GO

-- Thêm dữ liệu vào bảng Khách Hàng
INSERT INTO KhachHang (MaKhachHang, HoTen, DiaChi, SoDienThoai) VALUES
    ('KH001', N'Nguyễn Văn Quang', N'108 Nguyễn Văn Trỗi, Quận 1, TP.HCM', '0901234567'),
    ('KH002', N'Trần Thị Thu Hoài', N'201 Đường 30/4, Thành Phố Vũng Tàu , Tỉnh Bà Rịa Vũng Tàu', '0902345678'),
    ('KH003', N'Phạm Minh Quân', N'2/3 đường 3/2, Quận 10, TP.HCM', '0903456789'),
	('KH004', N'Phạm Minh Dương', N'111 đường Lương Chí Hiếu, Quận 8, TP.HCM', '0903456789'),
	('KH005', N'Nguyễn Ngọc Trà My', N'1 Đường Lý Thường Kiệt , Quận 10, TP.HCM', '0918177174'),
    ('KH006', N'Trần Tâm Thanh', N'48 Trường Sa, Quận 2, TP.HCM', '0903335678'),
    ('KH007', N'Phạm Chí Hào', N'12 Đường Võ Thị Sáu, Quận Bình Thạnh, TP.HCM', '0347245253'),
	('KH008', N'Tạ Minh Hoàng', N'606 Đường Lạc Long Quân, Quận 5, TP.HCM', '0902220394'),
	('KH009', N'Nguyễn Ngọc Ái Nhi', N'123 Đường Đống Đa, Quận 1, TP.HCM', '0901234567'),
    ('KH010', N'Đào Duy Phát', N'798 Đường Âu Cơ, Quận 5, TP.HCM', '0772658899'),
    ('KH011', N'Phạm Minh Châu', N'789 Đường 3/2, Quận 3, TP.HCM', '0347956982'),
	('KH012', N'Lê Hoàng Long', N'828 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', '0988776225'),
	('KH013', N'Le Dương Hải Nhi', N'716 Đường Lý Thải Tổ, Quận 10, TP.HCM', '09018882229'),
    ('KH014', N'Trần Tuấn Anh', N'1 đường 3/2, Quận 2, TP.HCM', '0347072662'),
	('KH015', N'Lê Thị Phương Thảo', N'444 Nguyễn Bỉnh Khiêm, Quận 1, TP.HCM','0110214144'),
	('KH016', N'Nguyễn Văn Nam', N'123 Lý Thái Tổ, Quận 10, TP.HCM','0439530464'),
	('KH017', N'Trần Thị Thúy Hằng', N'456 Trần Hưng Đạo, Quận 5, TP.HCM', '0691279345'),
	('KH018', N'Phạm Văn Đức', N'789 Nguyễn Trãi, Quận 1, TP.HCM', ' 0843195399'),
	('KH019', N'Lê Thị Kim Liên', N'567 Huỳnh Tấn Phát, Quận 7, TP.HCM','0475613815'),
	('KH020', N'Nguyễn Văn Hiển', N'999 Trần Não, Quận 2, TP.HCM', '0846668776'),
	('KH021', N'Võ Thị Kim Ngân', N'444 Nguyễn Thái Bình, Quận 1, TP.HCM', ' 0542807207'),
	('KH022', N'Nguyễn Đức Anh', N'123 Nguyễn Thị Minh Khai, Quận 3, TP.HCM',' 0678189579'),
	('KH023', N'Đỗ Thị Minh Hương', N'456 Điện Biên Phủ, Quận 10, TP.HCM',' 0217173800'),
	('KH024', N'Trần Đình Toàn', N'789 Lê Văn Lương, Quận 7, TP.HCM', '0851014460'),
	('KH025', N'Phạm Thị Hồng Loan', N'567 Nguyễn Văn Cừ, Quận 5, TP.HCM', '0442114095'),
	('KH026', N'Lê Thị Minh Tuyết', N'123 Nguyễn Cư Trinh, Quận 1, TP.HCM','0713697025'),
	('KH027', N'Phạm Văn Hoàn', N'456 Cao Thắng, Quận 3, TP.HCM','0149263535' ),
	('KH028', N'Nguyễn Thị Bích Trâm', N'789 Điện Biên Phủ, Quận 10, TP.HCM','0469641826'),
	('KH029', N'Võ Văn Phước', N'567 Lê Duẩn, Quận 1, TP.HCM','0251202206'),
	('KH030', N'Trần Thị Hồng Nhung', N'999 Nguyễn Văn Cừ, Quận 5, TP.HCM','0567695893'),
	('KH031', N'Phan Thị Nga', N'23 Trần Hưng Đạo, Quận 1, TP.HCM', '0920281694'),
	('KH032', N'Nguyễn Văn Lợi', N'2A Trần Nhật Duật, Quận 1, TP.HCM','0736646840'),
	('KH033', N'Lê Thị Thanh Huyền', N'145 Nguyễn Thị Minh Khai, Quận 3, TP.HCM','0364281779'),
	('KH034', N'Trần Văn Khang', N'22 Lê Lợi, Quận 1, TP.HCM',' 0467579884'),
	('KH035', N'Nguyễn Thị Lan', N'12 Hùng Vương, Quận 5, TP.HCM',' 0186014243'),
	('KH036', N'Phạm Văn Đức', N'234 Nguyễn Văn Cừ, Quận 5, TP.HCM',' 0442114095'),
	('KH037', N'Nguyễn Thị Huyền', N'123 Phan Đình Phùng, Quận 1, TP.HCM', '0713697025'),
	('KH038', N'Trần Thị Tuyết', N'45 Võ Văn Tần, Quận 3, TP.HCM', ' 0149263535'),
	('KH039', N'Nguyễn Văn Thắng', N'34 Huỳnh Tịnh Của, Quận 3, TP.HCM','0677862180'),
	('KH040', N'Lê Thị Ngọc Ánh', N'97 Trần Quang Khải, Quận 1, TP.HCM',' 0229182872'),
	('KH041', N'Trần Thị Phương Thảo', N'124 Trần Hưng Đạo, Quận 1, TP.HCM', '0834573434'),
	('KH042', N'Nguyễn Văn Bình', N'67 Nguyễn Du, Quận 1, TP.HCM',' 0881723281'),
	('KH043', N'Lê Thị Hồng Vân', N'1 Đinh Tiên Hoàng, Quận 1, TP.HCM',' 0722798508'),
	('KH044', N'Trần Văn Hiếu', N'89 Trần Quốc Thảo, Quận 3, TP.HCM',' 0366189905'),
	('KH045', N'Nguyễn Thị Thu Trang', N'56 Phạm Văn Đồng, Quận Gò Vấp, TP.HCM','0380409484'),
	('KH046', N'Phạm Văn Long', N'6 Phan Văn Trị, Quận Gò Vấp, TP.HCM','0233248046'),
	('KH047', N'Nguyễn Thị Thùy Dương', N'4A Nguyễn Thái Bình, Quận 1, TP.HCM','0684882831'),
	('KH048', N'Trần Thanh Tuấn', N'19A Nguyễn Huệ, Quận 1, TP.HCM',' 0253767719'),
	('KH049', N'Lê Thị Ngọc Diệp', N'121 Nguyễn Cư Trinh, Quận 1, TP.HCM','0834638936'),
	('KH050', N'Nguyễn Văn Minh', N'27B Lê Thánh Tôn, Quận 1, TP.HCM','0392899108'),
	('KH051', N'Trương Văn Thành', N'145 Cao Thắng, Quận 3, TP.HCM','0488360867'),
	('KH052', N'Nguyễn Thị Kim Cương', N'24 Hoàng Sa, Quận 1, TP.HCM',' 0585601628'),
	('KH053', N'Vũ Thanh Tùng', N'7A Bùi Thị Xuân, Quận 1, TP.HCM','0163234081'),
	('KH054', N'Lê Thị Hồng Hạnh', N'12/5C Nguyễn Trường Tộ, Quận 4, TP.HCM', '0862290390'),
	('KH055', N'Nguyễn Văn Hùng', N'9 Trần Quang Khải, Quận 1, TP.HCM', '0181234513'),
	('KH056', N'Phạm Thị Thanh Hương', N'105 Tôn Đức Thắng, Quận 1, TP.HCM', '0679308883'),
	('KH057', N'Đỗ Thị Hồng Phượng', N'51 Lê Anh Xuân, Quận 1, TP.HCM', ' 0328551213'),
	('KH058', N'Nguyễn Thị Thùy Trang', N'44 Cách Mạng Tháng Tám, Quận 1, TP.HCM','0707360974'),
	('KH059', N'Lê Thị Minh Trang', N'789 Lý Thường Kiệt, Quận 10, TP.HCM','0193804007'),
	('KH060', N'Trần Văn Mạnh', N'99 Bà Huyện Thanh Quan, Quận 3, TP.HCM','0846519345'),
	('KH061', N'Dương Vũ Nguyệt Anh', N'179 Đ. Cách Mạng Tháng 8, Phường 05, Quận 3, Thành phố Hồ Chí Minh','0365296192'),
	('KH062', N'Vũ Thị Ngọc Anh', N'61 Trần Minh Quyền, Phường 10, Quận 10, Thành phố Hồ Chí Minh ','0849847366'),
	('KH063', N'Cáp Xuân Bách', N'71b Phan Huy Thực, Tân Kiểng, Quận 7, Thành phố Hồ Chí Minh, Việt Nam','0357161030'),
	('KH064', N'Nguyễn Xuân Bách', N'176 Công chúa Ngọc Hân, Phường 12, Quận 11, Thành phố Hồ Chí Minh, Việt Nam','0823173965'),
	('KH065', N'Vũ Nguyễn Đức Dũng', N'205/9 Đ. Cách Mạng Tháng 8, Phường 4, Quận 3, Thành phố Hồ Chí Minh, Việt Nam','0564695715'),
	('KH066', N'Hoàng Đức Duy', N'240 Đ. Nhật Tảo, Phường 8, Quận 10, Thành phố Hồ Chí Minh, Việt Nam','0925703201'),
	('KH067', N'Nguyễn Thùy Dương', N'40/34 Lữ Gia, Phường 15, Quận 11, Thành phố Hồ Chí Minh 100000, Việt Nam','0563167142'),
	('KH068', N'Đặng Ngọc Giáp', N'408 Đ. 3 Tháng 2, Phường 12, Quận 10, Thành phố Hồ Chí Minh 740345, Việt Nam','0925662371'),
	('KH069', N'Lê Thị Thu Hà', N'352 Bà Hạt, Phường 9, Quận 10, Thành phố Hồ Chí Minh, Việt Nam','0924497929'),
	('KH070', N'Nguyễn Thị Thanh Hà', N'361/45/1 Nguyễn Đình Chiểu, Phường 5, Quận 3, Thành phố Hồ Chí Minh 70000, Việt Nam','0824747622'),
	('KH071', N'Nguyễn Thị Thúy Hằng', N'71 Đ. 3 Tháng 2, Phường 11, Quận 10, Thành phố Hồ Chí Minh 70000, Việt Nam','0829691884'),
	('KH072', N'Vũ Thanh Hằng', N'211B Bến Bãi Sậy, Phường 4, Quận 6, Thành phố Hồ Chí Minh 70000, Việt Nam','0819994685'),
	('KH073', N'Nguyễn Hoàng Hiệp', N'18 Đ. Nguyễn Trãi, Phường 7, Quận 5, Thành phố Hồ Chí Minh 70000, Việt Nam','0359828532'),
	('KH074', N'Phạm Minh Hoàng', N'91a Đ. 3 Tháng 2, Phường 11, Quận 10, Thành phố Hồ Chí Minh 700000, Việt Nam','0879067284'),
	('KH075', N'Lê Văn Hùng', N'296 Đ. Nhật Tảo, Phường 8, Quận 10, Thành phố Hồ Chí Minh 700000, Việt Nam','0362400394'),
	('KH076', N'Nguyễn Mạnh Hùng', N'92/7/4 Đường Phạm Đức Sơn, Phường 16, Quận 8, Thành phố Hồ Chí Minh 700000, Việt Nam','0563138221'),
	('KH077', N'Đỗ Thị Trang Hương', N'479/22/28 HL2, Bình Trị Đông, Bình Tân, Thành phố Hồ Chí Minh, Việt Nam','0367635165'),
	('KH078', N'Hà Anh Ngọc Linh', N'256 Âu Dương Lân, Phường 3, 8, Quận 8, Thành phố Hồ Chí Minh, Việt Nam','0826899513'),
	('KH079', N'Nguyễn Gia Linh', N'285/2 Âu Cơ, Phú Trung, Tân Phú, Thành phố Hồ Chí Minh, Việt Nam','0926740868'),
	('KH080', N'Đào Thị Quỳnh Loan', N'45/17 Hàn Hải Nguyên, Phường 16, Quận 11, Thành phố Hồ Chí Minh 70000, Việt Nam','0563063502'),
	('KH081', N'Lê Xuân Mạnh', N'chung cư B5, Lầu 3, Số 12B, Phường 3, Quận 4, Thành phố Hồ Chí Minh, Việt Nam','0386847876'),
	('KH082', N'Lê Xuân Minh', N'1500 TL10, Tân Tạo, Bình Tân, Thành phố Hồ Chí Minh 71915, Việt Nam','0563934654'),
	('KH083', N'Nhữ Ngọc Minh', N'30B/11F Đ. Vĩnh Lộc, Vĩnh Lộc B, Bình Chánh, Thành phố Hồ Chí Minh, Việt Nam','0566980512'),
	('KH084', N'Trần Huyền My', N'20 9 Đoàn Văn Bơ, Phường 9, Quận 4, Thành phố Hồ Chí Minh, Việt Nam','0384752983'),
	('KH085', N'Hoàng Thị Thúy Nga', N'208A Hòa Bình, Phú Thạnh, Tân Phú, Thành phố Hồ Chí Minh 70000, Việt Nam','0376070247'),
	('KH086', N'Trương Thị Băng Nhi', N'40 Dương Khuê, Hoà Thanh, Tân Phú, Thành phố Hồ Chí Minh, Việt Nam','0928645416'),
	('KH087', N'Đoàn Hải Ninh', N'1036 Đ. 3 Tháng 2, Phường 12, Quận 11, Thành phố Hồ Chí Minh, Việt Nam','0566960230'),
	('KH088', N'Vũ Nhật Quang', N'Hẻm 86/42 Trịnh Đình Trọng, Phú Trung, Tân Phú, Thành phố Hồ Chí Minh 700000, Việt Nam','0563625602'),
	('KH089', N'Nguyễn Công Quyền', N'68 Nguyễn Lâm, Phường 6, Quận 10, Thành phố Hồ Chí Minh, Việt Nam','0379286596'),
	('KH090', N'Nguyễn Như Quỳnh', N'183/18 Lê Đình Cẩn, Tân Tạo, Bình Tân, Thành phố Hồ Chí Minh, Việt Nam','0349653449'),
	('KH091', N'Cáp Duy Thái', N'3 Đ. 3 Tháng 2, Phường 7, Quận 10, Thành phố Hồ Chí Minh, Việt Nam','0566583837'),
	('KH092', N'Nguyễn Phương Thảo', N'212b/c12 Đ. Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh 700000, Việt Nam','0386091411'),
	('KH093', N'Trần Hoàng Vy Thảo', N'252 Đường Đ. Cao Thắng, Phường 12, Quận 10, Thành phố Hồ Chí Minh, Việt Nam','0925617671'),
	('KH094', N'Vũ Thị Thanh Thảo', N'3 Đ. 3 Tháng 2, Phường 7, Quận 10, Thành phố Hồ Chí Minh, Việt Nam','0565454102'),
	('KH095', N'Đỗ Thị Thêu', N'7/2 Tôn Thất Tùng, P. Phú Thuận, Quận 1, Thành phố Hồ Chí Minh, Việt Nam','0924058758'),
	('KH096', N'Đặng Ngô Thanh Thúy', N'110 Đường Số 7, Tân Kiểng, Quận 7, Thành phố Hồ Chí Minh 756841, Việt Nam','0924232926'),
	('KH097', N'Nguyễn Thị Thanh Xuân', N'183/18 Lê Đình Cẩn, Tân Tạo, Bình Tân, Thành phố Hồ Chí Minh, Việt Nam','0568004467'),
	('KH098', N'Đào Thị Hoàng Yến', N'81 Đ. Dạ Nam, Phường 2, Quận 8, Thành phố Hồ Chí Minh, Việt Nam','0582786337'),
	('KH099', N'Vũ Thị Hải Yến', N'14 Lũy Bán Bích, Tân Thới Hoà, Tân Phú, Thành phố Hồ Chí Minh, Việt Nam','0974692684'),
	('KH100', N'Phạm Thị Lan Anh', N'3 Đ. 3 Tháng 2, Phường 7, Quận 10, Thành phố Hồ Chí Minh, Việt Nam','0765574514')
GO

--Thêm dữ liệu vào bảng phiếu nhập
INSERT INTO PhieuNhap (MaPhieuNhap, MaNCC, NgayNhap)
VALUES ('PN001', 'NCC001', '2022-01-02 10:30:00'),
       ('PN002', 'NCC002', '2022-01-03 15:20:00'),
       ('PN003', 'NCC003', '2022-01-04 08:45:00'),
       ('PN004', 'NCC001', '2022-01-05 11:10:00'),
       ('PN005', 'NCC002', '2022-01-06 13:30:00'),
       ('PN006', 'NCC003', '2022-02-05 09:45:00'),
	   ('PN007', 'NCC001', '2022-03-01 10:30:00'),
       ('PN008', 'NCC002', '2022-03-02 14:00:00'),
       ('PN009', 'NCC003', '2022-03-03 11:15:00'),
       ('PN010', 'NCC004', '2022-03-04 16:30:00'),
       ('PN011', 'NCC005', '2022-03-05 09:45:00'),
       ('PN012', 'NCC002', '2022-03-29 11:00:00'),
       ('PN013', 'NCC003', '2022-03-30 16:00:00'),
	   ('PN014', 'NCC004', '2022-04-01 10:30:00'),
       ('PN015', 'NCC005', '2022-04-02 14:00:00'),
	   ('PN016', 'NCC005', '2022-04-05 12:48:52'),
       ('PN017', 'NCC002', '2022-04-29 13:45:00'),
       ('PN018', 'NCC003', '2022-04-30 16:00:00'),
	   ('PN019', 'NCC004', '2022-05-01 10:30:00'),
       ('PN020', 'NCC005', '2022-05-02 07:45:30'),
	   ('PN021', 'NCC003', '2022-05-03 14:00:40'),
	   ('PN022', 'NCC004', '2022-05-04 08:47:35'),
	   ('PN023', 'NCC001', '2022-05-15 10:50:30'),
	   ('PN024', 'NCC002', '2022-05-16 14:00:00'),
	   ('PN025', 'NCC003', '2022-05-17 14:00:00'),
	   ('PN026', 'NCC003', '2022-05-28 14:30:00')
GO

--Thêm dữ liệu bảng Chi Tiết Nhập Sách
INSERT INTO ChiTietNhapSach (MaPhieuNhap, MaSach, SoLuongNhap, DonGia)
VALUES ('PN001', 'MS001', 20, 25000),
       ('PN007', 'MS002', 15, 55000),
	   ('PN001', 'MS005', 15, 35000),
       ('PN004', 'MS003', 10, 85000),
       ('PN002', 'MS004', 25, 55000),
	   ('PN002', 'MS001', 25, 25000),
       ('PN003', 'MS005', 30, 35000),
	   ('PN003', 'MS001', 12, 25000),
       ('PN004', 'MS006', 18, 45000),
       ('PN011', 'MS007', 15, 90000),
       ('PN005', 'MS002', 20, 55000),
	   ('PN006', 'MS006', 20, 45000),
	   ('PN005', 'MS008', 20, 70000),
       ('PN003', 'MS009', 8, 60000),
	   ('PN006', 'MS010', 17, 40000),
       ('PN012', 'MS007', 10, 90000),
       ('PN007', 'MS010', 25, 40000),
	   ('PN013', 'MS009', 18, 60000),
	   ('PN002', 'MS007', 25, 90000),
       ('PN007', 'MS011', 30, 30000),
	   ('PN001', 'MS013', 15, 100000),
       ('PN008', 'MS016', 12, 50000),
       ('PN015', 'MS012', 18, 35000),
	   ('PN014', 'MS014', 20, 75000),
       ('PN009', 'MS015', 12, 45000),
       ('PN010', 'MS017', 10, 70000),
       ('PN015', 'MS020', 17, 50000),
	   ('PN009', 'MS042', 19, 95000),
	   ('PN012', 'MS018', 12, 95000),
       ('PN006', 'MS019', 21, 30000),
       ('PN012', 'MS023', 20, 85000),
       ('PN011', 'MS024', 14, 50000),
       ('PN001', 'MS025', 10, 35000),
	   ('PN011', 'MS028', 14, 60000),
       ('PN005', 'MS029', 10, 65000),
       ('PN013', 'MS030', 16, 100000),
       ('PN007', 'MS026', 15, 65000),
       ('PN010', 'MS027', 12, 35000),
       ('PN014', 'MS021', 24, 60000),
       ('PN004', 'MS022', 22, 70000),
       ('PN004', 'MS030', 16, 100000),
	   ('PN015', 'MS033', 12, 55000),
	   ('PN003', 'MS031', 21, 80000),
       ('PN004', 'MS032', 28, 45000),
       ('PN001', 'MS036', 14, 85000),
       ('PN002', 'MS034', 24, 90000),
       ('PN006', 'MS035', 11, 65000),
	   ('PN007', 'MS039', 23, 95000),
       ('PN002', 'MS035', 12, 23000),
       ('PN005', 'MS036', 19, 85000),
       ('PN007', 'MS037', 15, 45000),
	   ('PN009', 'MS038', 14, 75000),
       ('PN012', 'MS040', 22, 70000),
	   ('PN004', 'MS034', 21, 90000),
       ('PN005', 'MS041', 14, 70000),
	   ('PN005', 'MS042', 14, 70000),
	   ('PN005', 'MS043', 14, 70000),
	   ('PN016', 'MS044', 14, 70000),
	   ('PN016', 'MS045', 28, 40000),
	   ('PN025', 'MS046', 24, 30000),
	   ('PN026', 'MS047', 34, 37000),
	   ('PN018', 'MS048', 18, 70000),
	   ('PN020', 'MS051', 19, 70000),
	   ('PN021', 'MS052', 10, 100000),
	   ('PN023', 'MS053', 15, 120000),
	   ('PN019', 'MS054', 14, 50000),
	   ('PN019', 'MS055', 14, 50000),
	   ('PN021', 'MS056', 27, 50000),
	   ('PN024', 'MS057', 30, 60000),
	   ('PN017', 'MS058', 14, 70000),
	   ('PN017', 'MS059', 14, 70000),
	   ('PN022', 'MS060', 14, 70000)
GO

--Thêm dữ liệu bảng Hóa Đơn
INSERT INTO HoaDon (MaHoaDon, MaNhanVien, MaKhachHang, ThoiGian) 
VALUES ('HD001', 'NV001', 'KH001', '2022-05-02 08:10:00'),
	   ('HD002', 'NV003', 'KH002', '2022-05-02 09:12:00'),
	   ('HD003', 'NV002', 'KH002', '2022-05-02 10:15:00'),
	   ('HD004', 'NV004', 'KH003', '2022-05-03 07:35:00'),
	   ('HD005', 'NV002', 'KH004', '2022-05-03 09:42:00'),
	   ('HD006', 'NV004', 'KH005', '2022-05-03 16:24:00'),
	   ('HD007', 'NV005', 'KH006', '2022-05-03 19:18:00'),
	   ('HD008', 'NV006', 'KH007', '2022-05-04 09:05:00'),
	   ('HD009', 'NV007', 'KH008', '2022-05-04 20:09:00'),
	   ('HD010', 'NV001', 'KH009', '2022-05-05 07:55:00'),
	   ('HD011', 'NV003', 'KH010', '2022-05-05 08:42:00'),
	   ('HD012', 'NV005', 'KH010', '2022-05-05 11:44:00'),
	   ('HD013', 'NV004', 'KH011', '2022-05-06 11:50:00'),
	   ('HD014', 'NV008', 'KH012', '2022-05-06 12:03:00'),
	   ('HD015', 'NV009', 'KH013', '2022-05-06 19:19:00'),
	   ('HD016', 'NV010', 'KH013', '2022-05-06 21:30:00'),
	   ('HD017', 'NV002', 'KH014', '2022-05-07 12:36:00'),
	   ('HD018', 'NV003', 'KH015', '2022-05-08 13:41:00'),
	   ('HD019', 'NV004', 'KH015', '2022-05-08 15:32:00'),
	   ('HD020', 'NV002', 'KH016', '2022-05-09 15:32:00'),
	   ('HD021', 'NV005', 'KH017', '2022-05-09 18:12:00'),
	   ('HD022', 'NV007', 'KH018', '2022-05-09 19:12:00'),
	   ('HD023', 'NV008', 'KH019', '2022-05-09 20:35:00'),
	   ('HD024', 'NV008', 'KH020', '2022-05-09 21:56:00'),
	   ('HD025', 'NV009', 'KH021', '2022-05-10 08:32:00'),
	   ('HD026', 'NV009', 'KH021', '2022-05-10 10:30:00'),
	   ('HD027', 'NV010', 'KH021', '2022-05-11 08:31:00'),
	   ('HD028', 'NV010', 'KH022', '2022-05-11 09:01:00'),
	   ('HD029', 'NV009', 'KH022', '2022-05-12 11:30:00'),
	   ('HD030', 'NV008', 'KH023', '2022-05-12 14:24:00'),
	   ('HD031', 'NV009', 'KH024', '2022-05-13 16:22:00'),
	   ('HD032', 'NV006', 'KH025', '2022-05-13 17:31:00'),
	   ('HD033', 'NV002', 'KH026', '2022-05-13 17:57:00'),
	   ('HD034', 'NV008', 'KH026', '2022-05-13 18:12:00'),
	   ('HD035', 'NV009', 'KH027', '2022-05-14 08:43:00'),
	   ('HD036', 'NV007', 'KH027', '2022-05-14 09:20:00'),
	   ('HD037', 'NV004', 'KH027', '2022-05-14 14:12:00'),
	   ('HD038', 'NV004', 'KH027', '2022-05-14 15:30:00'),
	   ('HD039', 'NV006', 'KH028', '2022-05-14 19:46:00'),
	   ('HD040', 'NV006', 'KH028', '2022-05-14 20:21:00'),
	   ('HD041', 'NV007', 'KH029', '2022-05-15 11:30:00'),
	   ('HD042', 'NV003', 'KH030', '2022-05-15 12:45:00'),
	   ('HD043', 'NV005', 'KH031', '2022-05-16 13:56:00'),
	   ('HD044', 'NV002', 'KH032', '2022-05-16 19:58:00'),
	   ('HD045', 'NV008', 'KH033', '2022-05-16 21:21:00'),
	   ('HD046', 'NV009', 'KH034', '2022-05-17 08:33:00'),
	   ('HD047', 'NV003', 'KH035', '2022-05-17 10:11:00'),
	   ('HD048', 'NV002', 'KH036', '2022-05-17 18:39:00'),
	   ('HD049', 'NV003', 'KH037', '2022-05-17 19:31:00'),
	   ('HD050', 'NV001', 'KH038', '2022-05-18 10:21:00'),
	   ('HD051', 'NV005', 'KH039', '2022-05-19 12:58:00'),
	   ('HD052', 'NV006', 'KH040', '2022-05-19 13:43:00'),
	   ('HD053', 'NV003', 'KH041', '2022-05-19 14:45:00'),
	   ('HD054', 'NV007', 'KH041', '2022-05-20 15:34:00'),
	   ('HD055', 'NV004', 'KH042', '2022-05-21 19:45:00'),
	   ('HD056', 'NV009', 'KH043', '2022-05-22 16:30:00'),
	   ('HD057', 'NV003', 'KH044', '2022-05-23 16:31:00'),
	   ('HD058', 'NV002', 'KH045', '2022-05-23 19:32:00'),
	   ('HD059', 'NV001', 'KH045', '2022-05-23 20:34:00'),
	   ('HD060', 'NV003', 'KH045', '2022-05-23 21:24:00'),
	   ('HD061', 'NV006', 'KH046', '2022-05-24 08:25:00'),
	   ('HD062', 'NV004', 'KH047', '2022-05-24 18:36:00'),
	   ('HD063', 'NV002', 'KH048', '2022-05-25 09:39:00'),
	   ('HD064', 'NV004', 'KH049', '2022-05-25 19:37:00'),
	   ('HD065', 'NV008', 'KH050', '2022-05-25 20:38:00'),
	   ('HD066', 'NV006', 'KH051', '2022-05-26 09:43:00'),
	   ('HD067', 'NV007', 'KH051', '2022-05-26 16:11:00'),
	   ('HD068', 'NV001', 'KH051', '2022-05-27 17:16:00'),
	   ('HD069', 'NV002', 'KH051', '2022-05-27 17:27:00'),
	   ('HD070', 'NV003', 'KH052', '2022-05-27 17:59:00'),
	   ('HD071', 'NV005', 'KH052', '2022-05-28 08:16:00'),
	   ('HD072', 'NV006', 'KH053', '2022-05-29 09:18:00'),
	   ('HD073', 'NV007', 'KH054', '2022-05-29 10:16:00'),
	   ('HD074', 'NV009', 'KH055', '2022-05-29 17:26:00'),
	   ('HD075', 'NV006', 'KH056', '2022-05-29 18:16:00'),
	   ('HD076', 'NV002', 'KH057', '2022-05-29 18:21:00'),
	   ('HD077', 'NV001', 'KH058', '2022-05-29 20:17:00'),
	   ('HD078', 'NV003', 'KH059', '2022-05-30 07:24:00'),
	   ('HD079', 'NV005', 'KH059', '2022-05-30 09:11:00'),
	   ('HD080', 'NV005', 'KH060', '2022-05-30 15:28:00'),
	   ('HD081', 'NV004', 'KH061', '2022-05-30 17:19:00'),
	   ('HD082', 'NV004', 'KH062', '2022-05-31 07:21:00'),
	   ('HD083', 'NV004', 'KH062', '2022-05-31 08:10:00'),
	   ('HD084', 'NV008', 'KH063', '2022-05-31 17:20:00'),
	   ('HD085', 'NV009', 'KH063', '2022-06-01 10:15:00'),
	   ('HD086', 'NV010', 'KH064', '2022-06-01 11:29:00'),
	   ('HD087', 'NV010', 'KH065', '2022-06-01 13:11:00'),
	   ('HD088', 'NV010', 'KH066', '2022-06-01 13:22:00'),
	   ('HD089', 'NV002', 'KH067', '2022-06-01 14:13:00'),
	   ('HD090', 'NV008', 'KH067', '2022-06-01 17:21:00'),
	   ('HD091', 'NV009', 'KH068', '2022-06-01 18:10:00'),
	   ('HD092', 'NV003', 'KH068', '2022-06-01 19:21:00'),
	   ('HD093', 'NV003', 'KH069', '2022-06-02 07:12:00'),
	   ('HD094', 'NV004', 'KH070', '2022-06-02 08:29:00'),
	   ('HD095', 'NV001', 'KH070', '2022-06-03 09:18:00'),
	   ('HD096', 'NV007', 'KH071', '2022-06-03 15:22:00'),
	   ('HD097', 'NV007', 'KH071', '2022-06-03 17:12:00'),
	   ('HD098', 'NV007', 'KH072', '2022-06-04 09:23:00'),
	   ('HD099', 'NV005', 'KH072', '2022-06-04 11:12:00'),
	   ('HD100', 'NV009', 'KH073', '2022-06-05 09:26:00'),
	   ('HD101', 'NV009', 'KH073', '2022-06-05 12:23:00'),
	   ('HD102', 'NV010', 'KH074', '2022-06-05 17:24:00'),
	   ('HD103', 'NV010', 'KH075', '2022-06-06 17:25:00'),
	   ('HD104', 'NV010', 'KH076', '2022-06-08 15:26:00'),
	   ('HD105', 'NV008', 'KH077', '2022-06-09 11:27:00'),
	   ('HD106', 'NV004', 'KH078', '2022-06-09 12:27:00'),
	   ('HD107', 'NV003', 'KH079', '2022-06-09 19:21:00'),
	   ('HD108', 'NV005', 'KH079', '2022-06-10 10:22:00'),
	   ('HD109', 'NV007', 'KH079', '2022-06-10 11:24:00'),
	   ('HD110', 'NV002', 'KH080', '2022-06-11 17:25:00'),
	   ('HD111', 'NV008', 'KH080', '2022-06-12 18:21:00'),
	   ('HD112', 'NV002', 'KH081', '2022-06-13 19:23:00'),
	   ('HD113', 'NV009', 'KH081', '2022-06-14 08:24:00'),
	   ('HD114', 'NV002', 'KH081', '2022-06-14 09:25:00'),
	   ('HD115', 'NV002', 'KH082', '2022-06-14 20:27:00'),
	   ('HD116', 'NV001', 'KH082', '2022-06-15 11:21:00'),
	   ('HD117', 'NV008', 'KH082', '2022-06-15 16:23:00'),
	   ('HD118', 'NV005', 'KH083', '2022-06-16 09:23:00'),
	   ('HD119', 'NV002', 'KH083', '2022-06-16 10:22:00'),
	   ('HD120', 'NV003', 'KH084', '2022-06-17 12:24:00'),
	   ('HD121', 'NV003', 'KH085', '2022-06-17 17:26:00'),
	   ('HD122', 'NV008', 'KH086', '2022-06-18 11:21:00'),
	   ('HD123', 'NV009', 'KH087', '2022-06-18 17:22:00'),
	   ('HD124', 'NV002', 'KH088', '2022-06-19 10:24:00'),
	   ('HD125', 'NV009', 'KH089', '2022-06-19 19:26:00'),
	   ('HD126', 'NV009', 'KH090', '2022-06-19 20:27:00'),
	   ('HD127', 'NV001', 'KH091', '2022-06-19 21:21:00'),
	   ('HD128', 'NV001', 'KH092', '2022-06-20 08:23:00'),
	   ('HD129', 'NV004', 'KH093', '2022-06-20 10:24:00'),
	   ('HD130', 'NV004', 'KH094', '2022-06-20 16:25:00'),
	   ('HD131', 'NV002', 'KH095', '2022-06-21 09:26:00'),
	   ('HD132', 'NV009', 'KH095', '2022-06-21 11:27:00'),
	   ('HD133', 'NV009', 'KH096', '2022-06-22 15:21:00'),
	   ('HD134', 'NV009', 'KH096', '2022-06-22 16:21:00'),
	   ('HD135', 'NV009', 'KH096', '2022-06-22 18:27:00'),
	   ('HD136', 'NV001', 'KH097', '2022-06-23 09:21:00'),
	   ('HD137', 'NV001', 'KH097', '2022-06-23 10:24:00'),
	   ('HD138', 'NV002', 'KH098', '2022-06-23 15:21:00'),
	   ('HD139', 'NV006', 'KH099', '2022-06-23 19:21:00'),
	   ('HD140', 'NV007', 'KH100', '2022-06-24 20:24:00')
GO

--Thêm dữ liệu bảng Chi Tiết Hóa Đơn
INSERT INTO dbo.ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia)
VALUES ('HD001', 'MS001', 2, 45000.00),
	   ('HD001', 'MS002', 1, 90000.00),
	   ('HD002', 'MS002', 2, 90000.00),
	   ('HD002', 'MS004', 3, 75000.00),
	   ('HD003', 'MS003', 2, 110000.00),
	   ('HD004', 'MS004', 1, 75000.00),
	   ('HD005', 'MS005', 1, 55000.00),
	   ('HD005', 'MS006', 8, 65000.00),
	   ('HD006', 'MS006', 5, 65000.00),
	   ('HD007', 'MS007', 1, 120000.00),
	   ('HD008', 'MS042', 6, 120000.00),
	   ('HD009', 'MS023', 3, 110000.00),
	   ('HD009', 'MS019', 2, 45000.00),
	   ('HD009', 'MS003', 1, 110000.00),
	   ('HD010', 'MS004', 1, 75000.00),
	   ('HD010', 'MS012', 5, 45000.00),
	   ('HD010', 'MS015', 7, 60000.00),
	   ('HD011', 'MS009', 3, 85000.00),
	   ('HD012', 'MS016', 4, 70000.00),
	   ('HD013', 'MS018', 4, 125000.00),
	   ('HD014', 'MS019', 1, 45000.00),
	   ('HD015', 'MS021', 9, 85000.00),
	   ('HD016', 'MS020', 5, 70000.00),
	   ('HD017', 'MS026', 2, 60000.00),
	   ('HD017', 'MS018', 5, 125000.00),
	   ('HD017', 'MS013', 3, 125000.00),
	   ('HD018', 'MS032', 8, 60000.00),
	   ('HD019', 'MS033', 7, 75000.00),
	   ('HD020', 'MS008', 1, 95000.00),
	   ('HD021', 'MS021', 2, 85000.00),
	   ('HD022', 'MS022', 3, 90000.00),
	   ('HD023', 'MS031', 9, 95000.00),
	   ('HD023', 'MS001', 9, 45000.00),
	   ('HD024', 'MS024', 10, 65000.00),
	   ('HD025', 'MS005', 4, 55000.00),
	   ('HD025', 'MS015', 4, 60000.00),
	   ('HD026', 'MS026', 1, 60000.00),
	   ('HD027', 'MS027', 6, 55000.00),
	   ('HD028', 'MS028', 9, 80000.00),
	   ('HD029', 'MS029', 1, 95000.00),
	   ('HD030', 'MS030', 6, 120000.00),
	   ('HD031', 'MS002', 8, 90000.00),
	   ('HD032', 'MS032', 3, 60000.00),
	   ('HD033', 'MS014', 5, 95000.00),
	   ('HD034', 'MS034', 6, 105000.00),
	   ('HD035', 'MS021', 7, 85000.00),
	   ('HD036', 'MS036', 8, 100000.00),
	   ('HD037', 'MS037', 2, 65000.00),
	   ('HD037', 'MS031', 2, 95000.00),
	   ('HD038', 'MS038', 1, 90000.00),
	   ('HD039', 'MS039', 8, 125000.00),
	   ('HD040', 'MS001', 3, 45000.00),
	   ('HD041', 'MS040', 5, 89000.00),
	   ('HD041', 'MS030', 5, 120000.00),
	   ('HD042', 'MS042', 9, 120000.00),
	   ('HD043', 'MS001', 10, 45000.00),
	   ('HD044', 'MS040', 2, 89000.00),
	   ('HD045', 'MS011', 2, 40000.00),
	   ('HD046', 'MS007', 3, 120000.00),
	   ('HD047', 'MS006', 5, 65000.00),
	   ('HD048', 'MS002', 1, 90000.00),
	   ('HD049', 'MS021', 2, 85000.00),
	   ('HD050', 'MS012', 2, 45000.00),
	   ('HD051', 'MS037', 4, 65000.00),
	   ('HD052', 'MS012', 6, 45000.00),
	   ('HD053', 'MS002', 8, 90000.00),
	   ('HD054', 'MS004', 8, 75000.00),
	   ('HD055', 'MS005', 3, 55000.00),
	   ('HD056', 'MS022', 1, 90000.00),
	   ('HD057', 'MS023', 10, 110000.00),
	   ('HD058', 'MS024', 4, 65000.00),
	   ('HD059', 'MS026', 6, 60000.00),
	   ('HD059', 'MS035', 6, 90000.00),
	   ('HD060', 'MS031', 8, 95000.00),
	   ('HD061', 'MS002', 9, 90000.00),
	   ('HD062', 'MS006', 1, 65000.00),
	   ('HD063', 'MS021', 1, 85000.00),
	   ('HD064', 'MS001', 6, 45000.00),
	   ('HD065', 'MS001', 5, 45000.00),
	   ('HD066', 'MS003', 7, 110000.00),
	   ('HD067', 'MS037', 7, 65000.00),
	   ('HD068', 'MS018', 9, 125000.00),
	   ('HD069', 'MS019', 3, 45000.00),
	   ('HD070', 'MS020', 2, 80000.00),
	   ('HD071', 'MS021', 5, 84000.00),
	   ('HD072', 'MS025', 8, 71000.00),
	   ('HD073', 'MS028', 12, 200000.00),
	   ('HD074', 'MS030', 11, 270000.00),
	   ('HD075', 'MS022', 1, 78000.00),
	   ('HD076', 'MS029', 2, 80000.00),
	   ('HD077', 'MS022', 2, 84000.00),
	   ('HD078', 'MS060', 2, 90000.00),
	   ('HD079', 'MS054', 3, 70000.00),
	   ('HD080', 'MS057', 14, 150000.00),
	   ('HD081', 'MS048', 9, 170000.00),
	   ('HD082', 'MS034', 8, 270000.00),
	   ('HD083', 'MS033', 8, 175000.00),
	   ('HD084', 'MS032', 6, 210000.00),
	   ('HD085', 'MS041', 2, 70000.00),
	   ('HD086', 'MS046', 2, 70000.00),
	   ('HD087', 'MS047', 1, 90000.00),
	   ('HD088', 'MS049', 6, 190000.00),
	   ('HD089', 'MS021', 7, 270000.00),
	   ('HD090', 'MS029', 1, 50000.00),
	   ('HD091', 'MS036', 5, 120000.00),
	   ('HD092', 'MS033', 3, 40000.00),
	   ('HD093', 'MS032', 4, 44000.00),
	   ('HD094', 'MS033', 4, 80000.00),
	   ('HD095', 'MS029', 4, 90000.00),
	   ('HD096', 'MS030', 5, 78000.00),
	   ('HD097', 'MS060', 1, 81000.00),
	   ('HD098', 'MS060', 10, 81000.00),
	   ('HD099', 'MS055', 11, 370000.00),
	   ('HD100', 'MS058', 12, 270000.00),
	   ('HD101', 'MS059', 6, 170000.00),
	   ('HD102', 'MS019', 1, 20000.00),
	   ('HD103', 'MS030', 2, 30000.00),
	   ('HD104', 'MS052', 3, 40000.00),
	   ('HD105', 'MS053', 2, 20000.00),
	   ('HD106', 'MS059', 2, 70000.00),
	   ('HD107', 'MS058', 2, 80000.00),
	   ('HD108', 'MS041', 1, 65000.00),
	   ('HD109', 'MS048', 7, 210000.00),
	   ('HD110', 'MS054', 8, 170000.00),
	   ('HD111', 'MS045', 1, 50000.00),
	   ('HD112', 'MS056', 1, 40000.00),
	   ('HD113', 'MS048', 2, 30000.00),
	   ('HD114', 'MS040', 6, 120000.00),
	   ('HD115', 'MS047', 7, 250000.00),
	   ('HD116', 'MS049', 2, 30000.00),
	   ('HD117', 'MS060', 4, 81000.00),
	   ('HD118', 'MS057', 5, 120000.00),
	   ('HD119', 'MS059', 7, 200000.00),
	   ('HD120', 'MS060', 1, 81000.00),
	   ('HD121', 'MS059', 3, 60000.00),
	   ('HD122', 'MS057', 13, 400000.00),
	   ('HD123', 'MS039', 3, 40000.00),
	   ('HD124', 'MS033', 4, 120000.00),
	   ('HD125', 'MS032', 4, 150000.00),
	   ('HD126', 'MS039', 6, 270000.00),
	   ('HD127', 'MS038', 4, 100000.00),
	   ('HD128', 'MS035', 9, 370000.00),
	   ('HD129', 'MS036', 2, 75000.00),
	   ('HD130', 'MS031', 3, 75000.00),
	   ('HD131', 'MS030', 1, 51000.00),
	   ('HD132', 'MS041', 1, 20000.00),
	   ('HD133', 'MS045', 7, 250000.00),
	   ('HD134', 'MS049', 9, 450000.00),
	   ('HD135', 'MS050', 1, 60000.00),
	   ('HD136', 'MS052', 2, 50000.00),
	   ('HD137', 'MS060', 4, 81000.00),
	   ('HD138', 'MS060', 2, 81000.00),
	   ('HD139', 'MS028', 3, 70000.00),
	   ('HD140', 'MS060', 7, 81000.00)
GO	

-- Tính Lương của Nhân viên
UPDATE Luong
SET TongLuong = (
    SELECT (Luong / 26 * SoNgayLamViec + Thuong)
    FROM PhanLoaiNhanVien join NhanVien on PhanLoaiNhanVien.MaChucVu = NhanVien.MaChucVu
    WHERE NhanVien.MaNhanVien = Luong.MaNhanVien
)
GO

-- Tính Thành tiền của Hóa đơn
UPDATE HoaDon
SET ThanhTien = (
    SELECT SUM(SoLuong * DonGia)
    FROM ChiTietHoaDon
    WHERE HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon
)

-- Tính Thành tiền của Phiếu nhập
UPDATE PhieuNhap
SET ThanhTien = (
    SELECT SUM(SoLuongNhap * DonGia)
    FROM ChiTietNhapSach
    WHERE PhieuNhap.MaPhieuNhap = ChiTietNhapSach.MaPhieuNhap
)
GO