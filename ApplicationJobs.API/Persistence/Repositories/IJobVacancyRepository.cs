using ApplicationJobs.API.Entities;

namespace ApplicationJobs.API.Persistence.Repositories
{
  public interface IJobVacancyRepository
  {
    List<JobVacancy> GetAll();
    JobVacancy? GetById(int id);
    void Add(JobVacancy jobVacancy);
    void Update(JobVacancy jobVacancy);
  }
}