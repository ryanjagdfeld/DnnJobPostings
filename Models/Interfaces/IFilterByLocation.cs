using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YogIt.Modules.JobPostings.Models
{
    public class IFilterByLocation
    {
        IEnumerable<JobPostingInfo> Data { get; set; }
        IEnumerable<SelectListItem> Locations { get; set; }
        string SelectedLocation { get; set; }
    }
}