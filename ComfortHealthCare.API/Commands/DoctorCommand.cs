namespace ComfortHealthCare.API.Queries
{
    public class DoctorCommand
    {
        public Guid Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorIdentity { get; set; }
        public string Specility { get; set; }
        public string Others { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string DoctorEmail { get; set; }
    }
}
