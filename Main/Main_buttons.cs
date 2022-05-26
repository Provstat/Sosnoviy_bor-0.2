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
    public partial class MainWindow
    {
        private void B_Start_Click(object sender, RoutedEventArgs e)
        {
            B_Start_Action();
        }
        private void B_Lore_Click(object sender, RoutedEventArgs e)
        {
            B_Lore_Action();
        }
        private void B_Mine_Click(object sender, RoutedEventArgs e)
        {
            B_Mine_Action();
        }
        private void B_Build_Click(object sender, RoutedEventArgs e)
        {
            B_Build_Action();
        }
        private void B_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (G1.Area[P1.x, P1.y] == (int)Sosnoviy_bor.Cells.Camp)
            {
                B_Remove_Camp_Action();
            }
            if (G1.Area[P1.x, P1.y] == (int)Sosnoviy_bor.Cells.Sawmill)
            {
                B_Remove_Sawmill_Action();
            }
            if (G1.Area[P1.x, P1.y] == (int)Sosnoviy_bor.Cells.Quarry)
            {
                B_Remove_Quarry_Action();
            }
            if (G1.Area[P1.x, P1.y] == (int)Sosnoviy_bor.Cells.Obelisk)
            {
                B_Remove_Obelisk_Action();
            }
        }

    }
}
