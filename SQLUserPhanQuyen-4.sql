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

/*
create TRIGGER TaoTaiKhoanDangNhap ON DangNhap
AFTER INSERT
AS
BEGIN
	DECLARE @sqlString nvarchar(2000)
    DECLARE @userName nvarchar(10)
    DECLARE @passWord nvarchar(30)
    DECLARE @cv varchar(20)
    
    SELECT @userName = DangNhap.TenDangNhap, @passWord = DangNhap.MatKhau, @cv = NhanVien.MaChucVu 
    FROM DangNhap 
    INNER JOIN NhanVien ON DangNhap.MaNhanVien = NhanVien.MaNhanVien
    INNER JOIN INSERTED ON DangNhap.MaNhanVien = INSERTED.MaNhanVien
	
	SET @sqlString= 'CREATE LOGIN [' + @userName +'] WITH PASSWORD='''+ @passWord
	+''', DEFAULT_DATABASE=[QLCHBS], CHECK_EXPIRATION=OFF,
	CHECK_POLICY=OFF'
	EXEC (@sqlString)
	SET @sqlString= 'CREATE USER ' + @userName +' FOR LOGIN '+ @userName
	EXEC (@sqlString)
	--role quản lý
	if (@cv='CV001')
	begin
		SET @sqlString = N'ALTER SERVER ROLE sysadmin ADD MEMBER ' +@userName;
		exec (@sqlString)
	end
	--role thu ngân
	else if(@cv='CV002')
	begin
		SET @sqlString = N'ALTER ROLE ThuNgan ADD MEMBER ' + @userName;
		exec (@sqlString)
	end
	--role Quản lý kho
	else if(@cv='CV003')
	begin
		SET @sqlString = N'ALTER ROLE ThuKho ADD MEMBER ' + @userName;
		exec (@sqlString)
	end
	--role tư vấn
	else
	begin
		SET @sqlString = N'ALTER ROLE TuVan ADD MEMBER ' + @userName;
		exec (@sqlString)
	end
END
go
*/