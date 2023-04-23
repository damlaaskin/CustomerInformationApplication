using CustomerInformation.Core.Data.Contracts;
using System;

namespace Customer.Information.Data.Access.Tables
{
    public partial class tb_CustomerInformation: IAuditable
    {
        public int CustomerRef { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentificationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
