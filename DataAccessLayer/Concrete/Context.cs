using EntityLayer.Conrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7C53G4M\\SQLEXPRESS;database=DbNewOopCoreNotes;integrated security=true");
        }
        public DbSet<Notes> Notes { get; set; }
    }
}
