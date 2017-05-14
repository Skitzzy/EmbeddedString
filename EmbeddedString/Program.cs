using System;
using System.IO;
using System.Collections.Generic;

namespace EmbeddedString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordList = new List<string>();
            #Enter filepath here
            using (StreamReader sr = new StreamReader(source))
            {
                while (sr.Peek() >= 0)
                {
                    wordList.Add( sr.ReadLine());
                }
            }
            string embeddedWords = "scpareotunimdleabroinsthecagroulipfenstamriodelvscenatiryosgehunwlaitesrdbkionesclpametirsgonedyhslatizesfurxonicalestgidpymesnorbleainstvehksiquegjarsocniledytsiwamesrntugioeslzpanedctisrbleyhonsgifaekslritesmvendicasteuslyriongsexpsbhialestrzydesncimawesotfnikselursdgneojaslyitcpsenshuorsgveanismtesdquelbilyarsnekinsfeiaslcdestzongesyhieslumxyaesl";
            
            foreach (string word in wordList)
            {
                int i = 0;
                foreach (char letter in word)
                {
                    while (letter != embeddedWords[i])
                    {
                        i++;
                        if (i >= embeddedWords.Length)
                        {
                            embeddedWords = embeddedWords + letter;
                            
                        }
                    }
                    Console.WriteLine("Word embedded / checked");
                }
            }
            Console.WriteLine(embeddedWords);
            Console.WriteLine(embeddedWords.Length);

            Console.WriteLine("Word has been created, begin depth search? Y/N");
            string option = Console.ReadLine();
            if (option.ToUpper() == "Y")
            {
                DepthSearch(embeddedWords, wordList);
            }
        }

        static void DepthSearch(string embeddedWords, List<string> wordList)
        {
            bool doesEmbed = false;
            bool exceedLimit = false;
            int i = 0;
            while (!(i >= embeddedWords.Length))
            {
                string prevWord = embeddedWords;
                embeddedWords = embeddedWords.Remove(i,1);
                doesEmbed = CheckWords(embeddedWords, wordList);
                if (!doesEmbed)
                {
                    embeddedWords = prevWord;
                    i++;
                }
            }
            FinalWord(embeddedWords, wordList);
        }

        static bool CheckWords(string embeddedWords, List<string> wordList)
        {
            foreach (string word in wordList)
            {
                int j = 0;
                foreach (char letter in word)
                {
                    while (letter != embeddedWords[j])
                    {
                        j++;
                        if (j >= embeddedWords.Length)
                        {
                            return false;

                        }
                    }
                    Console.WriteLine("Word checked");
                }
            }
            return true;
        }

        static void FinalWord(string embeddedWords, List<string> wordList)
        {
            Console.WriteLine(embeddedWords);
            Console.WriteLine(embeddedWords.Length);
            Console.ReadKey();
            Console.WriteLine("Recheck depth search with new word? Y/N");
            string option = Console.ReadLine();
            if (option.ToUpper() == "Y")
            {
                DepthSearch(embeddedWords, wordList);
            }
        }
    }
}
