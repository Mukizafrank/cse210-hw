using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        
    
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            
            
            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                {
                    break; 
                }
                numbers.Add(number); 
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        
        
        
        
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");
        
        
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        Console.WriteLine($"The average is: {average}");
        
        
        int max = numbers.Count > 0 ? numbers.Max() : 0;
        Console.WriteLine($"The largest number is: {max}");
        
        
        
        
        if (numbers.Count > 0)
        {
            int smallestPositive = numbers
                .Where(n => n > 0)
                .DefaultIfEmpty(0)
                .Min();
            
            if (smallestPositive > 0)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
        }
        
        if (numbers.Count > 0)
        {
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}