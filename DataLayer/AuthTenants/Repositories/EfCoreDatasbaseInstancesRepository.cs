using DataLayer.AuthTenants.DataModels;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.AuthTenants.Repositories
{
    
    public class EfCoreDatasbaseInstancesRepository : EfCoreTenantsContextRepository<DatabaseInstance, TenantsContext>
    {
        TenantsContext context ;
        public EfCoreDatasbaseInstancesRepository(TenantsContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<DatabaseInstance> GetbyStringValue(string val)
        {

            return await context.DatabaseInstances.Where(k => k.DatabaseKey == val).FirstOrDefaultAsync();
        }
    }
}
