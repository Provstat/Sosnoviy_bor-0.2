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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public enum Processes : int
    {
        None,
        Mine,
        Sleep,

        B_Camp,
        R_Camp,

        B_Sawmill,
        R_Sawmill,

        B_Quarry,
        R_Quarry,

        B_Obelisk,
        R_Obelisk,
    }
    public partial class MainWindow : Window
    {
        public Player P1;
        public GameArea G1;
        Random rnd;
        DispatcherTimer mS_timer;
        public Processes processes;
        public int
            W_Ob_price = 10,
            S_Ob_price = 10,
            C_Ob_price = 20;
        public int
            progress = 0,
            sudden = 0,
            income = 0,
            Barrys = 0,
            Sawmills = 0,
            Quarrys = 0,
            Obelisks = 0,
            FamNum = 0,
            BerNum = 0;
        public bool
            press_start = false,
            removing = false,
            Kill = false,
            Progressing = false;
        public MainWindow()
        {
            InitializeComponent();
            P1 = new Player(this);
            G1 = new GameArea(this);
            rnd = new Random();
            Player_Pos_Check();
            Player_Stats_Check();
            Player_Resourses_Check();
            mS_timer = new DispatcherTimer();
            mS_timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            mS_timer.Tick += new EventHandler(mS_timer_Tick);
            processes = new Processes();
            
        }
        public void BerrySpawn()
        {
            BerNum++;
            if (BerNum >= 100 && G1.HaveBerry == false)
            {
                
                G1.HaveBerry = true;
                int x = rnd.Next(0, 9) * 50;
                int y = rnd.Next(0, 6) * 50;
                G1.BerX = x;
                G1.BerY = y;
                G1.Area[x, y] = (int)Sosnoviy_bor.Cells.Berry;
                Berry.Visibility = Visibility.Visible;
                Canvas.SetLeft(Berry, x);
                Canvas.SetTop(Berry, y);

            }
        }
        public void FamilliarSpawn()
        {
            FamNum++;
            if (FamNum >=6000 - (P1.Score / 10))
            {
                int x, y;
                x = rnd.Next(0, 20) * 50;
                y = rnd.Next(0, 14) * 50;
                if (G1.Area[x, y] <= (int)Sosnoviy_bor.Cells.Enemy)
                {
                    Familliar fam = new Familliar(this);
                    fam.x = x;
                    fam.y = y;
                    fam.HP = 10 + P1.Score / 100;
                    fam.Initialize();
                    FamNum = 0;
                }
            }
        }

        public void Tstop()
        {
            mS_timer.Stop();
            MessageBox.Show(this, "Добро пожаловать в Сосновый бор,\nпостоянных клиентов ваншотим..." +
                    "\nОчки: " + P1.Score,
                    "Вы погибли");
            this.Close();
        }
        public void Sudden_Death()
        {
            if (Kill)
            {
                sudden++;
                if (sudden >= 6000)
                {
                    P1.Damage(90000);
                    Kill = false;
                    sudden = 0;
                }
            }
            else
            {
                sudden++;
                if (sudden >= 6000 && (rnd.Next(0, 101) + P1.Score / 100) >= 95)
                {
                    P1.Damage(50000);
                    Kill = true;
                    sudden = 0;
                }
            }
        }
        private void Minecheck()
        {
            if ((P1.x <= 600 && P1.y <= 350) || (P1.x >= 600 && P1.y >= 600) || (P1.x >= 850 && P1.y <= 400))
            {
                Mining(2, 1, 0);
            }
            if ((P1.x >= 650 && P1.x <= 850) && (P1.y >= 400 && P1.y <= 550))
            {
                Mining(0, 2, 2);
            }
            else
            {
                Mining(1, 1, 0);
            }
            Player_Resourses_Check();
        }
        private void Mining(int Wood_Value, int Stone_Value, int Coin_Value)
        {
            P1.Wood += (rnd.Next(0, 3 + Wood_Value) + Wood_Value * Sawmills);
            P1.Stone += (rnd.Next(0, 3 + Stone_Value) + Stone_Value*Quarrys);
            P1.Coin +=(rnd.Next(0, 3 + Coin_Value)*(int)(Coin_Value*0.5*(Obelisks + 1)));
        }
        public void Interface_Off()
        {
            B_Mine.IsEnabled = false;
            B_Build.IsEnabled = false;
            B_Remove.IsEnabled = false;
        }
        public void Interface_On()
        {
            B_Mine.IsEnabled = true;
            B_Build.IsEnabled = true;
            B_Remove.IsEnabled = true;
        }
        private void Income()
        {
            income++;
            if (income == 100)
            {
                P1.Wood += (int)(Sawmills + Sawmills * 0.1 * Obelisks);
                P1.Stone += (int)(Quarrys + Quarrys * 0.1 * Obelisks);
                int chance = (int)Math.Floor((double)(1/ rnd.Next(1, 10)));
                P1.Coin += (int)(chance * Quarrys + chance * 0.1 * Obelisks);
                Player_Resourses_Check();
                income = 0;
            }
        }
        void mS_timer_Tick(object sender, EventArgs e)
        {
            P1.Hungry();
            Sudden_Death();
            BerrySpawn();
            FamilliarSpawn();
            Progress_Bar();
            Income();
        }
       
    }
}
