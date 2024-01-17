using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ajay_chouhan.Model;
using System;

namespace ajay_chouhan.Data
{
    public class ajay_chouhanContext : DbContext
    {
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Ajay_Chouhan;Persist Security Info=True;user id=sa;password=12345;Integrated Security=true;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}