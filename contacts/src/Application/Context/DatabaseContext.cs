using contacts.Domain;
using Microsoft.EntityFrameworkCore;

namespace contacts.Application.Context;

public class DatabaseContext: DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    public DbSet<Contact> Contacts { get; set; }
}