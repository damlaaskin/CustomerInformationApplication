using Customer.Information.QueryHandler.Caching;
using Customer.Information.Query.Requests;
using Customer.Information.Query.Responses;
using HR.Harmony.Query.Handler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Information.QueryHandler.ListCustomerInformation
{
    public class RequestHandler : IRequestHandler<ListCustomerInformationRequest, ListCustomerInformationResponse>
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

        public async Task<ListCustomerInformationResponse> Handle(ListCustomerInformationRequest request, CancellationToken cancellationToken)
        {

            var response = new ListCustomerInformationResponse();

            try
            {

                //var cache = _cacheManager.GetDatabase();

                //var cacheKey = string.Format("GetCustomerInformation:firstname:{0},lastname:{1},identificationnumber:{2}", request.FirstName, request.LastName, request.IdentificationNumber);
                //string value = cache.StringGet(cacheKey);

                //if (!string.IsNullOrWhiteSpace(value))
                //{
                //    return JsonSerializer.Deserialize<ListCustomerInformationResponse>(value);
                //}



                var list = await (from ci in _queryContext.tb_CustomerInformation

                                  where ((string.IsNullOrWhiteSpace(request.FirstName) || ci.FirstName.Contains(request.FirstName))
                                  && (string.IsNullOrWhiteSpace(request.LastName) || ci.LastName.Contains(request.LastName))
                                  && (request.IdentificationNumber == 0 || ci.IdentificationNumber.ToString().Contains(request.IdentificationNumber.ToString())))
                                  && !ci.IsDeleted
                                  select new ResponseItem
                                  {
                                      CustomerRef = ci.CustomerRef,
                                      DateOfBirth = ci.DateOfBirth.ToString(),
                                      FirstName = ci.FirstName,
                                      LastName = ci.LastName,
                                      IdentificationNumber = ci.IdentificationNumber.ToString()
                                  }

                                  ).ToListAsync(cancellationToken);

                if (list.Count != 0)
                {
                    response.Data = new List<ResponseItem>();
                    list.ForEach(e => response.Data.Add(EncryptCustomerInformation(e.CustomerRef, e.FirstName, e.LastName, e.IdentificationNumber, Convert.ToDateTime(e.DateOfBirth))));

                }

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
