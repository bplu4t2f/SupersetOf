using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SupersetOf
{
	class DragDropNonsense
	{
		public DragDropNonsense(TextBox target)
		{
			this.target = target;
			target.AllowDrop = true;
			target.PreviewDragOver += this.HandleDragOver;
			//target.DragOver += this.HandleDragOver;
			target.Drop += this.HandleDrop;
		}

		private readonly TextBox target;

		private void HandleDragOver(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.None;

			// If the DataObject contains string data, extract it.
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effects = DragDropEffects.Copy;
			}
		
			e.Handled = true;
		}

		private void HandleDrop(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.None;

			// If the DataObject contains string data, extract it.
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] dataString = (string[])e.Data.GetData(DataFormats.FileDrop);
				this.target.Text = dataString[0];
			}

			e.Handled = true;
		}
	}
}
