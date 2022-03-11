namespace Name.Controllers
{
  using ApplicationJobs.API.Entities;
  using ApplicationJobs.API.Models;
  using ApplicationJobs.API.Persistence;
  using ApplicationJobs.API.Persistence.Repositories;
  using Microsoft.AspNetCore.Mvc;

  [Route("api/job_vacancies/{id}/applications")]
  [ApiController]
  public class JobApplicationsController : ControllerBase
  {
    private readonly IJobVacancyRepository _repository;
    public JobApplicationsController(IJobVacancyRepository repository)
    {
      _repository = repository;
    }

    //POST job_vacancies/{idJobVacancy}/applications
    [HttpPost]
    public IActionResult Post(int idJobVacancy, AddJobApplicationInputModel model)
    {
      var jobVacancy = _repository.GetById(idJobVacancy);
      if (jobVacancy == null)
        return NotFound();

      var jobApplication = new JobApplication(
        model.ApplicantName,
        model.ApplicantEmail,
        idJobVacancy
      );
      _repository.AddApplication(jobApplication);
      return Ok(jobApplication);
    }
  }
}