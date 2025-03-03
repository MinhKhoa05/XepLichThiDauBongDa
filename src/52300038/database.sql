CREATE DATABASE QuanLyThucTap;

GO
USE QuanLyThucTap;

CREATE TABLE SinhVien (
	MaSV VARCHAR(4) PRIMARY KEY,
	HoTen NVARCHAR(50) NOT NULL,
	QueQuan NVARCHAR(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	HocLuc DECIMAL(3, 1) NOT NULL
);

CREATE TABLE DeTai (
	MaDT VARCHAR(4) PRIMARY KEY,
	TenDT NVARCHAR(50) NOT NULL,
	ChuNhiem NVARCHAR(50) NOT NULL,
	KinhPhi INT NOT NULL
);

CREATE TABLE SinhVien_DeTai (
	MaSV VARCHAR(4) NOT NULL,
	MaDT VARCHAR(4) NOT NULL,

	NoiThucTap NVARCHAR(50) NOT NULL,
	QuangDuong SMALLINT NOT NULL,
	KetQua DECIMAL(3, 1) NOT NULL,

	PRIMARY KEY(MaSV, MaDT),
	FOREIGN KEY(MaSV) REFERENCES SinhVien(MaSV),
	FOREIGN KEY(MaDT) REFERENCES DeTai(MaDT)
);

--- Dữ liệu mẫu
DELETE FROM SinhVien_DeTai;
DELETE FROM SinhVien;
DELETE FROM DeTai;

INSERT INTO SinhVien (MaSV, HoTen, QueQuan, NgaySinh, HocLuc)
VALUES
('SV01', N'Trần Thanh Trâm', N'Sài Gòn', CONVERT(DATE, '23-03-1998', 105), 8.5),
('SV02', N'Nguyễn Hồng Linh', N'Thanh Hóa', CONVERT(DATE, '20-01-2000', 105), 9.0),
('SV03', N'Trần Thanh Phước', N'Tiền Giang', CONVERT(DATE, '12-07-2001', 105), 7.5),
('SV04', N'Nguyễn Minh Hải', N'Nghệ An', CONVERT(DATE, '28-02-1993', 105), 7.0),
('SV05', N'Trần Thị Hồng Nhung', N'Kiên Giang', CONVERT(DATE, '15-07-1998', 105), 9.0);

INSERT INTO DeTai (MaDT, TenDT, ChuNhiem, KinhPhi)
VALUES
('DT01', N'Quản lý quán ăn', N'Nguyễn Thễ Hữu', 100000000),
('DT02', N'Quản lý khách sạn', N'Trần Trung Hiếu', 200000000),
('DT03', N'Quản lý sân bóng đá mini', N'Nguyễn Công Tâm', 300000000),
('DT04', N'Quản lý shop hoa tươi', N'Đặng Đức Trung', 150000000),
('DT05', N'Quản lý cửa hàng điện thoại', N'Trịnh Thanh Duy', 2000000000);

INSERT INTO SinhVien_DeTai(MaSV, MaDT, NoiThucTap, QuangDuong, KetQua)
VALUES
('SV01', 'DT01', N'Tiền Giang', 70, 8.0),
('SV02', 'DT01', N'Bình Dương', 50, 7.0),
('SV03', 'DT02', N'Vũng Tàu', 150, 9.5),
('SV03', 'DT03', N'Long An', 50, 8.5),
('SV04', 'DT03', N'Nha Trang', 500, 10);