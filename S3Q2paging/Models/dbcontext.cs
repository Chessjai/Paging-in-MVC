using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S3Q2paging.Models
{
    public class dbcontext : DbContext
    {
        public dbcontext() : base("MyConnectionString")
        {
            Database.SetInitializer<dbcontext>(null);
        }
        public DbSet<Studentmodel> models { get; set; }
    }

  
    }
