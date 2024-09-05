using Microsoft.EntityFrameworkCore;
using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace CSharpEducation.GroupProject.ChatMSG.Core.DataBase
{
	public class DataContext : DbContext
	{
		 
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Chat> Chat { get; set; }
		public DbSet<User> User { get; set; }

	}
}
