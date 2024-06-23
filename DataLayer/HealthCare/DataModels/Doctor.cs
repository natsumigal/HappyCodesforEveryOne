using DataLayer.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.HealthCare.DataModels
{
    public partial class Doctor:IEntity
    {
        public Guid Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorIdentity { get; set; }
        public string Specility { get; set; }
        public string Others { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string DoctorEmail { get; set; }
        public bool? Deleteflag { get; set; }
    }
}
