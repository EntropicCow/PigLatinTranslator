using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator piglatin = new Translator();
            int quit = 0;
            while (quit == 0)
            {
                Console.WriteLine("Input your phrase(leave blank to quit):");
                string input = Console.ReadLine();
                if (input.Length > 0)
                {
                    Console.Clear();
                    Console.WriteLine("\"" + input + "\"" + " " + "in Pig Latin: \n\n");
                    Console.WriteLine(piglatin.translateWords(input) + " \n\n");
                }
                else
                {
                    quit = 1;
                }
            }
                
        }
    }
}
