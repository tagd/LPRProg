using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEtUI
{
    class MultiUseFun
    {
        
        public static void writeToVars(string launchType)//can overwrite without issue
        {
            string filepath = Properties.Settings.Default.ProjectPath + "vars.txt";
            File.WriteAllText(filepath, launchType + Environment.NewLine);
            File.AppendAllText(filepath, Properties.Settings.Default.CPPImgPath + Environment.NewLine);
            File.AppendAllText(filepath, Properties.Settings.Default.CPPFontPath + Environment.NewLine);
        }


    }
}
