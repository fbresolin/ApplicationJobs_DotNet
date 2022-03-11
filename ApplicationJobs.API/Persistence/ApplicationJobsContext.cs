using ApplicationJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationJobs.API.Persistence
{
  public class ApplicationJobsContext : DbContext
  {
    public ApplicationJobsContext(DbContextOptions<ApplicationJobsContext> options) : base(options)
    {
    }
    public DbSet<JobVacancy> JobVacancies { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<JobVacancy>(e =>
      {
        e.HasKey(jv => jv.Id);
        e.HasMany(jv => jv.Applications)
          .WithOne()
          .HasForeignKey(ja => ja.JobVacancyId)
          .OnDelete(DeleteBehavior.Restrict);
      });
      builder.Entity<JobApplication>(e =>
      {
        e.HasKey(ja => ja.Id);
        //e.HasOne(ja => ja.JobVacancy).WithMany(jv => jv.Applications).HasForeignKey(jv => jv.Id);
      });
    }
  }
}