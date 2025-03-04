CREATE DATABASE XepLichBongDa;

GO
USE XepLichBongDa;

CREATE TABLE League (
    LeagueID INT IDENTITY(1,1) PRIMARY KEY,
    LeagueName NVARCHAR(255) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    MaxMatchPerDay INT NOT NULL,
    MinRestDay INT NOT NULL
);

CREATE TABLE Stadium (
    StadiumID INT IDENTITY(1,1) PRIMARY KEY,
    StadiumName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(500) NOT NULL,
    IsNeutral BIT NOT NULL,
    Status TINYINT NOT NULL
);

CREATE TABLE UserAccount (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Status TINYINT NOT NULL,
    Email NVARCHAR(255),
    PhoneNumber NVARCHAR(20)
);

CREATE TABLE Team (
    TeamID INT IDENTITY(1,1) PRIMARY KEY,
    TeamName NVARCHAR(255) NOT NULL,
    Logo NVARCHAR(255),
    Hometown NVARCHAR(255) NOT NULL,
    StadiumID INT NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID),
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);

CREATE TABLE Match (
    MatchID INT IDENTITY(1,1) PRIMARY KEY,
    HomeTeamID INT NOT NULL,
    AwayTeamID INT NOT NULL,
    HomeScore INT NULL,
    AwayScore INT NULL,
    Round INT NOT NULL,
    LeagueID INT NOT NULL,
    FOREIGN KEY (HomeTeamID) REFERENCES Team(TeamID),
    FOREIGN KEY (AwayTeamID) REFERENCES Team(TeamID),
    FOREIGN KEY (LeagueID) REFERENCES League(LeagueID)
);

CREATE TABLE Referee (
    RefereeID INT IDENTITY(1,1) PRIMARY KEY,
    RefereeName NVARCHAR(255) NOT NULL,
    Hometown NVARCHAR(255) NOT NULL,
    Status TINYINT NOT NULL,
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);

CREATE TABLE MatchSchedule (
    ScheduleID INT IDENTITY(1,1),
    MatchID INT NOT NULL,
    MatchTime TIME NOT NULL,
    MatchDate DATE NOT NULL,
    Status TINYINT NOT NULL,
    StadiumID INT NOT NULL,
    PRIMARY KEY (ScheduleID, MatchID),
    FOREIGN KEY (MatchID) REFERENCES Match(MatchID),
    FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID)
);

CREATE TABLE Standing (
    LeagueID INT NOT NULL,
    TeamID INT NOT NULL,
    Played INT NOT NULL DEFAULT 0,
    Wins INT NOT NULL DEFAULT 0,
    Draws INT NOT NULL DEFAULT 0,
    Losses INT NOT NULL DEFAULT 0,
    GoalsFor INT NOT NULL DEFAULT 0,
    GoalsAgainst INT NOT NULL DEFAULT 0,
    GoalDifference AS (GoalsFor - GoalsAgainst) PERSISTED,
    Points INT NOT NULL DEFAULT 0,
    PRIMARY KEY (LeagueID, TeamID),
    FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),
    FOREIGN KEY (TeamID) REFERENCES Team(TeamID)
);

CREATE TABLE Match_Referee (
    MatchID INT NOT NULL,
    RefereeID INT NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Status TINYINT NOT NULL,
    Reasons NVARCHAR(500),
    PRIMARY KEY (MatchID, RefereeID),
    FOREIGN KEY (MatchID) REFERENCES Match(MatchID),
    FOREIGN KEY (RefereeID) REFERENCES Referee(RefereeID)
);

CREATE TABLE League_Team (
    LeagueID INT NOT NULL,
    TeamID INT NOT NULL,
    Status TINYINT NOT NULL,
    PRIMARY KEY (LeagueID, TeamID),
    FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),
    FOREIGN KEY (TeamID) REFERENCES Team(TeamID)
);