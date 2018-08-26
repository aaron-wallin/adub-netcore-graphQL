using NetCoreGraphSQL.Shared.Models;
using System.Collections.Generic;

namespace NetCoreGraphSQL.Shared.RepoDefinitions
{
    public interface IApplicationRepository
    {
        Application Get(int id);
        List<Application> All();
    }
}
