using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variabele aanmaken
            int[] getallen = new int[3];


            ////////////////versie 1////////////////////////////////////////////


            Console.WriteLine("===Som bepalen van 3 getalen ===");
            Console.WriteLine("Geef getal 1/3 : ");
            getallen[0] = int.Parse(Console.ReadLine());

            Console.WriteLine("Geef getal 2/3 : ");
            getallen[1] = int.Parse(Console.ReadLine());

            Console.WriteLine("Geef getal 3/3 : ");
            getallen[2] = int.Parse(Console.ReadLine());


            
            int som = getallen[0] + getallen[1] + getallen[2];

            Console.WriteLine($"De Som is {som} ");
            Console.ReadLine();

            /////////////////////versie 2///////////////////////////////////////////
            

            int som = 0;
            Console.WriteLine("===Som bepalen van 3 getalen ===");
  

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Geef getal {i + 1}/3 : ");
                getallen[i] = int.Parse(Console.ReadLine());
                som += getallen[i];
            }

            Console.WriteLine($"De Som is {som}");
            Console.Read();


        }
    }
}
