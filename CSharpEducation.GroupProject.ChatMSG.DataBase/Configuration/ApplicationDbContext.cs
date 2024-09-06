using CSharpEducation.GroupProject.ChatMSG.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CSharpEducation.GroupProject.ChatMSG.DataBase.Configuration
{
  public class ApplicationDbContext : IdentityDbContext<UserEntity>
  {
    public DbSet<ChatEntity> Chats { get; set; }
    public DbSet<MessageEntity> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<ChatEntity>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
        entity.HasMany(m => m.Messages)
              .WithOne(c => c.Chat)
              .HasForeignKey(c => c.ChatId);
      });
      //TODO в отдельном классе
      builder.Entity<MessageEntity>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.UserId).IsRequired();
        entity.Property(e => e.ChatId).IsRequired();
        entity.Property(e => e.Content).IsRequired();
        entity.Property(e => e.DateTime).IsRequired();
        entity.HasOne(u => u.User).WithMany(m => m.Messages).HasForeignKey(u => u.UserId);
      });
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
  }
}
