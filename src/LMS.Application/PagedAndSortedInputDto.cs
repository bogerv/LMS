using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    public class PagedAndSortedInputDto : IPagedAndSortedResultRequest
    {
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string Sorting { get; set; }
    }
}
