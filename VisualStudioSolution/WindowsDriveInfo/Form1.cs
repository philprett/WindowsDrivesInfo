using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
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
            UpdateDrives();
        }

        private void UpdateDrives()
        {
            int ok = 0;
            int warning = 0;
            int critical = 0;

            Grid.Rows.Clear();

            foreach (DriveInfo drive in DriveInfo.GetAllDrives().OrderBy(d => d.Name))
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cellName = new DataGridViewTextBoxCell();
                cellName.Value = drive.Name;
                row.Cells.Add(cellName);

                DataGridViewTextBoxCell cellFreeSpace = new DataGridViewTextBoxCell();
                cellFreeSpace.Value = drive.FreeSpace.ToString("#,###,###,###,###");
                cellFreeSpace.Value = drive.FreeSpace.GetAsNiceByteSize();
                cellFreeSpace.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                row.Cells.Add(cellFreeSpace);

                DataGridViewTextBoxCell cellSize = new DataGridViewTextBoxCell();
                cellSize.Value = drive.TotalSpace.ToString("#,###,###,###,###");
                cellSize.Value = drive.TotalSpace.GetAsNiceByteSize();
                cellSize.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                row.Cells.Add(cellSize);

                DataGridViewTextBoxCell percentFree = new DataGridViewTextBoxCell();
                percentFree.Value = drive.PercentFree.ToString() + "%";
                percentFree.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                row.Cells.Add(percentFree);

                DataGridViewTextBoxCell status = new DataGridViewTextBoxCell();
                status.Value = drive.Criticality.ToString();
                status.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells.Add(status);

                Grid.Rows.Add(row);
                Application.DoEvents();

                if (drive.Criticality == DriveInfoStatuses.OK)
                {
                    ok++;
                }
                else if (drive.Criticality == DriveInfoStatuses.Warning)
                {
                    warning++;
                }
                else if (drive.Criticality == DriveInfoStatuses.Critical)
                {
                    critical++;
                }

                MainNotifyIcon.Text = string.Format("Windows Drive Information: {0} ok, {1} warning, {2} critical", ok, warning, critical);
                if (critical > 0)
                {
                    MainNotifyIcon.ShowBalloonTip(10000, "Freespace CRITICAL!", "There are drives with a critical amount of freespace", ToolTipIcon.Error);
                    this.Focus();
                }
                else if (warning > 0)
                {
                    MainNotifyIcon.ShowBalloonTip(10000, "Freespace warning", "There are drives with a reduced amount of freespace", ToolTipIcon.Warning);
                }
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            UpdateDrives();
        }
    }
}
