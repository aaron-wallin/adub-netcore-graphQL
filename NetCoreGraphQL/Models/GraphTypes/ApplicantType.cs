using GraphQL.Types;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;

namespace NetCoreGraphQL.Api.Models.GraphTypes
{
    public class ApplicantType : ObjectGraphType<Applicant>
    {
        private readonly IAddressRepository _addressRepository;

        public ApplicantType(IAddressRepository addressRepository)
        {
            this._addressRepository = addressRepository;

            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field<StringGraphType>("fullName", resolve: x => $"{x.Source.FirstName} {x.Source.LastName}");
            Field<ListGraphType<AddressType>>("addresses",
                resolve: _ => this._addressRepository.All(_.Source.Id), description: "The application's addresses");
            
        }
    }
}
