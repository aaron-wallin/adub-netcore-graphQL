using GenFu;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreGraphQL.Data.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private List<Applicant> _applicants;

        public ApplicantRepository()
        {
            _applicants = new List<Applicant>();
            LoadData();
        }

        public List<Applicant> All(int applicationId)
        {
            return _applicants.Where(_ => _.ApplicationId == applicationId).ToList();
        }

        private void LoadData()
        {
            int i = 54276;

            GenFu.GenFu.Configure<Applicant>()
                .Fill(_ => _.ApplicationId).WithinRange(1, 500)
                .Fill(_ => _.Id, () => { return i++; });
            _applicants.AddRange(A.ListOf<Applicant>(2000));
        }
    }
}
