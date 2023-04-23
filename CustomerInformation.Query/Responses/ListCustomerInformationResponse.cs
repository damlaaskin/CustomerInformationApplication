using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Information.Query.Responses
{

    public class ListCustomerInformationResponse
    {
        public List<ResponseItem> Data { get; set; }
    }

    public class ResponseItem
    {
        public ResponseItem()
        {

        }

        public ResponseItem(int customerRef,string firstName, string lastName, string identificationNumber, string dateOfBirth)
        {
            CustomerRef = customerRef;
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            DateOfBirth = dateOfBirth;
        }
        public int CustomerRef { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string DateOfBirth { get; set; }

    }
}
