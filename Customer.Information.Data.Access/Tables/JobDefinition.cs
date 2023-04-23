using System;

namespace HR.Harmony.DataAccess.Tables
{
    public partial class JobDefinition
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string CallApiUrl { get; set; }
        public string CallType { get; set; }
        public string CallParameter { get; set; }
        public string CallBody { get; set; }
        public string CronExpression { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
