using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MostGamesTask1.Logic
{
    public class GetText
    {
        private readonly string _url = "http://tmgwebtest.azurewebsites.net/api/textstrings/";
        private readonly string _apiKey = "0J/RgNC40LLQtdGC0LjQutC4IQ==";

        private string GetAnswerByGivenId(int id)
        {
            WebRequest myWebRequest = WebRequest.Create($"{_url}{id}");
            var a = myWebRequest.Headers.ToString;
            myWebRequest.Headers["TMG-Api-Key"] = _apiKey;
            try
            {
                WebResponse myWebResponse = myWebRequest.GetResponse();
                    string text;
                using (var sr = new StreamReader(myWebResponse.GetResponseStream(), encoding: Encoding.UTF8))
                {
                    text = sr.ReadToEnd();
                }
                Text result = JsonSerializer.Deserialize<Text>(text);
                if (result.text is null)
                    throw new ArgumentNullException($"Text by id {id} does not exist");
                return result.text;
            }
            catch (WebException e)
            {
                return ("Random teapot, try again");
            }
        }

        public List<string> GetLines(List<int> ids)
        {
            List<string> lines = new();
            foreach(int id in ids)
            {
                lines.Add(GetAnswerByGivenId(id));
            }
            return lines;
        }
        public int CountWords(string text)
        {
            text.Trim();
            string[] splittedByWhiteSpace = text.Split(" ");
            return splittedByWhiteSpace.Count();
        }

        public int CountVowels(string text)
        {
            int vowelCount = text.Count(c => "aeiouаиеёоуыэюяäüöæøåóúáůýαεηιοωυ".Contains(Char.ToLower(c)));
            return vowelCount;
        }
    }
}
