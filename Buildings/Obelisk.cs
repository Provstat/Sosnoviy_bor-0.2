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
    class Obelisk
    {
        public int
            x,
            y;
        Image Im_Obelisk;
        MainWindow main;

        public Obelisk(MainWindow wind)
        {
            
            main = wind;
            Im_Obelisk = new Image();
            main.Canvas.Children.Add(Im_Obelisk);
            main.P1.Bullets++;
        }
        public void Initialize()
        {
            main.Obelisks++;
            Canvas canvas = (Canvas)Im_Obelisk.Parent;
            main.G1.Indexes[x, y] = main.Canvas.Children.IndexOf(Im_Obelisk);
            Im_Obelisk.Height = 48;
            Im_Obelisk.Width = 48;
            Canvas.SetLeft(Im_Obelisk, x + 1);
            Canvas.SetTop(Im_Obelisk, y + 1);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Obelisk.png", UriKind.Relative);
            bi3.EndInit();
            Im_Obelisk.Stretch = Stretch.Fill;
            Im_Obelisk.Source = bi3;
            main.G1.Area[x, y] = (int)Sosnoviy_bor.Cells.Obelisk;
        }
    }
}
