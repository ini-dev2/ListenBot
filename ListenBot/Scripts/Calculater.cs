using System;
using System.Collections.Generic;

namespace ListenBot.Scripts
{
    internal class Calculater
    {
        private double result;

        public double CalcResult(List<int> playersId)
        {
            result = 0;
            foreach (var id in playersId)
            {
                result += Math.Pow(2, id);
            }
            return result / 2;
        }
    }
}