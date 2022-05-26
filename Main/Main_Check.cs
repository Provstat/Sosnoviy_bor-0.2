using System.Windows;

namespace Sosnoviy_bor
{
    public partial class MainWindow : Window
    {
        public void Player_Pos_Check()
        {
            P1.Pos_Check();
        }
        public void Player_Stats_Check()
        {
            Hunger_BAR.Value = P1.hungry;
            HP_BAR.Value = P1.HP;
        }
        public void Player_Resourses_Check()
        {
            L_Wood.Content = P1.Wood;
            L_Stone.Content = P1.Stone;
            L_Coin.Content = P1.Coin;
        }
    }
}
