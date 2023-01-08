using Microsoft.EntityFrameworkCore;

namespace MithrasPieShop.Models;

public class MithrasPieShopDbContext : DbContext
{
    // The below is used if you do not specify specify code in the Program.cs
    // If you do specify the connection string to use and the server version in program.cs
    // then you can have an empty constructor as shown below
    
    /*protected readonly IConfiguration Configuration;

    public MithrasPieShopDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("MithrasPieShopDBContextConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }*/
    
    public MithrasPieShopDbContext(DbContextOptions<MithrasPieShopDbContext> options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Pie> Pies { get; set; }
}