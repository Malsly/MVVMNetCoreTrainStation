using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ReposirotyAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DAl.Impl.Repositories
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ReposirotyAPIContext>
    {
        public ReposirotyAPIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReposirotyAPIContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrainStaionDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new ReposirotyAPIContext(optionsBuilder.Options);
        }
    }
}
