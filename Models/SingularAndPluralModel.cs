using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarduLocitajs.Models
{
    public class SingularAndPluralModel
    {
        public ConjugationModel Singular { get; set; } = new ConjugationModel();
        public ConjugationModel Plural { get; set; } = new ConjugationModel();
    }
}
