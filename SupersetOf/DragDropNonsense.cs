using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupersetOf
{
	static class DragDropNonsense
	{
		public static void Register(TextBox target)
		{
			target.AllowDrop = true;
			target.DragOver -= HandleDragOver;
			target.DragOver += HandleDragOver;
			target.DragDrop -= HandleDrop;
			target.DragDrop += HandleDrop;
		}

		private static void HandleDragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.None;

			// If the DataObject contains string data, extract it.
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private static void HandleDrop(object sender, DragEventArgs e)
		{
			var textBox = (TextBox)sender;
			e.Effect = DragDropEffects.None;

			// If the DataObject contains string data, extract it.
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] dataString = (string[])e.Data.GetData(DataFormats.FileDrop);
				textBox.Text = dataString[0];
			}
		}
	}
}
