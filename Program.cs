using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

// #define DEBUG

namespace Processhighlevel
{

    class PUBG_RealTime
    {
        static ProcessPriorityClass newPriority = ProcessPriorityClass.High;

        static void Main(string[] args)
        {
#if DEBUG
            Regex regex = new Regex(@"(?<![\w\d])flashplayer(_([0-9]+)_sa)*(?![\w\d])");
            // Get all processes and use Linq to filter on the regex pattern
            var processes = Process.GetProcesses().Where(p => regex.IsMatch(p.ProcessName));
#endif
            
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Cyan;
           
#endif
            foreach (var proc in processes)
            {
#if DEBUG

#endif
               
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Set Priority for id: " + proc.Id + " to " + newPriority.ToString());
                Console.WriteLine("Enjoy!");
                Console.WriteLine("Created by Citydrifter :)");
                proc.PriorityClass = newPriority;
             
#if DEBUG
                PutDebug("Changed priority for \n" + proc.Id);
#endif
            }
#if DEBUG
            PutDebug("No more processes.. \n");
#endif      
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to exit... \n");
            Console.ReadKey(true);
        }

        private static void PutDebug(object p)
        {
            throw new NotImplementedException();
        }

#if DEBUG
        static bool debug = false;
        static int debugInc = 1;
        static void PutDebug(string info = "")
        {
            if (debug)
            {
                Console.WriteLine(" " + debugInc + ": " + info);
                debugInc++;
            }
        }
#endif
    }
}