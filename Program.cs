using System;
using System.Text.RegularExpressions;

namespace LabWork
{
    class Program
    {
        static void Main(string[] args)
        {
            const string urlPattern = @"\b(?:(?:https?|ftp)://|www\.)[a-z0-9](?:[a-z0-9-]*[a-z0-9])?(?:\.[a-z]{2,})+(?:[/?#][^\s]*)?\b";

            string textToSearch = @"
Here are a few test strings:
Valid: https://www.example.com and http://subdomain.example.co.uk/path/to/resource
Also valid: https://example.com?query=param and https://example.com/#fragment
This one should also be found: www.example.com (without http).
Link to the video: https://www.youtube.com/@ViktorZhukovskyy/videos

Invalid or incomplete:
This is just example, and this is ftp://example.com/resource (ftp will be found).
Erroneous: https://example..com or https://-example.com
URL with a space: 'https://example.com/path with spaces' (will only find the first part).
";

            Console.WriteLine("--- Text to search URLs in: ---");
            Console.WriteLine(textToSearch);
            Console.WriteLine("---------------------------------");

            ExtractUrls(textToSearch, urlPattern);
        }
        
        private static void ExtractUrls(string text, string pattern)
        {
            Console.WriteLine("Found URLs:");

            try
            {
                MatchCollection matches = Regex.Matches(text, pattern, 
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

                if (matches.Count == 0)
                {
                    Console.WriteLine("No valid URLs found.");
                    return;
                }

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            catch (RegexMatchTimeoutException ex)
            {
                Console.WriteLine($"Error: The regex operation timed out. {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: Invalid regex pattern. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}