namespace CrowdFundingApplication.Data;

public class ApplicationContext : IdentityDbContext<User>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }

    public DbSet<CreateProject> createProjects { get; set; }
}