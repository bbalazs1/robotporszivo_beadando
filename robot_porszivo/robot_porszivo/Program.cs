using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot_porszivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random veletlen = new Random();

            int sorSzam, oszlopSzam;
        
            do
            {
                Console.Write("Sorok szama (20-30): ");
                sorSzam = int.Parse(Console.ReadLine());
                Console.Write("Oszlopok szama (20-30): ");
                oszlopSzam = int.Parse(Console.ReadLine());
            }
            while (sorSzam < 20 || sorSzam > 30 ||
                   oszlopSzam < 20 || oszlopSzam > 30 ||
                   sorSzam == oszlopSzam);
            
            char[,] lakas = new char[sorSzam, oszlopSzam];
            
            int koszSzam = 0;
            int szabadSzam = 0;
        }
    }
}

