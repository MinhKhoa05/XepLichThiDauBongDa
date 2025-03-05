CREATE DATABASE XepLichBongDa;

GO
USE XepLichBongDa;

CREATE TABLE League (
    LeagueID VARCHAR(8) PRIMARY KEY,
    LeagueName NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    MaxMatchPerDay TINYINT NOT NULL CHECK (MaxMatchPerDay >= 0),
    MinRestDay TINYINT NOT NULL DEFAULT 2 CHECK(MinRestDay >= 0)
);

CREATE TABLE TimeSlot (
    TimeSlotID INT IDENTITY(1, 1) PRIMARY KEY,
    StartTime TIME UNIQUE
);

CREATE TABLE Stadium (
    StadiumID VARCHAR(8) PRIMARY KEY,
    StadiumName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(500) NOT NULL,
    IsNeutral BIT NOT NULL DEFAULT 0,       --- 1: Là sân trung lập, 0: Là sân nhà 
    Status TINYINT NOT NULL                 --- 1: Đang dùng, 2: Không dùng nữa, 3: Bảo trì      
);

CREATE TABLE UserAccount (
    UserID INT IDENTITY(1, 1) PRIMARY KEY,
    Username VARCHAR(10) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    UserRole TINYINT NOT NULL,              --- 1: Admin, 2: Team, 3: Referee
    Status TINYINT NOT NULL,
    Email NVARCHAR(255),
    PhoneNumber NVARCHAR(20)
);

CREATE TABLE Team (
    TeamID VARCHAR(5) PRIMARY KEY,
    TeamName NVARCHAR(255) NOT NULL,
    Logo NVARCHAR(255),
    Origin NVARCHAR(255) NOT NULL,
    StadiumID VARCHAR(8) NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID),
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);

CREATE TABLE Match (
    MatchID INT IDENTITY(1,1) PRIMARY KEY,
    HomeTeamID VARCHAR(5) NOT NULL,
    AwayTeamID VARCHAR(5) NOT NULL,
    HomeScore TINYINT NULL CHECK (HomeScore >= 0),
    AwayScore TINYINT NULL CHECK (AwayScore >= 0),
    Round TINYINT NOT NULL,
    LeagueID VARCHAR(8) NOT NULL,
    Status TINYINT NOT NULL,
    FOREIGN KEY (HomeTeamID) REFERENCES Team(TeamID),
    FOREIGN KEY (AwayTeamID) REFERENCES Team(TeamID),
    FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),
    CONSTRAINT CK_DifferentTeams CHECK (HomeTeamID <> AwayTeamID) -- Đảm bảo không tự đấu với chính mình
);

CREATE TABLE Referee (
    RefereeID VARCHAR(8) PRIMARY KEY,
    RefereeName NVARCHAR(255) NOT NULL,
    Origin NVARCHAR(255) NOT NULL,
    ExperienceYears TINYINT NOT NULL,
    Status TINYINT NOT NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);

CREATE TABLE MatchSchedule (
    ScheduleID INT IDENTITY(1,1),
    MatchID INT NOT NULL,
    MatchDateTime DATETIME NOT NULL,
    StadiumID VARCHAR(8) NOT NULL,
    PRIMARY KEY (ScheduleID, MatchID),
    FOREIGN KEY (MatchID) REFERENCES Match(MatchID),
    FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID)
);

CREATE TABLE Standing (
    LeagueID VARCHAR(8) NOT NULL,
    TeamID VARCHAR(5) NOT NULL,
    Played SMALLINT NOT NULL DEFAULT 0,
    Wins SMALLINT NOT NULL DEFAULT 0,
    Draws SMALLINT NOT NULL DEFAULT 0,
    Losses SMALLINT NOT NULL DEFAULT 0,
    GoalsFor INT NOT NULL DEFAULT 0,
    GoalsAgainst INT NOT NULL DEFAULT 0,
    GoalDifference AS (GoalsFor - GoalsAgainst) PERSISTED,
    Points AS (Wins * 3 + Draws) PERSISTED,
    PRIMARY KEY (LeagueID, TeamID),
    FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),
    FOREIGN KEY (TeamID) REFERENCES Team(TeamID)
);

CREATE TABLE Match_Referee (
    MatchID INT NOT NULL,
    RefereeID VARCHAR(8) NOT NULL,
    RefereeRole TINYINT NOT NULL,
    Status TINYINT NOT NULL,
    UnavailableReason NVARCHAR(500),
    PRIMARY KEY (MatchID, RefereeID),
    FOREIGN KEY (MatchID) REFERENCES Match(MatchID),
    FOREIGN KEY (RefereeID) REFERENCES Referee(RefereeID)
);

CREATE TABLE League_Team (
    LeagueID VARCHAR(8) NOT NULL,
    TeamID VARCHAR(5) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1 -- 1: Đang tham gia, 0: Đã bị loại / Rút lui
    PRIMARY KEY (LeagueID, TeamID),
    FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),
    FOREIGN KEY (TeamID) REFERENCES Team(TeamID)
);