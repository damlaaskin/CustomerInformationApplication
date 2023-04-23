using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformation.API.Customer.Command.CustomerInformation.Create
{
    public class Response
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int CreatedObjectRef { get; set; }
    }
}
