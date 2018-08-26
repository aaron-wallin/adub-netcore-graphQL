using GraphQL.Types;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;

namespace NetCoreGraphQL.Api.Models.GraphTypes
{
    public class ApplicationType : ObjectGraphType<Application>
    {
        private readonly IDecisionRepository decisionRepository;

        public ApplicationType(IDecisionRepository decisionRepository)
        {
            this.decisionRepository = decisionRepository;

            Field(_ => _.Id);
            Field(_ => _.LenderCode);
            Field(_ => _.LoanType);
            Field<ListGraphType<DecisionType>>("decisions",
                //arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "applicationId" }),
                resolve: _ => this.decisionRepository.All(_.Source.Id), description: "The application's decisions");
            
        }
    }
}
