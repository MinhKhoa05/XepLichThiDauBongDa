CREATE DATABASE XepLichBongDa;

GO
USE XepLichBongDa;

--- Bảng Giải đấu ---
CREATE TABLE Tournaments (
    TournamentID VARCHAR(10) PRIMARY KEY,

    TournamentName NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Format VARCHAR(20) NOT NULL
);

CREATE TABLE Referees (
    RefereeID VARCHAR(10) PRIMARY KEY,
    RefereeName NVARCHAR(100) NOT NULL,
    Hometown NVARCHAR(50) NOT NULL,
    Status INT NOT NULL
);

CREATE TABLE TournamentSettings (
    TournamentID VARCHAR(10) PRIMARY KEY,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID),

    MaxMatchPerDay TINYINT NOT NULL,
    MinRestDay TINYINT NOT NULL
);

CREATE TABLE Stadiums (
    StadiumID VARCHAR(10) PRIMARY KEY,
    StadiumName NVARCHAR(50) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    isNeutral BIT NOT NULL DEFAULT 0
);

CREATE TABLE Tournament_Refferee (
    TournamentID VARCHAR(10) NOT NULL,
    RefereeID VARCHAR(10) NOT NULL,
    PRIMARY KEY (TournamentID, RefereeID),
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID),
    FOREIGN KEY (RefereeID) REFERENCES Referees(RefereeID)
);

CREATE TABLE NeutralStadium (
    TournamentID VARCHAR(10) NOT NULL,
    StadiumID VARCHAR(10) NOT NULL,
    PRIMARY KEY (TournamentID, StadiumID),
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID),
    FOREIGN KEY (StadiumID) REFERENCES Stadiums(StadiumID)
);

CREATE TABLE TournamentSettings_AllowMatchesDay (
    TournamentID VARCHAR(10) NOT NULL,

    AllowMatchesDay TINYINT NOT NULL,   ---- 1 | 2 | 3 | 4 | 5 | 6 | 7
    PRIMARY KEY (AllowMatchesDay, TournamentID),
    FOREIGN KEY (TournamentID) REFERENCES TournamentSettings(TournamentID)
);

CREATE TABLE TournamentSettings_DefaultMatchtimes (
    TournamentID VARCHAR(10) NOT NULL,

    DefaultMatchtimes TIME NOT NULL,
    PRIMARY KEY (DefaultMatchtimes, TournamentID),
    FOREIGN KEY (TournamentID) REFERENCES TournamentSettings(TournamentID)
);

CREATE TABLE Teams (
    TeamID VARCHAR(10) PRIMARY KEY,
    TeamName NVARCHAR(50) NOT NULL,
    Logo VARCHAR(255),
    Hometown NVARCHAR(100) NOT NULL,
    HomeStadiumID VARCHAR(10),
    FOREIGN KEY (StadiumID) REFERENCES Stadiums(StadiumID)
);

CREATE TABLE Tournaments_Team (
    TournamentID VARCHAR(10) NOT NULL,
    TeamID VARCHAR(10) NOT NULL,
    isOut BIT NOT NULL,

    PRIMARY KEY (TournamentID, TeamID),
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID),
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);