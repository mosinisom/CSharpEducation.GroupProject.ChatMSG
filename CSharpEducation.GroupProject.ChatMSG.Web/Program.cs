
using CSharpEducation.GroupProject.ChatMSG.Application.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Abstractions;
using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using CSharpEducation.GroupProject.ChatMSG.Core.Services;
using CSharpEducation.GroupProject.ChatMSG.DataBase;
using CSharpEducation.GroupProject.ChatMSG.Web.DataBase;
using Npgsql;


namespace CSharpEducation.GroupProject.ChatMSG.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddScoped<IRepository<ChatEntity>, MockChatRepository>();
			builder.Services.AddScoped<IRepository<MessageEntity>, MockMessageRepository>();
			builder.Services.AddScoped<IChatService, ChatService>();
			builder.Services.AddScoped<IMessageService, MessageService>();
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<DataContext>();


			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.MapControllers();

			


			app.Run();

		
		}
	}
}
