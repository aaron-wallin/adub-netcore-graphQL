using NetCoreGraphSQL.Shared.Models;
using System.Collections.Generic;

namespace NetCoreGraphSQL.Shared.RepoDefinitions
{
    public interface IDecisionRepository
    {
        List<Decision> All(int applicationId);
        Decision GetCurrentDecision(int applicationId);
    }
}
