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
    public class Familliar
    {
        public int
           x,
           y,
           HP,
           Bullets = 2,
           dmg_tick = 0,
           Shoot_tick = 0,
           mS_timer_tick;
        bool get_dmg = false;
        Image Im_Familliar;
        MainWindow main;
        DispatcherTimer mS_timer;

        public Familliar(MainWindow wind)
        {
            main = wind;
            Im_Familliar = new Image();
            main.Canvas.Children.Add(Im_Familliar);
            mS_timer = new DispatcherTimer();
            mS_timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            mS_timer.Tick += new EventHandler(mS_timer_Tick);
        }
        public void Initialize()
        {
            Canvas canvas = (Canvas)Im_Familliar.Parent;
            main.G1.Indexes[x, y] = main.Canvas.Children.IndexOf(Im_Familliar);
            Im_Familliar.Height = 48;
            Im_Familliar.Width = 48;
            Canvas.SetLeft(Im_Familliar, x + 1);
            Canvas.SetTop(Im_Familliar, y + 1);
            Set_PNG("Familliar.png");
            main.G1.Area[x, y] = (int)Sosnoviy_bor.Cells.Enemy;
            mS_timer.Start();
        }
        public void Shoot()
        {
            if (Bullets > 0)
            {
                Bullets--;
                _1LVL_E_Bullet bullet = new _1LVL_E_Bullet(main, this);
                bullet.x = x + 25;
                bullet.y = y + 25;
                bullet.Initialize();
                bullet.Bullet_Life();
            }
        }
        public void Get_Damage(int dmg)
        {
            if (HP >= dmg)
            {
                HP -= dmg;
                main.G1.Bullets[x, y] = (int)Sosnoviy_bor.Shells.Null;
            }
            else
            {
                main.G1.Area[x, y] = (int)Sosnoviy_bor.Cells.Null;
                main.Canvas.Children.Remove(Im_Familliar);
                mS_timer.Stop();
            }
        }
        public void Set_PNG(string Link)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(Link, UriKind.Relative);
            bi3.EndInit();
            Im_Familliar.Stretch = Stretch.Fill;
            Im_Familliar.Source = bi3;
        }
        void mS_timer_Tick(object sender, EventArgs e)
        {
            if (main.G1.Bullets[x, y] == (int)Sosnoviy_bor.Shells._1LVL_Player)
            {
                Set_PNG("Familliar_DMG.png");
                Get_Damage((int)Sosnoviy_bor.Shells._1LVL_Player);
                get_dmg = true;
            }
            if (get_dmg)
            {
                dmg_tick++;
                if (dmg_tick >= 5)
                {
                    Set_PNG("Familliar.png");
                    get_dmg = false;
                    dmg_tick = 0;
                }
            }
            if (Bullets > 0)
            {
                Shoot_tick++;
                if (Shoot_tick >= 20)
                {
                    Shoot();
                    Shoot_tick = 0;
                }
            }
            
        }
    }
}
