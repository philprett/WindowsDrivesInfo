using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDriveInfo
{
    class Win32_DiskPartition
    {
        string DeviceID { get; set; }
        int DiskIndex { get; set; }
        int PartitionIndex { get; set; }
        string Name { get; set; }
        long Size { get; set; }

        public static List<Win32_DiskPartition> GetAll()
        {
            List<Win32_DiskPartition> retObjs = new List<Win32_DiskPartition>();

            ManagementObjectSearcher objs = new ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition");
            foreach (ManagementObject obj in objs.Get())
            {
                Win32_DiskPartition retObj = new Win32_DiskPartition();
                foreach (var prop in obj.Properties)
                {
                    if (prop.Name =="DeviceID")
                    {
                        retObj.DeviceID = prop.Value.ToString();
                    }
                    if (prop.Name == "DiskIndex")
                    {
                        retObj.DiskIndex = (int)(uint)prop.Value;
                    }
                    if (prop.Name == "Index")
                    {
                        retObj.PartitionIndex = (int)(uint)prop.Value;
                    }
                    if (prop.Name == "Name")
                    {
                        retObj.Name = prop.Value.ToString();
                    }
                    if (prop.Name == "Size")
                    {
                        retObj.Size = (long)(ulong)prop.Value;
                    }
                    //Console.Out.WriteLine("["+prop.Name + "]=" + (prop.Value == null ? "NULL" : prop.Value.ToString()));
                }
                retObjs.Add(retObj);
            }

            return retObjs;
        }
    }
}
