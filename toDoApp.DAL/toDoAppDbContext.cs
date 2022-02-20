using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.Entities;

namespace toDoApp.DAL
{
   public class toDoAppDbContext:DbContext
    {
        public toDoAppDbContext()
             : base("data source=.\\SQLEXPRESS;database=toDoAppDb;integrated security=true;")
        {
        }

        public virtual DbSet<Content> Contents { get; set; }
    }
}
