CREATE DATABASE FootballScheduling;

GO
USE FootballScheduling;

-- League details
CREATE TABLE League (
    LeagueID VARCHAR(8) PRIMARY KEY,
    LeagueName NVARCHAR(255) NOT NULL,
    MaxMatchPerDay TINYINT NOT NULL CHECK (MaxMatchPerDay >= 0),  -- Maximum match per day
    MinRestDay TINYINT NOT NULL DEFAULT 2 CHECK (MinRestDay >= 0) -- Minimum rest days per team
);

-- Season details
CREATE TABLE Season (
	SeasonID VARCHAR(9) PRIMARY KEY,
	SeasonName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
	LeagueID VARCHAR(8) NOT NULL,
	FOREIGN KEY(LeagueID) REFERENCES League(LeagueID)
);

-- Stadium details
CREATE TABLE Stadium (
    StadiumID VARCHAR(8) PRIMARY KEY,  
    StadiumName NVARCHAR(255) NOT NULL, 
    Address NVARCHAR(500) NOT NULL,    
    IsNeutral BIT NOT NULL DEFAULT 0,  -- 1: Neutral venue, 0: Home venue
    Status TINYINT NOT NULL             -- 1: Active, 2: Inactive, 3: Maintenance
);

-- User accounts (admins, team managers, referees)
CREATE TABLE UserAccount (
    UserID INT IDENTITY(1, 1) PRIMARY KEY, 
    Username VARCHAR(50) NOT NULL UNIQUE, 
    PasswordHash NVARCHAR(255) NOT NULL,   
    UserRole TINYINT NOT NULL, -- 1: Admin, 2: Team Manager, 3: Referee
    Status TINYINT NOT NULL,   -- 1: Active, 2: Inactive
    Email NVARCHAR(255),                   
    PhoneNumber NVARCHAR(20)               
);

-- Teams participating in leagues
CREATE TABLE Team (
    TeamID VARCHAR(5) PRIMARY KEY,  
    TeamName NVARCHAR(255) NOT NULL, 
    Logo NVARCHAR(255),  -- Team logo (URL or file path)
    Origin NVARCHAR(255) NOT NULL,  
    StadiumID VARCHAR(8) NULL, -- Home stadium (NULL if not assigned)
    UserID INT NOT NULL, -- Linked to the team manager
    FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID),
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);

-- Match details (teams, scores, status)
CREATE TABLE Match (
    MatchID INT IDENTITY(1,1) PRIMARY KEY, 
    HomeTeamID VARCHAR(5) NOT NULL,        
    AwayTeamID VARCHAR(5) NOT NULL,        
    HomeScore TINYINT NULL CHECK (HomeScore >= 0), 
    AwayScore TINYINT NULL CHECK (AwayScore >= 0), 
    Round TINYINT NOT NULL,                
    SeasonID VARCHAR(9) NOT NULL,          
    Status TINYINT NOT NULL, -- 1: Scheduled, 2. Postponed, 3: Pending Result, 4: Completed
    FOREIGN KEY (HomeTeamID) REFERENCES Team(TeamID),
    FOREIGN KEY (AwayTeamID) REFERENCES Team(TeamID),
    FOREIGN KEY (SeasonID) REFERENCES Season(SeasonID),
    CONSTRAINT CK_DifferentTeams CHECK (HomeTeamID <> AwayTeamID) 
);

-- Referee details
CREATE TABLE Referee (
    RefereeID VARCHAR(8) PRIMARY KEY,  
    RefereeName NVARCHAR(255) NOT NULL, 
    Origin NVARCHAR(255) NOT NULL,     
    ExperienceYears TINYINT NOT NULL,  
    Status TINYINT NOT NULL, -- 1: Active, 2: Retired, 3: Suspended
    UserID INT NOT NULL,               
    FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);

-- Match scheduling (date, time, stadium)
CREATE TABLE MatchSchedule (
    ScheduleID INT IDENTITY(1,1), 
    MatchID INT NOT NULL,         
    MatchDateTime DATETIME NOT NULL, 
    StadiumID VARCHAR(8) NOT NULL,  
    PRIMARY KEY (ScheduleID, MatchID),
    FOREIGN KEY (MatchID) REFERENCES Match(MatchID),
    FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID)
);

-- League standings with auto-calculated fields
CREATE TABLE Standing (
    SeasonID VARCHAR(9) NOT NULL, 
    TeamID VARCHAR(5) NOT NULL,   
    Played SMALLINT NOT NULL DEFAULT 0, 
    Wins SMALLINT NOT NULL DEFAULT 0,   
    Draws SMALLINT NOT NULL DEFAULT 0,  
    Losses SMALLINT NOT NULL DEFAULT 0, 
    GoalsFor INT NOT NULL DEFAULT 0,    
    GoalsAgainst INT NOT NULL DEFAULT 0, 
    GoalDifference AS (GoalsFor - GoalsAgainst) PERSISTED, 
    Points AS (Wins * 3 + Draws) PERSISTED, 
    PRIMARY KEY (SeasonID, TeamID),
    FOREIGN KEY (SeasonID) REFERENCES Season(SeasonID),
    FOREIGN KEY (TeamID) REFERENCES Team(TeamID)
);

-- Referee assignments for matches
CREATE TABLE Match_Referee (
    MatchID INT NOT NULL,   
    RefereeID VARCHAR(8) NOT NULL, 
    RefereeRole TINYINT NOT NULL,  -- 1: Main, 2: Assistant, 3: VAR
	Status TINYINT NOT NULL,  -- 1: Pending, 2: Accepted, 3: Declined
    Reason NVARCHAR(500), 
    PRIMARY KEY (MatchID, RefereeID),
    FOREIGN KEY (MatchID) REFERENCES Match(MatchID),
    FOREIGN KEY (RefereeID) REFERENCES Referee(RefereeID)
);

-- Teams registered in a season
CREATE TABLE Season_Team (
    SeasonID VARCHAR(9) NOT NULL, 
    TeamID VARCHAR(5) NOT NULL,   
    IsActive BIT NOT NULL DEFAULT 1, -- 1: Active, 0: Withdrawn
    PRIMARY KEY (SeasonID, TeamID),
    FOREIGN KEY (SeasonID) REFERENCES Season(SeasonID),
    FOREIGN KEY (TeamID) REFERENCES Team(TeamID)
);