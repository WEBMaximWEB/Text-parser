using System;
using System.Collections.Generic;
using System.IO;

namespace Text_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text, longWord;
            Console.WriteLine("Введите текст:");
            text = Console.ReadLine();

            Console.WriteLine("Количество символов в тексте:" + Counter(text));

            // вывод каждого предложения отдельно
            Console.WriteLine("{0}", string.Join("\n", Separator(text)));

            Console.WriteLine("список уникальных слов: \n" + "{0}", string.Join("\n", Unique_words(text)));

            // самое длинное слово в тексте
            longWord = LongWord(Unique_words(text));
            Console.WriteLine("Самое длинное слово в тексте:" + longWord);
            Processing(longWord);
        }

        static int Counter(string text)
        {
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsPunctuation(text, i))
                    sum++;
            }
            return sum;
        }

        static List<string> Separator(string text)
        {
            string symbols = ".?!";
            int startNumber = 0;
            List<String> sentence = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (text[i] == symbols[j])
                    {
                        sentence.Add(text.Substring(startNumber, i-startNumber + 1));
                        startNumber = i + 2;
                    }
                }
            }
            return sentence;
        }

        static List<string> Unique_words(string text)
        {
            bool flag = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsPunctuation(text, i))
                    text = text.Remove(i, 1);
            }

            string[] words = text.Split(" ");
            List<String> newWords = new List<string>();
            foreach (string str in words)
            {
                for (int i = 0; i < newWords.Count; i++)
                {
                    if (str == newWords[i])
                        flag = false;
                }
                if (flag)
                    newWords.Add(str);
                else flag = true;
                
            }
            return newWords;
        }

        static string LongWord(List<string> words)
        {
            string outWord = "";
            foreach (string str in words)
                if (str.Length > outWord.Length)
                    outWord = str;
            return outWord;
        }

        static void Processing(string word)
        {
            if (word.Length % 2 == 0)
                Console.WriteLine(word.Substring(word.Length / 2));
            else
            {
                char[] ch = word.ToCharArray();
                ch[word.Length / 2] = '*';
                for (int i = 0; i < ch.Length; i++)
                    Console.Write(ch[i]);
            }
        }
    }
}
