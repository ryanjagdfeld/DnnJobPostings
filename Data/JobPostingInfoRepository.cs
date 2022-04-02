
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using YogIt.Modules.JobPostings.Data;
using YogIt.Modules.JobPostings.Models;

namespace YogIt.Modules.JobPostings.Data
{
    public interface IJobPostingInfoRepository
    {
        void CreateItem(JobPostingInfo t);
        void DeleteItem(int itemId, int moduleId);
        void DeleteItem(JobPostingInfo t);
        IEnumerable<JobPostingInfo> GetItems(int moduleId);
        JobPostingInfo GetItem(int itemId, int moduleId);
        void UpdateItem(JobPostingInfo t);
    }

    public class JobPostingInfoRepository : ServiceLocator<IJobPostingInfoRepository, JobPostingInfoRepository>, IJobPostingInfoRepository
    {
        public void CreateItem(JobPostingInfo t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<JobPostingInfo>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var t = GetItem(itemId, moduleId);
            DeleteItem(t);
        }

        public void DeleteItem(JobPostingInfo t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<JobPostingInfo>();
                rep.Delete(t);
            }
        }

        public IEnumerable<JobPostingInfo> GetItems(int moduleId)
        {
            IEnumerable<JobPostingInfo> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<JobPostingInfo>();
                t = rep.Get(moduleId);
            }
            return t;
        }
        
        public JobPostingInfo GetItem(int itemId, int moduleId)
        {
            JobPostingInfo t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<JobPostingInfo>();
                t = rep.GetById(itemId, moduleId);
            }
            return t;
        }

        public void UpdateItem(JobPostingInfo t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<JobPostingInfo>();
                rep.Update(t);
            }
        }

        protected override System.Func<IJobPostingInfoRepository> GetFactory()
        {
            return () => new JobPostingInfoRepository();
        }
    }
}
