using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Sosnoviy_bor
{
    public class Player
    {
        public int
            x = 450,
            y = 400;
        public int
            HP = 100000,
            hungry = 100000,
            Bullets = 1,
            Dmg = 1,
            Coin = 0,
            Stone = 0,
            Wood = 0,
            dmg_tick = 0,
            Score = 0;
        bool get_dmg = false;
        MainWindow main;
        Image Im_Player;
        DispatcherTimer mS_timer;
        public Player(MainWindow wind)
        {
            main = wind;
            Im_Player = new Image();
            main.Canvas.Children.Add(Im_Player);
            mS_timer = new DispatcherTimer();
            mS_timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            mS_timer.Tick += new EventHandler(mS_timer_Tick);
        }
        public void Initialize()
        {
            Canvas canvas = (Canvas)Im_Player.Parent;
            main.G1.Indexes[x, y] = main.Canvas.Children.IndexOf(Im_Player);
            Im_Player.Height = 52;
            Im_Player.Width = 52;
            Canvas.SetLeft(Im_Player, x - 1);
            Canvas.SetTop(Im_Player, y - 1);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("ghost.png", UriKind.Relative);
            bi3.EndInit();
            Im_Player.Stretch = Stretch.Fill;
            Im_Player.Source = bi3;
            mS_timer.Start();
        }
        public void Pos_Check()
        {
            Canvas.SetLeft(Im_Player, x - 1);
            Canvas.SetTop(Im_Player, y - 1);
            main.G1.Player[x, y] = true;
        }
        public void Player_UP()
        {
            if (y != 0)
            {
                main.G1.Player[x, y] = false;
                y -= 50;
                main.Player_Pos_Check();
            }
        }
        public void Player_Down()
        {
            if (y != 650)
            {
                main.G1.Player[x, y] = false;
                y += 50;
                main.Player_Pos_Check();
            }
        }
        public void Player_Right()
        {
            if (x != 950)
            {
                main.G1.Player[x, y] = false;
                x += 50;
                main.Player_Pos_Check();
            }
        }
        public void Player_Left()
        {
            if (x != 0)
            {
                main.G1.Player[x, y] = false;
                x -= 50;
                main.Player_Pos_Check();
            }
        }
        public void Damage(int dmg)
        {
            if (HP >= dmg)
            {
                HP -= dmg;
            }
            else
            {
                HP = 0;
                main.Player_Stats_Check();
                main.Canvas.Children.Remove(Im_Player);
                main.Tstop();
            }


        }
        public void Hungry()
        {
            if (hungry != 0)
            {
                hungry -= 5;
            }
            else
            {
                Damage(100);
            }
            main.Player_Stats_Check();
        }
        public void Eating()
        {
            if (x == main.G1.BerX && y == main.G1.BerY)
            {
                main.G1.HaveBerry = false;
                main.Berry.Visibility = Visibility.Hidden;
                main.BerNum = 0;
                if (hungry <= 80000)
                    hungry += 20000;
                else
                    hungry = 100000;
                main.Player_Stats_Check();
                Score++;
            }
        }
        public void Sleep()
        {
            if (HP <= 80000 && hungry > 20000)
            {
                HP += 20000;
                hungry -= 20000;
                main.Player_Stats_Check();
            }
            else
            {
                HP = 100000;
            }


        }
        public void Shoot()
        {
            if (Bullets > 0)
            {
                Bullets--;
                _1LVL_Bullet bullet = new _1LVL_Bullet(main);
                bullet.x = x + 25;
                bullet.y = y + 25;
                bullet.Initialize();
                bullet.Bullet_Life();
            }
        }
        void mS_timer_Tick(object sender, EventArgs e)
        {
            if (main.G1.Bullets[x, y] == (int)Sosnoviy_bor.Shells._1LVL_Enemy)
            {
                get_dmg = true;
                Damage((int)Sosnoviy_bor.Shells._1LVL_Enemy);
                main.G1.Bullets[x, y] = (int)Sosnoviy_bor.Shells.Null;
            }
            if (get_dmg)
            {
                dmg_tick++;
                if (dmg_tick >= 5)
                {
                    get_dmg = false;
                    dmg_tick = 0;
                }
            }

        }
    }
}
