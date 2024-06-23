namespace ComfortHealthCare.API.Queries
{
    public class PatientHistoryCommand
    {
        public Guid Id { get; set; }
        public Guid? Pid { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? Bmi { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string BloodGroup { get; set; }
        public string IllnessHistory { get; set; }
        public string AllergiesHistory { get; set; }
        public string PastMedicineTaking { get; set; }
        public string CurrentMedicineTaking { get; set; }
        public string Others { get; set; }
        public string Gpefindings { get; set; }
        public string Investigation { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
   
    }
}
