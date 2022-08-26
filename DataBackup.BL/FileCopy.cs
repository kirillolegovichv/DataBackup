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
        string SubPath;


        public void CreateCatalog(string path)
        {
            _dateTime = new DateTime();
            SubPath = string.Format(@"{0}", _dateTime);

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(SubPath)
        }  
    }
}
