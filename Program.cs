using System;

namespace ConvertBinario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] b = new bool[32];  //1=true,0=false    //array da 32 true o false
            int[] dp = new int[] { 10, 10, 10, 10 };
            int decimale = Convert_Binario_To_Intero(b);
            int decimalePuntato = Convert_Decimale_Puntato_To_Intero(dp);
            Console.WriteLine(decimale);
            Console.WriteLine(decimalePuntato);
            Console.ReadLine();
        }
        static int Convert_Binario_To_Intero(bool[] b)
        {
            int decimale = 0;
            int potenza = 1; // Inizia con 2^0
            for (int i = b.Length - 1; i >= 0; i--) //parte dalla fine dell'array e fa i calcoli
            {
                if (b[i])   //entra solo se il valore nell'array bool "b" è true
                {
                    decimale = decimale + potenza;
                }
                potenza = potenza * 2; // Calcola la potenza di 2 
            }
            return decimale;
        }
        static int Convert_Decimale_Puntato_To_Intero(int[] dp) //array di 4 cifre
        {
            int decimalePuntato = 0, potenza = 0, decimaleBase = 256;
            for (int i = dp.Length-1; i >= 0; i--) //parte dalla fine dell'array 
            {
                decimalePuntato =decimalePuntato+ dp[i] * (int)Math.Pow(decimaleBase, potenza); //prende il valore di "decimalePuntato" e lo somma al calcolo dato dal valore nell'array moltiplicato alla base 256 elevato alla potenza
                potenza++;  //viene sommato 1
            }
            return decimalePuntato;
        }
    }
}
