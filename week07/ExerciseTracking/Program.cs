using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create activities of each type
        List<Activity> activities = new List<Activity>();
        
        // Add running activity
        Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        activities.Add(running);
        
        // Add cycling activity  
        Cycling cycling = new Cycling(new DateTime(2022, 11, 3), 30, 20.0);
        activities.Add(cycling);
        
        // Add swimming activity
        Swimming swimming = new Swimming(new DateTime(2022, 11, 3), 30, 20);
        activities.Add(swimming);

        // Display summaries using polymorphism
        Console.WriteLine("Exercise Tracking Summary");
        Console.WriteLine("=========================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}