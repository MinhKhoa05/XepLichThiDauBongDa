-- Drop the database if it already exists
DROP DATABASE IF EXISTS FootballScheduler;
GO

-- Create the database
CREATE DATABASE FootballScheduler;
GO

-- Use the created database
USE FootballScheduler;
GO

/*
=============================
===== CREATE TABLES     =====
=============================
*/

-- Create League table
CREATE TABLE League (
    LeagueID        VARCHAR(6)     PRIMARY KEY,
    LeagueName      NVARCHAR(100)  NOT NULL UNIQUE,
    LogoURL         NVARCHAR(255)  NULL,
    MaxTeams        TINYINT        NOT NULL CHECK (MaxTeams >= 2),
    StartDate       DATE           NOT NULL,
    EndDate         DATE           NOT NULL,
    Status          TINYINT        NOT NULL DEFAULT 0 CHECK (Status IN (0, 1, 2)) -- 0: chưa lên lịch, 1: đã lên lịch, 2: đã kết thúc
);
GO

-- Create Stadium table
CREATE TABLE Stadium (
    StadiumID       VARCHAR(6)     PRIMARY KEY,  
    StadiumName     NVARCHAR(50)   NOT NULL,
    Address         NVARCHAR(255)  NOT NULL         
);
GO

-- Create Account table
CREATE TABLE Account (
    AccountID       VARCHAR(6) PRIMARY KEY,
    Username        VARCHAR(50)       NOT NULL UNIQUE,
    PasswordHash    NVARCHAR(255)     NOT NULL DEFAULT '123456',
    Role            VARCHAR(8)        NOT NULL DEFAULT 'Admin' CHECK (Role IN ('Admin', 'Referee', 'Team'))
);
GO

-- Create Team table
CREATE TABLE Team (
    TeamID          VARCHAR(6)      PRIMARY KEY,
    TeamName        NVARCHAR(50)    NOT NULL,
    LogoURL         NVARCHAR(255)   NULL,
    CoachName       NVARCHAR(30)    NOT NULL,
    HomeStadiumID   VARCHAR(6)      NULL,
    Email           NVARCHAR(255)   NOT NULL,
    Phone           VARCHAR(20)     NULL,
    CONSTRAINT FK_Team_Stadium  FOREIGN KEY (HomeStadiumID) REFERENCES Stadium(StadiumID)
);
GO

-- Create League_Team table
CREATE TABLE League_Team (
    LeagueID        VARCHAR(6)  NOT NULL,
    TeamID          VARCHAR(6)  NOT NULL,
    PRIMARY KEY (LeagueID, TeamID),
    CONSTRAINT FK_LeagueTeam_League FOREIGN KEY (LeagueID) REFERENCES League(LeagueID) ON DELETE CASCADE,
    CONSTRAINT FK_LeagueTeam_Team   FOREIGN KEY (TeamID)   REFERENCES Team(TeamID) ON DELETE CASCADE
);
GO

-- Create Referee table
CREATE TABLE Referee (
    RefereeID     VARCHAR(6)    PRIMARY KEY,
    RefereeName   NVARCHAR(50)  NOT NULL,
    BirthDate     DATE          NOT NULL,
    PhoneNumber   VARCHAR(15)   NULL,
    Email         NVARCHAR(255) NOT NULL
);
GO

-- Create Match table
CREATE TABLE [Match] (
    MatchID         INT IDENTITY(1,1) PRIMARY KEY,
    HomeTeamID      VARCHAR(6)        NOT NULL,
    AwayTeamID      VARCHAR(6)        NOT NULL,
    HomeGoals       TINYINT           NULL CHECK (HomeGoals >= 0) DEFAULT 0,
    AwayGoals       TINYINT           NULL CHECK (AwayGoals >= 0) DEFAULT 0,
    RoundNumber     TINYINT           NOT NULL,
    LeagueID        VARCHAR(6)        NOT NULL,
    KickoffDateTime DATETIME          NOT NULL,
    StadiumID       VARCHAR(6)        NOT NULL,
    RefereeID       VARCHAR(6)        NULL,
    Complete        BIT               NOT NULL DEFAULT 0,
    CONSTRAINT FK_Match_HomeTeam  FOREIGN KEY (HomeTeamID) REFERENCES Team(TeamID) ON DELETE NO ACTION,
    CONSTRAINT FK_Match_AwayTeam  FOREIGN KEY (AwayTeamID) REFERENCES Team(TeamID) ON DELETE NO ACTION,
    CONSTRAINT FK_Match_League    FOREIGN KEY (LeagueID)   REFERENCES League(LeagueID) ON DELETE CASCADE,
    CONSTRAINT FK_Match_Stadium   FOREIGN KEY (StadiumID)  REFERENCES Stadium(StadiumID),
    CONSTRAINT FK_Match_Referee   FOREIGN KEY (RefereeID)  REFERENCES Referee(RefereeID),
    CONSTRAINT CK_Match_TeamDifferent CHECK (HomeTeamID <> AwayTeamID)
);
GO

-- Create Standings table
CREATE TABLE Standings (
    LeagueID        VARCHAR(6)  NOT NULL,
    TeamID          VARCHAR(6)  NOT NULL,
    MatchesPlayed   SMALLINT    NOT NULL DEFAULT 0,
    Wins            SMALLINT    NOT NULL DEFAULT 0,
    Draws           SMALLINT    NOT NULL DEFAULT 0,
    Losses          SMALLINT    NOT NULL DEFAULT 0,
    GoalsScored     INT         NOT NULL DEFAULT 0,
    GoalsConceded   INT         NOT NULL DEFAULT 0,
    Points          INT         NOT NULL DEFAULT 0,
    PRIMARY KEY (LeagueID, TeamID),
    CONSTRAINT FK_Standing_League FOREIGN KEY (LeagueID) REFERENCES League(LeagueID) ON DELETE CASCADE,
    CONSTRAINT FK_Standing_Team   FOREIGN KEY (TeamID)   REFERENCES Team(TeamID) ON DELETE CASCADE
);
GO

/*
=============================
======= CREATE VIEW ========
=============================
*/

-- Drop existing view if it exists
IF OBJECT_ID('v_MatchDetails', 'V') IS NOT NULL
    DROP VIEW v_MatchDetails;
GO

-- Create Match Details view
CREATE VIEW v_MatchDetails AS
SELECT
    m.MatchID,
    ht.TeamName AS HomeTeam,
    at.TeamName AS AwayTeam,
    m.HomeGoals,
    m.AwayGoals,
    m.RoundNumber,
    l.LeagueID,
    l.LeagueName,
    m.KickoffDateTime,
    s.StadiumName,
    s.Address,
    r.RefereeName,
    m.Complete
FROM [Match] m
INNER JOIN Team ht ON m.HomeTeamID = ht.TeamID
INNER JOIN Team at ON m.AwayTeamID = at.TeamID
INNER JOIN League l ON m.LeagueID = l.LeagueID
INNER JOIN Stadium s ON m.StadiumID = s.StadiumID
LEFT JOIN Referee r ON m.RefereeID = r.RefereeID;
GO

USE FootballScheduler;
GO
-- Procedure tính lại điểm cho một đội
CREATE PROCEDURE CalculatePoints
    @TeamID VARCHAR(6)
AS
BEGIN
    DECLARE @MatchesPlayed INT, @Wins INT, @Draws INT, @Losses INT, 
            @GoalsScored INT, @GoalsConceded INT, @Points INT;
    
    -- Lấy tổng số trận đã chơi, thắng, hòa, thua, số bàn ghi và thủng cho đội
    SELECT @MatchesPlayed = COUNT(*),
           @Wins = SUM(CASE WHEN (HomeGoals > AwayGoals AND HomeTeamID = @TeamID) 
                            OR (AwayGoals > HomeGoals AND AwayTeamID = @TeamID) THEN 1 ELSE 0 END),
           @Draws = SUM(CASE WHEN HomeGoals = AwayGoals THEN 1 ELSE 0 END),
           @Losses = SUM(CASE WHEN (HomeGoals < AwayGoals AND HomeTeamID = @TeamID) 
                              OR (AwayGoals < HomeGoals AND AwayTeamID = @TeamID) THEN 1 ELSE 0 END),
           @GoalsScored = SUM(CASE WHEN HomeTeamID = @TeamID THEN HomeGoals ELSE AwayGoals END),
           @GoalsConceded = SUM(CASE WHEN HomeTeamID = @TeamID THEN AwayGoals ELSE HomeGoals END)
    FROM [Match]
    WHERE (HomeTeamID = @TeamID OR AwayTeamID = @TeamID) AND Complete = 1;

    -- Tính điểm cho đội
    SET @Points = (@Wins * 3) + @Draws;

    -- Cập nhật lại thông tin bảng xếp hạng
    UPDATE Standings
    SET MatchesPlayed = @MatchesPlayed,
        Wins = @Wins,
        Draws = @Draws,
        Losses = @Losses,
        GoalsScored = @GoalsScored,
        GoalsConceded = @GoalsConceded,
        Points = @Points
    WHERE TeamID = @TeamID;
END;
GO

-- Trigger cập nhật kết quả trận đấu và tính lại điểm của các đội
CREATE TRIGGER trg_UpdateMatchResult
ON [Match]
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra nếu có thay đổi kết quả (cập nhật số bàn thắng)
    IF UPDATE(HomeGoals) OR UPDATE(AwayGoals)
    BEGIN
        DECLARE @HomeTeamID VARCHAR(6), @AwayTeamID VARCHAR(6);
        DECLARE @HomeGoals INT, @AwayGoals INT;
        
        -- Lấy ID và số bàn của đội nhà, đội khách từ trận đấu vừa cập nhật
        SELECT @HomeTeamID = HomeTeamID, @AwayTeamID = AwayTeamID, 
               @HomeGoals = HomeGoals, @AwayGoals = AwayGoals
        FROM INSERTED;

        -- Tính lại điểm cho đội nhà
        EXEC CalculatePoints @TeamID = @HomeTeamID;

        -- Tính lại điểm cho đội khách
        EXEC CalculatePoints @TeamID = @AwayTeamID;
    END
END;
GO

-- Trigger tự động tạo tài khoản khi một đội được thêm vào bảng Team
CREATE TRIGGER trg_CreateAccountForTeam
ON Team
AFTER INSERT
AS
BEGIN
    -- Biến lưu trữ thông tin đội bóng
    DECLARE @TeamID VARCHAR(6);
    
    -- Lấy thông tin đội từ bảng Team
    SELECT @TeamID = TeamID
    FROM INSERTED;
    
    -- Chèn tài khoản mới vào bảng Account
    INSERT INTO Account (AccountID, Username, Role)
    VALUES (@TeamID, @TeamID, 'Team');
END;
GO

-- Trigger tự động tạo tài khoản khi một trọng tài được thêm vào bảng Referee
CREATE TRIGGER trg_CreateAccountForReferee
ON Referee
AFTER INSERT
AS
BEGIN
    -- Biến lưu trữ thông tin trọng tài
    DECLARE @RefereeID VARCHAR(6);
    
    -- Lấy thông tin trọng tài từ bảng Referee
    SELECT @RefereeID = RefereeID
    FROM INSERTED;
    
    -- Chèn tài khoản mới vào bảng Account
    INSERT INTO Account (AccountID, Username, Role)
    VALUES (@RefereeID, @RefereeID, 'Referee');
END;
GO
