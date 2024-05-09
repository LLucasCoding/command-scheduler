using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Program Starting...");
        int timestamp = (int)(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

        Console.WriteLine("Current timestamp: " + timestamp); // print timestamp

        short commandcount = (short)(File.ReadAllLines("data.txt").Length);

        for (short command_num = 0; command_num < commandcount; command_num ++) {
            // File reading process
            string lineread = File.ReadLines("data.txt").First(); // get first line
            string[] linewords = lineread.Split(); // split file into words
    
            int targetstamp = Int32.Parse(linewords[0]); // get target timestamp
            string command = lineread;
    
            int ind = command.IndexOf(" ") + 1; // remove command from line
            command = command.Substring(ind);
    
            Console.WriteLine("Targestamp: " + targetstamp);
            int timediff = targetstamp - timestamp;
            Console.WriteLine("Seconds until command: " + timediff); // time difference, seconds
            if (timediff > 0)
            {
                System.Threading.Thread.Sleep(timediff * 1000);
            }
            else
            {
                Console.WriteLine("The time was negative, therefore I run the command immediately.");
            }
    
            Console.WriteLine("Removing first line");
            var lines = File.ReadAllLines("data.txt"); // remove first line of data
            File.WriteAllLines("data.txt", lines.Skip(1).ToArray());
            
            Console.WriteLine("Running command! The command is");
            Console.WriteLine(command);

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true; // Disables window creation
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine("Command output:");
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            
            
        }

        return;
    }
}