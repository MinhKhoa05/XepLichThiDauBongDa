USE FootballScheduler;

INSERT INTO League (LeagueID, LeagueName, LogoURL, MaxTeams, StartDate, EndDate, Status)
VALUES
('L00001', N'Premier League', NULL, 20, '2025-01-01', '2025-06-01', 1),
('L00002', N'V-League', NULL, 14, '2025-03-01', '2025-07-30', 0);

INSERT INTO Stadium (StadiumID, StadiumName, Address)
VALUES
('S00001', N'Sân vận động Mỹ Đình', N'Hà Nội, Việt Nam'),
('S00002', N'Sân Thống Nhất', N'TP. Hồ Chí Minh, Việt Nam'),
('S00003', N'Sân Hàng Đẫy', N'Hà Nội, Việt Nam'),
('S00004', N'Sân Lạch Tray', N'Hải Phòng, Việt Nam'),
('S00005', N'Sân Vinh', N'Vinh, Nghệ An, Việt Nam'),
('S00006', N'Sân Cẩm Phả', N'Quảng Ninh, Việt Nam'),
('S00007', N'Sân Hòa Xuân', N'Đà Nẵng, Việt Nam'),
('S00008', N'Sân Lào Cai', N'Lào Cai, Việt Nam'),
('S00009', N'Sân Pleiku', N'Gia Lai, Việt Nam'),
('S00010', N'Sân Bà Rịa', N'Bà Rịa-Vũng Tàu, Việt Nam'),
('S00011', N'Sân Bình Dương', N'Bình Dương, Việt Nam'),
('S00012', N'Sân Quân khu 7', N'TP. Hồ Chí Minh, Việt Nam'),
('S00013', N'Sân Thanh Hóa', N'Thanh Hóa, Việt Nam'),
('S00014', N'Sân Phú Thọ', N'TP. Hồ Chí Minh, Việt Nam'),
('S00015', N'Sân Ninh Bình', N'Ninh Bình, Việt Nam'),
('S00016', N'Sân Vĩnh Phúc', N'Vĩnh Phúc, Việt Nam'),
('S00017', N'Sân Kiên Giang', N'Kiên Giang, Việt Nam'),
('S00018', N'Sân Bình Phước', N'Bình Phước, Việt Nam'),
('S00019', N'Sân Tự Do', N'Thừa Thiên Huế, Việt Nam'),
('S00020', N'Sân Thành Long', N'Bến Tre, Việt Nam');

INSERT INTO Team (TeamID, TeamName, CoachName, HomeStadiumID, Email, Phone)
VALUES
('T00001', N'Hà Nội FC', N'Chu Đình Nghiêm', 'S00001', 'hanoi@football.com', '0912345678'),
('T00002', N'TP HCM FC', N'Tô Quang Hiếu', 'S00002', 'tphcm@football.com', '0987654321'),
('T00003', N'Sài Gòn FC', N'Vũ Tiến Thành', 'S00003', 'saigon@football.com', '0901234567'),
('T00004', N'Hải Phòng FC', N'Vũ Tiến Thành', 'S00004', 'haiphong@football.com', '0909876543'),
('T00005', N'SLNA', N'Nguyễn Đức Thắng', 'S00005', 'slna@football.com', '0912233445'),
('T00006', N'Quảng Ninh FC', N'Phan Thanh Hùng', 'S00006', 'qnp@football.com', '0987766554'),
('T00007', N'Đà Nẵng FC', N'Lê Huỳnh Đức', 'S00007', 'danang@football.com', '0981234567'),
('T00008', N'Hoàng Anh Gia Lai', N'Lee Tae Hoon', 'S00008', 'hagl@football.com', '0912345678'),
('T00009', N'Bà Rịa Vũng Tàu FC', N'Nguyễn Minh Phương', 'S00009', 'brvt@football.com', '0978765432'),
('T00010', N'Bình Dương FC', N'Nguyễn Thanh Sơn', 'S00010', 'bd@football.com', '0976543210'),
('T00011', N'Cần Thơ FC', N'Vũ Quang Bảo', 'S00011', 'cantho@football.com', '0909876543'),
('T00012', N'Thanh Hóa FC', N'Vũ Quang Bảo', 'S00012', 'thanhhoa@football.com', '0901234567'),
('T00013', N'Phú Thọ FC', N'Nguyễn Duy Dũng', 'S00013', 'phutho@football.com', '0912345678'),
('T00014', N'Ninh Bình FC', N'Đinh Hồng Vinh', 'S00014', 'ninhbinh@football.com', '0909876543'),
('T00015', N'Vĩnh Phúc FC', N'Trần Minh Tú', 'S00015', 'vinhphuc@football.com', '0976543210'),
('T00016', N'Kiên Giang FC', N'Lê Minh Tân', 'S00016', 'kiengiang@football.com', '0901234567'),
('T00017', N'Bình Phước FC', N'Phạm Minh Tuấn', 'S00017', 'binhphuoc@football.com', '0987654321'),
('T00018', N'Thừa Thiên Huế FC', N'Phan Văn Tài Em', 'S00018', 'hue@football.com', '0912345678'),
('T00019', N'Bến Tre FC', N'Nguyễn Hoàng Hiệp', 'S00019', 'bentre@football.com', '0909876543'),
('T00020', N'Nam Định FC', N'Phan Thanh Hùng', 'S00020', 'namdinh@football.com', '0976543210');

INSERT INTO Referee (RefereeID, RefereeName, BirthDate, PhoneNumber, Email)
VALUES
('R00001', N'Nguyễn Mạnh Hùng', '1985-05-10', '0901234567', 'nguyenmanhhung@referee.com'),
('R00002', N'Trần Minh Tùng', '1983-03-15', '0912345678', 'tranminhtung@referee.com'),
('R00003', N'Phan Thị Thu Hà', '1990-07-22', '0987654321', 'phanthithuha@referee.com'),
('R00004', N'Lê Đức Thắng', '1986-08-05', '0912345679', 'leducthang@referee.com'),
('R00005', N'Nguyễn Thị Kim Oanh', '1988-09-18', '0978765432', 'nguyenthikimoanh@referee.com'),
('R00006', N'Vũ Quang Hòa', '1987-06-25', '0909876543', 'vuquanghoa@referee.com'),
('R00007', N'Bùi Quang Huy', '1984-11-30', '0931234567', 'buiquanghuy@referee.com'),
('R00008', N'Lê Minh Tuấn', '1992-01-15', '0976543210', 'leminhtuan@referee.com'),
('R00009', N'Trương Thanh Sơn', '1982-04-28', '0912233445', 'truongthanhson@referee.com'),
('R00010', N'Phan Đức Hòa', '1981-12-02', '0905678901', 'phanduchoa@referee.com');

INSERT INTO Account (UserName, PasswordHash)
VALUES ('admin', '123456')