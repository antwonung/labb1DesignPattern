using labb1DesignPattern.Factory;
using labb1DesignPattern.Strategy;
using System;
using static System.Console;
namespace labb1DesignPattern
{
    //Design patterns som jag implementerat är:
    //Singelton,Factory Method,Strategy
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] playerMap;
            string[,] playerShoot;
            string[,] computerMap;
            string[,] computerShoot;

            //Factory Method
            TitleFactory factory = new ConcreteTitleFactory();
            ITitleFactory main = factory.GetTitleClass("MenuTitle");
            string prompt = main.GetTitle();

            ITitleFactory aboutobj = factory.GetTitleClass("AboutTitle");
            string aboutTitle = aboutobj.GetTitle();


 
            string[] options = {"Play","About","Exit" };
            int selectedIndex = 0;
            
            while (selectedIndex != 2)
            {
                Menu mainMenu = new Menu(prompt, options);
                selectedIndex = mainMenu.Run();
                if (selectedIndex == 0)
                {
                    //Singelton Method
                    PrepareGame obj = PrepareGame.getInstance();

                    //Strategy Method
                    obj.SetStrategy(new CreateMap());
                    playerMap = obj.GetCreatedMap();
                    playerShoot = obj.GetCreatedMap();
                    computerMap = obj.GetCreatedMap();
                    computerShoot = obj.GetCreatedMap();

                    //Place ships and play the game
                    PlaceShips(playerMap, computerMap);
                    PlayGame(playerMap, computerMap, playerShoot, computerShoot,prompt);
                }
                else if(selectedIndex == 1)
                {
                    About about = new About(aboutTitle);
                    about.AboutPage();
                }

            }

        }
        public static void PlayGame(string[,] plyrMap, string[,] cpuMap, string[,] playerShoot, string[,] cpuShoot,string title)
        {
            string prompt = title;
            Random rnd = new Random();
            bool hasSomeoneWin = false;
            while (hasSomeoneWin == false)
            
            {
                Console.Clear();
                DrawGamePlan(plyrMap, cpuMap, playerShoot, cpuShoot,prompt);
                Console.WriteLine("Where do u want to shoot? (enter column number)");
                int x = IntParse();
                Console.WriteLine("Where do u want to shoot? (enter row number)");
                int y = IntParse();
                playerShoot[x - 1, y - 1] = "B";
                cpuShoot[rnd.Next(8), rnd.Next(8)] = "B";

                if (HasPlayerWon(cpuMap,playerShoot)) 
                {
                    Console.Clear();
                    DrawGamePlan(plyrMap, cpuMap, playerShoot, cpuShoot,prompt);
                    Console.WriteLine("Player has won !!!!");
                    Console.ReadKey();
                    hasSomeoneWin = true;
                }
                else if (HasCpuWon(plyrMap, cpuShoot))
                {
                    Console.Clear();
                    DrawGamePlan(plyrMap,cpuMap,playerShoot,cpuShoot,prompt);
                    Console.WriteLine("CPU has won !!!");
                    Console.ReadKey();
                    hasSomeoneWin = true;
                }
                
            }
        }
     
        public static void PlaceShips(string[,] plyrMap, string[,] cpuMap)
        {
            
            int x = 0, y = 1,counter = 0;
            int wCordinate = 0, hCordinate = 0,wCordinateSecond = 0,hCordinateSecond = 0;
            Random rnd = new Random();
            

            while (counter < 2)
            {
                Console.Clear();
                for (int i = 0; i < plyrMap.GetLength(0); i++)
                {
 
                    for (int d = 0; d < plyrMap.GetLength(1); d++)
                    {
                    
                        
                        Console.Write(plyrMap[d, i]);


                    }
                    Console.WriteLine();

                }
                Console.WriteLine("Where do u want to place ur ships? (X, enter column number)");
                x = IntParse();
                Console.WriteLine("Enter Row number(Y):");
                y = IntParse();
                plyrMap[x - 1,y - 1 ] = "X";
                counter++;
            }

          
            while(wCordinate == wCordinateSecond || hCordinate == hCordinateSecond)
            {
                wCordinate = rnd.Next(8);
                hCordinate = rnd.Next(8);
                wCordinateSecond = rnd.Next(8);
                hCordinateSecond = rnd.Next(8);
            }
            cpuMap[wCordinate, hCordinate] = "X";
            cpuMap[wCordinateSecond, hCordinateSecond] = "X";
        }
        public static bool HasPlayerWon(string[,] cpuMap,string[,] playerShoot)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (cpuMap[y,i] == "X" && playerShoot[y,i] == "0")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool HasCpuWon(string[,] playerMap, string[,] cpuShoot)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (playerMap[y, i] == "X" && cpuShoot[y, i] == "0")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static int IntParse()
        {
            int number = 0;
            while(int.TryParse(Console.ReadLine(), out number) == false || number > 8 || number < 1)
            {
                Console.WriteLine("Wrong input, either u didnt enter a number or u did enter wrong column or row number.. try again!");
            }
            return number;

        }
        public static void DrawGamePlan(string[,]plyrMap,string[,] cpuMap,string[,] playerShoot,string[,] cpuShoot,string prompt)
        {

            Console.WriteLine(prompt);
            Console.WriteLine("Players Map \t Computers Map");
                for (int i = 0; i < plyrMap.GetLength(0); i++)
                {
                    for (int y = 0; y < plyrMap.GetLength(1); y++)
                    {
                        if (cpuShoot[y, i] == "B")
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(plyrMap[y, i]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(plyrMap[y, i]);
                            
                        }
                    }

                    Console.Write("\t");
                    for(int x = 0; x < cpuMap.GetLength(1); x++)
                    {
                        if (playerShoot[x, i] == "B")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(cpuMap[x, i]);
                        }
                        else
                        {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("-");
                            
                        }

                    
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }

        }
       
    }
}
