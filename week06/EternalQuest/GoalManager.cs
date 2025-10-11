using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nYou have {_score} points.");
        }

        public void ListGoalNames()
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
            }
        }

        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\nNo goals have been created yet.");
                return;
            }

            Console.WriteLine("\nYour Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("\nThe types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string choice = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Goal created successfully!");
        }

        public void RecordEvent()
        {
            ListGoalNames();
            if (_goals.Count == 0) return;

            Console.Write("Which goal did you accomplish? ");
            int goalNumber = int.Parse(Console.ReadLine()) - 1;

            if (goalNumber >= 0 && goalNumber < _goals.Count)
            {
                Goal goal = _goals[goalNumber];
                goal.RecordEvent();
                
                int pointsEarned = goal.GetPoints();
                _score += pointsEarned;

                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                
                // Special message for checklist goal completion
                if (goal is ChecklistGoal checklist && checklist.IsComplete() && checklist.GetAmountCompleted() == checklist.GetTarget())
                {
                    Console.WriteLine($"You also earned a bonus of {checklist.GetBonus()} points!");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void SaveGoals(string filename = "goals.txt")
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved to {filename}");
        }

        public void LoadGoals(string filename = "goals.txt")
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            
            // First line is the score
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(goalData[0], goalData[1], 
                            int.Parse(goalData[2]), bool.Parse(goalData[3])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(goalData[0], goalData[1], 
                            int.Parse(goalData[2])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(goalData[0], goalData[1], 
                            int.Parse(goalData[2]), int.Parse(goalData[4]), 
                            int.Parse(goalData[3]), int.Parse(goalData[5])));
                        break;
                }
            }
            Console.WriteLine($"Goals loaded from {filename}");
        }

        public int GetScore() => _score;
    }
}