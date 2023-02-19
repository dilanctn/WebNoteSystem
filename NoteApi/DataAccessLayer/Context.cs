using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7C53G4M\\SQLEXPRESS;database=DbNewOopCoreApiNotes;integrated security=true");
        }
        public DbSet<NotesEntities> Notes { get; set; }

    }
}
