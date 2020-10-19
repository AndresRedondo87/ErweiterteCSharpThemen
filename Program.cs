using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            // TIP AUS Windows:Beim Windows Explorer kann man mit Shift + Rechte Maustaste die Option 
            // "Als Pfad kopieren" nutzen um den Pfad inkl. Dateiname in die Zwischenablage zu speichern. 


            // TEXTDATEIEN SCHREIBEN: ABER ÜBERSCHREIBEN!!!!!!!
            //------------------------------------------------
            Console.WriteLine("\nIn eine eigene Textdatei schreiben:\n mit Dateiname Eingabe und freie eingabe für Text (außer direkt nur Enter (mit space einfach umzugehen)");

            // Methode 1 --alle zeilen schreiben        // DAS WIRD ABER ALLES ÜBERSCHREIBEN WAS DAVOR GAB!!!!!
            string[] zeilenSchreiben = { "hey", "ho", "Let´s", "go!!" };
            File.WriteAllLines(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\textFile.txt", zeilenSchreiben);

            //Methode 2 --WriteAllText ---
            string textSchreiben = "Obladi\nOblada\nich weiss nicht mehr\nwie es weitergeht!!";
            File.WriteAllText(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\textFile.txt", textSchreiben);

            //Herausforderung: benutzer darf den text und Dateiname Eingeben...
            Console.WriteLine($"Bitte geben sie die Dateiname ein (keine .txt nötig, wird automatisch hinzugefügt!):");
            string dateiName = Console.ReadLine();

            //File.Create(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\" + $"{dateiName}.txt");
            // File.Create vielleicht nicht nötig, wird einfach bei WriteAllLines erledigt?

            ////Text Inhalt Eingabe:
            //int counter = 0;
            //string[] linienEingabe = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,};
            //do
            //{
            //    Console.WriteLine($"Bitte geben sie die gewünschte Text Linie ein (ENTER to End, maximal 8 Linien):");
            //    linienEingabe[counter] = Console.ReadLine();
            //    counter++;
            //} while ((linienEingabe[counter-1].Length>0)&& (counter<8));

            ////Text Inhalt schreiben:
            //File.WriteAllLines(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\" + $"{dateiName}.txt", linienEingabe);

            //Text Inhalt Eingabe versuch mit List:
            List<string> listEingaben = new List<string>();
            do
            {
                Console.WriteLine($"Bitte geben sie die gewünschte Text Linie ein, \n(ENTER to End, no max of Lines now because of List):");
                listEingaben.Add(Console.ReadLine());
            } while (listEingaben.Last().Length > 0);

            // TIPP Interpolation+Verbatim geht auch!!! mit $@"......";
            //    Da ich ein großer Anhänger der "string interplation" 
            //    bin => File.WriteAllText($@"D:\ProgrammierenBeispiele\TextInFileSchreiben\{dateiName}.txt", 
            //    dateiInhalt);<=, wollte ich Dich fragen ob es einen bestimmten Grund warum Du sie nicht benutzt.
            //Text Inhalt schreiben versuch mit List:
            //File.WriteAllLines(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\" + $"{dateiName}.txt", listEingaben); // geht direkt mit List?? SCHEINBAR SCHON, IMPLIZITE KONVERTIERUNG MÖGLICH!!
            File.WriteAllLines($@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\{dateiName}.txt", listEingaben); // IMPLIZITE KONVERTIERUNG UND INTERPOLATION beide MÖGLICH!!



            //ReadAllText - zeigt das ganze Text
            string dateiContent = System.IO.File.ReadAllText(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\" + $"{dateiName}.txt");
            Console.WriteLine("Display my eingegebener Text:");
            Console.WriteLine($"Die Textdatei beinhaltet folgender Text: \n{dateiContent}");



            //Methode 3 via StreamWriter 
            //irgendwie der Datei erstellen als new StreamWriter, es braucht nur den pfad.
            using (StreamWriter datei = new StreamWriter(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\StreamWriterText.txt"))
            {
                foreach (string zeile in zeilenSchreiben)
                // hier ändern wir einfach ein bisschen die Logik um ein andere datei zu kriegen.
                // wir lesen { "hey", "ho", "Let´s", "go!!" };
                // und schreiben nur die die mit h starten, so hey und ho. es klappt
                {
                    if (zeile.StartsWith("h"))
                    {
                        datei.WriteLine(zeile);
                    }
                }
            }



            //--Ohne Überschreiben ???? BITTE ???
            // ----------------------------------OHNE ÜBERSCHREIBEN
            // WERTE oder Texte schreiben und einfach am Ende hinzufügen!!  Beim StreamWriter nach dem Pfad ein true hinzufügen. Es ist das append bool!!
            // append = true, automatisch am ende Erweitern,
            // append = false, einfach überschreiben (das ist das default wert wenn wir nur Pfad eingeben!!)!!

            using (StreamWriter datei = new StreamWriter(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\StreamWriterText.txt", true))
            {
                datei.WriteLine("Zusätzliche Zeile");
                datei.WriteLine("Zusätzliche Zeile noch eine");
                datei.WriteLine("Zusätzliche Zeile und noch eine...");
            }

            //ReadAllText
            string dateiContent3 = System.IO.File.ReadAllText(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\StreamWriterText.txt");
            Console.WriteLine("Display my eingegebener Text:");
            Console.WriteLine($"Die Textdatei beinhaltet folgender Text: \n{dateiContent3}");


            //// TEXTDATEIEN LESEN!!!!
            ////ReadAllText - zeigt das ganze Text
            //string text = System.IO.File.ReadAllText(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\textFile.txt");
            //Console.WriteLine("Via ReadAllText");
            //Console.WriteLine($"Die Textdatei beinhaltet folgender Text: \n{text}");
            //Console.WriteLine("\nEnde der Textdatei\n\n");

            ////ReadAllLines, zeigt jede einzelne Zeile (wenn wir via foreach alle Linien aufrufen)
            //string[]  zeilen = System.IO.File.ReadAllLines(@"C:\Users\Andres Redondo\source\repos\ErweiterteCSharpThemen\textFile.txt");
            //Console.WriteLine("Via ReadAllLines, foreach line loop (+Erw.keine Leelre Linie anzeigen):");
            //foreach (string line in zeilen)
            //{
            //    //kleine erweiterung um Leere Linien zu überspringen:
            //    if (line.Length>0)
            //    {
            //        Console.WriteLine(line);
            //    }
            //    //kein else, einfach weiterlesen
            //}
            //Console.WriteLine("\nEnde der Textdatei\n\n");



            Console.ReadKey();

        }
    }
}

