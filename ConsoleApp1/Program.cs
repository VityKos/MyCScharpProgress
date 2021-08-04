using System;


namespace ConsoleApp1
{
	class Program
	{
       
        public static void Main()
		{
            string userInput = Console.ReadLine();
            Console.WriteLine(Calculate(userInput));
            
		}
        
        public static double Calculate(string userInput)
        {
            string[] data = userInput.Split();
            var startSum = Convert.ToDouble(data[0]);
            var procent = Convert.ToDouble(data[1]);
            var mounth = Convert.ToDouble(data[2]);
            var result = startSum * Math.Pow(1 + (procent / 12) / 100, mounth);
            return result;
        }
    }
}