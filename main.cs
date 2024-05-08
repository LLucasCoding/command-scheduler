using System;
using System.IO;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Program Starting...");
        int timestamp = (int)(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

        Console.WriteLine("Current timestamp: " + timestamp); // print timestamp

        // File reading process
        string lineread = File.ReadLines("data.txt").First(); // get first line
        string[] linewords = lineread.Split(); // split file into words
        
        int targetstamp = Int32.Parse(linewords[0]); // get target timestamp
        string command = lineread;

        int ind = command.IndexOf(" ") + 1; // remove command from line
        command = command.Substring(ind);
        
        Console.WriteLine("Targestamp: " + targetstamp);
        int timediff = targetstamp - timestamp;
        Console.WriteLine("Seconds to \"shutdown\": " + timediff); // time difference, seconds
        if (timediff > 0)
        {
            System.Threading.Thread.Sleep(timediff * 1000);
        }
        else
        {
            Console.WriteLine("The time was negative, therefore I shut down no matter what");
        }
        Console.WriteLine("Running command! The command was");
        Console.WriteLine(command);
        
        return;
    }
}