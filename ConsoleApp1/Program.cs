using System;
using System.Text;
using System.IO;


namespace ConsoleApp1
{
	class Program
	{
        public static void Main()
        {
            var textFromFile = TakeTextFromFile();
            var parsedText = TextParser.ParseByWord(textFromFile);

            var result = NGramming.OneTwoGramming(parsedText); 

            string phraseBeginning = Console.ReadLine();
            int wordsCount = int.Parse(Console.ReadLine());

            var sens = CreateText.CreateOneSentence(phraseBeginning, wordsCount, result);
            Console.WriteLine(sens);
        }
        
        static string TakeTextFromFile()
        {
            string path = @"C:\Users\User\source\repos\ConsoleApp1\ConsoleApp1\Text.txt";
            return File.ReadAllText(path, Encoding.Default);
        }
	}
}