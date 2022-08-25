using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Data
{
    public class SettingsBase
    {
        private const string filePath = @"backupTB.tb";
        
        private static SettingsBase _instance;

        private SettingsBase()
        {

        }

        private static SettingsBase GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SettingsBase();
            }
            return _instance;
        }
    }
}
