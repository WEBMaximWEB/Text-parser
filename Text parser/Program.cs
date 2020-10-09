using System;
using System.Collections.Generic;
using System.IO;

namespace Text_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            Console.WriteLine("Введите текст:");
            text = Console.ReadLine();

            Console.WriteLine("Количество символов в тексте:" + Counter(text));
            Console.WriteLine("{0}", string.Join("\n", Separator(text)) + "\n");
            Console.WriteLine("{0}", string.Join("\n", Unique_words(text)));
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
            //string[] sentence = text.Split('.');
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

        static string[] Unique_words(string text)
        {
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
                    if (str =)
            }

            return words;
        }
    }
}
