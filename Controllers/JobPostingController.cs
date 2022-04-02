
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Instrumentation;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Web.Mvc;
using YogIt.Modules.JobPostings.Components;
using YogIt.Modules.JobPostings.Data;
using YogIt.Modules.JobPostings.Models;
using System.Linq;

namespace YogIt.Modules.JobPostings.Controllers
{
    [DnnHandleError]
    public class JobPostingController : DnnController
    {
        private readonly ILog _log;

        public JobPostingController()
        {
            _log = LoggerSource.Instance.GetLogger(this.GetType());
        }

        protected ILog Log
        {
            get { return _log; }
        }

        public ActionResult Delete(int itemId)
        {
            JobPostingInfoRepository.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var item = (itemId == -1)
                 ? new JobPostingInfo { ModuleId = ModuleContext.ModuleId }
                 : JobPostingInfoRepository.Instance.GetItem(itemId, ModuleContext.ModuleId);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(JobPostingInfo item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // updated by
                    item.LastUpdatedByUserId = User.UserID;
                    item.LastUpdatedOnDate = DateTime.UtcNow;

                    if (item.JobPostingId == -1)
                    {
                        // created by
                        item.CreatedByUserId = User.UserID;
                        item.CreatedOnDate = DateTime.UtcNow;

                        // create the posting
                        JobPostingInfoRepository.Instance.CreateItem(item);
                    }
                    else
                    {
                        // update the posting
                        JobPostingInfoRepository.Instance.UpdateItem(item);
                    }
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat("An error occurred saving the Job Posting. Exception: {0}", ex);
                }

                return RedirectToDefaultRoute();

            }

            return View(item);

        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            return GetView(string.Empty);
        }


        [HttpPost]
        public ActionResult Index(FilterByLocation data)
        {
            return GetView(data.SelectedLocation);
        }

        private ActionResult GetView(string selectedLocation = "")
        {
            // create the view
            var vm = new FilterByLocation();

            // read the job postings
            var items = JobPostingInfoRepository.Instance.GetItems(ModuleContext.ModuleId);

            // get a list of all locations
            vm.Locations = new SelectList(items.Select(m => m.Location).Distinct());

            // filter the postings by selected location
            if (!String.IsNullOrEmpty(selectedLocation))
            {
                items = items.Where(f => f.Location == selectedLocation);
            }

            // set the views data and return
            vm.Data = items.ToList();
            return View(vm);
        }
    }
}
