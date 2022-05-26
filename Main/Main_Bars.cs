using System.Windows;
using System.Windows.Controls;

namespace Sosnoviy_bor
{
    public partial class MainWindow
    {
        private void Progress_Bar()
        {
            if (Progressing)
            {
                progress++;
                Progress.Value++;
                if (progress == 250)
                {
                    Progressing = false;
                    progress = 0;
                    switch (processes)
                    {
                        case Processes.Mine:
                            {
                                Minecheck();
                                P1.Score += 10;
                            }
                            break;
                        case Processes.Sleep:
                            {
                                P1.Sleep();
                                P1.Score++;
                            }
                            break;
                        case Processes.B_Camp:
                            {
                                Camp_Build();
                                P1.Score += 10;
                            }
                            break;
                        case Processes.R_Camp:
                            {
                                Canvas.Children.RemoveAt(G1.Indexes[P1.x, P1.y]);
                                G1.Area[P1.x, P1.y] = (int)Sosnoviy_bor.Cells.Null;
                                P1.Wood += 6;
                                P1.Bullets--;
                                Player_Resourses_Check();
                            }
                            break;
                        case Processes.B_Sawmill:
                            {
                                Sawmill_Build();
                                P1.Score += 50;
                            }
                            break;
                        case Processes.R_Sawmill:
                            {
                                Canvas.Children.RemoveAt(G1.Indexes[P1.x, P1.y]);
                                G1.Area[P1.x, P1.y] = (int)Sosnoviy_bor.Cells.Null;
                                P1.Wood += 12;
                                P1.Stone += 30;
                                Player_Resourses_Check();
                            }
                            break;
                        case Processes.B_Quarry:
                            {
                                Quarry_Build();
                                P1.Score += 100;
                            }
                            break;
                        case Processes.R_Quarry:
                            {
                                Canvas.Children.RemoveAt(G1.Indexes[P1.x, P1.y]);
                                G1.Area[P1.x, P1.y] = (int)Sosnoviy_bor.Cells.Null;
                                P1.Wood += 42;
                                P1.Stone += 12;
                                Player_Resourses_Check();
                            }
                            break;
                        case Processes.B_Obelisk:
                            {
                                Obelisk_Build();
                                P1.Score += 500;
                            }
                            break;
                        case Processes.R_Obelisk:
                            {
                                Canvas.Children.RemoveAt(G1.Indexes[P1.x, P1.y]);
                                G1.Area[P1.x, P1.y] = (int)Sosnoviy_bor.Cells.Null;
                                P1.Wood += (int)(0.6 * W_Ob_price * 0.9);
                                P1.Stone += (int)(0.6 * S_Ob_price * 0.9);
                                P1.Coin += (int)(0.6 * C_Ob_price * 0.9);
                                W_Ob_price -= (int)(W_Ob_price / 11);
                                S_Ob_price -= (int)(S_Ob_price / 11);
                                C_Ob_price -= (int)(C_Ob_price / 11);
                                P1.Dmg--;
                                Player_Resourses_Check();
                            }
                            break;
                        default:
                            MessageBox.Show("Не знаю как можно получить эту ошибку(921)");
                            break;

                    }
                    Interface_On();
                }
            }
        }
    }
}
