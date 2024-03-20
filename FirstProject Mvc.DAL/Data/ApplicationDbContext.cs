using FirstProject_Mvc.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.DAL.Data
{
    public class ApplicationDbContext:DbContext
        
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option ) :base(option)
        {
             
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server = DESKTOP-H7D87VE ; database = ApplicationMvc ;Trusted_Connection=True ; encrypt = false");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Department> departments { get; set; }
    }
}
