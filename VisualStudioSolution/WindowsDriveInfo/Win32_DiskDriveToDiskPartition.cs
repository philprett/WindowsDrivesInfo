using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDriveInfo
{
    class Win32_DiskDriveToDiskPartition
    {
        string DiskDriveDeviceID { get; set; }
        string PartitionDeviceID { get; set; }

        public static List<Win32_DiskDriveToDiskPartition> GetAll()
        {
            List<Win32_DiskDriveToDiskPartition> retObjs = new List<Win32_DiskDriveToDiskPartition>();

            ManagementObjectSearcher objs = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDriveToDiskPartition");
            foreach (ManagementObject obj in objs.Get())
            {
                Win32_DiskDriveToDiskPartition retObj = new Win32_DiskDriveToDiskPartition();
                foreach (var prop in obj.Properties)
                {
                    if (prop.Name == "Antecedent")
                    {
                        retObj.DiskDriveDeviceID = prop.Value.ToString();
                        if (retObj.DiskDriveDeviceID.IndexOf("=") >= 0)
                        {
                            retObj.DiskDriveDeviceID = retObj.DiskDriveDeviceID.Substring(retObj.DiskDriveDeviceID.IndexOf("=") + 1);
                        }
                        if (retObj.DiskDriveDeviceID.Substring(0, 1) == "\"")
                        {
                            retObj.DiskDriveDeviceID = retObj.DiskDriveDeviceID.Substring(1);
                        }
                        if (retObj.DiskDriveDeviceID.Substring(retObj.DiskDriveDeviceID.Length - 1, 1) == "\"")
                        {
                            retObj.DiskDriveDeviceID = retObj.DiskDriveDeviceID.Substring(0, retObj.DiskDriveDeviceID.Length - 1);
                        }
                    }
                    if (prop.Name == "Dependent")
                    {
                        retObj.PartitionDeviceID = prop.Value.ToString();
                        if (retObj.PartitionDeviceID.IndexOf("=") >= 0)
                        {
                            retObj.PartitionDeviceID = retObj.PartitionDeviceID.Substring(retObj.PartitionDeviceID.IndexOf("=") + 1);
                        }
                        if (retObj.PartitionDeviceID.Substring(0, 1) == "\"")
                        {
                            retObj.PartitionDeviceID = retObj.PartitionDeviceID.Substring(1);
                        }
                        if (retObj.PartitionDeviceID.Substring(retObj.PartitionDeviceID.Length - 1, 1) == "\"")
                        {
                            retObj.PartitionDeviceID = retObj.PartitionDeviceID.Substring(0, retObj.PartitionDeviceID.Length - 1);
                        }
                    }
                }
                retObjs.Add(retObj);
            }

            return retObjs;
        }
    }
}
