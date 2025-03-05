using System;
using System.Diagnostics;

namespace PdfGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
         Console.WriteLine("Välj stil");
         Console.WriteLine("[1] Modern");
         Console.WriteLine("[2] Playful");
         Console.WriteLine("[3] Black and white");
         string ans = Console.ReadLine();
         string inputHtmlFile;

         switch (ans)
         {
          case "1": {
            inputHtmlFile = "modern.html";
            break;
          }
          case "2": {
            inputHtmlFile = "playful.html";
            break;
          }
          case "3": {
            inputHtmlFile = "blackwhite.html";
            break;
          }

          default: {
            inputHtmlFile = "input.html";
            break;
          }
         }
            string outputPdfFile = "output.pdf";  // Ange filen att spara som PDF

            // Ange sökvägen till wkhtmltopdf-binären
            string wkhtmltopdfPath = @"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe";  // Sätt rätt sökväg här

            // Skapa en ProcessStartInfo för att köra wkhtmltopdf
            var startInfo = new ProcessStartInfo()
            {
                FileName = wkhtmltopdfPath,
                Arguments = $"{inputHtmlFile} {outputPdfFile}",  // Ange argumenten för konverteringen
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            // Starta processen och fånga eventuella fel
            using (var process = Process.Start(startInfo))
            {
                string output = process!.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // Skriv ut utmatning eller fel
                Console.WriteLine(output);
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Fel: " + error);
                }
            }

            Console.WriteLine("PDF skapad!");
        }
    }
}
