namespace DTO
{
    public class TeamDTO
    {
        public string TeamID { get; set; }
        public string TeamName { get; set; }
        public string LogoURL { get; set; }
        public string CoachName { get; set; }
        public string HomeStadiumID { get; set; }
        public string StadiumName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public TeamDTO() { }

        public TeamDTO(string teamID, string teamName, string logoURL, string coachName, string email, string phone, string homeStadiumID)
        {
            TeamID = teamID;
            TeamName = teamName;
            LogoURL = logoURL;
            CoachName = coachName;
            Email = email;
            Phone = phone;
            HomeStadiumID = homeStadiumID;
        }
    }
}