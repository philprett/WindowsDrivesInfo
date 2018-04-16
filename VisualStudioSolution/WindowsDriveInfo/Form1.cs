using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsDriveInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Grid.Rows.Clear();
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
