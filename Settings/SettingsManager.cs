using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace WordleConsole.Settings
{
    public class SettingsManager
    {
        public static readonly SettingsManager Instance = new SettingsManager();

        public string gamePath;
        public XmlSerializer serializer;

        public Settings Settings { get; set; }

        public Settings Load(string file)
        {
            Settings res;
            using (var reader = new StreamReader(file))
                res = (Settings)serializer.Deserialize(reader);
            return res;
        }

        public void Load()
        {
            string settingsPath = gamePath + "\\Settings.xml";
            if (File.Exists(settingsPath))
            {
                try
                {
                    Settings = Load(settingsPath);
                }
                catch
                {
                    Settings = LoadDefaults();
                    Console.WriteLine($"Couldn't load Settings file with path {settingsPath}; using defaults");
                }
            }
            else
            {
                Console.WriteLine($"Settings file not found; path {settingsPath}; using defaults");
                Settings = LoadDefaults();
            }
        }

        public Settings LoadDefaults()
        {
            var res = new Settings();
            res.WordLength = 5;
            res.NumberOfWords = 1;
            res.NumberOfGuesses = 10;
            res.PathToWordList = Directory.GetCurrentDirectory();
            return res;
        }

        public void Save()
        {
            Console.WriteLine("Not implemented");
            //lock (_writeLock)
            //{
            //    using (var writer = new StreamWriter(gamePath + "Settings.xml"))
            //    {
            //        serializer.Serialize(writer, Settings);
            //        writer.Flush();
            //        writer.BaseStream.Flush();
            //    }
            //}
        }
        
        public SettingsManager()
        {
            serializer = new XmlSerializer(typeof(Settings));
            gamePath = Directory.GetCurrentDirectory();
            Settings = new Settings();
        }

        public Object _writeLock = new Object();
    }
}