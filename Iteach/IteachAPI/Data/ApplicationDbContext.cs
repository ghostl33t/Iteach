using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using Microsoft.EntityFrameworkCore;

namespace IteachAPI.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }  
    public DbSet<Child> Childs { get; set; }
    public DbSet<TeachPlan> TeachPlans { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<ChildTest> ChildTests { get; set; }
    public DbSet<TeachPlanUser> TeachPlanUsers { get; set; }
    public DbSet<TestResponse> TestResponses { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }

}