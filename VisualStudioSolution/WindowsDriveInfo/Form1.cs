using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsDriveInfo
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr FindFirstVolume([Out] StringBuilder lpszVolumeName, uint cchBufferLength);

        [DllImport("kernel32.dll")]
        static extern bool FindNextVolume(IntPtr hFindVolume, [Out] StringBuilder lpszVolumeName, uint cchBufferLength);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Grid.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            IntPtr volInfo = FindFirstVolume(sb, 100000);

            foreach (DriveInfo drive in DriveInfo.GetDrives().OrderBy(d => d.Name))
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cellName = new DataGridViewTextBoxCell();
                cellName.Value = drive.Name;
                row.Cells.Add(cellName);

                DataGridViewTextBoxCell cellFreeSpace = new DataGridViewTextBoxCell();
                cellFreeSpace.Value = drive.TotalFreeSpace.ToString("#,###,###,###,###");
                cellFreeSpace.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                row.Cells.Add(cellFreeSpace);

                DataGridViewTextBoxCell cellSize = new DataGridViewTextBoxCell();
                cellSize.Value = drive.TotalSize.ToString("#,###,###,###,###");
                cellSize.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                row.Cells.Add(cellSize);

                Grid.Rows.Add(row);
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
