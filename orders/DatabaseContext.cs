using Microsoft.EntityFrameworkCore;
using orders.Domain;
using System.Collections.Generic;

namespace orders;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Provider> Providers { get; set; }
}