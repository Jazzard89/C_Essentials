using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string naam;
            int getal;

            //Inlezen
            Console.Write("Geef een naam: ");
            naam = Console.ReadLine();
            Console.Write("Geef een getal: ");
            getal = int.Parse(Console.ReadLine());

            //Afdruk
            Console.WriteLine("Afdruk");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Naam: {naam}\t Getal: {getal}");
            Console.WriteLine("Druk op enter om af te sluiten...");
            Console.ReadLine();
        }
    }
}
