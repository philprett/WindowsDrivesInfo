namespace WindowsDriveInfo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.butClose = new System.Windows.Forms.Button();
            this.Drive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drives";
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.AllowUserToResizeRows = false;
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid.BackgroundColor = System.Drawing.Color.White;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Drive,
            this.FreeSpace,
            this.TotalSize,
            this.PercentFree,
            this.Status});
            this.Grid.Location = new System.Drawing.Point(12, 25);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.RowHeadersVisible = false;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(497, 325);
            this.Grid.TabIndex = 1;
            // 
            // butClose
            // 
            this.butClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butClose.Location = new System.Drawing.Point(224, 364);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // Drive
            // 
            this.Drive.HeaderText = "Drive";
            this.Drive.Name = "Drive";
            this.Drive.ReadOnly = true;
            // 
            // FreeSpace
            // 
            this.FreeSpace.FillWeight = 200F;
            this.FreeSpace.HeaderText = "Free";
            this.FreeSpace.Name = "FreeSpace";
            this.FreeSpace.ReadOnly = true;
            // 
            // TotalSize
            // 
            this.TotalSize.FillWeight = 200F;
            this.TotalSize.HeaderText = "Size";
            this.TotalSize.Name = "TotalSize";
            this.TotalSize.ReadOnly = true;
            // 
            // PercentFree
            // 
            this.PercentFree.HeaderText = "Percent Free";
            this.PercentFree.Name = "PercentFree";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 5000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainNotifyIcon.Icon")));
            this.MainNotifyIcon.Text = "Windows Drives Information";
            this.MainNotifyIcon.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butClose;
            this.ClientSize = new System.Drawing.Size(521, 399);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(364, 329);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Drives Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drive;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeSpace;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentFree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
    }
}

