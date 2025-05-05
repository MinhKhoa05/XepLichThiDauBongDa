namespace DTO
{
    public class StadiumDTO
    {
        public string StadiumID { get; set; }
        public string StadiumName { get; set; }
        public string Address { get; set; }

        public StadiumDTO() { }

        public StadiumDTO(string stadiumID, string stadiumName, string address)
        {
            StadiumID = stadiumID;
            StadiumName = stadiumName;
            Address = address;
        }
    }
}
