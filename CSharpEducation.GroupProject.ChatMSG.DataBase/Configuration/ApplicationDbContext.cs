using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation.GroupProject.ChatMSG.DataBase.Configuration
{
  public class ApplicationDbContext : IdentityDbContext<UserEntity>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
  }
  //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
  //{
  //  public ApplicationDbContext CreateDbContext(string[] args)
  //  {
  //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
  //    optionsBuilder.UseNpgsql("Host=localhost;User ID=postgres;Port=5432;Password=daniar007;Database=SSNRT");

  //    return new ApplicationDbContext(optionsBuilder.Options);
  //  }
  //}
}
