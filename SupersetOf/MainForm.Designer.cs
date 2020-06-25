namespace SupersetOf
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelSupersetHint = new System.Windows.Forms.Label();
			this.textBoxSuperset = new System.Windows.Forms.TextBox();
			this.textBoxSubset = new System.Windows.Forms.TextBox();
			this.labelSubsetHint = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.labelStatusHint = new System.Windows.Forms.Label();
			this.textBoxDifferences = new System.Windows.Forms.TextBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.labelDifferencesHint = new System.Windows.Forms.Label();
			this.buttonDeleteSubset = new System.Windows.Forms.Button();
			this.labelVersion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelSupersetHint
			// 
			this.labelSupersetHint.AutoSize = true;
			this.labelSupersetHint.Location = new System.Drawing.Point(23, 18);
			this.labelSupersetHint.Name = "labelSupersetHint";
			this.labelSupersetHint.Size = new System.Drawing.Size(84, 13);
			this.labelSupersetHint.TabIndex = 0;
			this.labelSupersetHint.Text = "Check if folder...";
			// 
			// textBoxSuperset
			// 
			this.textBoxSuperset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSuperset.Location = new System.Drawing.Point(26, 34);
			this.textBoxSuperset.Name = "textBoxSuperset";
			this.textBoxSuperset.Size = new System.Drawing.Size(704, 20);
			this.textBoxSuperset.TabIndex = 1;
			// 
			// textBoxSubset
			// 
			this.textBoxSubset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSubset.Location = new System.Drawing.Point(26, 85);
			this.textBoxSubset.Name = "textBoxSubset";
			this.textBoxSubset.Size = new System.Drawing.Size(704, 20);
			this.textBoxSubset.TabIndex = 3;
			// 
			// labelSubsetHint
			// 
			this.labelSubsetHint.AutoSize = true;
			this.labelSubsetHint.Location = new System.Drawing.Point(23, 69);
			this.labelSubsetHint.Name = "labelSubsetHint";
			this.labelSubsetHint.Size = new System.Drawing.Size(116, 13);
			this.labelSubsetHint.TabIndex = 2;
			this.labelSubsetHint.Text = "... is superst of folder ...";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(655, 124);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Location = new System.Drawing.Point(574, 124);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 4;
			this.buttonStart.Text = "DO IT";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// labelStatusHint
			// 
			this.labelStatusHint.AutoSize = true;
			this.labelStatusHint.Location = new System.Drawing.Point(23, 156);
			this.labelStatusHint.Name = "labelStatusHint";
			this.labelStatusHint.Size = new System.Drawing.Size(40, 13);
			this.labelStatusHint.TabIndex = 6;
			this.labelStatusHint.Text = "Status:";
			// 
			// textBoxDifferences
			// 
			this.textBoxDifferences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDifferences.Location = new System.Drawing.Point(130, 182);
			this.textBoxDifferences.Multiline = true;
			this.textBoxDifferences.Name = "textBoxDifferences";
			this.textBoxDifferences.Size = new System.Drawing.Size(600, 244);
			this.textBoxDifferences.TabIndex = 10;
			// 
			// labelStatus
			// 
			this.labelStatus.BackColor = System.Drawing.Color.DarkRed;
			this.labelStatus.Location = new System.Drawing.Point(130, 151);
			this.labelStatus.Margin = new System.Windows.Forms.Padding(3);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(229, 23);
			this.labelStatus.TabIndex = 7;
			this.labelStatus.Text = "$TATUS";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDifferencesHint
			// 
			this.labelDifferencesHint.AutoSize = true;
			this.labelDifferencesHint.Location = new System.Drawing.Point(23, 185);
			this.labelDifferencesHint.Name = "labelDifferencesHint";
			this.labelDifferencesHint.Size = new System.Drawing.Size(64, 13);
			this.labelDifferencesHint.TabIndex = 9;
			this.labelDifferencesHint.Text = "Differences:";
			// 
			// buttonDeleteSubset
			// 
			this.buttonDeleteSubset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDeleteSubset.Location = new System.Drawing.Point(365, 151);
			this.buttonDeleteSubset.Name = "buttonDeleteSubset";
			this.buttonDeleteSubset.Size = new System.Drawing.Size(156, 23);
			this.buttonDeleteSubset.TabIndex = 8;
			this.buttonDeleteSubset.Text = "Delete Subset";
			this.buttonDeleteSubset.UseVisualStyleBackColor = true;
			this.buttonDeleteSubset.Click += new System.EventHandler(this.ButtonDeleteSubset_Click);
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(23, 413);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(62, 13);
			this.labelVersion.TabIndex = 11;
			this.labelVersion.Text = "Version: {0}";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(765, 438);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.buttonDeleteSubset);
			this.Controls.Add(this.labelDifferencesHint);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.textBoxDifferences);
			this.Controls.Add(this.labelStatusHint);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxSubset);
			this.Controls.Add(this.textBoxSuperset);
			this.Controls.Add(this.labelSubsetHint);
			this.Controls.Add(this.labelSupersetHint);
			this.Name = "MainForm";
			this.Text = "SupersetOf";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelSupersetHint;
		private System.Windows.Forms.TextBox textBoxSuperset;
		private System.Windows.Forms.TextBox textBoxSubset;
		private System.Windows.Forms.Label labelSubsetHint;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label labelStatusHint;
		private System.Windows.Forms.TextBox textBoxDifferences;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label labelDifferencesHint;
		private System.Windows.Forms.Button buttonDeleteSubset;
		private System.Windows.Forms.Label labelVersion;
	}
}