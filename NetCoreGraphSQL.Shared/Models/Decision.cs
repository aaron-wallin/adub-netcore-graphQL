using System;

namespace NetCoreGraphSQL.Shared.Models
{
    public class Decision
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public DateTime DecisionDate { get; set; }
        public string DecisionResult { get; set; }
        public bool CurrentDecision { get; set; }

    }
}
