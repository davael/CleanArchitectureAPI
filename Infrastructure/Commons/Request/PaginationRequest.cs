using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Request
{
    public class PaginationRequest
    {
        public int NumPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        private readonly int NumMaxRecordsPage = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;
        public int Records
        {
            get => PageSize;
            set
            {
                PageSize = value > NumMaxRecordsPage ? NumMaxRecordsPage : value;
            }
        }
    }
}
