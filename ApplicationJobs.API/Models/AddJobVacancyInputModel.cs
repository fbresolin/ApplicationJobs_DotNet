namespace ApplicationJobs.API.Models
{
  public record AddJobVacancyInputModel(
    string Title,
    string Description,
    string Company,
    bool isRemote,
    string SalaryRange
  )
  {

  }
}