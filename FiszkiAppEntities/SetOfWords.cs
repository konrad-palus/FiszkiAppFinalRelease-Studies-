namespace FiszkiAppEntities
{
	/// <summary>
	/// Class representing set of words taken from txt file
	/// </summary>
	public class SetOfWords
	{
		static Dictionary<string, string> _words = new Dictionary<string, string>();
		public static Dictionary<string, string> Words { get => _words; set => _words = value; }
	}
}