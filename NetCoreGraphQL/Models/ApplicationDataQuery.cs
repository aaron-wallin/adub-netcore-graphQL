using GraphQL.Types;
using NetCoreGraphQL.Api.Models.GraphTypes;
using NetCoreGraphSQL.Shared.RepoDefinitions;

namespace NetCoreGraphQL.Api.Models
{
    public class ApplicationDataQuery : ObjectGraphType
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly IDecisionRepository decisionRepository;
        private readonly IApplicantRepository applicantRepository;

        public ApplicationDataQuery(IApplicationRepository applicationRepository, IDecisionRepository decisionRepository, IApplicantRepository applicantRepository)
        {
            this.applicationRepository = applicationRepository;
            this.decisionRepository = decisionRepository;
            this.applicantRepository = applicantRepository;

            Field<ApplicationType>(
                "application",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name= "id"}),
                resolve: _ => applicationRepository.Get(_.GetArgument<int>("id"))
                );

            Field<ListGraphType<ApplicationType>>(
                "applications",
                resolve: _ => applicationRepository.All()
                );

            Field<ListGraphType<DecisionType>>(
                "decisions",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "applicationId" }),
                resolve: _ => this.decisionRepository.All(_.GetArgument<int>("applicationId")), description: "The application's decisions"
                );

            Field<ListGraphType<ApplicantType>>(
                "applicants",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "applicationId" }),
                resolve: _ => this.applicantRepository.All(_.GetArgument<int>("applicationId")), description: "The application's applicants"
                );


        }
    }
}
