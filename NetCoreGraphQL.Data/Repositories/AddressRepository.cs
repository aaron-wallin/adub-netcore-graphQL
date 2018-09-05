using GenFu;
using NetCoreGraphSQL.Shared.Models;
using NetCoreGraphSQL.Shared.RepoDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreGraphQL.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private List<Address> _addresses;

        public AddressRepository()
        {
            _addresses = new List<Address>();
            LoadData();
        }

        public List<Address> All(int applicantId)
        {
            return _addresses.Where(_ => _.ApplicantId == applicantId).ToList();
        }

        private void LoadData()
        {
            int applicantId = 54276;
            int i = 1000;

            GenFu.GenFu.Configure<Address>()
                .Fill(_ => _.ApplicantId).WithinRange(applicantId, applicantId + 2000)
                .Fill(_ => _.Id, () => { return i++; })
                .Fill(_ => _.StreetAddress).AsAddress();
            _addresses.AddRange(A.ListOf<Address>(5000));
        }
    }
}
