
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Web.Caching;
using System.ComponentModel.DataAnnotations;

namespace YogIt.Modules.JobPostings.Models
{
    [TableName("yogit_JobPostings")]
    //setup the primary key for table
    [PrimaryKey("JobPostingId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("JobPostingInfo", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class JobPostingInfo : IJobPostingInfo
    {
        public JobPostingInfo()
        {
            JobPostingId = -1;
        }

        public int JobPostingId { get; set; }

        public int ModuleId { get; set; }

        public string Location { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [StringLength(1000)]
        public string ShortDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? ExpriationDate { get; set; }

        public string Description { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int LastUpdatedByUserId { get; set; }

        public DateTime LastUpdatedOnDate { get; set; }
    }
}
