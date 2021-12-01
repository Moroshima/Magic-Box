namespace MagicalBox.Model
{
    public class User
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public string Username { get; set; }
        public string IdCard { get; set; }
        public string BoardCard { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string BackupLink { get; set; }
        public string? Comment { get; set; }
        public bool? Returned { get; set; }
        public Satisfaction? Satisfaction { get; set; }
        public User()
        {
            Username = string.Empty;
            IdCard = string.Empty;
            BoardCard = string.Empty;
            Departure = string.Empty;
            Destination = string.Empty;
        }
    }

    public enum Satisfaction
    {
        Unidentified, Satisfied, Unsatisfied
    }
}
