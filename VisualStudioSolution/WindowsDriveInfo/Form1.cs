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
            Grid.Rows.Clear();

            List<Win32_DiskDriveToDiskPartition> diskdriveToPartitions = Win32_DiskDriveToDiskPartition.GetAll();
            List<Win32_DiskPartition> partitions = Win32_DiskPartition.GetAll();

            ManagementObjectSearcher disksToPartitions = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDriveToDiskPartition");
            foreach (ManagementObject diskToPartition in disksToPartitions.Get())
            {

            }

            ManagementObjectSearcher disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDriveToDiskPartition");
            foreach (ManagementObject disk in disks.Get())
            {
                foreach (var prop in disk.Properties)
                {
                    Console.Out.WriteLine(prop.Name + "=" + (prop.Value == null ? "NULL" : prop.Value.ToString()));
                }
            }

            var volumes = VolumeInfo.GetVolumes();

            foreach (var volume in volumes)
            {
                string volumeID = volume.Substring(volume.IndexOf("{") + 1, volume.IndexOf("}") - volume.IndexOf("{") - 1);
                ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + volume + "\"");
                foreach (var prop in disk.Properties)
                {
                    Console.Out.WriteLine(prop.Name + "=" + prop.Value.ToString());
                }
            }
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
