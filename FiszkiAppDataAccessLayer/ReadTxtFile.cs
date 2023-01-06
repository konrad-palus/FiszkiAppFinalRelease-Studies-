namespace FiszkiAppDataAccessLayer
{
	using FiszkiAppEntities;
	public class ReadTxtFile
	{
		/// <summary>
		/// Method that represents reading from PathButton in LoadingPage page
		/// </summary>
		/// <param name="path">file path</param>
		public static void ReadFromTxt(string path)
		{

			var temp = File.ReadAllText(path);
			string[] lines = temp.Split(new char[] { ';', '\n' });

			for (int i = 0; i < lines.Count() - 1; i += 2)
			{
				SetOfWords.Words.Add(lines[i], lines[i + 1]);
			}
		}
	}
}