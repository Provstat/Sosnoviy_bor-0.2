using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sosnoviy_bor
{
    class Sawmill
    {
        public int
            x,
            y;
        Image Im_Sawmill;
        MainWindow main;

        public Sawmill(MainWindow wind)
        {
            main = wind;
            Im_Sawmill = new Image();
            main.Canvas.Children.Add(Im_Sawmill);
        }
        public void Initialize()
        {
            main.Sawmills++;
            Canvas canvas = (Canvas)Im_Sawmill.Parent;
            main.G1.Indexes[x, y] = main.Canvas.Children.IndexOf(Im_Sawmill);
            Im_Sawmill.Height = 48;
            Im_Sawmill.Width = 48;
            Canvas.SetLeft(Im_Sawmill, x + 1);
            Canvas.SetTop(Im_Sawmill, y + 1);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Sawmill.png", UriKind.Relative);
            bi3.EndInit();
            Im_Sawmill.Stretch = Stretch.Fill;
            Im_Sawmill.Source = bi3;

            main.G1.Area[x, y] = (int)Sosnoviy_bor.Cells.Sawmill;
        }
    }
}
