using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SupersetOf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
			this.buttonCancel.IsEnabled = false;

			new DragDropNonsense(this.textBoxSupersetDir);
			new DragDropNonsense(this.textBoxSubsetDir);
		}

		public string SupersetDir { get; set; }
		public string SubsetDir { get; set; }
		
		private CancellationTokenSource cts;

		private async void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrWhiteSpace(this.SupersetDir) || String.IsNullOrWhiteSpace(this.SubsetDir))
			{
				return;
			}

			this.Cancel();
			this.cts = new CancellationTokenSource();

			try
			{
				this.buttonStart.IsEnabled = false;
				this.buttonCancel.IsEnabled = true;

				this.labelStatus.Background = new SolidColorBrush(Colors.Yellow);
				this.labelStatus.Foreground = new SolidColorBrush(Colors.Black);
				this.labelStatus.Content = "Working...";

				var differences = await Task.Run(() => TheOperator.Operate(this.SupersetDir, this.SubsetDir, cts.Token));
				if (!differences.Any())
				{
					this.labelStatus.Background = new SolidColorBrush(Colors.Green);
					this.labelStatus.Foreground = new SolidColorBrush(Colors.White);
					this.labelStatus.Content = "Is superset";
				}
				else
				{
					this.labelStatus.Background = new SolidColorBrush(Colors.Maroon);
					this.labelStatus.Foreground = new SolidColorBrush(Colors.White);
					this.labelStatus.Content = "Is NOT superset";
					this.textBoxDifferences.Text = String.Join(Environment.NewLine, differences);
				}
			}
			catch (Exception ex)
			{
				this.labelStatus.Background = new SolidColorBrush(Colors.Red);
				this.labelStatus.Foreground = new SolidColorBrush(Colors.White);
				this.labelStatus.Content = ex.ToString();
			}
			finally
			{
				this.buttonStart.IsEnabled = true;
				this.buttonCancel.IsEnabled = false;
			}
		}

		private void Cancel()
		{
			if (this.cts != null)
			{
				this.cts.Cancel();
			}
		}

		private void buttonCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Cancel();
		}
	}
}
