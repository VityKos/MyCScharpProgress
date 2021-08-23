using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        
        {
            var result = new Dictionary<string, string>();

            var stat = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sens in text)
            {
               
                for (int i = 0; i < sens.Count - 1; i++)
                {
                   
                    if (!stat.ContainsKey(sens[i]))
                    {
                        var a = new Dictionary<string, int>();
                        if (a.TryGetValue(sens[i+1], out var sometihng))
                        {
                            a[sens[i + 1]]++;
                        }
                        else
                        {
                            a.Add(sens[i + 1], 1);
                        }
                        stat.Add(sens[i], a);
                    }
                    else
                    {
                        if(stat.TryGetValue(sens[i], out var b))
                        {
                            if(b.TryGetValue(sens[i + 1], out var sometihng))
                            {
                                b[sens[i + 1]]++;
                            }
                            else
                            {
                                b.Add(sens[i + 1], 1);
                            }
                        }
                    }
                }
                
            }
            foreach(var dictionaryOfWord in stat)
            {
                string oneGrammWord = "";
                int maxCountofGrrammWord = 0;
                foreach(var dictionatyOfwordOfMainWord in dictionaryOfWord.Value)
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
                    
                    string slovo = "";
                    int max  = 0;
                    foreach(var a in stat[dictionaryOfWord.Key])
                    {
                        if (a.Value > max)
                        {
                            max = a.Value;
                            slovo = a.Key;
                        }
                        else if(a.Value == max)
                        {
                            if (string.CompareOrdinal(a.Key, slovo) < string.CompareOrdinal(slovo, a.Key))
                            {
                                slovo = a.Key;
                            }
                        }
                    }
                    result[dictionaryOfWord.Key] = slovo;
                }
            }
            
            
            return result;
        }
   }
}