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
LEFT JOIN Referee r ON m.RefereeID = r.RefereeID;