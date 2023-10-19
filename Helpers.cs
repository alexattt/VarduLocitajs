using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VarduLocitajs.Enums;

namespace VarduLocitajs
{
    public class Helpers
    {
        public Dictionary<string, WordEndings> GetWordType(string word)
        {
            if (word.EndsWith("aks") || word.EndsWith("āks"))
            {
                return new Dictionary<string, WordEndings>() { { "Šis ir īpašības vārds", WordEndings.aks } };
            }
            else if (word.EndsWith("a"))
            {
                return new Dictionary<string, WordEndings>() { { "Šis ir 4. deklinācijas lietvārds", WordEndings.a } };
            }
            else if (word.EndsWith("s"))
            {
                return new Dictionary<string, WordEndings>() { { "Šis ir 1. deklinācijas lietvārds", WordEndings.s } };
            }
            else
            {
                return new Dictionary<string, WordEndings>() { { "Šis vārds man nav pazīstams", WordEndings.unknown } };
            }
        }
    }
}
