using Customer.Information.QueryHandler.Caching;
using Customer.Information.Query.Requests;
using Customer.Information.Query.Responses;
using HR.Harmony.Core.CQRS.Handlers;
using HR.Harmony.Query.Handler;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Customer.Information.QueryHandler.GetCustomerInformation
{

    public class RequestHandler : QueryHandlerBaseAsync<GetCustomerInformationQueryRequest, GetCustomerInformationResponse>

    {
        private readonly QueryContext _queryContext;
        //private readonly ILogger _logger;
        private readonly ICacheManager _cacheManager;

        public RequestHandler(QueryContext queryContext
            //, ILogger logger
            , ICacheManager cacheManager)
        {
            _queryContext = queryContext;
            //_logger = logger;
            _cacheManager = cacheManager;

        }

        protected override async Task<GetCustomerInformationResponse> HandleCore(GetCustomerInformationQueryRequest request)
        {

            var response = new GetCustomerInformationResponse();

            try
            {

                //var cache = _cacheManager.GetDatabase();

                //var cacheKey = string.Format("GetCustomerInformation:customerRef:{0}", request.CustomerRef);
                //string value = cache.StringGet(cacheKey);

                //if (!string.IsNullOrWhiteSpace(value))
                //{
                //    return JsonSerializer.Deserialize<GetCustomerInformationResponse>(value);
                //}



                var resp = await (from ci in _queryContext.tb_CustomerInformation

                                  where ci.CustomerRef == request.CustomerRef
                                    && !ci.IsDeleted
                                  select new ResponseItem
                                  {
                                      CustomerRef = ci.CustomerRef,
                                      DateOfBirth = ci.DateOfBirth.ToString(),
                                      FirstName = ci.FirstName,
                                      LastName = ci.LastName,
                                      IdentificationNumber = ci.IdentificationNumber.ToString()
                                  }

                                  ).FirstOrDefaultAsync();

                if (resp != null)
                {
                    response.Data = EncryptCustomerInformation(resp.CustomerRef, resp.FirstName, resp.LastName, resp.IdentificationNumber, Convert.ToDateTime(resp.DateOfBirth));
                }


                // select EncryptCustomerInformation(ci.FirstName, ci.LastName, ci.IdentificationNumber.ToString(), ci.DateOfBirth)

                //if (resp != null)
                //{
                //    cache.StringSet(cacheKey, JsonSerializer.Serialize(response));
                //}

                return response;
            }
            catch (Exception ex)
            {
                //_logger.Error(string.Format("{0} GetCustomerInformationHandler instance : {1},Exception", ex));
            }


            return response;
        }

        private ResponseItem EncryptCustomerInformation(int customerRef, string firstName, string lastName, string identificationNumber, DateTime dateOfBirth)
        {
            return new ResponseItem(customerRef, firstName.Substring(0, 2) + "*****", lastName.Substring(0, 2) + "*****", "*******" + identificationNumber.Substring(7), "**/**/" + dateOfBirth.Year.ToString());
        }
    }
}
