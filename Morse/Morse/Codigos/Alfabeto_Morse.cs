using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Morse.Codigos
{
    class Alfabeto_Morse
    {
        public int[] Tempo_beep { get; set; }
        private string[] Morse { get; set; }
        private string[] My { get; set; }

        private Dictionary<string, string> Alfabeto = new Dictionary<string, string>()
        {
            {"a","._" },{"b","_..."},{"c","_._."},{"d","_.."},{"e","."},{"f",".._."},
            {"g","__."},{"h","...."},{"i",".."},{"j",".___"},{"k","_._"},
            {"l","._.."},{"m","__"},{"n","_."},{"o","___"},{"p",".__."},
            {"q","__._"},{"r","._."},{"s","..."},{"t","_"},{"u",".._"},
            {"v","..._"},{"w",".__"},{"x","_.._"},{"y","_.__"},{"z","__.." },
            {"0","_____" },{"1",".____"},{"2","..___" },{"3","...--"},{"4","...._" },
            {"5","......"},{"6","_...." },{"7","__..."},{"8","___.." },{"9","____."},
            {".","._._._" },{",","__..__"},{"?","..__.."},{" ", " "}
        };

        private string[] Metodo(int tamanho,string text)
        {
            string[] My = new string[tamanho];
            int i = 0;
            
            foreach (var item2 in text)
            {                
                foreach (var item in Alfabeto)
                {
                    if (item2.ToString().Equals(item.Key))
                    {
                        My[i] = item.Value;
                        i++;
                    }
                }
            }
                        
            this.My = My;
            return this.My;
        }

        private string[] Return(int tamanho,string text)
        {
            string[] Morse = new string[tamanho];
            int i = 0;
            foreach (string item in Metodo(tamanho,text))
            {
                Console.Write(item);
                Morse[i] = item;
                i++;
            }
            this.Morse = Morse;
            return this.Morse;
        }

        private char[] ConversorCharArray(int tamanho, string text)
        {
            string[] morse = Return(tamanho, text);

            int cont = 0;
            foreach (var item in morse)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    cont++;
                }
            }
            char[] array = new char[cont];
            int iv = 0;
            foreach (var item in morse)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    array[iv] = item[i];
                    iv++;
                }
            }

            return array;
        }

        private int[] ConversorParaSom(int tamanho,string text)
        {            
            int i = 0;
            char[] array = ConversorCharArray(tamanho, text);
            int[] tempo_beep = new int[array.Length];

            foreach (var item in array )
            {
                if (item.Equals('.'))
                {
                    tempo_beep[i] = 150;
                }
                else if(item.Equals('_'))
                {
                    tempo_beep[i] = 500;
                }
                else
                {
                    tempo_beep[i] = 2000;
                }
                i++;
            }
            this.Tempo_beep = tempo_beep;
            return this.Tempo_beep;
        }

        public void Beep(int tamanho,string text)
        {
            foreach (var item in ConversorParaSom(tamanho,text))
            {
                Thread.Sleep(500);
                Console.Beep(400,item);
            }
        }
    }
}
