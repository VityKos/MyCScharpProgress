using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp1
{
    class CreateText
    {
        public static string CreateOneSentence(string phraseBeginning, int wordsCount, Dictionary<string, string> result)
        {
            var sentence = new List<string>();
            var start = phraseBeginning.Split(' ');
            foreach (var word in start)
            {
                sentence.Add(word);
            }
            for (int i = 0; i < wordsCount; i++)
            {
                if (sentence.Count >= 2 && result.ContainsKey(sentence[sentence.Count - 2] + ' ' + sentence[sentence.Count - 1]))
                {
                    if (result.TryGetValue(sentence[sentence.Count - 2] + ' ' + sentence[sentence.Count - 1], out string word))
                    {
                        sentence.Add(word);
                    }
                }
                else if (sentence.Count == 1 & result.ContainsKey(sentence[sentence.Count - 1]))
                {
                    if (result.TryGetValue(sentence[sentence.Count - 1], out string word))
                    {
                        sentence.Add(word);
                    }
                }
                else
                {
                    break;
                }
            }
            var tSentence = new StringBuilder();
            foreach (var word in sentence) tSentence.Append(word + ' ');
            tSentence.Length = tSentence.Length - 1;
            return tSentence.ToString();
        }
    }
}
