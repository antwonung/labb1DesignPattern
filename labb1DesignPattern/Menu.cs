using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace labb1DesignPattern
{
    public class Menu
    {
        public int SelectedIndex { get; set; }
        public string[] Options { get; set; }
        public string Prompt { get; set; }
        public Menu(string prompt, string[] options)
        {
            SelectedIndex = 0;
            Options = options;
            Prompt = prompt;
        }
        private void DisplayOtions()
        {
            Console.WriteLine(Prompt);
            Console.WriteLine("\t\t\tWelcome to battleships, what do u wanna do?");
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                
                if(i == SelectedIndex)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    ForegroundColor= ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                    
                }
                Console.WriteLine($"||{currentOption}||");
            }
            ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOtions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                if(keyPressed == ConsoleKey.DownArrow)
                {
                    if(SelectedIndex < 2)
                        SelectedIndex++;
                }
                else if(keyPressed == ConsoleKey.UpArrow)
                {
                    if(SelectedIndex > 0)
                        SelectedIndex--;
                }
            }
            while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
