using System.Web.Mvc;


namespace YucataTracker.Web.Mvc.Controllers.ActionFilters
{
	/// <summary>
	/// Taken from http://weblogs.asp.net/rashid/archive/2009/04/01/asp-net-mvc-best-practices-part-1.aspx#prg
	/// </summary>
	public abstract class ModelStateTempDataTransfer : ActionFilterAttribute
	{
		protected static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
	}

	public class ExportModelStateToTempData : ModelStateTempDataTransfer
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			//Only export when ModelState is not valid
			if (!filterContext.Controller.ViewData.ModelState.IsValid)
			{
				//Export if we are redirecting
				if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToRouteResult))
				{
					filterContext.Controller.TempData[Key] = filterContext.Controller.ViewData.ModelState;
				}
			}

			base.OnActionExecuted(filterContext);
		}
	}

	public class ImportModelStateFromTempData : ModelStateTempDataTransfer
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			ModelStateDictionary modelState = filterContext.Controller.TempData[Key] as ModelStateDictionary;

			if (modelState != null)
			{
				//Only Import if we are viewing
				if (filterContext.Result is ViewResult)
				{
					filterContext.Controller.ViewData.ModelState.Merge(modelState);
				}
				else
				{
					//Otherwise remove it.
					filterContext.Controller.TempData.Remove(Key);
				}
			}

			base.OnActionExecuted(filterContext);
		}
	}
}