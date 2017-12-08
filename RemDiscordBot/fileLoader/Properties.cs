using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                Console.WriteLine(streamReader.ReadLine().ToString());
            }
            catch (Exception)
            {
                throw new ArgumentException("File was not found at given filePath");
            }
        }

        public string GetKey(string key)
        {
            return null;
        }
    }
}
