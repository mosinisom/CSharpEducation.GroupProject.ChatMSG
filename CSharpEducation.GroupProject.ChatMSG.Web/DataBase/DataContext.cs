using Microsoft.EntityFrameworkCore;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;

namespace CSharpEducation.GroupProject.ChatMSG.Web.DataBase
{
	public class DataContext : DbContext
	{
		protected readonly IConfiguration Configuration;
	
		public DataContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
		}

		public DbSet<Chat> Chat { get; set; }
		public DbSet<User> User { get; set; }

	}
}
