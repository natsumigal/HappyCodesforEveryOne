using System;
using System.Collections.Generic;

#nullable disable

namespace ComfortHealthCare.Presentation.ViewModels
{
    public partial class Patient 
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string PatientAddress { get; set; }
        public string Nrc { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Sex { get; set; }
        public string Contact { get; set; }
        public Guid DoctorId { get; set; }
        public bool? Deleteflag { get; set; }
    }
}
