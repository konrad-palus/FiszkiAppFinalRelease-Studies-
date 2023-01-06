using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiszkiAppEntities
{
	/// <summary>
	///  Class that represents a single result guessed by the user
	/// </summary>
	public class Result
	{
		string _meaning;
		string _answer;
		DateTime _time;
		int _point;
		int _tries;

		public string Answer { get => _answer; set => _answer = value; }
		public string Meaning { get => _meaning; set => _meaning = value; }
		public DateTime Time { get => _time; set => _time = value; }
		public int Point { get => _point; set => _point = value; }
		public int Tries { get => _tries; set => _tries = value; }

		public override string ToString()
		{
			return $"Mening -> {_meaning} CorrectAnswer -> {Answer} Time -> {_time.ToShortTimeString()} -> Points {_point} {_tries} \n" ;
		}
	}
}
