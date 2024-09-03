using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Entities;

namespace NotesApp.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Database=notesapp;Username=ayush;Password=");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAddOrUpdate();
        modelBuilder.Entity<Note>().Property(u => u.CreatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAdd();
        modelBuilder.Entity<Note>().Property(u => u.UpdatedAt).HasDefaultValueSql("now()").ValueGeneratedOnAddOrUpdate();

    }
}
