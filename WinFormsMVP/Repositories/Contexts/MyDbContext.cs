using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsMVP.Models;

namespace WinFormsMVP.Repositories.Contexts;

public class MyDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder();
        var path = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
        configurationBuilder.AddJsonFile(path, false);
        var root = configurationBuilder.Build();
        var sqlConnectionString = root.GetConnectionString("DefaultConnectionStr");

        optionsBuilder.UseSqlServer(sqlConnectionString);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Student>? Students { get; set; }
}
