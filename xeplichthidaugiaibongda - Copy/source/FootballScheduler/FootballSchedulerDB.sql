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
    Status          TINYINT        NOT NULL DEFAULT 0 CHECK (Status IN (0, 1, 2)), -- 0: chưa lên lịch, 1: đã lên lịch, 2: đã kết thúc
    IsDeleted       BIT            NOT NULL DEFAULT 0
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
    AccountID       INT IDENTITY(1,1) PRIMARY KEY,
    UserName        VARCHAR(50)       NOT NULL UNIQUE,
    PasswordHash    NVARCHAR(255)     NOT NULL,
    Role            VARCHAR(8)        NOT NULL DEFAULT 'admin' CHECK (Role IN ('admin', 'referee', 'team'))
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
    IsDeleted       BIT             NOT NULL DEFAULT 0,
    CONSTRAINT FK_Team_Stadium  FOREIGN KEY (HomeStadiumID) REFERENCES Stadium(StadiumID),
);
GO

-- Create League_Team table
CREATE TABLE League_Team (
    LeagueID        VARCHAR(6)  NOT NULL,
    TeamID          VARCHAR(6)  NOT NULL,
    PRIMARY KEY (LeagueID, TeamID),
    CONSTRAINT FK_LeagueTeam_League FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),
    CONSTRAINT FK_LeagueTeam_Team   FOREIGN KEY (TeamID)   REFERENCES Team(TeamID)
);
GO

-- Create Referee table
CREATE TABLE Referee (
    RefereeID     VARCHAR(6)    PRIMARY KEY,
    RefereeName   NVARCHAR(50)  NOT NULL,
    BirthDate     DATE          NOT NULL,
    PhoneNumber   VARCHAR(15)   NULL,
    Email         NVARCHAR(255) NOT NULL,
    IsDeleted     BIT           NOT NULL DEFAULT 0
);
GO

-- Create Match table
CREATE TABLE Match (
    MatchID         INT IDENTITY(1,1) PRIMARY KEY,
    HomeTeamID      VARCHAR(6)        NOT NULL,
    AwayTeamID      VARCHAR(6)        NOT NULL,
    HomeGoals       TINYINT           NULL CHECK (HomeGoals >= 0),
    AwayGoals       TINYINT           NULL CHECK (AwayGoals >= 0),
    RoundNumber     TINYINT           NOT NULL,
    LeagueID        VARCHAR(6)        NOT NULL,
    KickoffDateTime DATETIME          NOT NULL,
    StadiumID       VARCHAR(6)        NOT NULL,
    RefereeID       VARCHAR(6)        NULL,
    Status          TINYINT           NOT NULL DEFAULT 1,
    IsDeleted       BIT               NOT NULL DEFAULT 0,
    CONSTRAINT FK_Match_HomeTeam  FOREIGN KEY (HomeTeamID) REFERENCES Team(TeamID),
    CONSTRAINT FK_Match_AwayTeam  FOREIGN KEY (AwayTeamID) REFERENCES Team(TeamID),
    CONSTRAINT FK_Match_League    FOREIGN KEY (LeagueID)   REFERENCES League(LeagueID),
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
    CONSTRAINT FK_Standing_League FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),
    CONSTRAINT FK_Standing_Team   FOREIGN KEY (TeamID)   REFERENCES Team(TeamID)
);
GO

-- -- Create Notification table
-- CREATE TABLE Notification (
--     NotificationID  INT IDENTITY(1,1) PRIMARY KEY,
--     Title           NVARCHAR(100)     NOT NULL,
--     Content         NVARCHAR(500)     NOT NULL,
--     CreatedAt       DATETIME          NOT NULL DEFAULT GETDATE(),
--     Receiver        NVARCHAR(6)       NOT NULL
-- );
-- GO

/*
=============================
======= CREATE VIEW ========
=============================
*/

USE FootballScheduler;
-- Drop existing view
IF OBJECT_ID('v_MatchDetails', 'V') IS NOT NULL
    DROP VIEW v_MatchDetails;
GO

-- Create updated Match Details view with soft delete filters
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
    m.Status
FROM Match m
INNER JOIN Team ht ON m.HomeTeamID = ht.TeamID
INNER JOIN Team at ON m.AwayTeamID = at.TeamID
INNER JOIN League l ON m.LeagueID = l.LeagueID
INNER JOIN Stadium s ON m.StadiumID = s.StadiumID
LEFT JOIN Referee r ON m.RefereeID = r.RefereeID
WHERE 
    m.IsDeleted = 0 AND
    ht.IsDeleted = 0 AND
    at.IsDeleted = 0 AND
    l.IsDeleted = 0 AND
    (r.IsDeleted = 0);




GO
USE FootballScheduler;
GO 
CREATE TRIGGER trg_UpdateStandings
ON Match
AFTER INSERT, UPDATE
AS
BEGIN
    -- Cập nhật kết quả bảng xếp hạng cho các đội có trong trận đấu vừa được thêm hoặc cập nhật
    DECLARE @LeagueID VARCHAR(6), @HomeTeamID VARCHAR(6), @AwayTeamID VARCHAR(6), @HomeGoals TINYINT, @AwayGoals TINYINT;
    
    -- Lấy thông tin trận đấu từ bảng INSERTED (chứa các bản ghi đã được thêm hoặc cập nhật)
    SELECT 
        @LeagueID = LeagueID,
        @HomeTeamID = HomeTeamID,
        @AwayTeamID = AwayTeamID,
        @HomeGoals = HomeGoals,
        @AwayGoals = AwayGoals
    FROM INSERTED;

    -- Cập nhật thông tin cho đội chủ nhà
    MERGE INTO Standings s
    USING (
        SELECT 
            @LeagueID AS LeagueID,
            @HomeTeamID AS TeamID,
            1 AS MatchesPlayed,
            CASE WHEN @HomeGoals > @AwayGoals THEN 1 ELSE 0 END AS Wins,
            CASE WHEN @HomeGoals = @AwayGoals THEN 1 ELSE 0 END AS Draws,
            CASE WHEN @HomeGoals < @AwayGoals THEN 1 ELSE 0 END AS Losses,
            @HomeGoals AS GoalsScored,
            @AwayGoals AS GoalsConceded,
            CASE WHEN @HomeGoals > @AwayGoals THEN 3
                 WHEN @HomeGoals = @AwayGoals THEN 1
                 ELSE 0 END AS Points
    ) AS cr
    ON s.LeagueID = cr.LeagueID AND s.TeamID = cr.TeamID
    WHEN MATCHED THEN
        UPDATE SET
            s.MatchesPlayed = s.MatchesPlayed + cr.MatchesPlayed,
            s.Wins = s.Wins + cr.Wins,
            s.Draws = s.Draws + cr.Draws,
            s.Losses = s.Losses + cr.Losses,
            s.GoalsScored = s.GoalsScored + cr.GoalsScored,
            s.GoalsConceded = s.GoalsConceded + cr.GoalsConceded,
            s.Points = s.Points + cr.Points
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (LeagueID, TeamID, MatchesPlayed, Wins, Draws, Losses, GoalsScored, GoalsConceded, Points)
        VALUES (cr.LeagueID, cr.TeamID, cr.MatchesPlayed, cr.Wins, cr.Draws, cr.Losses, cr.GoalsScored, cr.GoalsConceded, cr.Points);

    -- Cập nhật thông tin cho đội khách
    MERGE INTO Standings s
    USING (
        SELECT 
            @LeagueID AS LeagueID,
            @AwayTeamID AS TeamID,
            1 AS MatchesPlayed,
            CASE WHEN @AwayGoals > @HomeGoals THEN 1 ELSE 0 END AS Wins,
            CASE WHEN @HomeGoals = @AwayGoals THEN 1 ELSE 0 END AS Draws,
            CASE WHEN @AwayGoals < @HomeGoals THEN 1 ELSE 0 END AS Losses,
            @AwayGoals AS GoalsScored,
            @HomeGoals AS GoalsConceded,
            CASE WHEN @AwayGoals > @HomeGoals THEN 3
                 WHEN @HomeGoals = @AwayGoals THEN 1
                 ELSE 0 END AS Points
    ) AS cr
    ON s.LeagueID = cr.LeagueID AND s.TeamID = cr.TeamID
    WHEN MATCHED THEN
        UPDATE SET
            s.MatchesPlayed = s.MatchesPlayed + cr.MatchesPlayed,
            s.Wins = s.Wins + cr.Wins,
            s.Draws = s.Draws + cr.Draws,
            s.Losses = s.Losses + cr.Losses,
            s.GoalsScored = s.GoalsScored + cr.GoalsScored,
            s.GoalsConceded = s.GoalsConceded + cr.GoalsConceded,
            s.Points = s.Points + cr.Points
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (LeagueID, TeamID, MatchesPlayed, Wins, Draws, Losses, GoalsScored, GoalsConceded, Points)
        VALUES (cr.LeagueID, cr.TeamID, cr.MatchesPlayed, cr.Wins, cr.Draws, cr.Losses, cr.GoalsScored, cr.GoalsConceded, cr.Points);
END;
