using Customer.Information.QueryHandler.GetCustomerInformation;
using HR.Harmony.Core.CQRS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformation.API.Customer.Command.CustomerInformation.Delete
{
    public class DeleteRequest  : CommandBase
    {
        public int CustomerRef { get; set; }
        
    }
}
