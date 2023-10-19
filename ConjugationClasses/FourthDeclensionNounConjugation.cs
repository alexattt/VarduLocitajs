using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VarduLocitajs.Models;

namespace VarduLocitajs.ConjugationClasses
{
    public class FourthDeclensionNounConjugation : ConjugationBase
    {
        private string wordToConjugate;

        public FourthDeclensionNounConjugation(string wordToConjugate)
        {
            this.wordToConjugate = wordToConjugate;
        }

        public override void ConjugateWord()
        {
            Console.WriteLine($"Sāk 4.deklinācijas lietvārda locīšanas procesu vārdam {wordToConjugate}");

            var conjugationResult = FourthDeclensionConjugator();

            CreateFile(conjugationResult);
        }

        private void CreateFile(SingularAndPluralModel conjugationResult)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory("conjugations");
            string pathName = Path.Combine(path, $"conjugations\\conjugation_{wordToConjugate}.txt");

            using (StreamWriter writer = new StreamWriter(pathName))
            {
                writer.WriteLine($"Vārda {wordToConjugate} locīšana");
                writer.WriteLine();
                writer.WriteLine("VIENSKAITLIS");
                writer.WriteLine($"Nominatīvs --- {conjugationResult.Singular.Nominativs}");
                writer.WriteLine($"Ģenitīvs --- {conjugationResult.Singular.Genitivs}");
                writer.WriteLine($"Datīvs --- {conjugationResult.Singular.Dativs}");
                writer.WriteLine($"Akuzatīvs --- {conjugationResult.Singular.Akuzativs}");
                writer.WriteLine($"Instrumentālis --- {conjugationResult.Singular.Instrumentalis}");
                writer.WriteLine($"Lokatīvs --- {conjugationResult.Singular.Lokativs}");
                writer.WriteLine($"Vokatīvs --- {conjugationResult.Singular.Vokativs}");

                writer.WriteLine();
                writer.WriteLine("DAUDZSKAITLIS");
                writer.WriteLine($"Nominatīvs --- {conjugationResult.Plural.Nominativs}");
                writer.WriteLine($"Ģenitīvs --- {conjugationResult.Plural.Genitivs}");
                writer.WriteLine($"Datīvs --- {conjugationResult.Plural.Dativs}");
                writer.WriteLine($"Akuzatīvs --- {conjugationResult.Plural.Akuzativs}");
                writer.WriteLine($"Instrumentālis --- {conjugationResult.Plural.Instrumentalis}");
                writer.WriteLine($"Lokatīvs --- {conjugationResult.Plural.Lokativs}");
                writer.WriteLine($"Vokatīvs --- {conjugationResult.Plural.Vokativs}");

                writer.Close();
            }

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Fails ir atrodams šeit: {pathName}");
        }

        private SingularAndPluralModel FourthDeclensionConjugator()
        {
            var result = new SingularAndPluralModel();

            var singularConjugationObj = new ConjugationModel()
            {
                Nominativs = wordToConjugate,
                Genitivs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "as",
                Dativs = $"{wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ai"} " +
                         $"vai {wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "am"}",
                Akuzativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u",
                Instrumentalis = $"ar {wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u"}",
                Lokativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ā",
                Vokativs = wordToConjugate
            };

            var pluralConjugationObj = new ConjugationModel()
            {
                Nominativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "as",
                Genitivs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u",
                Dativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ām",
                Akuzativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "as",
                Instrumentalis = $"ar {wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ām"}",
                Lokativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ās",
                Vokativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "as",
            };

            result.Singular = singularConjugationObj;
            result.Plural = pluralConjugationObj;

            return result;
        }
    }
}
