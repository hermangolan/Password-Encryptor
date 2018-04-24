using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniThingsIDo
{
    public static class Logger
    {
        public static void Log(string text)
        {
            using (StreamWriter sw = File.AppendText("C:\\Users\\golan\\OneDrive\\שולחן העבודה\\CSharpForMe"))
            {
                sw.WriteLine(text+ "/n new Log:");
            }
        }
    }
}
