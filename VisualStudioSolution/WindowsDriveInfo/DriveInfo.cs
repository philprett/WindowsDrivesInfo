using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDriveInfo
{
    enum DriveInfoStatuses { OK, Warning, Critical }

    static class LongExtension
    {
        public static string GetAsNiceByteSize(this long bytes)
        {
            const long kb = 1024L;
            const long mb = 1024L * 1024L;
            const long gb = 1024L * 1024L * 1024L;
            const long tb = 1024L * 1024L * 1024L * 1024L;

            if (bytes > tb) return ((double)bytes / (double)tb).ToString("0.00") + " TB";
            else if (bytes > gb) return ((double)bytes / (double)gb).ToString("0.00") + " GB";
            else if (bytes > mb) return ((double)bytes / (double)mb).ToString("0.00") + " MB";
            else if (bytes > kb) return ((double)bytes / (double)kb).ToString("0.00") + " KB";
            else return bytes.ToString("0.00") + " B";
        }
    }

    class DriveInfo
    {
        private System.IO.DriveInfo drive;

        public string Name { get; set; }
        public string Label { get; set; }
        public long FreeSpace { get { return drive.TotalFreeSpace; } }
        public long TotalSpace { get { return drive.TotalSize; } }

        public long PercentFree { get { return FreeSpace * 100 / TotalSpace; } }

        public DriveInfoStatuses Criticality
        {
            get
            {
                long percentFree = PercentFree;
                if (percentFree <= 10)
                {
                    return DriveInfoStatuses.Warning;
                }
                else if (percentFree <= 5)
                {
                    return DriveInfoStatuses.Critical;
                }
                else
                {
                    return DriveInfoStatuses.OK;
                }
            }
        }

        public DriveInfo(string drive)
        {
            this.drive = new System.IO.DriveInfo(drive);
            this.Name = this.drive.Name;
            this.Label = this.drive.VolumeLabel;
        }

        public static DriveInfo[] GetAllDrives()
        {
            List<DriveInfo> drives = new List<DriveInfo>();
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                if (drive.DriveType == System.IO.DriveType.Fixed || drive.DriveType == System.IO.DriveType.Removable)
                {
                    drives.Add(new DriveInfo(drive.Name));
                }
            }
            return drives.ToArray();
        }
    }
}
