CREATE DATABASE QuanLyBongDa;
GO
USE QuanLyBongDa;

---- Quản lý Đội Bóng ----
-- Bảng Sân Vận Động --
CREATE TABLE Stadiums (
    StadiumID INT IDENTITY(1, 1) PRIMARY KEY,
    StadiumName NVARCHAR(50) NOT NULL,
    Location NVARCHAR(50) NOT NULL,
    Capacity INT NOT NULL
);

-- Bảng Tình trạng SVD --
CREATE TABLE StadiumStatus (
    StatusID INT IDENTITY(1, 1) NOT NULL,
    StadiumID INT NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    PRIMARY KEY(StatusID, StadiumID),

    FOREIGN KEY(StadiumID) REFERENCES Stadiums(StadiumID)
);

-- Bảng Huấn Luyện Viên --
CREATE TABLE Coachs (
    CoachID INT IDENTITY(1, 1) PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
    CoachImage NVARCHAR(MAX)
);

-- Bảng Đội Bóng --
CREATE TABLE Teams (
    TeamID INT IDENTITY(1, 1) PRIMARY KEY,
    TeamName NVARCHAR(50) NOT NULL,
    Logo NVARCHAR(MAX),
    CoachID INT NOT NULL,
    StadiumID INT NOT NULL,

    FOREIGN KEY(CoachID) REFERENCES Coachs(CoachID),
    FOREIGN KEY(StadiumID) REFERENCES Stadiums(StadiumID)
);

-- Bảng Cầu Thủ --
CREATE TABLE Players (
    PlayerID INT IDENTITY(1, 1) PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    JerseyNumber TINYINT NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    TeamID INT NOT NULL,
    PlayerImage NVARCHAR(MAX),

    FOREIGN KEY(TeamID) REFERENCES Teams(TeamID)
);

---- Quản lý Giải Đấu ----
-- Bảng Giải Đấu --
CREATE TABLE Tournaments (
    TournamentID INT IDENTITY(1, 1) PRIMARY KEY,
    TournamentName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);

-- Bảng Vòng Đấu --
CREATE TABLE Rounds (
    RoundID INT IDENTITY(1, 1) PRIMARY KEY,
    TournamentID INT NOT NULL,
    RoundName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,

    FOREIGN KEY(TournamentID) REFERENCES Tournaments(TournamentID),
);

-- Bảng Bảng Đấu / Nhóm Đấu --
CREATE TABLE Groups (
    GroupID INT IDENTITY(1, 1) PRIMARY KEY,
    RoundID INT NOT NULL,
    GroupName NVARCHAR(50) NOT NULL,

    FOREIGN KEY(RoundID, TournamentID) REFERENCES Rounds(RoundID, TournamentID),
);

-- Bảng trung gian giữa Teams với Groups --
CREATE TABLE Groups_Teams (
    GroupID INT NOT NULL,
    TeamID INT NOT NULL,

    PRIMARY KEY(GroupID, TeamID),
    FOREIGN KEY(GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY(TeamID) REFERENCES Teams(TeamID)
);

-- Bảng trung gian giữa Teams với Tournaments --
CREATE TABLE Tournaments_Teams (
    TournamentID INT NOT NULL,
    TeamID INT NOT NULL,

    PRIMARY KEY(TournamentID, TeamID),
    FOREIGN KEY(TournamentID) REFERENCES Tournaments(TournamentID),
    FOREIGN KEY(TeamID) REFERENCES Teams(TeamID)
);

-- Bảng Rankings --
CREATE TABLE Rankings (
    GroupID INT NOT NULL,
    TeamID INT NOT NULL,

    Wins TINYINT NOT NULL DEFAULT 0 CHECK (Wins >= 0),
    Draws TINYINT NOT NULL DEFAULT 0 CHECK (Draws >= 0),
    Losses TINYINT NOT NULL DEFAULT 0 CHECK (Losses >= 0),

    GoalsFor TINYINT NOT NULL DEFAULT 0 CHECK (GoalsFor >= 0),
    GoalsAgainst TINYINT NOT NULL DEFAULT 0 CHECK (GoalsAgainst >= 0),
    GoalDifference AS (GoalsFor - GoalsAgainst),

    Rank TINYINT NOT NULL DEFAULT 0 CHECK (Rank >= 0),
    MatchesPlayed TINYINT NOT NULL DEFAULT 0 CHECK (MatchesPlayed >= 0),
    Points SMALLINT NOT NULL DEFAULT 0 CHECK(Points >= 0),
    
    PRIMARY KEY(GroupID, TeamID),
    FOREIGN KEY(GroupID) REFERENCES Groups(GroupID),
    FOREIGN KEY(TeamID) REFERENCES Teams(TeamID)
);

---- Quản lý Trận Đấu ----
-- Bảng Trận Đấu --
CREATE TABLE Matches (
    MatchID INT IDENTITY(1, 1) PRIMARY KEY,
    GroupID INT NOT NULL,

    HomeTeamID INT NOT NULL,
    AwayTeamID INT NOT NULL,
    Legs NVARCHAR(7) NOT NULL DEFAULT N'Lượt đi' CHECK (Legs IN (N'Lượt đi', N'Lượt về')),

    FOREIGN KEY(HomeTeamID) REFERENCES Teams(TeamID),
    FOREIGN KEY(AwayTeamID) REFERENCES Teams(TeamID),
    FOREIGN KEY(GroupID) REFERENCES Groups(GroupID),
);

--- Bảng Trọng Tài ---
CREATE TABLE Referees (
    RefereeID INT IDENTITY(1, 1) PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    RefereeImage NVARCHAR(MAX)
);

--- Bảng Lịch Thi Đấu ---
CREATE TABLE MatchSchedules (
    ScheduleID INT IDENTITY(1, 1) NOT NULL,
    MatchID INT NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    MatchDateTime DATETIME NOT NULL,

    StadiumID INT NOT NULL,

    PRIMARY KEY(MatchID, ScheduleID),
    FOREIGN KEY(MatchID) REFERENCES Matches(MatchID),
    FOREIGN KEY(StadiumID) REFERENCES Stadiums(StadiumID)
);

--- Bảng Phân Công Trọng tài ---
CREATE TABLE assign (
    ScheduleID INT NOT NULL,
	MatchID INT NOT NULL,

    RefereeID INT NOT NULL,
    Position NVARCHAR(50) NOT NULL,

    PRIMARY KEY(MatchID, ScheduleID, RefereeID),
    FOREIGN KEY(MatchID, ScheduleID) REFERENCES MatchSchedules(MatchID, ScheduleID),
    FOREIGN KEY(RefereeID) REFERENCES Referees(RefereeID)
);

--- Bảng Kết Quả Trận Đấu ---
CREATE TABLE MatchResults (
    MatchID INT PRIMARY KEY,
    HomeTeamScore TINYINT NOT NULL,
    AwayTeamScore TINYINT NOT NULL,
    FOREIGN KEY(MatchID) REFERENCES Matches(MatchID)
);