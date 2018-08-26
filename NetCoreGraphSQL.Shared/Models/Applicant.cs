namespace NetCoreGraphSQL.Shared.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Address ApplicantAddress { get; set; }
    }
}
