using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErweiterteCSharpThemen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pfad und Name exact richtig geschrieben, @ für Verbatim formatierungen, die escapezeichen "\" werden ignoriert, damit die Lesbarkeit verbessert wird.
            // könnte man auch mit doppel zeichen schreiben, ist aber oft eine fehlerquelle "//"
            // Aufpassen mit pfad nicht verwechseln und kein . anstatt\ zu verwenden.
            // Manchmal gibt es probleme mit Administrator und schreibrechte. Dagegen könnte helfen, der VisualStudio als Admin auszuführen!!

            //ReadAllText - zeigt das ganze Text
            string text = System.IO.File.ReadAllText(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\textFile.txt");
            Console.WriteLine("Via ReadAllText");
            Console.WriteLine($"Die Textdatei beinhaltet folgender Text: \n{text}");
            Console.WriteLine("\nEnde der Textdatei\n\n");

            //ReadAllLines, zeigt jede einzelne Zeile (wenn wir via foreach alle Linien aufrufen)
            string[]  zeilen = System.IO.File.ReadAllLines(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\textFile.txt");
            Console.WriteLine("Via ReadAllLines, foreach line loop (+Erw.keine Leelre Linie anzeigen):");
            foreach (string line in zeilen)
            {
                //kleine erweiterung um Leere Linien zu überspringen:
                if (line.Length>0)
                {
                    Console.WriteLine(line);
                }
                //kein else, einfach weiterlesen
            }
            Console.WriteLine("\nEnde der Textdatei\n\n");


            Console.ReadKey();

        }
    }
}

