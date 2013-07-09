using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.ComponentModel;
using System.Linq.Expressions;

namespace YucataTracker.ViewModels.Helpers
{
	public static class EnumToSelectListHtmlHelper
	{
		/// <summary>
		/// Returns a List of SelectListItems (suitable for use with Html.DropDownListFor) with the values being the
		/// Enum values and the text being the description attribute or the value itself if no description is present.
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <param name="enumObj"></param>
		/// <returns></returns>
		/// <remarks>Adapted from http://stackoverflow.com/questions/9280465/mvc3-enumdropdownlist-selected-value
		/// </remarks>
		public static IEnumerable<SelectListItem> ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct, IConvertible
		{
			if (!typeof(TEnum).IsEnum)
			{
				throw new ArgumentException("Object passed to ToSelectList(enumObj) must be an enumeration", "enumObj");
			}

			//DO NOT ATTEMPT TO USE integer values as the Value. The html helper will attempt to match the STRING VALUE of your property.
			return Enum.GetValues(typeof(TEnum)).Cast<Enum>().Select(e => new SelectListItem() { Text = e.GetDescription(), Value = e.ToString() });
		}

		public static string GetDescription(this System.Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}

	}
}