using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiszkiAppEntities;
namespace FiszkiAppBuissinesLogicLayer
{
	/// <summary>
	/// Represents end panel with game score 
	/// </summary>
	public class SummaryPanel
	{
		static List<Result> _summaryList = new List<Result>();

		static public List<Result> SummaryList { get => _summaryList; set => _summaryList = value; }
	}

}
