using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FHP_Application
{
    /// <summary>
    /// Utility class for handling operations on INI files, providing methods to read and write
    /// </summary>
    internal class cls_IniFile
    {
        private string filePath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public cls_IniFile(string path)
        {
            filePath = path;
        }

        /// <summary>
        /// Writes a string value to the specified section and key in the INI file.
        /// </summary>
        /// <param name="section">The section in the INI file.</param>
        /// <param name="key">The key in the specified section.</param>
        /// <param name="value">The string value to write.</param>
        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// Reads a string value from the specified section and key in the INI file.
        /// </summary>
        /// <param name="section">The section in the INI file.</param>
        /// <param name="key">The key in the specified section.</param>
        /// <param name="defaultValue">The default value if the key is not found.</param>
        /// <returns>The read string value.</returns>
        public string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder retVal = new StringBuilder(255);
            GetPrivateProfileString(section, key, defaultValue, retVal, 255, filePath);
            return retVal.ToString();
        }
    }
}
