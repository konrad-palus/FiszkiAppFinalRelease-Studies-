using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;
using FiszkiAppBuissinesLogicLayer;
using FiszkiAppEntities;

namespace FiszkiAppVisualLayer
{
	/// <summary>
	/// Interaction logic for GamePage.xaml
	/// </summary>
	public partial class GamePage : Page
	{
		#region PRIVATE_FIELDS
		 int _point = 0;
		 int _tries = 0;
		 string _properChoice = string.Empty;
		 double _myTime = 1;
		 DispatcherTimer _timer;
		 TimeSpan _time;
		#endregion

		public GamePage()
		{
			InitializeComponent();
			#region TIMER
			_time = TimeSpan.FromSeconds(_myTime);
			_timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
			{
				Timer.Text = _time.ToString("c");
				if (_time == TimeSpan.Zero) _timer.Stop();
				_time = _time.Add(TimeSpan.FromSeconds(+1));

			}, Application.Current.Dispatcher);
			_timer.Start();
			#endregion

		}

		#region STUFF_NEDEED_TO_LISTEN_CLICKS
		private void GamePage_Loaded(object sender, RoutedEventArgs e)
		{
			var window = Window.GetWindow(this);
			window.KeyDown += HandleKeyPress;
		}
		/// <summary>
		/// A,S,D,SPACE,END keys handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HandleKeyPress(object sender, KeyEventArgs e) 
		{
			switch (e.Key) 
			{
				case Key.A:
					LeftAnswerButton_Click(new object(), new RoutedEventArgs());
					break;

				case Key.S:
					MidAnswerButton_Click(new object(), new RoutedEventArgs());
					break;

				case Key.D:
					RightAnswerButton_Click(new object(), new RoutedEventArgs());
					break;
				case Key.Space:
					Start_Click(new object(), new RoutedEventArgs());
					break;
				default:
					Result_Click(new object(), new RoutedEventArgs());
					break;
			}
		}
		#endregion

		/// <summary>
		///  Method that on/off click after accepting answer or drawing another word
		/// </summary>
		private void ChangePossibilityOfClicking() 
		{
			BW1.IsEnabled = !BW1.IsEnabled;
			BW2.IsEnabled = !BW2.IsEnabled;
			BW3.IsEnabled = !BW3.IsEnabled;
			if(!BW1.IsEnabled)
			HighLighting();
		}

		/// <summary>
		/// Method that refreshing points label
		/// </summary>
		private void WorkWithPoints()
		{
			Label_points.Content = $"Points {_point} : {_tries}";
		}

		/// <summary>
		/// Method that removes color from button after drawin' another word
		/// </summary>
		private void DefaultButtonColor()
		{
			BW1.Foreground = Brushes.Black;
			BW2.Foreground = Brushes.Black;
			BW3.Foreground = Brushes.Black;
		}

		/// <summary>
		/// Method that highlighting answers after accepting user choice
		/// </summary>
		private void HighLighting() 
		{
			if (BW1.Content.ToString() == _properChoice)
				BW1.Foreground = Brushes.Green;
			else
				BW1.Foreground = Brushes.Red;

			if (BW2.Content.ToString() == _properChoice)
				BW2.Foreground = Brushes.Green;
			else
				BW2.Foreground = Brushes.Red;

			if (BW3.Content.ToString() == _properChoice)
				BW3.Foreground = Brushes.Green;
			else
				BW3.Foreground = Brushes.Red;			
		}

		#region BASIC_BUTTONS
		private void LeftAnswerButton_Click(object sender, RoutedEventArgs e)
		{
			if (WorkWithDictionary.CountPoints(Convert.ToString(Meaning.Content), Convert.ToString(BW1.Content)))
			{
				_point += 1;
				Label_points.Content = _point;
			}
			ChangePossibilityOfClicking();
			WorkWithPoints();
			FillSummaryList();
		}

		private void MidAnswerButton_Click(object sender, RoutedEventArgs e)
		{
			if (WorkWithDictionary.CountPoints(Convert.ToString(Meaning.Content), Convert.ToString(BW2.Content)))
			{
				_point += 1;
			}
			ChangePossibilityOfClicking();
			WorkWithPoints();
			FillSummaryList();
		}

		private void RightAnswerButton_Click(object sender, RoutedEventArgs e)
		{
			if (WorkWithDictionary.CountPoints(Convert.ToString(Meaning.Content), Convert.ToString(BW3.Content)))
			{
				_point += 1;
			}
			ChangePossibilityOfClicking();
			WorkWithPoints();
			FillSummaryList();
		}

		private void Start_Click(object sender, RoutedEventArgs e)
		{
			_tries++;
			WorkWithPoints();
			(string, string, string, string) tupla = WorkWithDictionary.DrawWord();
			BW1.Content = tupla.Item4;
			BW2.Content = tupla.Item3;
			BW3.Content = tupla.Item2;
			Meaning.Content = tupla.Item1;
			SetOfWords.Words.TryGetValue(tupla.Item1, out string meaning);
			_properChoice = meaning;
			if (!BW1.IsEnabled)
			{
				ChangePossibilityOfClicking();
			}
			DefaultButtonColor();

		}

		private void Result_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new ResultPage());

		}
		#endregion

		/// <summary>
		/// Method that populating summary list
		/// </summary>
		private void FillSummaryList() 
		{
			SummaryPanel.SummaryList.Add(new Result
			{
				Meaning = Meaning.Content.ToString(),
				Answer = _properChoice,
				Time = DateTime.Parse(Timer.Text),
				Point = _point,
				Tries = _tries
			}) ;
		}	
	}
}
