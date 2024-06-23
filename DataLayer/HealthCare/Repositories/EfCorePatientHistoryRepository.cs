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
    
    public class EfCorePatientHistoryRepository : EfCoreComfortHealthContextRepository<PatientHistoryDetail, ComfortHealthContext>
    {
        ComfortHealthContext context ;
        public EfCorePatientHistoryRepository(ComfortHealthContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<PatientHistoryDetail>> GetPatientHistorybyPatient(int num,string val)
        {

            return await context.PatientHistoryDetails.Where(k => k.Pid.ToString() == val).Take(num).ToListAsync();
        }
    }
}
