namespace ApplicationJobs.API.Models
{
  public record AddJobApplicationInputModel(
      string ApplicantName,
      string ApplicantEmail,
      int idJobVacancy)
  {

  }
}