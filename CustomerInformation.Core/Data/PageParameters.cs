using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Harmony.Core.Data
{
    public class PageParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 100;
        public string OrderBy { get; set; }
        public bool Ascending { get; set; } = true;
    }
}