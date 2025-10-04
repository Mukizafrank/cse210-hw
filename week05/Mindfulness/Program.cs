using System;
using System.Collections.Generic;

class Program
{
    private static Dictionary<string, int> activityLog = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        // Initialize activity log
        activityLog["Breathing"] = 0;
        activityLog["Reflection"] = 0;
        activityLog["Listing"] = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("===================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write("Choose an activity (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunBreathingActivity();
                    break;
                case "2":
                    RunReflectionActivity();
                    break;
                case "3":
                    RunListingActivity();
                    break;
                case "4":
                    ShowActivityLog();
                    break;
                case "5":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Have a peaceful day!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    PauseWithSpinner(2);
                    break;
            }
        }
    }

    static void RunBreathingActivity()
    {
        // Log the activity
        activityLog["Breathing"]++;
        
        BreathingActivity activity = new BreathingActivity();
        activity.Run();
        
        Console.WriteLine();
        Console.Write("Press enter to return to the menu...");
        Console.ReadLine();
    }

    static void RunReflectionActivity()
    {
        // Log the activity
        activityLog["Reflection"]++;
        
        ReflectionActivity activity = new ReflectionActivity();
        activity.Run();
        
        Console.WriteLine();
        Console.Write("Press enter to return to the menu...");
        Console.ReadLine();
    }

    static void RunListingActivity()
    {
        // Log the activity
        activityLog["Listing"]++;
        
        ListingActivity activity = new ListingActivity();
        activity.Run();
        
        Console.WriteLine();
        Console.Write("Press enter to return to the menu...");
        Console.ReadLine();
    }

    static void ShowActivityLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("============");
        Console.WriteLine("Number of times each activity has been completed:");
        Console.WriteLine();
        
        foreach (var entry in activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
        }
        
        Console.WriteLine();
        Console.Write("Press enter to return to the menu...");
        Console.ReadLine();
    }

    static void PauseWithSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }
}