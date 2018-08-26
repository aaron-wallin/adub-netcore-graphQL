using System.Collections.Generic;

namespace NetCoreGraphSQL.Shared.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string LenderCode { get; set; }
        public string LoanType { get; set; }        
        public List<Decision> Decisions { get; set; }
        public List<Applicant> Applicants { get; set; }
    }
}
