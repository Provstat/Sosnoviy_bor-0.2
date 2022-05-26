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
            P1.Shoot();
        }
    }
}
