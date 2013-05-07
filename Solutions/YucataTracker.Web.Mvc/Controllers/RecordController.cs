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
				Response.Cookies.Add(new HttpCookie("BggID", vm.BggID) { Expires = DateTime.MaxValue });
				return this.RedirectToAction(rc => rc.MatchOverview(vm.BggID, vm.GameId));
			}
			//invalid, return to present validation errors
			return this.RedirectToAction(rc => rc.SelectPlayer(vm.GameId));
		}

		[HttpGet, ImportModelStateFromTempData]
		public ActionResult MatchOverview(string BggID, int GameID)
		{
			IList<Match> Matches = RecordTasks.GetMatchesByUserIDAndGameID(BggID, GameID);
			if (Matches.Count == 0)
			{
				ModelState.AddModelError("BggID", "No matches found for that user for the selected game.");
				return this.RedirectToAction(rc => rc.SelectPlayer(GameID));
			}

			return View(RecordTasks.PrepareNewMatchOverviewModel(BggID, GameID));

		}

		/// <summary>
		/// This encapsulates "Mark All Invited" as well as allowing YucataIDs to be set.
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		[HttpPost, ExportModelStateToTempData, ValidateAntiForgeryToken]
		[MultipleButton(Name="action",Argument="MarkInvited")]
		public ActionResult MarkAllInvited(MatchOverviewViewModel vm)
		{
			RecordTasks.RecordYucataIDs(vm);
			RecordTasks.MarkAllInvited(vm);
			return this.RedirectToAction(rc => rc.MatchOverview(vm.BggID, vm.GameID));
		}

		/// <summary>
		/// This encapsulates "Mark All Playing" as well as allowing YucataIDs to be set.
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		[HttpPost, ExportModelStateToTempData, ValidateAntiForgeryToken]
		[MultipleButton(Name = "action", Argument = "MarkPlaying")]
		public ActionResult MarkAllPlaying(MatchOverviewViewModel vm)
		{
			RecordTasks.RecordYucataIDs(vm);
			RecordTasks.MarkAllPlaying(vm);
			return this.RedirectToAction(rc => rc.MatchOverview(vm.BggID, vm.GameID));
		}

		[HttpGet, ImportModelStateFromTempData]
		public ActionResult MatchDetail(int MatchId)
		{
			Match m = RecordTasks.GetMatchById(MatchId);
			if (null == m) return new HttpNotFoundResult("No match found by ID");
				//the only way you're getting here with a bogus ID is url hacking, so I'm not obliged to help you navigate back here


			return View(RecordTasks.PrepareMatchDetailViewModel(m));

		}

		[HttpPost, ValidateAntiForgeryToken, ExportModelStateToTempData]
		public ActionResult MatchDetail(MatchDetailViewModel vm)
		{
			if (ModelState.IsValid)
			{
				RecordTasks.UpdateMatchDetails(vm);
			}
			return this.RedirectToAction(rc => rc.MatchDetail(vm.MatchId));
		}
		
	}
}
