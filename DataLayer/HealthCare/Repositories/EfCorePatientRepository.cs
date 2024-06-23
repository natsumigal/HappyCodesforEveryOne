using DataLayer.HealthCare.DataModels;
using DataLayer.HealthCare.Repositories;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.HealthCare.Repositories
{
    
    public class EfCorePatientRepository : EfCoreComfortHealthContextRepository<Patient, ComfortHealthContext>
    {
        ComfortHealthContext context ;
        public EfCorePatientRepository(ComfortHealthContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Patient> GetPatientbyDoctor(string val)
        {

            return await context.Patients.Where(k => k.DoctorId.ToString() == val).FirstOrDefaultAsync();
        }
    }
}
