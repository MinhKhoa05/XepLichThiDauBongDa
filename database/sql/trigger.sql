USE QuanLyBongDa;

-- Trigger tự động cập nhật Bảng xếp hạng --
GO
CREATE TRIGGER trg_UpdateRankings
ON MatchResult
AFTER INSERT, UPDATE
AS
BEGIN
    PRINT 'Hello';
END;