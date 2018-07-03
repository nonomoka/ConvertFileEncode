using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string source1 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\sps\sp\";
            string source2 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\sps\sp-1\";
            string source3 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\sps\sp-2\";
            string source4 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\sps\sp-3\";
            string source5 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\sps\sp-4\";

            string target1 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\spsbk\sp\";
            string target2 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\spsbk\sp-1\";
            string target3 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\spsbk\sp-2\";
            string target4 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\spsbk\sp-3\";
            string target5 = @"C:\nonoData\Project\TFS\Version\TestCode\ConsoleApplication1\spsbk\sp-4\";

            ChangeEncode(source1, target1);
            ChangeEncode(source2, target2);
            ChangeEncode(source3, target3);
            ChangeEncode(source4, target4);
            ChangeEncode(source5, target5);
            Console.Read();

        }

        private static void ChangeEncode(string sou,string tar) {
            string SourcePath = sou;
            string TargetPath = tar;
            if (!Directory.Exists(tar))
                Directory.CreateDirectory(tar);

            DirectoryInfo info = new DirectoryInfo(SourcePath);
            Console.Write("Start Change Format!!");
            foreach (var s in info.GetFiles("*.sql"))
            {
                Console.WriteLine(s.FullName);
                string str = File.ReadAllText(s.FullName, Encoding.GetEncoding("gb2312"));
                File.WriteAllText(string.Format("{0}\\{1}", TargetPath, s.Name), str, Encoding.UTF8);
            }


            Console.Write("End Change!!");

        }
    }
}
