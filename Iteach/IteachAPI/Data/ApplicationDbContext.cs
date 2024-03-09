using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using Microsoft.EntityFrameworkCore;

namespace IteachAPI.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> UserTable { get; set; }  
    public DbSet<Child> ChildsTable { get; set; }
    public DbSet<TeachPlan> TeachPlanTable { get; set; }
    public DbSet<Test> TestTable { get; set; }
    public DbSet<ChildTest> ChildTestTable { get; set; }
    public DbSet<TeachPlanUser> TeachPlanUserTable { get; set; }
    public DbSet<TestResponse> TestResponseTable { get; set; }

}