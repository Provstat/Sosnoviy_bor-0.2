using System;

namespace Sosnoviy_bor
{
    public enum Cells : int
    {
        Null,
        Enemy,
        Player,
        Berry,
        Camp,
        Sawmill,
        Quarry,
        Obelisk,
    }
    public enum Shells
    {
        Null = 0,
        _1LVL_Player = 1,
        _1LVL_Enemy = 10000,
    }
    public class GameArea
    {
        public bool
            HaveBerry = false;
        public int
            BerX = 0,
            BerY = 0,
            free_indexes = 20;
        MainWindow main;
        public GameArea(MainWindow wind)
        {
            main = wind;
        }
        Random rnd = new Random();
        public int[,] Area = new int[1001, 700];
        public int[,] Indexes = new int[1001, 700];
        public int[,] Bullets = new int[1001, 700];
        public bool[,] Player = new bool[1001, 700];



    }
}
