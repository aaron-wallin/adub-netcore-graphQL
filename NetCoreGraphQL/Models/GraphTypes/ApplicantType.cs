using GraphQL.Types;
using NetCoreGraphSQL.Shared.Models;

namespace NetCoreGraphQL.Api.Models.GraphTypes
{
    public class ApplicantType : ObjectGraphType<Applicant>
    {
        public ApplicantType()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field<StringGraphType>("fullName", resolve: x => $"{x.Source.FirstName} {x.Source.LastName}");
        }
    }
}
