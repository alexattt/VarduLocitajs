using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarduLocitajs.ConjugationClasses;
using static VarduLocitajs.Enums;

namespace VarduLocitajs
{
    public class ConjugationFactory
    {
        public ConjugationBase CreateConjugationProcess(string wordToConjugate, WordEndings wordEnding)
        {
            switch (wordEnding)
            {
                case WordEndings.s:
                    return new FirstDeclensionNounConjugation(wordToConjugate);
                case WordEndings.a:
                    return new FourthDeclensionNounConjugation(wordToConjugate);
                case WordEndings.aks:
                    return new AdjectiveConjugation(wordToConjugate);
                default:
                    throw new Exception("Nemāku locīt vārdu ar šādu galotni. :(");
            }
        }
    }
}
