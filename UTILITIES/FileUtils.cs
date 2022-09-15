using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRPT1.UTILITIES
{
    class FileUtils
    {
        /// <summary>
        /// Get the default download folder.
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadFolderPath()
        {
            return System.Convert.ToString(
                Microsoft.Win32.Registry.GetValue(
                     @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"
                    , "{374DE290-123F-4565-9164-39C4925E467B}"
                    , String.Empty
                )
            );
        }
        
        /// <summary>
        /// Save to the download folder.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SaveFileToDownloadFolder(String filename, byte[] data)
        {
            String folder = GetDownloadFolderPath();
            String fullpath = folder + "\\" + filename;
            File.WriteAllBytes(fullpath, data);
            return fullpath;
        }
    }
}
