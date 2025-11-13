using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    class Program
    {
        static void Main(string[] args)
        {
            const string patterns = @"^(https?:\/\/)?([a-z\d][a-z\d\.-]*)\.([a-z\.]{2,6})([\/\w\.\-?=&%#]*)*\/?$";
            string[] text = {
                "https://www.example.com",
                "http://subdomain.example.co.uk/path/to/resource",
                "www.example.com",
                "example",
                "https://example.com?query=param",
                "ftp://example.com/resource",
                "https://example..com",
                "https://-example.com",
                "https://example.com/path with spaces",
                "https://example.com/#fragment"
            };
            Console.WriteLine("Text to validate URLs:");
            foreach (var line in text)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Valid URLs:");
            foreach (var line in text)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(line, patterns))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
