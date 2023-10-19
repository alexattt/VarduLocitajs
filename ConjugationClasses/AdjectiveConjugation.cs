using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VarduLocitajs.Models;

namespace VarduLocitajs.ConjugationClasses
{
    public class AdjectiveConjugation : ConjugationBase
    {
        private string wordToConjugate;

        public AdjectiveConjugation(string wordToConjugate)
        {
            this.wordToConjugate = wordToConjugate;
        }

        public override void ConjugateWord()
        {
            Console.WriteLine($"Sāk īpašības vārda locīšanas procesu vārdam {wordToConjugate}");

            var conjugationResult = AdjectiveConjugator();

            CreateFile(conjugationResult);
        }

        private void CreateFile(GenderModel conjugationResult)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory("conjugations");
            string pathName = Path.Combine(path, $"conjugations\\conjugation_{wordToConjugate}.txt");

            using (StreamWriter writer = new StreamWriter(pathName))
            {
                writer.WriteLine($"Vārda {wordToConjugate} locīšana");
                writer.WriteLine();
                writer.WriteLine("VIENSKAITLIS SIEVIEŠU DZIMTE");
                writer.WriteLine($"Nominatīvs --- {conjugationResult.Feminine.Singular.Nominativs}");
                writer.WriteLine($"Ģenitīvs --- {conjugationResult.Feminine.Singular.Genitivs}");
                writer.WriteLine($"Datīvs --- {conjugationResult.Feminine.Singular.Dativs}");
                writer.WriteLine($"Akuzatīvs --- {conjugationResult.Feminine.Singular.Akuzativs}");
                writer.WriteLine($"Instrumentālis --- {conjugationResult.Feminine.Singular.Instrumentalis}");
                writer.WriteLine($"Lokatīvs --- {conjugationResult.Feminine.Singular.Lokativs}");
                writer.WriteLine($"Vokatīvs --- {conjugationResult.Feminine.Singular.Vokativs}");
                writer.WriteLine();
                writer.WriteLine("DAUDZSKAITLIS SIEVIEŠU DZIMTE");
                writer.WriteLine($"Nominatīvs --- {conjugationResult.Feminine.Plural.Nominativs}");
                writer.WriteLine($"Ģenitīvs --- {conjugationResult.Feminine.Plural.Genitivs}");
                writer.WriteLine($"Datīvs --- {conjugationResult.Feminine.Plural.Dativs}");
                writer.WriteLine($"Akuzatīvs --- {conjugationResult.Feminine.Plural.Akuzativs}");
                writer.WriteLine($"Instrumentālis --- {conjugationResult.Feminine.Plural.Instrumentalis}");
                writer.WriteLine($"Lokatīvs --- {conjugationResult.Feminine.Plural.Lokativs}");
                writer.WriteLine($"Vokatīvs --- {conjugationResult.Feminine.Plural.Vokativs}");

                writer.WriteLine();
                writer.WriteLine("VIENSKAITLIS VĪRIEŠU DZIMTE");
                writer.WriteLine($"Nominatīvs --- {conjugationResult.Masculine.Singular.Nominativs}");
                writer.WriteLine($"Ģenitīvs --- {conjugationResult.Masculine.Singular.Genitivs}");
                writer.WriteLine($"Datīvs --- {conjugationResult.Masculine.Singular.Dativs}");
                writer.WriteLine($"Akuzatīvs --- {conjugationResult.Masculine.Singular.Akuzativs}");
                writer.WriteLine($"Instrumentālis --- {conjugationResult.Masculine.Singular.Instrumentalis}");
                writer.WriteLine($"Lokatīvs --- {conjugationResult.Masculine.Singular.Lokativs}");
                writer.WriteLine($"Vokatīvs --- {conjugationResult.Masculine.Singular.Vokativs}");
                writer.WriteLine();
                writer.WriteLine("DAUDZSKAITLIS VĪRIEŠU DZIMTE");
                writer.WriteLine($"Nominatīvs --- {conjugationResult.Masculine.Plural.Nominativs}");
                writer.WriteLine($"Ģenitīvs --- {conjugationResult.Masculine.Plural.Genitivs}");
                writer.WriteLine($"Datīvs --- {conjugationResult.Masculine.Plural.Dativs}");
                writer.WriteLine($"Akuzatīvs --- {conjugationResult.Masculine.Plural.Akuzativs}");
                writer.WriteLine($"Instrumentālis --- {conjugationResult.Masculine.Plural.Instrumentalis}");
                writer.WriteLine($"Lokatīvs --- {conjugationResult.Masculine.Plural.Lokativs}");
                writer.WriteLine($"Vokatīvs --- {conjugationResult.Masculine.Plural.Vokativs}");

                writer.Close();
            }

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Fails ir atrodams šeit: {pathName}");
        }

        private GenderModel AdjectiveConjugator()
        {
            var result = new GenderModel();

            var singularMasculine = new ConjugationModel()
            {
                Nominativs = wordToConjugate,
                Genitivs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "a",
                Dativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "am",
                Akuzativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u",
                Instrumentalis = $"ar {wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u"}",
                Lokativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ā",
                Vokativs = "-"
            };
            var pluralMasculine = new ConjugationModel()
            {
                Nominativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "i",
                Genitivs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u",
                Dativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "iem",
                Akuzativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "us",
                Instrumentalis = $"ar {wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "iem"}",
                Lokativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "os",
                Vokativs = "-"
            };
            var masculineObj = new SingularAndPluralModel() { Singular = singularMasculine, Plural = pluralMasculine };

            var singularFeminine = new ConjugationModel()
            {
                Nominativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "a",
                Genitivs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "as",
                Dativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ai",
                Akuzativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u",
                Instrumentalis = $"ar {wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u"}",
                Lokativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ā",
                Vokativs = "-"
            };
            var pluralFeminine = new ConjugationModel()
            {
                Nominativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "as",
                Genitivs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "u",
                Dativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ām",
                Akuzativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "as",
                Instrumentalis = $"ar {wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ām"}",
                Lokativs = wordToConjugate.Substring(0, wordToConjugate.Length - 1) + "ās",
                Vokativs = "-"
            };
            var feminineObj = new SingularAndPluralModel() { Singular = singularFeminine, Plural = pluralFeminine };

            result.Masculine = masculineObj;
            result.Feminine = feminineObj;

            return result;
        }
    }
}
