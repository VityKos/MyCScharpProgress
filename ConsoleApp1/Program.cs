using System;


namespace ConsoleApp1
{
	class Program
	{
        static double GetDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
        static double GetFirstRoot(double a, double b, double c)
        {
            var discriminant = GetDiscriminant(a, b, c);
            var squareroot = Math.Sqrt(discriminant);
            return(-b - squareroot) / (2*a);
        }
        static double GetSecondRoot(double a, double b, double c)
        {
            return b / GetFirstRoot(a,b,c);
        }
        public static void Main()
		{

            double[] result =  { GetFirstRoot(3, -14, 16), GetSecondRoot(3, -14, 16) };
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
            Console.ReadKey();
		}
        
    }
}