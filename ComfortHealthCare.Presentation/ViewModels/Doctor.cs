using System;

namespace ComfortHealthCare.Presentation.ViewModels
{
    public partial class Doctor
    {
        public Guid Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorIdentity { get; set; }
        public string Specialty { get; set; } // Corrected spelling
        public string Others { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string DoctorEmail { get; set; }
        public bool? DeleteFlag { get; set; } // Corrected casing
    }
}
