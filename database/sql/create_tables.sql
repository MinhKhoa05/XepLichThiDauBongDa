CREATE DATABASE XepLichBongDa;

GO
USE XepLichBongDa;

CREATE TABLE Tournaments (
    TournamentID INT IDENTITY(1, 1) PRIMARY KEY,
    TournamentName NVARCHAR(MAX) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);

CREATE TABLE Rounds (
    RoundID INT IDENTITY(1, 1) PRIMARY KEY,
    RoundName NVARCHAR(MAX) NOT NULL,
    TournamentID INT NOT NULL,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID)
);

CREATE TABLE Stadiums (
    StadiumID INT IDENTITY(1, 1) PRIMARY KEY,
    StadiumName NVARCHAR(MAX) NOT NULL,
    Location NVARCHAR(MAX) NOT NULL,
    Capacity INT NOT NULL
);

CREATE TABLE StadiumUsages (
    UsageID INT IDENTITY(1, 1) NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    isUsing BIT NOT NULL DEFAULT 0,
    StadiumID INT NOT NULL,
    PRIMARY KEY (UsageID, StadiumID),
    FOREIGN KEY (StadiumID) REFERENCES Stadiums(StadiumID)
);

CREATE TABLE Referees (
    RefereeID INT IDENTITY(1, 1) PRIMARY KEY,
    RefereeName NVARCHAR(MAX) NOT NULL,
    Email VARCHAR(MAX),
    SDT VARCHAR(11),
    RefereeImage VARCHAR(MAX)
);

CREATE TABLE Teams (
    TeamID INT IDENTITY(1, 1) PRIMARY KEY,
    TeamName NVARCHAR(MAX) NOT NULL,
    Logo VARCHAR(MAX),
    Email VARCHAR(MAX),
    SDT VARCHAR(11),
    StadiumID INT,
    FOREIGN KEY (StadiumID) REFERENCES Stadiums(StadiumID)
);

CREATE TABLE RoundStandings (
    GroupName VARCHAR(50) NOT NULL,
    Played TINYINT NOT NULL DEFAULT 0,
    Wins TINYINT NOT NULL DEFAULT 0,
    Draws TINYINT NOT NULL DEFAULT 0,
    Losses TINYINT NOT NULL DEFAULT 0,
    Points INT NOT NULL DEFAULT 0,
    RoundID INT NOT NULL,
    TeamID INT NOT NULL,
    PRIMARY KEY (RoundID, TeamID),
    FOREIGN KEY (RoundID) REFERENCES Rounds(RoundID),
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);

CREATE TABLE Matchs (
    MatchID INT IDENTITY(1, 1) PRIMARY KEY,
    Legs BIT NOT NULL,          -- 0 cho luot di, 1 cho luot ve
    isPlayed BIT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    
    RoundID INT NOT NULL,
    HomeTeamID INT NOT NULL,
    AwayTeamID INT NOT NULL,
    StadiumID INT NOT NULL,
    FOREIGN KEY (RoundID) REFERENCES Rounds(RoundID),
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID),
    FOREIGN KEY (homeTeamTeamID) REFERENCES Teams(TeamID),
    FOREIGN KEY (StadiumID) REFERENCES Stadiums(StadiumID)
);

CREATE TABLE MatchResult (
    MatchID INT PRIMARY KEY,
    HomeTeamScore TINYINT NOT NULL,
    AwayTeamScore TINYINT NOT NULL,
    RefereeID INT NOT NULL,                 -- Entered By
    FOREIGN KEY (MatchID) REFERENCES Matchs(MatchID),
    FOREIGN KEY (RefereeID) REFERENCES Referees(RefereeID)
);

CREATE TABLE Assignments (
    Position VARCHAR(50) NOT NULL,
    MatchID INT NOT NULL,
    RefereeID INT NOT NULL,
    PRIMARY KEY (MatchID, RefereeID),
    FOREIGN KEY (MatchID) REFERENCES Matchs(MatchID),
    FOREIGN KEY (RefereeID) REFERENCES Referees(RefereeID)
);