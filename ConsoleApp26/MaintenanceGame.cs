using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    static class MaintenanceGame
    {
        static public void RunGame()
        {
            PlayerPerson Player = GenerateGameObject.GeneratePlayer();
            Player.PrintAllStat();

            int SizeMap = 4;
            Map map = new Map("Болото", SizeMap, '-', Player, GenerateGameObject.GenerateCoins(SizeMap));
            map.SetPlayerOnMap();
            map.SetCoinsOnMap();
            map.DrawMap();
            //GenerateGameObject.Test();

            HelperCommand.GetCommandsControl();

            char action;
            do
            {
                action = Console.ReadKey().KeyChar;
                if (action == 'q') { Console.Clear(); break; } // Для выхода из программы
                switch (action)
                {
                    case 'w': { map.ReDrawMap(-1, 0); break; }
                    case 'a': { map.ReDrawMap(0, -1); break; }
                    case 's': { map.ReDrawMap(1, 0); break; }
                    case 'd': { map.ReDrawMap(0, 1); break; }
                    case 'p': { Player.PrintAllStat(); break; }
                    case 'h': { HelperCommand.GetCommandsControl(); break; }
                    default: { Console.WriteLine(" -> Такой команды нет. Введите другую."); break; }
                }
            } while (Player.Wallet < map.CountOfCoins);

            Console.WriteLine($"Игра окончена!\r\nВаш счет: {Player.Wallet}");
        }
    }
}
