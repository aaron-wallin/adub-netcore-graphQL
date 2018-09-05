using GraphQL.Types;
using NetCoreGraphSQL.Shared.Models;

namespace NetCoreGraphQL.Api.Models.GraphTypes
{
    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Field(_ => _.StreetAddress);
            Field(_ => _.City);
            Field(_ => _.State);
        }
    }
}
