using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History
{
    public class HistoryTxt
    {
        public string Load(string text)
        {
            return text = System.IO.File.ReadAllText(@"C:\Programming\C#\Projects\ELMA projects\calc\Text file\History.txt");
        }

        public void Save(string text)
        {
            System.IO.File.WriteAllText(@"C:\Programming\C#\Projects\ELMA projects\calc\Text file\History.txt", text);
        }

        public void Clear()
        {

        }
    }
}
