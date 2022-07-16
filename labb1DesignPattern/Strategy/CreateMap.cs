using System;
using System.Collections.Generic;
using System.Text;

namespace labb1DesignPattern.Strategy
{
    public class CreateMap : IStrategy
    {
        public string[,] SetGamePlan(int width,int height)
        {
            string[,] playField = new string[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int y = 0; y < width; y++)
                {
                    playField[y, i] = "0";
                }
            }

            return playField;
        }
    }
}
