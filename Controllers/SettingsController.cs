
using DotNetNuke.Collections;
using DotNetNuke.Security;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System.Web.Mvc;

namespace YogIt.Modules.JobPostings.Controllers
{
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
    [DnnHandleError]
    public class SettingsController : DnnController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Settings()
        {
            var settings = new Models.Settings();
            
            settings.PostingTemplate = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("YogIt.Modules.JobPostings_PostingTemplate", string.Empty);

            return View(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Settings(Models.Settings settings)
        {
			var security = new PortalSecurity();
			
            ModuleContext.Configuration.ModuleSettings["YogIt.Modules.JobPostings_PostingTemplate"] = security.InputFilter(settings.PostingTemplate.ToString().Trim(), PortalSecurity.FilterFlag.NoMarkup);

            return RedirectToDefaultRoute();
        }
    }
}