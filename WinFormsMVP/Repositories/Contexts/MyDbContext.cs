using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMVP.Models;

namespace WinFormsMVP.Repositories.Contexts;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = DemoMVP; Integrated Security = True;");

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Student>? Students { get; set; }
}