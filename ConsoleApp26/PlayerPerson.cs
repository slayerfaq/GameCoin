using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class PlayerPerson
    {
        public string NamePerson { get; set; }
        public char TracePlayer { get; set; }
        public int[] CoordsOnMap { get; set; }
        public int Wallet { get; set; }
        public char DisplaySymbolOnMap { get; set; }

        public PlayerPerson(string Name, char SymbolOnMap, int[] Coords, char Trace)
        {
            NamePerson = Name;
            DisplaySymbolOnMap = SymbolOnMap;
            CoordsOnMap = Coords;
            TracePlayer = Trace;
            Wallet = 0;
        }

        public void PrintAllStat()
        {
            Console.WriteLine($"Имя персонажа: {NamePerson}\r\nСлед персонажа: {TracePlayer}\r\nКоординаты персонажа [x, y]: [{CoordsOnMap[0]}, {CoordsOnMap[1]}]");
        }
    }
}
