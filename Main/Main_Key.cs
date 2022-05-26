using System.Windows.Input;

namespace Sosnoviy_bor
{
    public partial class MainWindow
    {
        private void Main_Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (Progressing == false)
            {
                if (e.Key == Key.W)
                {
                    P1.Player_UP();
                }
                if (e.Key == Key.A)
                {
                    P1.Player_Left();
                }
                if (e.Key == Key.S)
                {
                    P1.Player_Down();

                }
                if (e.Key == Key.D)
                {
                    P1.Player_Right();
                }
            }
            P1.Eating();
        }
        private void Main_Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (press_start)
            {
                P1.Shoot();
            }
        }
    }
}
