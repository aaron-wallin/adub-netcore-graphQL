using GraphQL.Types;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;

namespace NetCoreGraphQL.Api.Models.GraphTypes
{
    public class ApplicationType : ObjectGraphType<Application>
    {
        private readonly IDecisionRepository decisionRepository;
        private readonly IApplicantRepository applicantRepository;

        public ApplicationType(IDecisionRepository decisionRepository, IApplicantRepository applicantRepository)
        {
            this.decisionRepository = decisionRepository;
            this.applicantRepository = applicantRepository;
           
            Field(_ => _.Id);
            Field(_ => _.LenderCode);
            Field(_ => _.LoanType);
            Field<ListGraphType<DecisionType>>("decisions",                
                resolve: _ => this.decisionRepository.All(_.Source.Id), description: "The application's decisions");
            Field<ListGraphType<ApplicantType>>("applicants",
                resolve: _ => this.applicantRepository.All(_.Source.Id), description: "The application's applicants");

        }
    }
}
