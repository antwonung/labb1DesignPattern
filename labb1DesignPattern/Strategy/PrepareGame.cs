using labb1DesignPattern.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace labb1DesignPattern
{
    public class PrepareGame
    {
        private IStrategy _strategy;

        static int mapWidth = 8;
        static int mapHeight = 8;
        public string[,] createdMap = new string[mapWidth,mapHeight];
        public string[,] computersField = new string[mapWidth, mapHeight];
        public string[,] playersShoot = new string[mapWidth, mapHeight];
        public string[,] computersShoot = new string[mapWidth, mapHeight];
        
        
        private static PrepareGame instance = null;
        private PrepareGame() { }
        public PrepareGame(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public static PrepareGame getInstance()
        {
            if (instance == null)
                instance = new PrepareGame();
            return instance;
            
        }
        public string [,] GetCreatedMap()
        {
            createdMap = this._strategy.SetGamePlan(mapWidth, mapHeight);
            return createdMap;
        }


     

    }

}
