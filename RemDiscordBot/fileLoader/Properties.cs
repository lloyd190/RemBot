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
            _FilePaths = new List<string>();
            _keyDictionary = new Dictionary<string, string>();         
        }

        public string GetKey(string key)
        {
            return null;
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
                    if (Regex.IsMatch(line, @"[a-z\d]+=[\w]+"))
                    {
                        MatchCollection matches = Regex.Matches(line, @"([a-z\d]+)=([\w]+)");
                        foreach (Match match in matches)
                        {
                            string propertyName = match.Groups[1].Value;
                            string propertyKey = match.Groups[2].Value;

                            _keyDictionary.Add(propertyName, propertyKey);
                            Console.WriteLine("property was added {0}={1}", propertyName, propertyKey);
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
                if (!_FilePaths.Contains(filePath))
                {
                    _FilePaths.Add(filePath);
                }
                streamReader.Dispose();
            }
        }

        public void Reload()
        {
            foreach (var path in _FilePaths)
            {
                LoadPropertiesFile(path);
            }
        }
    }
}
