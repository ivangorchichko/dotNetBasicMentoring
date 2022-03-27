using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class QueryParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int CategoryId { get; set; }
    }
}
