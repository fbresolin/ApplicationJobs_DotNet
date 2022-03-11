using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationJobs.API.Entities;

namespace ApplicationJobs.API.Persistence.Repositories
{
  public class JobApplicationRepository : IJobApplicationRepository
  {
    private readonly ApplicationJobsContext _context;
    public JobApplicationRepository(ApplicationJobsContext context)
    {
      _context = context;
    }
    public void AddApplication(JobApplication jobApplication)
    {
      _context.JobApplications.Add(jobApplication);
      _context.SaveChanges();
    }

    public JobApplication? GetById(int id)
    {
      return _context.JobApplications.FirstOrDefault(ja => ja.Id == id);
    }
  }
}