using GraphQL.Types;
using NetCoreGraphSQL.Shared.Models;

namespace NetCoreGraphQL.Api.Models.GraphTypes
{
    public class DecisionType : ObjectGraphType<Decision>
    {
        public DecisionType()
        {
            Field(x => x.Id);
            Field(x => x.ApplicationId);
            Field<StringGraphType>("decisionDate", resolve: x => x.Source.DecisionDate.ToLongTimeString());
            Field(x => x.DecisionResult);
            Field(x => x.CurrentDecision);
        }
    }
}
