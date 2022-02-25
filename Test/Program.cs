// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Test;

string url = "http://tmgwebtest.azurewebsites.net/api/textstrings/6";

Uri ourUri = new Uri(url);

// Create a 'WebRequest' object with the specified url. 

WebRequest myWebRequest = WebRequest.Create(url);
var a = myWebRequest.Headers.ToString;
// Send the 'WebRequest' and wait for response.
myWebRequest.Headers["TMG-Api-Key"] = "0J/RgNC40LLQtdGC0LjQutC4IQ==";
WebResponse myWebResponse = myWebRequest.GetResponse();
string text;
using (var sr = new StreamReader(myWebResponse.GetResponseStream(), encoding: Encoding.UTF8))
{
    text = sr.ReadToEnd();
}

Console.WriteLine(text);
//var newText = text.RemoveDiacritics();
TextToCount result = JsonSerializer.Deserialize<TextToCount>(text);

Console.WriteLine(result.text);
int aw = CountWordsAndVowels.CountWords(result.text);
Console.WriteLine(aw);
int ww = 0;

//string input = "Ёntity framёwork";

//Console.WriteLine(input);

////C# Extension Method: String - RemoveDiacritics
//var output = input.RemoveDiacritics();
//Console.WriteLine(output);
// aeiouAEIOU аАиИеЕёЁоОуУыЫэЭюЮяЯ  ÄäÜüÖö