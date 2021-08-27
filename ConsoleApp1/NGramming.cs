using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class NGramming
    {
        public static Dictionary<string, string> OneTwoGramming(List<List<string>> parsedText)
        {
            var result = new Dictionary<string, string>();
            var statistics = new Dictionary<string, Dictionary<string, int>>();
            CreateStatistics(parsedText, statistics);
            AddNGramm(result, statistics);
            return result;
        }
        static void CreateStatistics(List<List<string>> text, Dictionary<string, Dictionary<string, int>> stat)
        {
            foreach (var offer in text)
            {
                for (int i = 0; i < offer.Count - 1; i++)
                {

                    if (!stat.ContainsKey(offer[i]))
                    {
                        var dictionatyOfwordOfMainWord = new Dictionary<string, int>();
                        if (dictionatyOfwordOfMainWord.TryGetValue(offer[i + 1], out var sometihng))
                        {
                            dictionatyOfwordOfMainWord[offer[i + 1]]++;
                        }
                        else
                        {
                            dictionatyOfwordOfMainWord.Add(offer[i + 1], 1);
                        }
                        stat.Add(offer[i], dictionatyOfwordOfMainWord);
                    }
                    else
                    {
                        if (stat.TryGetValue(offer[i], out var b))
                        {
                            if (b.TryGetValue(offer[i + 1], out var sometihng))
                            {
                                b[offer[i + 1]]++;
                            }
                            else
                            {
                                b.Add(offer[i + 1], 1);
                            }
                        }
                    }
                }
                for (int i = 0; i < offer.Count - 2; i++)
                {
                    if (!stat.ContainsKey(offer[i] + ' ' + offer[i + 1]))
                    {
                        var a = new Dictionary<string, int>();
                        if (a.TryGetValue(offer[i + 2], out var something))
                        {
                            a[offer[i + 2]]++;
                        }
                        else
                        {
                            a.Add(offer[i + 2], 1);
                        }
                        stat.Add(offer[i] + ' ' + offer[i + 1], a);
                    }
                    else
                    {
                        if (stat.TryGetValue(offer[i] + ' ' + offer[i + 1], out var b))
                        {
                            if (b.TryGetValue(offer[i + 2], out var something))
                            {
                                b[offer[i + 2]]++;
                            }
                            else
                            {
                                b.Add(offer[i + 2], 1);
                            }
                        }
                    }
                }
            }
        }
        static void AddNGramm(Dictionary<string, string> result, Dictionary<string, Dictionary<string, int>> stat)
        {
            foreach (var dictionaryOfWord in stat)
            {
                string oneGrammWord = "";
                int maxCountofGrrammWord = 0;
                foreach (var dictionatyOfwordOfMainWord in dictionaryOfWord.Value)
                {
                    if (dictionatyOfwordOfMainWord.Value > maxCountofGrrammWord)
                    {
                        oneGrammWord = dictionatyOfwordOfMainWord.Key;
                        maxCountofGrrammWord = dictionatyOfwordOfMainWord.Value;
                    }
                    else if (dictionatyOfwordOfMainWord.Value == maxCountofGrrammWord)
                    {
                        if (string.CompareOrdinal(dictionatyOfwordOfMainWord.Key, oneGrammWord) < string.CompareOrdinal(oneGrammWord, dictionatyOfwordOfMainWord.Key))
                        {
                            oneGrammWord = dictionatyOfwordOfMainWord.Key;
                        }
                    }
                }
                if (!result.ContainsKey(dictionaryOfWord.Key))
                {
                    result.Add(dictionaryOfWord.Key, oneGrammWord);
                }
                else
                {
                    string gramm = "";
                    int maxCountOfGramm = 0;
                    foreach (var a in stat[dictionaryOfWord.Key])
                    {
                        if (a.Value > maxCountOfGramm)
                        {
                            maxCountOfGramm = a.Value;
                            gramm = a.Key;
                        }
                        else if (a.Value == maxCountOfGramm)
                        {
                            if (string.CompareOrdinal(a.Key, gramm) < string.CompareOrdinal(gramm, a.Key))
                            {
                                gramm = a.Key;
                            }
                        }
                    }
                    result[dictionaryOfWord.Key] = gramm;
                }
            }
        }
    }
}
