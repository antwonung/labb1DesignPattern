using System;
using System.Collections.Generic;
using System.Text;

namespace labb1DesignPattern.Strategy
{
    public interface IStrategy
    {
        public string[,] SetGamePlan(int width,int height);
    }
}
