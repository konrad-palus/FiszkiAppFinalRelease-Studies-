using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FiszkiAppVisualLayer
{
	/// <summary>
	/// Interaction logic for LoadingPage.xaml
	/// </summary>
	public partial class LoadingPage : Page
	{
		public LoadingPage()
		{
			InitializeComponent();
		}
		private void Path_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				FiszkiAppDataAccessLayer.ReadTxtFile.ReadFromTxt(Convert.ToString(LoadingPath.Text));
			}
			catch(Exception)
			{
				LoadingPath.Text = "Something goes wrong, check path";
			}
			if(FiszkiAppEntities.SetOfWords.Words.Count != 0)
			NavigationService.Navigate(new GamePage());
		}

		
	}
}
