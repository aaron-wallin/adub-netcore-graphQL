using GenFu;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreGraphQL.Data.Repositories
{
    public class DecisionRepository : IDecisionRepository
    {
        private List<Decision> _decisions;

        public DecisionRepository()
        {
            _decisions = new List<Decision>();
            LoadData();
        }

        public List<Decision> All(int applicationId)
        {
            return _decisions.Where(_ => _.ApplicationId == applicationId).ToList();
        }

        public Decision GetCurrentDecision(int applicationId)
        {
            return _decisions.FirstOrDefault(_ => _.ApplicationId == applicationId && _.CurrentDecision);
        }

        private void LoadData()
        {
            GenFu.GenFu.Configure<Decision>().Fill(_ => _.ApplicationId).WithinRange(1, 25);
            _decisions = A.ListOf<Decision>();
        }
    }
}
