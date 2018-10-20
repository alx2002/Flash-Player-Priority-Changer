using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;



namespace Processhighlevel
{

    class Find_Process
    {
        static ProcessPriorityClass newPriority = ProcessPriorityClass.High; //
        

        static void Main(string[] args)
        {

            Regex regex = new Regex(@"(?<![\w\d])flashplayer(_([0-9]+)_sa)*(?![\w\d])");
            // name must be flashplayer_1_sa

            var processes = Process.GetProcesses().Where(p => regex.IsMatch(p.ProcessName));


            Console.ForegroundColor = ConsoleColor.Cyan;


            foreach (var proc in processes)
            {




                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Set Priority for PID: " + proc.Id + " to " + newPriority.ToString());
                proc.PriorityClass = newPriority;


                

            }



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to exit... \n");
            Console.ReadKey(true);
        }

    }

}
