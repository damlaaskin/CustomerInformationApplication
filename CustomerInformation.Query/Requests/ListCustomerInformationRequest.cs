using CustomerInformation.Core.CQRS.Domain;
using Customer.Information.Query.Responses;

namespace Customer.Information.Query.Requests
{
  public  class ListCustomerInformationRequest : QueryBase<ListCustomerInformationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentificationNumber { get; set; }
    }
}
