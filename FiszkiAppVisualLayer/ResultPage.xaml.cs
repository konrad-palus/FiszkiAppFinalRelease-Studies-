using FiszkiAppBuissinesLogicLayer;
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
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
            FillTextBoxes();
        }

		/// <summary>
		/// A method to fill the final text field with the correct answer, the percentage of correct answers, and the time it takes to answer
        /// /// </summary>
		public void FillTextBoxes()
        {
            for (int i = 0; i < SummaryPanel.SummaryList.Count; i++)
            {
                if (i > 0)
                    Time.Text += $"{SummaryPanel.SummaryList[i].Time - SummaryPanel.SummaryList[i - 1].Time}\n";
                else
                    Time.Text += $"{SummaryPanel.SummaryList[i].Time.TimeOfDay.ToString()}\n";

                Points.Text += $"{((double)SummaryPanel.SummaryList[i].Point / SummaryPanel.SummaryList[i].Tries * 100).ToString("N2")}%\n";
				Answer.Text += $"{SummaryPanel.SummaryList[i].Meaning}: {SummaryPanel.SummaryList[i].Answer}\n";
				
			}
		}
    }
}
