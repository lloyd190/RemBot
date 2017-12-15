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
        private Dictionary<String, String> _keyDictionary;

        public Properties(string filePath)
        {
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                while (streamReader.ReadLine() != null)
                {
                    string line = streamReader.ReadLine();
                    if (Regex.IsMatch(line, @"^"))
                    {

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetKey(string key)
        {
            return null;
        }
    }
}
