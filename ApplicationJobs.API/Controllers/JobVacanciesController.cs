namespace ApplicationJobs.API.Controllers
{
  using ApplicationJobs.API.Entities;
  using ApplicationJobs.API.Models;
  using ApplicationJobs.API.Persistence;
  using ApplicationJobs.API.Persistence.Repositories;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using Serilog;

  [Route("api/job_vacancies")]
  [ApiController]
  public class JobVacanciesController : ControllerBase
  {
    private readonly IJobVacancyRepository _repository;
    public JobVacanciesController(IJobVacancyRepository repository)
    {
      _repository = repository;
    }
    // GET api/job_vacancies
    [HttpGet]
    public IActionResult GetAll()
    {
      var jobVacancies = _repository.GetAll();
      return Ok(jobVacancies);
    }

    // GET api/job_vacancies/id
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var jobVacancy = _repository.GetById(id);

      if (jobVacancy == null)
        return NotFound();

      return Ok(jobVacancy);
    }

    // POST api/job_vacancies
    /// <summary>
    /// Cadastrar uma vaga de emprego
    /// </summary>
    /// {
    /// "title": "Dev .Net Jr",
    /// "description": "Vaga para sustentação de aplicações",
    /// "company": "Deli",
    /// "isRemote": true,
    /// "salaryRange": "4000-5000"
    /// }
    /// <param name="model">Dados da vaga</param>
    /// <returns>Objeto recém-criado</returns>
    /// <response code="201">Sucesso</response>
    [HttpPost]
    public IActionResult Post(AddJobVacancyInputModel model)
    {
      Log.Information("POST JobVacancy chamado");
      var jobVacancy = new JobVacancy(
        model.Title,
        model.Description,
        model.Company,
        model.isRemote,
        model.SalaryRange
      );

      _repository.Add(jobVacancy);

      return CreatedAtAction(
        "GetById",
        new { id = jobVacancy.Id },
        jobVacancy);
    }

    // PUT api/job_vacancies/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateJobVacancyInputModel model)
    {

      var jobVacancy = _repository.GetById(id);

      if (jobVacancy == null)
        return NotFound();

      jobVacancy.Update(model.Title, model.Description);

      _repository.Update(jobVacancy);

      return NoContent();
    }
  }
}