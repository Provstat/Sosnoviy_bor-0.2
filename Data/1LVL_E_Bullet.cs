using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Sosnoviy_bor
{
    class _1LVL_E_Bullet
    {
        MainWindow main;
        Familliar owner;
        DispatcherTimer mS_timer;
        private int
            damage = 1,
            mS_timer_tick;

        public double
            x,
            y;
        public double
                XTarget,
                YTarget,
                X_Side,
                Y_Side,
                X_Change,
                Y_Change;
        Image Im_Bullet;

        public _1LVL_E_Bullet(MainWindow wind, Familliar fam)
        {
            main = wind;
            owner = fam;
            Im_Bullet = new Image();
            main.Canvas.Children.Add(Im_Bullet);
            mS_timer = new DispatcherTimer();
            mS_timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            mS_timer.Tick += new EventHandler(mS_timer_Tick);
        }
        public void Initialize()
        {
            Canvas canvas = (Canvas)Im_Bullet.Parent;
            main.G1.Indexes[(int)(x - 1) / 50, (int)(y - 1) / 50] = main.Canvas.Children.IndexOf(Im_Bullet);
            Im_Bullet.Height = 16;
            Im_Bullet.Width = 16;
            Canvas.SetLeft(Im_Bullet, x * 50 + 25);
            Canvas.SetTop(Im_Bullet, y * 50 + 25);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("1LVL_E_Bullet.png", UriKind.Relative);
            bi3.EndInit();
            Im_Bullet.Stretch = Stretch.Fill;
            Im_Bullet.Source = bi3;
        }
        public void Bullet_Life()
        {
            XTarget = main.P1.x;
            YTarget = main.P1.y;
            X_Side = Math.Abs(x - XTarget);
            Y_Side = Math.Abs(y - YTarget);
            if (X_Side != 0)
                X_Change = 5 * X_Side / Math.Sqrt(X_Side * X_Side + Y_Side * Y_Side) * X_Side / (x - XTarget);
            if (Y_Side != 0)
                Y_Change = 5 * Y_Side / Math.Sqrt(X_Side * X_Side + Y_Side * Y_Side) * Y_Side / (y - YTarget);
            mS_timer.Start();
        }
        public void Target_Check()
        {
            for (int i = (int)x - 49; i <= x + 49; i++)
            {
                for (int j = (int)y - 49; j <= y + 49; j++)
                {
                    if (j >= 700 || j <= 0 || i >= 1000 || i <= 0)
                    {
                        break;
                    }
                    if (main.G1.Player[(int)i, (int)j] == true)
                    {
                        owner.Bullets++;
                        main.G1.Bullets[(int)i, (int)j] = (int)Sosnoviy_bor.Shells._1LVL_Enemy;
                        main.Canvas.Children.Remove(Im_Bullet);
                        mS_timer.Stop();
                    }
                }

            }
        }
        void mS_timer_Tick(object sender, EventArgs e)
        {

            mS_timer_tick++;
            x -= X_Change;
            y -= Y_Change;
            Canvas.SetLeft(Im_Bullet, x);
            Canvas.SetTop(Im_Bullet, y);
            if (mS_timer_tick == 200 || x >= 990 || x <= 10 || y >= 690 || y <= 10)
            {
                owner.Bullets++;
                main.Canvas.Children.Remove(Im_Bullet);
                mS_timer.Stop();
            }
            Target_Check();
        }
    }
}
