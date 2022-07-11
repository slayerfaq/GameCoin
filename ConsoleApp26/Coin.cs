using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Coin
    {
        public char DisplaySymbolOnMap { get; set; }
        public int[] CoordsOnMap { get; set; }

        public Coin(char SymbolOnMap, int[] Coords)
        {
            DisplaySymbolOnMap = SymbolOnMap;
            CoordsOnMap = Coords;
        }
    }
}
