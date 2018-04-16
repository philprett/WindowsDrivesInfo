using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDriveInfo
{
    class VolumeInfo
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern FindVolumeSafeHandle FindFirstVolume([Out] StringBuilder lpszVolumeName, uint cchBufferLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FindNextVolume(FindVolumeSafeHandle hFindVolume, [Out] StringBuilder lpszVolumeName, uint cchBufferLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FindVolumeClose(IntPtr hFindVolume);

        public class FindVolumeSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private FindVolumeSafeHandle()
            : base(true)
            {
            }

            public FindVolumeSafeHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
            {
                SetHandle(preexistingHandle);
            }

            protected override bool ReleaseHandle()
            {
                return FindVolumeClose(handle);
            }
        }

        public static StringCollection GetVolumes()
        {
            const uint bufferLength = 1024;
            StringBuilder volume = new StringBuilder((int)bufferLength, (int)bufferLength);
            StringCollection ret = new StringCollection();

            using (FindVolumeSafeHandle volumeHandle = FindFirstVolume(volume, bufferLength))
            {
                if (volumeHandle.IsInvalid)
                {
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                }

                do
                {
                    ret.Add(volume.ToString());
                } while (FindNextVolume(volumeHandle, volume, bufferLength));

                return ret;
            }
        }
    }
}
