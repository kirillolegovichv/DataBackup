using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataBackup.BL;
using DataBackup.BL.Data;

namespace DataBackup.BL
{
    public class FileCopy
    {
        private SettingsBase OnePath = SettingsBase.GetInstance();
        private DateTime _dateTime;
        string subPath;


        public void CreateNewCatalog(string endpath)
        {
            _dateTime = new DateTime();
            subPath = string.Format(@"{0}", _dateTime);

            DirectoryInfo dirInfo = new DirectoryInfo(endpath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subPath);
        }  

        public void CopyOldCatalog(string startPath, string endPath)
        {
            foreach (var dirPath in Directory.GetDirectories(startPath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(startPath, endPath));
            }

            foreach (var newPath in Directory.GetFiles(startPath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(startPath, endPath), true);
            }
        }
    }
}
