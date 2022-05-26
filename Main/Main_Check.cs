using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sosnoviy_bor
{
    public partial class MainWindow : Window
    {
        public void Player_Pos_Check ()
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
