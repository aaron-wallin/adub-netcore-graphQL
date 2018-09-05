using GenFu;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreGraphQL.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private List<Application> _apps;

        public ApplicationRepository()
        {
            _apps = new List<Application>();
            LoadData();
        }

        public List<Application> All()
        {
            return _apps;
        }

        public Application Get(int id)
        {
            return _apps.FirstOrDefault(_ => _.Id == id);
        }

        private void LoadData()
        {
            int i = 1;
            
            GenFu.GenFu.Configure<Application>()
                .Fill(_ => _.Id, () => { return i++; })
                .Fill(_ => _.LoanType).WithRandom(new string[] { "Auto", "Mortgage", "Credit Card" })
                .Fill(_ => _.LenderCode).WithRandom(new string[] { "702", "331", "999" });
            _apps.AddRange(A.ListOf<Application>(500));
        }
    }    
}
