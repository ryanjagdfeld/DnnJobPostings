using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YogIt.Modules.JobPostings.Models
{
    public class FilterByLocation : IFilterByLocation
    {
        public IEnumerable<JobPostingInfo> Data { set; get; }
        public IEnumerable<SelectListItem> Locations { set; get; }
        public string SelectedLocation { set; get; }
    }
}