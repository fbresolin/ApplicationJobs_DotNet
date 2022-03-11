namespace ApplicationJobs.API.Entities
{
  public class JobApplication
  {
    public JobApplication(string applicantName, string applicantEmail, int jobVacancyId)
    {
      ApplicantName = applicantName;
      ApplicantEmail = applicantEmail;
      JobVacancyId = jobVacancyId;
    }
    public int Id { get; private set; }
    public string ApplicantName { get; private set; }
    public string ApplicantEmail { get; private set; }
    public int JobVacancyId { get; private set; }
  }
}