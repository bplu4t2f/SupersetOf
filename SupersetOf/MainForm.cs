using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupersetOf
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			this.InitializeComponent();

			var versionFormat = this.labelVersion.Text;
			this.labelVersion.Text = String.Format(versionFormat, Application.ProductVersion);

			this.labelStatus.BackColor = Color.Gray;
			this.labelStatus.ForeColor = Color.White;
			this.labelStatus.Text = "Idle";

			DragDropNonsense.Register(this.textBoxSuperset);
			DragDropNonsense.Register(this.textBoxSubset);
		}

		private CancellationTokenSource cts;

		private async void buttonStart_Click(object sender, EventArgs e)
		{
			var supersetDir = this.textBoxSuperset.Text;
			var subsetDir = this.textBoxSubset.Text;

			if (String.IsNullOrWhiteSpace(supersetDir))
			{
				MessageBox.Show("No superset specified.");
				return;
			}

			if (String.IsNullOrWhiteSpace(subsetDir))
			{
				MessageBox.Show("No subset specified.");
				return;
			}

			this.Cancel();

			CancellationTokenSource cts = null;

			try
			{
				cts = new CancellationTokenSource();
				this.cts = cts;

				this.buttonStart.Enabled = false;
				this.buttonCancel.Enabled = true;

				this.textBoxDifferences.Text = String.Empty;

				this.labelStatus.BackColor = Color.Gold;
				this.labelStatus.ForeColor = Color.Black;
				this.labelStatus.Text = "Working...";

				var differences = await Task.Run(() => TheOperator.Operate(supersetDir, subsetDir, cts.Token));
				if (!differences.Any())
				{
					this.labelStatus.BackColor = Color.ForestGreen;
					this.labelStatus.ForeColor = Color.White;
					this.labelStatus.Text = "Is superset";
				}
				else
				{
					this.labelStatus.BackColor = Color.Firebrick;
					this.labelStatus.ForeColor = Color.White;
					this.labelStatus.Text = "Is NOT superset";
					this.textBoxDifferences.Text = String.Join(Environment.NewLine, differences);
				}
			}
			catch (Exception ex)
			{
				this.labelStatus.BackColor = Color.MediumOrchid;
				this.labelStatus.ForeColor = Color.White;
				this.labelStatus.Text = "Exception";
				this.textBoxDifferences.Text = ex.ToString();
			}
			finally
			{
				this.buttonStart.Enabled = true;
				this.buttonCancel.Enabled = false;

				if (this.cts == cts)
				{
					this.cts = null;
				}
				cts?.Dispose();
			}
		}

		private void Cancel()
		{
			this.cts?.Cancel();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Cancel();
		}

		private void ButtonDeleteSubset_Click(object sender, EventArgs e)
		{
			var subsetDir = this.textBoxSubset.Text;
			if (String.IsNullOrWhiteSpace(subsetDir))
			{
				MessageBox.Show("No subset specified.");
				return;
			}

			var choice = MessageBox.Show($"Really delete this directory?\r\n{subsetDir}", "Really delete?", MessageBoxButtons.YesNo);
			if (choice != DialogResult.Yes) return;

			try
			{
				Directory.Delete(subsetDir, recursive: true);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Could not delete dir:\r\n{ex}");
			}
		}
	}
}
