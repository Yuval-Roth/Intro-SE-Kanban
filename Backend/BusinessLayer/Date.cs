using System;
using System.Text.RegularExpressions;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
	/// <summary>
	/// This class respresents a date
	/// 
	/// <code>Supported operations:</code>
	/// <list type="bullet">Day()</list>
	/// <list type="bullet">Month()</list>
	/// <list type="bullet">Year()</list>
	/// <list type="bullet">ToString()</list>
	/// <br/><br/>
	/// ===================
	/// <br/>
	/// <c>Ⓒ Yuval Roth</c>
	/// <br/>
	/// ===================
	/// </summary>
	public class Date
	{
		public readonly int day;
		public readonly int month;
		public readonly int year;

		/// <summary>
		/// Build a <c>Date</c> object from a string<br/>
		/// <br/>
		/// <b>Note:</b> the only accepted separators are '.' and '/' .<br/>
		/// Example for legal strings: "16.6.1950" and "16/6/1950"
		/// <br/><br/>
		/// <b>Throws</b> <c>ArgumentException</c> if the string is not a legal date string
		/// </summary>
		/// <param name="s"></param>
		/// <exception cref="ArgumentException"></exception>
		public Date(string s)
		{
			Regex reg = new Regex(@"([1-9]{1,2}\.[1-9]{1,2}\.[1-9]{4})|([1-9]{1,2}\/[1-9]{1,2}\/[1-9]{4})");

			if (reg.IsMatch(s) == false) throw new ArgumentException("Illegal date string");
			
			string[] raw;
			if (s.Contains('.')) raw = s.Split('.');
			else raw = s.Split('/');

			day = int.Parse(raw[0]);
			month = int.Parse(raw[1]);
			year = int.Parse(raw[2]);
		}

		/// <summary>
		/// Build Date object from 3 ints
		///  <br/> <br/>
		/// <b>Note:</b> the correct format is Day / Month / Year
		/// </summary>
		/// <param name="day"></param>
		/// <param name="month"></param>
		/// <param name="year"></param>
		public Date(int day,int month,int year)
		{
			this.day= day;
			this.month = month;
			this.year= year;
		}
		///// <summary>
		///// Returns the day
		///// </summary>
		///// <returns>int</returns>
		//public int Day()
		//{
		//	return day;
		//}

		///// <summary>
		///// Returns the month
		///// </summary>
		///// <returns>int</returns>
		//public int Month()
		//{
		//	return month;
		//}

		///// <summary>
		///// returns the year
		///// </summary>
		///// <returns>int</returns>
		//public int Year()
		//{
		//	return year;
		//}

		/// <summary>
		/// Returns a string representing the date
		/// </summary>
		/// <returns>"Day/Month/Year"</returns>
		public override string ToString()
		{
			return day+"/"+month+"/"+year;
		}
	}
}

