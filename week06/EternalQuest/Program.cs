using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            bool quit = false;

            Console.WriteLine("Welcome to the Eternal Quest Program!");

            while (!quit)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. View Level"); // ← EASY CREATIVITY OPTION
                Console.WriteLine("7. Quit");
                
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.CreateGoal();
                        break;
                    case "2":
                        manager.ListGoalDetails();
                        break;
                    case "3":
                        manager.SaveGoals();
                        break;
                    case "4":
                        manager.LoadGoals();
                        break;
                    case "5":
                        manager.RecordEvent();
                        manager.DisplayPlayerInfo();
                        break;
                    case "6":  // ← EASY CREATIVITY OPTION
                        DisplaySimpleLevel(manager.GetScore());
                        break;
                    case "7":
                        quit = true;
                        Console.WriteLine("Goodbye! Keep working on your eternal quest!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplaySimpleLevel(int score)
        {
            string level;
            if (score >= 2000)
                level = "Legend 🌟";
            else if (score >= 1000)
                level = "Master 🏅";
            else if (score >= 500)
                level = "Achiever ⭐";
            else if (score >= 100)
                level = "Beginner 🌱";
            else
                level = "Newcomer 🐣";

            Console.WriteLine($"\n🏆 Current Level: {level}");
            Console.WriteLine($"📊 Total Points: {score}");
        }
    }
}