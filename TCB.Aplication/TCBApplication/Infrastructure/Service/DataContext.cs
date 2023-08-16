using Microsoft.EntityFrameworkCore;
using TCB.Aplication.Configuration;
using TCB.Aplication.Domain;

namespace TCB.Aplication.Infrastructure.Service;

public class DataContext :DbContext
{
    public DataContext()

    {
        
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<AnonymChat> AnonymChats { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Settings.dbConnectionString);
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Conversations");
        
        modelBuilder
            .Entity<Message>()
            .Property(x => x.Content)
            .HasColumnType("jsonb");
        
        /*modelBuilder
            .Entity<LogView>()
            .Property(x => x.UpdateMessage)
            .HasColumnType("jsonb");*/
        
        modelBuilder
            .Entity<User>()
            .HasIndex(x => x.PhoneNumber)
            .IsUnique();

        modelBuilder
            .Entity<Message>()
            .HasOne(x => x.Client)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.FromId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Message>()
            .HasOne(x => x.Conversation)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ConversationId);

        modelBuilder.Entity<Message>()
            .HasOne(x => x.Board)
            .WithMany(x => x.messages)
            .HasForeignKey(x => x.BoardId);

        modelBuilder
            .Entity<Client>()
            .HasOne(x => x.User)
            .WithOne(x => x.Client)
            .HasForeignKey<Client>(x => x.UserId);

        modelBuilder
            .Entity<Client>()
            .HasMany(x => x.Boards)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);

        modelBuilder
            .Entity<Client>()
            .HasMany(x => x.FromConversations)
            .WithOne(x => x.ClientChatFirst)
            .HasForeignKey(x => x.ClientChatIdFirst);
        
        modelBuilder
            .Entity<Client>()
            .HasMany(x => x.ToConversations)
            .WithOne(x => x.ClientChatLast)
            .HasForeignKey(x => x.ClientChatIdFirst);

       



        base.OnModelCreating(modelBuilder);
    }
}