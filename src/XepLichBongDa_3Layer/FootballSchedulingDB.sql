CREATE DATABASE FootballScheduling;

GO
USE FootballScheduling;

/*
============================
=====   CREATE TABLE   =====
============================
*/

-- League details
CREATE TABLE League (
    LeagueID        VARCHAR(8)      PRIMARY KEY,
    LeagueName      NVARCHAR(255)   NOT NULL,
    MaxMatchPerDay  TINYINT         NOT NULL    CHECK(MaxMatchPerDay > 0),          -- Maximum match per day
    MinRestDay      TINYINT         NOT NULL    DEFAULT 2 CHECK(MinRestDay > 0)     -- Minimum rest days per team
);

-- Season details
CREATE TABLE Season (
	SeasonID    VARCHAR(20)     PRIMARY KEY,    -- eg: '{LeagueID}-2024-2025'
    StartDate   DATE            NOT NULL,
    EndDate     DATE            NOT NULL,
	LeagueID    VARCHAR(8)      NOT NULL,

    CONSTRAINT FK_Season_League FOREIGN KEY (LeagueID) REFERENCES League(LeagueID),

    CONSTRAINT CK_SeasonDates CHECK(StartDate < EndDate)
);

-- Stadium details
CREATE TABLE Stadium (
    StadiumID       VARCHAR(8)      PRIMARY KEY,
    StadiumName     NVARCHAR(255)   NOT NULL,
    Address         NVARCHAR(500)   NOT NULL,
    IsNeutral       BIT             NOT NULL    DEFAULT 0,  -- 1: Neutral venue, 0: Home venue
    Status          TINYINT         NOT NULL                -- 1: Active, 2: Inactive, 3: Maintenance
);

-- User accounts (admins, team managers, referees)
CREATE TABLE UserAccount (
    UserID          INT IDENTITY(1, 1)  PRIMARY KEY,
    Username        VARCHAR(50)         NOT NULL    UNIQUE,
    PasswordHash    NVARCHAR(255)       NOT NULL,
    UserRole        TINYINT             NOT NULL,   -- 0: SuperAdmin, 1: Admin, 2: Team Manager, 3: Referee
    Status          TINYINT             NOT NULL,   -- 1: Active, 2: Inactive
    Email           NVARCHAR(255)       NULL,
    PhoneNumber     NVARCHAR(20)        NULL
);

-- Teams participating in leagues
CREATE TABLE Team (
    TeamID      VARCHAR(5)      PRIMARY KEY,
    TeamName    NVARCHAR(255)   NOT NULL,
    Logo        NVARCHAR(255)   NULL,       -- Team logo (URL or file path)
    Origin      NVARCHAR(255)   NOT NULL,   -- Team's origin (hometown for small leagues, country for major leagues)
    StadiumID   VARCHAR(8)      NULL,       -- Home stadium (NULL if not assigned)
    UserID      INT             NOT NULL,   -- Linked to the team manager

    CONSTRAINT  FK_Team_Stadium      FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID),
    CONSTRAINT  FK_Team_UserAccount  FOREIGN KEY (UserID)    REFERENCES UserAccount(UserID)
);

-- Match details (teams, scores, status)
CREATE TABLE Match (
    MatchID         INT IDENTITY(1,1)   PRIMARY KEY,
    HomeTeamID      VARCHAR(5)          NOT NULL,
    AwayTeamID      VARCHAR(5)          NOT NULL,
    HomeScore       TINYINT             NULL,       -- Goals scored by the home team (NULL if the match hasn't been played)
    AwayScore       TINYINT             NULL,       -- Goals scored by the away team (NULL if the match hasn't been played)
    Round           TINYINT             NOT NULL,
    SeasonID        VARCHAR(20)         NOT NULL,
    Status          TINYINT             NOT NULL,
    -- StatusCode:  1: Scheduled, 2. Postponed, 3: Pending Result, 4: Pending Confirmation, 5: Completed, 6: Canceled

    CONSTRAINT FK_Match_Team_Home   FOREIGN KEY (HomeTeamID) REFERENCES Team(TeamID),    
    CONSTRAINT FK_Match_Team_Away   FOREIGN KEY (AwayTeamID) REFERENCES Team(TeamID),
    CONSTRAINT FK_Match_Season      FOREIGN KEY (SeasonID)   REFERENCES Season(SeasonID)
);

-- Referee details
CREATE TABLE Referee (
    RefereeID           VARCHAR(8)      PRIMARY KEY,
    RefereeName         NVARCHAR(255)   NOT NULL,
    Origin              NVARCHAR(255)   NOT NULL,
    ExperienceYears     TINYINT         NOT NULL,
    Status              TINYINT         NOT NULL    DEFAULT 1,   -- 1: Active, 2: Retired, 3: Suspended
    UserID              INT             NOT NULL,

    CONSTRAINT FK_Referee_UserAccount FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);

-- Match scheduling (date, time, stadium)
CREATE TABLE MatchSchedule (
    ScheduleID      INT IDENTITY(1,1),
    MatchID         INT             NOT NULL,
    MatchDateTime   DATETIME        NOT NULL,
    StadiumID       VARCHAR(8)      NOT NULL,
    IsActive        BIT             NOT NULL    DEFAULT 1, -- 1: Active, 0: Canceled/Rescheduled
    Reason          NVARCHAR(255)   NULL,               -- Reason for schedule change
    
    PRIMARY KEY (ScheduleID, MatchID),
    
    CONSTRAINT FK_MatchSchedule_Match FOREIGN KEY (MatchID) REFERENCES Match(MatchID),
    CONSTRAINT FK_MatchSchedule_Stadium FOREIGN KEY (StadiumID) REFERENCES Stadium(StadiumID)
);

-- League standings with auto-calculated fields
CREATE TABLE Standing (
    SeasonID        VARCHAR(20) NOT NULL,
    TeamID          VARCHAR(5)  NOT NULL,
    Played          SMALLINT    NOT NULL DEFAULT 0,
    Wins            SMALLINT    NOT NULL DEFAULT 0,
    Draws           SMALLINT    NOT NULL DEFAULT 0,
    Losses          SMALLINT    NOT NULL DEFAULT 0,
    GoalsFor        INT         NOT NULL DEFAULT 0,
    GoalsAgainst    INT         NOT NULL DEFAULT 0,
    WithdrawAt      DATE        NULL,               -- NULL = Still competing, has a date = Withdrawn from the league

    GoalDifference  AS (GoalsFor - GoalsAgainst) PERSISTED,
    Points          AS (Wins * 3 + Draws)        PERSISTED,

    PRIMARY KEY (SeasonID, TeamID),

    CONSTRAINT FK_Standing_Season   FOREIGN KEY (SeasonID)  REFERENCES Season(SeasonID),
    CONSTRAINT FK_Standing_Team     FOREIGN KEY (TeamID)    REFERENCES Team(TeamID)
);

-- Referee assignments for matches
CREATE TABLE Match_Referee (
    MatchID         INT             NOT NULL,
    RefereeID       VARCHAR(8)      NOT NULL,
    RefereeRole     TINYINT         NOT NULL,               -- 1: Main, 2: Assistant 1, 3: Assistant 2, 4: Fourth Official, 5: VAR, 6: Assistant VAR
	Status          TINYINT         NOT NULL    DEFAULT 1,  -- 1: Pending, 2: Accepted, 3: Declined
    Reason          NVARCHAR(255)   NULL,                   -- Reason for Declined

    PRIMARY KEY (MatchID, RefereeID),

    CONSTRAINT FK_MatchReferee_Match    FOREIGN KEY (MatchID)   REFERENCES Match(MatchID),
    CONSTRAINT FK_MatchReferee_Referee  FOREIGN KEY (RefereeID) REFERENCES Referee(RefereeID)
);

-- Notifications sent to users
CREATE TABLE Notification (
    NotificationID      INT IDENTITY(1,1)   PRIMARY KEY,
    UserID              INT                 NOT NULL,                       -- Recipient of the notification
    Message             NVARCHAR(500)       NOT NULL,                       -- Notification content
    CreatedAt           DATETIME            NOT NULL    DEFAULT GETDATE(),  -- Timestamp of notification
    IsRead              BIT                 NOT NULL    DEFAULT 0,          -- 0: Unread, 1: Read
    NotificationType    TINYINT             NOT NULL,
    -- TypeCode: 1: Match Result Update, 2: Schedule Change, 3: Cancellation, 4: Referee Assignment, 5: Reminder, 6: Announcement

    CONSTRAINT FK_Notification_UserAccount FOREIGN KEY (UserID) REFERENCES UserAccount(UserID)
);