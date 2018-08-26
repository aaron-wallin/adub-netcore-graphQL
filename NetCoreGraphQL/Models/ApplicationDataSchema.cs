using GraphQL;
using GraphQL.Types;

namespace NetCoreGraphQL.Api.Models
{
    public class ApplicationDataSchema : Schema
    {
        public ApplicationDataSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ApplicationDataQuery>();
        }
    }
}
