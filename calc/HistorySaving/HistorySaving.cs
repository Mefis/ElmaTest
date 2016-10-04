using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistorySaving
{
    public class HistoryTxt
    {
        static void Main()
        {

        }

        public string Load()
        {
            return System.IO.File.ReadAllText(@"C:\Programming\C#\Projects\ELMA projects\calc\Text file\History.txt");
        }

        public void Save(string text)
        {
            System.IO.File.WriteAllText(@"C:\Programming\C#\Projects\ELMA projects\calc\Text file\History.txt", text);
        }
    }
}
