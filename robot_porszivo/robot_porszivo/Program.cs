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

           
            do
            {
                koszSzam = 0;
                szabadSzam = 0;
            
                for (int i = 0; i < sorSzam; i++)
                {
                    for (int j = 0; j < oszlopSzam; j++)
                    {
                        int r = veletlen.Next(100);
            
                        if (r < 50)
                            lakas[i, j] = '-';
                        else if (r < 70)
                            lakas[i, j] = 'b';
                        else
                            lakas[i, j] = 'k';
            
                        if (lakas[i, j] == '-') szabadSzam++;
                        if (lakas[i, j] == 'k') koszSzam++;
                    }
                }
            }
            while (szabadSzam == 0 || koszSzam == 0);

             
             int robotSor, robotOszl;
             do
             {
                 robotSor = veletlen.Next(sorSzam);
                 robotOszl = veletlen.Next(oszlopSzam);
             }
             while (lakas[robotSor, robotOszl] != '-');
            
             lakas[robotSor, robotOszl] = 'r';

             
             Console.WriteLine("\nTAKARITAS ELOTT:");
             Kiir(lakas);
            
             int lepesSzam = 0;
             int tisztitottDb = 0;
             
             while (koszSzam > 0)
             {
                 int irany = veletlen.Next(4);
                 int ujSor = robotSor;
                 int ujOszl = robotOszl;
            
                 if (irany == 0) ujSor--; // fel
                 if (irany == 1) ujSor++; // le
                 if (irany == 2) ujOszl--; // bal
                 if (irany == 3) ujOszl++; // jobb
            
                 if (ujSor < 0 || ujOszl < 0 ||
                     ujSor >= sorSzam || ujOszl >= oszlopSzam)
                     continue;
            
                 if (lakas[ujSor, ujOszl] == 'b')
                     continue;
            
                 lakas[robotSor, robotOszl] = '-';
                 robotSor = ujSor;
                 robotOszl = ujOszl;
            
                 if (lakas[robotSor, robotOszl] == 'k')
                 {
                     tisztitottDb++;
                     koszSzam--;
                 }
            
                 lakas[robotSor, robotOszl] = 'r';
                 lepesSzam++;
             }
             
                 lakas[robotSor, robotOszl] = '-';
                 Console.WriteLine("\nTAKARITAS UTAN:");
                     Kiir(lakas);

                
                    Console.WriteLine("\nSTATISZTIKA:");
                    Console.WriteLine("Lepesek szama: " + lepesSzam);
                    Console.WriteLine("Feltakaritott kosz: " + tisztitottDb);
                }
                    static void Kiir(char[,] lakas)
            {
                for (int i = 0; i < lakas.GetLength(0); i++)
                {
                    for (int j = 0; j < lakas.GetLength(1); j++)
                    {
                        Console.Write(lakas[i, j] + " ");
                    }
                    Console.WriteLine();
            }
        }
    }
}








