using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Map
    {
        public string NameMap { get; set; }
        public int SizeMap { get; set; }
        public char DisplaySymbolMap { get; set; }
        public char[,] Fields { get; set; }
        PlayerPerson Player { get; set; }
        List<Coin> Coins { get; set; }
        public int CountOfCoins { get; set; }

        public Map(string Name, int Size, char SymbolMap, PlayerPerson PlayerPerson, List<Coin> CoinsList)
        {
            NameMap = Name;
            SizeMap = Size;
            DisplaySymbolMap = SymbolMap;
            Player = PlayerPerson;
            Coins = CoinsList;
            CountOfCoins = CoinsList.Count;

            Fields = GenerateMap(SizeMap, DisplaySymbolMap);
        }

        public char[,] GenerateMap(int SizeMap, char SymbolMap)
        {
            char[,] NewMapFields = new char[SizeMap, SizeMap];
            for (int i = 0; i < SizeMap; ++i)
            {
                for (int j = 0; j < SizeMap; ++j)
                {
                    NewMapFields[i, j] = DisplaySymbolMap;
                }
            }

            return NewMapFields;
        }

        public void DrawMap()
        {
            Console.WriteLine();
            for (int i = 0; i < SizeMap; ++i)
            {
                for (int j = 0; j < SizeMap; ++j)
                {
                    Console.Write($"{Fields[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void ReDrawMap(int dx, int dy)
        {
            ClearScreen();
            SetPlayerOnMap(dx, dy);
            DrawMap();
        }

        public void SetPlayerOnMap()
        {
            Fields[Player.CoordsOnMap[0], Player.CoordsOnMap[1]] = Player.DisplaySymbolOnMap;
        }

        public void SetPlayerOnMap(int dx, int dy)
        {
            int initial_X = Player.CoordsOnMap[0], initial_Y = Player.CoordsOnMap[1];
            Fields[initial_X, initial_Y] = Player.TracePlayer;

            int player_coords_dx = initial_X + dx;
            int player_coords_dy = initial_Y + dy;

            if ((player_coords_dx > SizeMap - 1) || (player_coords_dy > SizeMap - 1) 
                || (player_coords_dx < 0) || (player_coords_dy < 0))
            {
                Fields[initial_X, initial_Y] = Player.DisplaySymbolOnMap;
                return;
            }

            if (Fields[player_coords_dx, player_coords_dy] == '+') Player.Wallet++;

            Fields[player_coords_dx, player_coords_dy] = Player.DisplaySymbolOnMap;
            Player.CoordsOnMap = new int[] { player_coords_dx, player_coords_dy };
        }

        public void SetCoinsOnMap()
        {
            foreach(var coin in Coins)
            {
                Fields[coin.CoordsOnMap[0], coin.CoordsOnMap[1]] = coin.DisplaySymbolOnMap;
            }
        }
    }
}
