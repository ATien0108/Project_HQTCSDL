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