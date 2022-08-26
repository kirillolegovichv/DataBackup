using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DataBackup.BL;

namespace DataBackup.BL.Data
{
    public class SettingsBase
    {
        private const string filePath = @"backupTB.tb";

        public List<Paths> AllPaths { get; private set; }
        
        private static SettingsBase _instance;

        private SettingsBase()
        {
            AllPaths = new List<Paths>();
        }

        public static SettingsBase GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SettingsBase();
            }
            return _instance;
        }

        private string Serialize(List<Paths> paths)
        {
            return JsonSerializer.Serialize<List<Paths>>(paths);
        }

        private List<Paths> Deserialize(string json)
        {
            return JsonSerializer.Deserialize<List<Paths>>(json);
        }

        public void Save(List<Paths> paths)
        {
            string json = Serialize(paths);

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(json);
            }
        }

        public void Load()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadLine();
                AllPaths = Deserialize(json);
            }
        }
    }
}
