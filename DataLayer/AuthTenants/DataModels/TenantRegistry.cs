using DataLayer.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.AuthTenants.DataModels
{
    public partial class TenantRegistry: IEntity
    {
        public Guid Id { get; set; }
        public string Tenant { get; set; }
        public string TenantKey { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
