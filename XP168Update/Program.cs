using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XP168Update
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add XP168 new DNS entry to hosts");
            string path = @"C:\Windows\System32\drivers\etc\hosts";

            var sb = new List<string>();
            var lines = File.ReadLines(path);
            foreach (string line in lines)
            {
                if (line.Contains("10.57.210.213") |
                    line.Contains("10.57.210.185") | 
                    line.Contains("10.57.210.177") |
                    line.Contains("10.57.208.64") |
                    line.Contains("10.57.210.180") |
                    line.Length == 0)
                {
                    continue;
                }
                sb.Add(line);
            }
            File.WriteAllLines(path, sb.ToArray(), Encoding.UTF8);

            File.AppendAllText(path, Environment.NewLine);
            File.AppendAllText(path, "10.57.208.64 xp168.z.net    #XP168 Domain entry" + Environment.NewLine);
            File.AppendAllText(path, "10.57.208.64 xp168          #XP168 entry" + Environment.NewLine);
            //File.AppendAllText(path, "10.57.210.185 xp168-fs1      #XP168 file server entry" + Environment.NewLine);
            //File.AppendAllText(path, "10.57.210.180  xp168-dc1       #XP168 file server entry" + Environment.NewLine);


            Console.WriteLine("hosts modify done.");
        }
    }
}
