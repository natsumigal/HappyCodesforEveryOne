using DataLayer.HealthCare.DataModels;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.HealthCare.Repositories
{
    
    public class EfCoreDoctorRepository : EfCoreComfortHealthContextRepository<Doctor, ComfortHealthContext>
    {
        ComfortHealthContext context;
        public EfCoreDoctorRepository(ComfortHealthContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Doctor> GetDoctorbyName(string val)
        {

            return await context.Doctors.Where(k => k.DoctorName.ToString() == val).FirstOrDefaultAsync();
        }
    }
}
