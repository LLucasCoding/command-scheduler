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
        string lineread = File.ReadLines("data.txt").First();
        string[] linewords = lineread.Split(); // split file into words
        int operation = Int32.Parse(linewords[0]); // get operation, different operations can do different things, ex. 0 = shutdown, 1 = BSOD etc
        int targetstamp = Int32.Parse(linewords[1]); // get target timestamp
        bool comment = false;
        string commenttext = "";
        
        if (linewords.Length > 2) {
            comment = true;
            commenttext = lineread;
            for (int i = 0; i < 2; i++) {
                int ind = commenttext.IndexOf(" ") + 1;
                commenttext = commenttext.Substring(ind);
            }
        }
        
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
        Console.WriteLine("Pretend this is a shutdown...");
        Console.WriteLine("Operation code: " + operation);
        if (comment) {
            Console.WriteLine("Comment: " + commenttext);
        }
        else {
            Console.WriteLine("No comment...");
        }
        return;
    }
}