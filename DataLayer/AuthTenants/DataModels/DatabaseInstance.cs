using DataLayer.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.AuthTenants.DataModels
{
    public partial class DatabaseInstance:IEntity
    {
        public Guid Id { get; set; }
        public string DatabaseKey { get; set; }
        public string DatabaseName { get; set; }
        public byte? Enable { get; set; }
        public string Connection { get; set; }
        public string Others { get; set; }
    }
}
