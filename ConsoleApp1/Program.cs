﻿using System;


namespace ConsoleApp1
{
	class Program
	{
       
        public static void Main()
		{
            TestMove("a1", "d4");
            TestMove("f4", "e7");
            TestMove("a1", "a4");
            
        }
        public static void TestMove(string from, string to)
        {
            Console.WriteLine("{0}-{1} {2}", from, to, IsCorrectMove(from, to));
        }
        public static bool IsCorrectMove(string from, string to)
        {
            var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
            var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали
            if (dx == 0 && dy == 0) return false;
            if (dy == 0 | dx == 0) return true;
            if (dx <= 1 && dy <= 1) return true;
            if (dx == dy) return true;

            return false;

        }   
    }
}