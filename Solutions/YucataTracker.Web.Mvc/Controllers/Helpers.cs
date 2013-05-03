using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YucataTracker.Web.Mvc.Controllers
{
	public static class Helpers
	{
		public static T SafeCookieGetter<T>(HttpCookie c) 
		{
			if (c == null) return default(T);
			try
			{
				return (T)(Object)c.Value;
			}
			catch (InvalidCastException)
			{
				//throw it away
			}
			return default(T);
		}
	}
}