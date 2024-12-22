using Microsoft.EntityFrameworkCore;
using BudgetAppAPI.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Compte> Comptes { get; set; }
    public DbSet<Categorie> Categories { get; set; }
    public DbSet<TransactionNormale> TransactionsNormales { get; set; }
    public DbSet<TransactionBoursiere> TransactionsBoursieres { get; set; }
    public DbSet<Actif> Actifs { get; set; }
    public DbSet<Budget> Budgets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Compte>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Utilisateur)
                .WithMany(u => u.Comptes);
        });

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Actif>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<TransactionNormale>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(t => t.Categorie);
            entity.HasOne(t => t.Compte)
                .WithMany(c => c.TransactionsNormales);
        });

        modelBuilder.Entity<TransactionBoursiere>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(t => t.Compte)
                .WithMany(c => c.TransactionsBoursieres);
            entity.HasOne(t => t.Actif);
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(b => b.Utilisateur);
            entity.HasOne(b => b.Categorie);
        });
    }
}
