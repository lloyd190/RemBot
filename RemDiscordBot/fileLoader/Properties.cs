using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RemDiscordBot.fileLoader
{
    public class Properties
    {
        private List<String> _FilePaths; 
        private Dictionary<String, String> _keyDictionary;

        public Properties(string filePath)
        {
            _FilePaths = new List<string>
            {
                filePath
            };
            _keyDictionary = new Dictionary<string, string>();
            LoadPropertiesFile(filePath);
        }

        public string GetKey(string keyName)
        {
            return _keyDictionary[keyName];
        }
        public void LoadPropertiesFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
                while (streamReader.Peek() >= 0)
                {
                    string line = streamReader.ReadLine();
                    //might be space sensitive
                    if (Regex.IsMatch(line, @"[A-z\d]+=[\S]+"))
                    {
                        MatchCollection matches = Regex.Matches(line, @"([A-z\d]+)=([\S]+)");
                        foreach (Match match in matches)
                        {
                            string propertyName = match.Groups[1].Value;
                            string propertyKey = match.Groups[2].Value;

                            _keyDictionary.Add(propertyName, propertyKey);
                            Console.WriteLine("property was added {0}={1}", propertyName, propertyKey);

                            if (!_FilePaths.Contains(filePath))
                            {
                                _FilePaths.Add(filePath);
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            { 
                Console.WriteLine("failed to load properties : {0}", e.Message);
            }
            finally
            {
                streamReader.Dispose();
            }
        }

        public void Reload()
        {
            _keyDictionary.Clear();
            foreach (var path in _FilePaths)
            {
                LoadPropertiesFile(path);
            }
        }
    }
}
