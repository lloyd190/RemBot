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
            if (!File.Exists(filePath) || _FilePaths.Contains(filePath))
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
                    if (Regex.IsMatch(line, @"[a-z\d]+=[\d\w]+"))
                    {
                        MatchCollection matches = Regex.Matches(line, @"([a-z\d]+)=([\d\w]+)");
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
                Console.WriteLine("there was a problem with loading the properties : {0}", e.Message);
            }
            finally
            {
                streamReader.Dispose();
            }
        }

        public void Reload()
        {
           
        }
    }
}
