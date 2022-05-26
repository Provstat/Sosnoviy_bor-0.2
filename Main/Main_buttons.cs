using System.Windows;

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
