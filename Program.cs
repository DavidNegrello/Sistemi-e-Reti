using System;

namespace ConvertBinario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] bn= new bool[32];
            bool[] b = new bool[32];  //1=true,0=false    //array da 32 true o false
            int[] dp = new int[] { 10, 10, 10, 10 };
            //bool[]Decimale= Convert_Numero_Decimale_To_Binario(uint numero)
            //int[]DecimalePuntato= Convert_Numero_Decimale_To_Decimale_Puntato(uint numero)
            
            int decimale = Convert_Binario_To_Intero(b);
            int decimalePuntato = Convert_Decimale_Puntato_To_Intero(dp);
            int []BinDecimalePuntato = Convert_binario_to_decimalePuntato(bn);
            bool[] binario =Convert_Decimale_Puntato_To_Binario(dp);
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
        static int[] Convert_binario_to_decimalePuntato(bool[] bn)
        {
            int[] risulato = new int[2]; // Inizializziamo un array di 2 interi per la parte intera e la parte decimale
            int potenza = 31; // Iniziamo con 2^31 per la parte intera

            for (int i = 0; i < bn.Length; i++)
            {
                if (i == 16)
                {
                    potenza = -1; // Passiamo a 2^-1 per la parte decimale dopo 16 bit
                }

                if (bn[i])
                {
                    risulato[i / 16] += (int)Math.Pow(2, potenza); // Aggiungiamo il valore alla parte appropriata
                }

                potenza--;
            }

            return risulato;
        }
        static bool[] Convert_Decimale_Puntato_To_Binario(int[] dp)
        {
            int intera = dp[0];
            int decimale = dp[1];

            bool[] binario = new bool[32]; // Inizializziamo un array booleano di 32 elementi

            // Convertiamo la parte intera in binario
            for (int i = 31; i >= 16; i--)
            {
                binario[i] = (intera & (1 << (31 - i))) != 0;
            }

            // Convertiamo la parte decimale in binario
            for (int i = 15; i >= 0; i--)
            {
                binario[i] = (decimale & (1 << (15 - i))) != 0;
            }

            return binario;
        }
        static int[] Convert_Numero_Decimale_To_Decimale_Puntato(uint numero)
        {
            int[] numeroPuntato = new int[4];
            for (int i = numeroPuntato.Length - 1; i >= 0; i--)
            {
                numeroPuntato[i] = (int)(numero % 256);
                numero /= 256;
                if (numero < 0) // se numero divento < 0 significa che la conversione è finita
                {
                    break;
                }
            }
            return numeroPuntato;
        }
        static bool[] Convert_Numero_Decimale_To_Binario(uint numero)
        {
            bool[] bools = new bool[32];
            for (int i = bools.Length - 1; i >= 0; i--)
            {
                if (numero % 2 == 1)
                {
                    bools[i] = true;
                }
                numero /= 2;
                if (numero < 0)
                {
                    break;
                }
            }
            return bools;
        }
    }
}
