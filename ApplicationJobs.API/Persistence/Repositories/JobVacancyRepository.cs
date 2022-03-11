using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationJobs.API.Persistence.Repositories
{
  public class JobVacancyRepository : IJobVacancyRepository
  {
    private readonly ApplicationJobsContext _context;
    public JobVacancyRepository(ApplicationJobsContext context)
    {
      _context = context;
    }
    public void Add(JobVacancy jobVacancy)
    {
      _context.Add(jobVacancy);
      _context.SaveChanges();
    }

    public List<JobVacancy> GetAll()
    {
      return _context.JobVacancies
        .Include(jv => jv.Applications)
        .ToList();
    }

    public JobVacancy? GetById(int id)
    {
      return _context.JobVacancies
        .Include(jv => jv.Applications)
        .FirstOrDefault(jv => jv.Id == id);
    }

    public void Update(JobVacancy jobVacancy)
    {
      _context.JobVacancies.Update(jobVacancy);
      _context.SaveChanges();
    }
  }
}