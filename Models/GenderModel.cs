using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarduLocitajs.Models
{
    public class GenderModel
    {
        public SingularAndPluralModel Masculine { get; set; } = new SingularAndPluralModel();
        public SingularAndPluralModel Feminine { get; set; } = new SingularAndPluralModel();
    }
}
