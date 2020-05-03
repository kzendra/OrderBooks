using System.Collections.Generic;
using System.IO;

namespace OrderBooks
{
    public class ReadDataFile
    {
        public ReadDataFile(string fileName)
        {
            _fileName = fileName;
        }
        private string _fileName;// = "order_books_data.json";
        public List<string> Rows { get; private set; }

        public void ReadFile()
        {
            Rows = new List<string>();
            using (StreamReader file = new StreamReader(_fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    ParseLine(line);

                }
            }
        }

        private void ParseLine(string line)
        {
            var separator = "\t".ToCharArray();
            string[] content = line.Split(separator);
            foreach (string data in content)
            {
                if (data.StartsWith("{"))
                    Rows.Add(data);
            }
        }
    }
}
