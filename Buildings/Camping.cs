using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sosnoviy_bor
{
    public class Camping
    {
        public int
            x,
            y;
        Image Im_Camp;
        MainWindow main;

        public Camping(MainWindow wind)
        {
            main = wind;
            Im_Camp = new Image();
            main.Canvas.Children.Add(Im_Camp);
            main.P1.Bullets++;
        }
        public void Initialize()
        {
            Canvas canvas = (Canvas)Im_Camp.Parent;
            main.G1.Indexes[x, y] = main.Canvas.Children.IndexOf(Im_Camp);
            Im_Camp.Height = 48;
            Im_Camp.Width = 48;
            Canvas.SetLeft(Im_Camp, x + 1);
            Canvas.SetTop(Im_Camp, y + 1);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Camp.png", UriKind.Relative);
            bi3.EndInit();
            Im_Camp.Stretch = Stretch.Fill;
            Im_Camp.Source = bi3;
            Im_Camp.MouseDown += Camp_Click;
            main.G1.Area[x, y] = (int)Sosnoviy_bor.Cells.Camp;
        }
        public void Camp_Click(object s, MouseEventArgs e)
        {
            if (main.P1.x == x && main.P1.y == y)
            {
                main.progress = 0;
                main.Progress.Value = 0;
                main.B_Mine.IsEnabled = false;
                main.B_Remove.IsEnabled = false;
                main.processes = Processes.Sleep;
                main.Progressing = true;
            }
        }
    }
}
