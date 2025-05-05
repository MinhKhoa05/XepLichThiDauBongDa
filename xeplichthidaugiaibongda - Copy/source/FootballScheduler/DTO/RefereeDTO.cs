using System;

namespace DTO
{
    public class RefereeDTO
    {
        public string RefereeID { get; set; }
        public string RefereeName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public RefereeDTO() { }

        public RefereeDTO(string refereeID, string refereeName, string email, string phone, DateTime birthDate)
        {
            RefereeID = refereeID;
            RefereeName = refereeName;
            Email = email;
            PhoneNumber = phone;
            BirthDate = birthDate;
        }
    }
}