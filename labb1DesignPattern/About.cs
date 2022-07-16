using System;
using System.Collections.Generic;
using System.Text;

namespace labb1DesignPattern
{
    public class About
    {
        public string aboutTitle { get; set; }

        public About(string title)
        {
           aboutTitle = title;
        }

        public void AboutPage()
        {
            Console.Clear();
            Console.WriteLine(aboutTitle);
            Console.WriteLine("\t\t\tInfo about battleships:");
            Console.WriteLine();
            Console.WriteLine("\t\t\tBattleships is a war-themed board game for two players");
            Console.WriteLine("\t\t\tin which the opponent try to guess the location of their");
            Console.WriteLine("\t\t\topponents warships and sink them, in this game the computers ships.");
            Console.WriteLine("\t\t\tIn the beginning of the game u get the chance to choose where");
            Console.WriteLine("\t\t\tto hide your ships. The ships is marked by an X. You have");
            Console.WriteLine("\t\t\ttwo ships available to hide, and computer also.");
            Console.WriteLine();
            Console.WriteLine("\t\t\tAfter that you are ready to bomb the computers ships. ");
            Console.WriteLine("\t\t\tchoose column number and row number u want to bomb.");
            Console.WriteLine("\t\t\tAnd try to hit computers ships before the computer");
            Console.WriteLine("\t\t\tbomb yours, good luck and have fun :)");
            Console.WriteLine("\t\t\tPress any key to get back to menu.");
            Console.ReadKey();
        }
    }
}
