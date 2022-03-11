namespace ApplicationJobs.API.Controllers
{
  using ApplicationJobs.API.Entities;
  using ApplicationJobs.API.Models;
  using ApplicationJobs.API.Persistence.Repositories;
  using Microsoft.AspNetCore.Mvc;

  [Route("api/job_vacancies/applications")]
  [ApiController]
  public class JobApplicationsController : ControllerBase
  {
    private readonly IJobApplicationRepository _repository;
    private readonly IJobVacancyRepository _jvrepository;
    public JobApplicationsController(IJobApplicationRepository repository,
    IJobVacancyRepository jvrepository)
    {
      _repository = repository;
      _jvrepository = jvrepository;
    }

    //GET job_vacancies/applications/{idJobVacancy}
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var jobApplication = _repository.GetById(id);
      if (jobApplication == null)
      {
        return NotFound();
      }
      return Ok(jobApplication);
    }

    //POST job_vacancies/applications
    [HttpPost]
    public IActionResult Post(int idJobVacancy, AddJobApplicationInputModel model)
    {
      var jobVacancy = _jvrepository.GetById(idJobVacancy);
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