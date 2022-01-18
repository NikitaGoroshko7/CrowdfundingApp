namespace CrowdFundingApplication.Data;

public class ApplicationContext : DbContext 
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // add roles in database
        Role adminRole = new Role { Id = 1, Name = "admin" };
        Role userRole = new Role { Id = 2, Name = "user" };

        modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });

        base.OnModelCreating(modelBuilder);
    }
}
