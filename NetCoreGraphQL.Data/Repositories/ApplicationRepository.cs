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
            GenFu.GenFu.Configure<Application>()
                .Fill(_ => _.Id )
                .WithinRange(1, 25);
            _apps = A.ListOf<Application>();
        }
    }    
}
