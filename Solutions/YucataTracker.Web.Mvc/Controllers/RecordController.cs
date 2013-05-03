using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YucataTracker.Domain;
using YucataTracker.Tasks;
using Microsoft.Web.Mvc;
using YucataTracker.ViewModels;
using YucataTracker.Web.Mvc.Controllers.ActionFilters;

namespace YucataTracker.Web.Mvc.Controllers
{
	public class RecordController : BaseController
	{
		private IRecordTasks RecordTasks;
		
		public RecordController(IRecordTasks recordTasks)
		{
			this.RecordTasks = recordTasks;
		}

		//
		// GET: /Record/

		[HttpGet, ImportModelStateFromTempData]
		public ActionResult Index()
		{
			return View(RecordTasks.GetListOfAllGames());
		}

		[HttpPost, ExportModelStateToTempData]
		[ValidateAntiForgeryToken]
		public ActionResult Index(int GameID)
		{
			Game g = RecordTasks.GetGameById(GameID);
			if (g == null)
			{
				ModelState.AddModelError("", "Invalid GameID specified. Select from the drop-down.");
				return this.RedirectToAction(rc => rc.Index());
			}
			return this.RedirectToAction(rc => rc.SelectPlayer(GameID));
		}

		[HttpGet, ImportModelStateFromTempData, ExportModelStateToTempData]
		public ActionResult SelectPlayer(int GameId)
		{
			Game g = RecordTasks.GetGameById(GameId);
			if (g == null)
			{
				ModelState.AddModelError("", "Invalid GameID specified. Select from the drop-down.");
				return this.RedirectToAction(rc => rc.Index());
			}
			string BggIDFromCookie = Helpers.SafeCookieGetter<string>(Request.Cookies["BggID"]);
			return View(new SelectPlayerViewModel(g, BggIDFromCookie ));
		}

		[HttpPost, ExportModelStateToTempData]
		[ValidateAntiForgeryToken]
		public ActionResult SelectPlayer(SelectPlayerViewModel vm)
		{
			if (ModelState.IsValid)
			{
				IList<Match> Matches = RecordTasks.GetMatchesByUserIDAndGameID(vm.BggID, vm.GameId);
				if (Matches.Count == 0) {
					ModelState.AddModelError("BggID","No matches found for that user for the selected game.");
					return this.RedirectToAction(rc => rc.SelectPlayer(vm.GameId));
				}


				Response.Cookies.Add(new HttpCookie("BggID", vm.BggID) { Expires = DateTime.MaxValue });
				return this.RedirectToAction(rc => rc.MatchOverview(vm.BggID, vm.GameId));
			}
			//invalid, return to present validation errors
			return this.RedirectToAction(rc => rc.SelectPlayer(vm.GameId));
		}

		public ActionResult MatchOverview(string BggID, int GameID)
		{
			throw new NotImplementedException();
		}
	}
}
