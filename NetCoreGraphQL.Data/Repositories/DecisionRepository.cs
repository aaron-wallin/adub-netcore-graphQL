using GenFu;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;
using System;
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
            int i = 92736;

            GenFu.GenFu.Configure<Decision>()
                .Fill(_ => _.ApplicationId).WithinRange(1, 500)
                .Fill(_ => _.Id, () => { return i++; })
                .Fill(_ => _.CurrentDecision).WithRandom(new bool[] { true, false })
                .Fill(_ => _.DecisionResult).WithRandom(new string[] { "Approved", "Declined", "Referred" })
                .Fill(_ => _.DecisionDate, () => { return DateTime.Now; });
            _decisions.AddRange(A.ListOf<Decision>(5000));
        }
    }
}
