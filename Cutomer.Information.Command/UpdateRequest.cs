using Customer.Information.QueryHandler.GetCustomerInformation;
using HR.Harmony.Core.CQRS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformation.API.Customer.Command.CustomerInformation.Update
{
    public class UpdateRequest : CommandBase
    {
        public int CustomerRef { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentificationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
