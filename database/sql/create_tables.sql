CREATE DATABASE QuanLyBongDa;
GO
USE QuanLyBongDa;

--- Bảng Giải Đấu ---
CREATE TABLE Tournaments (
    TournamentID INT PRIMARY KEY,
    TournamentName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL
);

--- Bảng Sân Vận Động ---
CREATE TABLE Stadiums (
    StadiumID INT PRIMARY KEY,
    Location NVARCHAR(50) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
);

--- Bảng Huấn Luyện Viên ---
CREATE TABLE Coachs (
    CoachID INT PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
);

--- Bảng Đội Bóng ---
CREATE TABLE Teams (
    TeamID INT PRIMARY KEY,
    TeamName NVARCHAR(50) NOT NULL,
    Logo NVARCHAR(50) NOT NULL,
    CoachID INT NOT NULL,
    StadiumID INT NOT NULL,
    FOREIGN KEY (CoachID) REFERENCES Coachs(CoachID),
    FOREIGN KEY (StadiumID) REFERENCES Stadiums(StadiumID)
);

--- Bảng Cầu Thủ ---
CREATE TABLE Players (
    PlayerID INT PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    JerseyNumber TINYINT NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    TeamID INT NOT NULL,
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);

--- Bảng Đăng ký Giải Đấu ---
CREATE TABLE Registrations (
    RegistrationID INT NOT NULL,
    TournamentID INT NOT NULL,
    TeamID INT NOT NULL,
    RegistrationsDate DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    PRIMARY KEY (RegistrationID, TournamentID, TeamID),
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID),
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);

--- Bảng Vòng Đấu ---
CREATE TABLE Rounds (
    RoundID INT NOT NULL,
    RoundName INT NOT NULL,
    EndDate INT NOT NULL,
    StartDate INT NOT NULL,
    TournamentID INT NOT NULL,
    PRIMARY KEY (RoundID, TournamentID),
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID)
);

--- Bảng Bảng Đấu ---
CREATE TABLE Groups (
    GroupID INT NOT NULL,
    GroupName INT NOT NULL,
    TournamentID INT NOT NULL,
    PRIMARY KEY (GroupID, TournamentID),
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID)
);

--- Bảng trung gian giữa Teams với Groups 
CREATE TABLE Group_Teams (
    GroupID INT NOT NULL,
    TournamentID INT NOT NULL,
    TeamID INT NOT NULL,
    PRIMARY KEY (GroupID, TournamentID, TeamID),
    FOREIGN KEY (GroupID, TournamentID) REFERENCES Groups(GroupID, TournamentID),
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);

--- Bảng Ranking ---
CREATE TABLE Ranking (
    GroupID INT NOT NULL,
    TournamentID INT NOT NULL,
    TeamID INT NOT NULL,
    Played TINYINT DEFAULT 0 CHECK (Played >= 0),
    Won TINYINT DEFAULT 0 CHECK (Won >= 0),
    Draw TINYINT DEFAULT 0 CHECK (Draw >= 0),
    Lost TINYINT DEFAULT 0 CHECK (Lost >= 0),
    GoalsScored TINYINT DEFAULT 0 CHECK (GoalsScored >= 0),
    GoalsConceded TINYINT DEFAULT 0 CHECK (GoalsConceded >= 0),
    Points SMALLINT DEFAULT 0 CHECK (Points >= 0),
    GoalDifference TINYINT DEFAULT 0,
    PRIMARY KEY (GroupID, TournamentID, TeamID),
    FOREIGN KEY (GroupID, TournamentID) REFERENCES Groups(GroupID, TournamentID),
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);

--- Bảng Trận Đấu ---
CREATE TABLE Matches (
    MatchID INT PRIMARY KEY,
    HomeTeamID INT NOT NULL,
    AwayTeamID INT NOT NULL,
    RoundID INT NOT NULL,
    TournamentID INT NOT NULL,
    GroupID INT,
    FOREIGN KEY (HomeTeamID) REFERENCES Teams(TeamID),
    FOREIGN KEY (AwayTeamID) REFERENCES Teams(TeamID),
    FOREIGN KEY (RoundID, TournamentID) REFERENCES Rounds(RoundID, TournamentID),
    FOREIGN KEY (GroupID, TournamentID) REFERENCES Groups(GroupID, TournamentID)
);

--- Bảng Trọng Tài ---
CREATE TABLE Referees (
    RefereeID INT PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
    Email VARCHAR(50) NOT NULL
);

--- Bảng Lịch Thi Đấu ---
CREATE TABLE MatchSchedules (
    ScheduleID INT PRIMARY KEY,
    Status INT NOT NULL,
    MatchDateTime INT NOT NULL,
    MatchID INT NOT NULL,
    StadiumID INT NOT NULL,
    RefereeID INT NOT NULL,
    FOREIGN KEY (MatchID) REFERENCES Matches(MatchID),
    FOREIGN KEY (StadiumID) REFERENCES Stadiums(StadiumID),
    FOREIGN KEY (RefereeID) REFERENCES Referees(RefereeID)
);

--- Bảng Phân Công Trọng tài ---
CREATE TABLE assign (
    ScheduleID INT NOT NULL,
    RefereeID INT NOT NULL,
    PRIMARY KEY (ScheduleID, RefereeID),
    FOREIGN KEY (ScheduleID) REFERENCES MatchSchedules(ScheduleID),
    FOREIGN KEY (RefereeID) REFERENCES Referees(RefereeID)
);

--- Bảng Kết Quả Trận Đấu ---
CREATE TABLE MatchResults (
    MatchID INT PRIMARY KEY,
    HomeTeamScore INT NOT NULL,
    AwayTeamScore INT NOT NULL,
    FOREIGN KEY (MatchID) REFERENCES Matches(MatchID)
);