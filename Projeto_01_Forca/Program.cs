
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_01_Forca
{
    class Program
    {
        static void Menu()
        {
            do
            {
                Jogar();
                Console.WriteLine("\nDeseja jogar mais? Y/N");
            }
            while (char.Parse(Console.ReadLine().ToUpper()) == 'Y');
            
            Environment.Exit(0);
        }
        static string[] Palavra()
        {
            string[] palavras = new string[3];

            Console.WriteLine("\t-->Jogo da Forca<--\n\t  ____\n\t  |  |\n\t  |\n\t__|__  _ _ _ _ _ \n");

            Console.WriteLine("Escolha sua categoria:" +
                "\n\t1 Para Frutas:" +
                "\n\t2 Para Carros:");


            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    palavras = new string[] { "LIMAO", "PERA", "UVA" };
                    break;
                case 2:
                    palavras = new string[] { "GOL", "FUSCA", "TORO" };
                    break;
            }

            return palavras;
        }
        static string Saida(string letraCerta, string letraErrada,int erros)
        {
           switch (erros)
           {
                case 1:
                    return "\t-- > Jogo da Forca<--\n\t _____\n\t |   |\n\t |   O\n      ___|    \t" + letraCerta + "\t\tErros: " + letraErrada + "\n";
                    break;
                case 2:
                    return "\t-- > Jogo da Forca<--\n\t _____\n\t |   |\n\t |   O\n      ___|   | \t" + letraCerta + "\t\tErros: " + letraErrada + "\n";
                    break;
                case 3:
                    return "\t-- > Jogo da Forca<--\n\t _____\n\t |   |\n\t |   O\n      ___|  /| \t" + letraCerta + "\t\tErros: " + letraErrada + "\n";
                    break;
                case 4:
                    return "\t-- > Jogo da Forca<--\n\t _____\n\t |   |\n\t |   O\n      ___|  /|\\\t" + letraCerta + "\t\tErros: " + letraErrada + "\n";
                    break;
                case 5:
                    return "\t-- > Jogo da Forca<--\n\t _____\n\t |   |\n\t |   O\n      ___|  /|\\\t" + letraCerta + "\t\tErros: " + letraErrada + "\n\t    /";
                    break;
                case 6:
                    return "\t-- > Jogo da Forca<--\n\t _____\n\t |   |\n\t |   O\n      ___|  /|\\\t" + letraCerta + "\t\tErros: " + letraErrada + "\n\t    / \\\n\tUltima chance!!!!!";
                    break;
                default:
                    return "\t-- > Jogo da Forca<--\n\t _____\n\t |   |\n\t |   \n      ___|    \t" + letraCerta + "\t\tErros: " + letraErrada + "\n";
                    break;
           }
           
        }
        static void Jogar()
        {
            Console.Clear();
            string[] palavras = Palavra();

            Random num = new Random();
            int sorteio = num.Next(3);

            char[] anonimo = new char[30];

            int erros = 0;

            string letraErrada ="" ,letraCerta ="", saida="";

            Console.Clear();

            for (int i = 0; i < palavras[sorteio].Length; i++)
            {
                anonimo[i] = '_';
            }

            while (anonimo.Contains('_')&& erros<7)
            {
                Console.Clear();


                letraCerta = "";

                for (int c = 0; c < 5; c++)
                {
                    letraCerta += anonimo[c]+" " ;
                }

                saida = Saida(letraCerta, letraErrada, erros);

                Console.WriteLine(saida);


                Console.WriteLine("\nDigite a palvra");

                char palavra = char.Parse(Console.ReadLine().ToUpper());

                int pos = palavras[sorteio].IndexOf(palavra);

                for (int r = 0; r < 5; r++)
                {
                        
                    if (pos != -1 && anonimo[pos] == '_')
                    {
                        anonimo[pos] = palavra;

                    }
                        

                }

               
                letraCerta = "";

                for (int c = 0; c < 5; c++)
                {
                    letraCerta += anonimo[c]+" ";
                }

                if (pos == -1)
                {
                    letraErrada += palavra + " ";
                    erros ++;
                }
                saida = Saida(letraCerta, letraErrada, erros);
            }

            Console.Clear();
                
            Console.WriteLine(saida);

            if (erros > 6)
            {
                Console.WriteLine("\tDefeat");
            }
            else
            {
                Console.WriteLine("\tVictory");
                
            }
        }

        public static void Main()
        {
            
            while(true)
            {
                Menu();
            }
            
        }

    }
}