using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core_Proje_Api.DAL.Entity;

namespace Core_Proje_Api.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=UNSAL\\SQLEXPRESS;database=CoreProjeApiDB;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
