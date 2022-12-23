using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morse.Codigos;

namespace Morse
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Alfabeto_Morse am = new Alfabeto_Morse();
            am.Beep(text.Length, text);

            Console.ReadKey();
        }
    }
}
