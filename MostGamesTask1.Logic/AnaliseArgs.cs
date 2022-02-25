using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostGamesTask1.Logic
{
    public class AnaliseArgs
    {
        public List<int> GetNumberOfLines(string args)
        {
            foreach(char c in args)
            {
                if (((int)c < 30 && (int)c > 39) && c != ',')
                    throw new ArgumentException($"Input has a bad character - {c}");
            }
            string[] lines = args.Split(",");
            List<int> numberLines = new();
            try
            {
                foreach(string str in lines)
                {
                    numberLines.Add(Convert.ToInt32(str));
                }
            }
            catch(FormatException)
            {
                return (new List<int> { -1 });
            }
            IsValid(numberLines);
            return numberLines;
        }
        //System.FormatException
        private void IsValid(List<int> ids)
        {
            foreach(var id in ids)
            {
                if (id < 1 || id > 20)
                    throw new($"Input has a bad arg - {id}. Take another from 1 to 20");
            }
        }
    }
}
