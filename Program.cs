using System.Text;
using VarduLocitajs;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

var helper = new Helpers();
var conjugationFactory = new ConjugationFactory();

var inputActive = true;

Console.WriteLine("Sveicināti vārdu locītājā! Ja vēlaties beigt procesu, rakstiet STOP.");
Console.WriteLine();

while (inputActive)
{
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine("Ievadiet, lūdzu, vārdu, ko vēlaties locīt:");

    string wordToConjugate = Console.ReadLine();

    if (wordToConjugate == "STOP")
    {
        inputActive = false;
        break;
    }

    if (wordToConjugate != null)
    {
        var wordProperties = helper.GetWordType(wordToConjugate);

        if (wordProperties.First().Value != Enums.WordEndings.unknown)
        {
            Console.WriteLine();
            Console.WriteLine(wordProperties.First().Key);

            try
            {
                var conjugationProcess = conjugationFactory.CreateConjugationProcess(wordToConjugate, wordProperties.First().Value);
                conjugationProcess.ConjugateWord();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Es nemāku locīt šādu vārdu un/vai vārds nav korekts.");
        }
    }
}