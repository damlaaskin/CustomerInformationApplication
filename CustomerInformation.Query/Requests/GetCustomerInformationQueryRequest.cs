using CustomerInformation.Core.CQRS.Domain;
using Customer.Information.Query.Responses;

namespace Customer.Information.Query.Requests
{
    public class GetCustomerInformationQueryRequest : QueryBase<GetCustomerInformationResponse>
    {
        public int CustomerRef { get; set; }
    }
}
