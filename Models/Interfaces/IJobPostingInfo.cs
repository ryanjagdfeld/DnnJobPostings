
using System;

namespace YogIt.Modules.JobPostings.Models
{
    public interface IJobPostingInfo
    {
        int JobPostingId { get; set; }
        int ModuleId { get; set; }
        string Location { get; set; }
        string Title { get; set; }
        string ShortDescription { get; set; }
        string Description { get; set; }
        DateTime? ExpriationDate { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedOnDate { get; set; }
        int LastUpdatedByUserId { get; set; }
        DateTime LastUpdatedOnDate { get; set; }
    }
}