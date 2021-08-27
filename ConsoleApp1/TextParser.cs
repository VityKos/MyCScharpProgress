using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TextParser
    {
        public static List<List<string>> ParseByWord(string textFromFile)
        {
            var text = new List<List<string>>();
            char[] separatorsOdSentens = new char[] { '.', '!', '?', ':', ';', '(', ')', '—' };
            string[] sentens = textFromFile.Split(separatorsOdSentens, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pred in sentens)
            {
                var preSentencesList = new List<string>();
                var word = new StringBuilder();
                for (int i = 0; i < pred.Length; i++)
                {
                    if (char.IsLetter(pred[i]) || pred[i] == '\'')
                    {
                        word.Append(pred[i]);
                    }
                    if (!char.IsLetter(pred[i]) && pred[i] != '\'' || i == pred.Length - 1)
                    {
                        if (word.Length != 0)
                        {
                            preSentencesList.Add(word.ToString().ToLower());
                            word.Clear();
                        }
                    }
                }
                text.Add(preSentencesList);
            }
            return text;
        }
    }
}
