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
        public void Camp_Try_Build()
        {
            int x = P1.x;
            int y = P1.y;
            if (G1.Area[x, y] <= (int)Sosnoviy_bor.Cells.Player)
            {
                Interface_Off();
                Progressing = true;
                processes = Processes.B_Camp;
            }
            else
            {
                MessageBox.Show("Разместить палатку не удалось, клетка занята");
            }
        }
        public void Sawmill_Try_Build()
        {
            int x = P1.x;
            int y = P1.y;
            if ((P1.x <= 550 && P1.y <= 350) || (P1.x <= 600 && P1.y >= 550) || (P1.x >= 850 && P1.y <= 400))
            {
                if (G1.Area[x, y] <= (int)Sosnoviy_bor.Cells.Player)
                {
                    Interface_Off();
                    Progressing = true;
                    processes = Processes.B_Sawmill;
                }
                else
                {
                    MessageBox.Show("Разместить лесопилку не удалось, клетка занята");
                }
            }
            else
            {
                MessageBox.Show("Лесопилку можно построить только в лесу");
            }

        }
        public void Quarry_Try_Build()
        {
            int x = P1.x;
            int y = P1.y;
            if ((P1.x >= 650 && P1.x <= 850) && (P1.y >= 400 && P1.y <= 550))
            {
                if (G1.Area[x, y] <= (int)Sosnoviy_bor.Cells.Player)
                {
                    Interface_Off();
                    Progressing = true;
                    processes = Processes.B_Quarry;
                }
                else
                {
                    MessageBox.Show("Разместить каменоломню не удалось, клетка занята");
                }
            }
            else
            {
                MessageBox.Show("Каменоломню можно построить только в руинах");
            }

        }
        public void Obelisk_Try_Build()
        {
            int x = P1.x;
            int y = P1.y;
            if (G1.Area[x, y] <= (int)Sosnoviy_bor.Cells.Player)
            {
                Interface_Off();
                Progressing = true;
                processes = Processes.B_Obelisk;
            }
            else
            {
                MessageBox.Show("Разместить обелиск не удалось, клетка занята");
            }
        }
        private void Camp_Build()
        {
            int x = P1.x;
            int y = P1.y;
            P1.Wood -= 10;
            Player_Resourses_Check();
            Camping Camp = new Camping(this);
            Camp.x = x;
            Camp.y = y;
            Camp.Initialize();
        }
        private void Sawmill_Build()
        {
            int x = P1.x;
            int y = P1.y;
            P1.Wood -= 20;
            P1.Stone -= 50;
            P1.Coin -= 5;
            Player_Resourses_Check();
            Sawmill sawmill = new Sawmill(this);
            sawmill.x = x;
            sawmill.y = y;
            sawmill.Initialize();
        }
        private void Quarry_Build()
        {
            int x = P1.x;
            int y = P1.y;
            P1.Wood -= 70;
            P1.Stone -= 20;
            P1.Coin -= 10;
            Player_Resourses_Check();
            Quarry quarry = new Quarry(this);
            quarry.x = x;
            quarry.y = y;
            quarry.Initialize();
        }
        private void Obelisk_Build()
        {
            int x = P1.x;
            int y = P1.y;
            P1.Wood -= W_Ob_price;
            P1.Stone -= S_Ob_price;
            P1.Coin -= C_Ob_price;
            W_Ob_price += (int)(W_Ob_price * 0.10);
            S_Ob_price += (int)(S_Ob_price * 0.10);
            C_Ob_price += (int)(C_Ob_price * 0.10);
            Player_Resourses_Check();
            Obelisk obelisk = new Obelisk(this);
            obelisk.x = x;
            obelisk.y = y;
            obelisk.Initialize();
        }
    }
}
