namespace FiszkiAppBuissinesLogicLayer
{
	using FiszkiAppEntities;
	using System.Linq;
	public class WorkWithDictionary
	{
		 static Random _rnd = new Random();

		/// <summary>
		/// Draws word from txt file
		/// </summary>
		/// <returns> returns tuple containing meaning, proper answer and two randomized answers </returns>
		public static (string,string, string, string) DrawWord()
		{
			int meamingIndex = _rnd.Next(0, SetOfWords.Words.Count());

			List<string> drawedWords = new List<string>()
			 {
				 SetOfWords.Words.ElementAt(meamingIndex).Value,
				 SetOfWords.Words.ElementAt(_rnd.Next(0, SetOfWords.Words.Count())).Value,
				 SetOfWords.Words.ElementAt(_rnd.Next(0, SetOfWords.Words.Count())).Value
			 };

			List<string> randomizedWords = new List<string>();

			for (int i = drawedWords.Count; i > 0; i--)
			{
				randomizedWords.Add(drawedWords[_rnd.Next(0, drawedWords.Count())]);
				drawedWords.Remove(randomizedWords.Last());
			}

			return (SetOfWords.Words.ElementAt(meamingIndex).Key, randomizedWords.First(), randomizedWords[1], randomizedWords.Last()) ;
		}

		/// <summary>
		/// Adds points depending on the answer
		/// </summary>
		/// <param  name="meaning">Proper answer</param>
		/// <param name="choice">User choice</param>
		public static bool CountPoints(string meaning, string choice)
		{
			SetOfWords.Words.TryGetValue(meaning, out string value);
			if (value == choice)
				return true;
			return false;
		}
	}
}