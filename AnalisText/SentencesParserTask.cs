using System.Collections.Generic;
using System;
using System.Text;
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            char[] separatorsOdSentens = new char[] {'.','!','?',':',';','(',')' };
            string[] sentens = text.Split(separatorsOdSentens, StringSplitOptions.RemoveEmptyEntries);
            foreach(var pred in sentens)
            {
                var preSentencesList = new List<string>();
                var word = new StringBuilder();
                for(int i = 0; i < pred.Length; i++)
                {
                    if (char.IsLetter(pred[i]) || pred[i] == '\'')
                    {
                        word.Append(pred[i]);
                    }
                    if (!char.IsLetter(pred[i]) && pred[i] != '\'' || i == pred.Length - 1 )
                    {
                        if (word.Length != 0)
                        {
                            preSentencesList.Add(word.ToString().ToLower());
                            word.Clear();
                        }
                    }
                }
                if(preSentencesList.Count != 0) sentencesList.Add(preSentencesList);
            }
            return sentencesList;
        }
    }
}