using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class DemoDBContext : DbContext 
    {
        public DemoDBContext() : base("DemoDBContext") 
        {
        }
        public DbSet<HocTap> HocTaps { get; set; }
        public DbSet<Lop> Lops { get; set; }

        public System.Data.Entity.DbSet<Demo.Models.Account> Accounts { get; set; }
    }
}
//DESKTOP-GIPHEE4\SQLEXPRESS