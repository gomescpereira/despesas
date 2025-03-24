using System.Reflection;
using Fina.Core.Models;
using Fina.Core.Models.Reports;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    public DbSet<IncomesAndExpenses> IncomesAndExpenses { get; set; } = null!;
    public DbSet<IncomesByCategory> IncomesByCategories { get; set; } = null!;
    public DbSet<ExpensesByCategory> ExpensesByCategories { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<IncomesAndExpenses>()
             .HasNoKey()
             .ToView("vwGetIncomesAndExpenses");

        modelBuilder.Entity<IncomesByCategory>()
            .HasNoKey()
            .ToView("vwGetIncomesByCategory");

        modelBuilder.Entity<ExpensesByCategory>()
            .HasNoKey()
            .ToView("vwGetExpensesByCategory");
    }

}
