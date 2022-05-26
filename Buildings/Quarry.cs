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
    class Quarry
    {
        public int
            x,
            y;
        Image Im_Quarry;
        MainWindow main;

        public Quarry(MainWindow wind)
        {
            main = wind;
            Im_Quarry = new Image();
            main.Canvas.Children.Add(Im_Quarry);
        }
        public void Initialize()
        {
            main.Quarrys++;
            Canvas canvas = (Canvas)Im_Quarry.Parent;
            main.G1.Indexes[x, y] = main.Canvas.Children.IndexOf(Im_Quarry);
            Im_Quarry.Height = 48;
            Im_Quarry.Width = 48;
            Canvas.SetLeft(Im_Quarry, x + 1);
            Canvas.SetTop(Im_Quarry, y + 1);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Quarry.png", UriKind.Relative);
            bi3.EndInit();
            Im_Quarry.Stretch = Stretch.Fill;
            Im_Quarry.Source = bi3;
            main.G1.Area[x, y] = (int)Sosnoviy_bor.Cells.Quarry;
        }
    }
}

