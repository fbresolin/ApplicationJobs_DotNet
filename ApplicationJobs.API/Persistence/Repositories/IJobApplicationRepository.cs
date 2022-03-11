using ApplicationJobs.API.Entities;

namespace ApplicationJobs.API.Persistence.Repositories
{
  public interface IJobApplicationRepository
  {
    void AddApplication(JobApplication jobApplication);
    JobApplication? GetById(int id);
  }
}