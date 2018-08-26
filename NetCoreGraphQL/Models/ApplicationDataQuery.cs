using GraphQL.Types;
using NetCoreGraphQL.Api.Models.GraphTypes;
using NetCoreGraphSQL.Shared.RepoDefinitions;

namespace NetCoreGraphQL.Api.Models
{
    public class ApplicationDataQuery : ObjectGraphType
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicationDataQuery(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;

            Field<ApplicationType>(
                "application",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name= "id"}),
                resolve: _ => applicationRepository.Get(_.GetArgument<int>("id"))
                );

            Field<ListGraphType<ApplicationType>>(
                "applications",
                //arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "lenderCode" }),
                resolve: _ => applicationRepository.All()
                );            
        }
    }
}
