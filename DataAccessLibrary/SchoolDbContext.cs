using Entities;
using System.Data.Entity;

public class SchoolDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }

    public SchoolDbContext()
    {
    }
}
