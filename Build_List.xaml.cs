using System;
using System.Windows;
using System.Windows.Controls;

namespace Sosnoviy_bor
{
    /// <summary>
    /// Логика взаимодействия для Build_List.xaml
    /// </summary>
    public partial class Build_List : Window
    {
        MainWindow main;
        public Build_List(MainWindow wind)
        {
            main = wind;
            InitializeComponent();
            L_Wood_obelisk.Content = main.W_Ob_price;
            L_Stone_obelisk.Content = main.S_Ob_price;
            L_Coin_obelisk.Content = main.C_Ob_price;
        }

        private void Menu_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void B_Exit_Click(object sender, RoutedEventArgs e)
        {
            main.Interface_On();
            this.Close();
        }

        private void B_Camp_Click(object sender, RoutedEventArgs e)
        {
            if (main.P1.Wood >= 10)
            {
                main.Interface_On();
                this.Close();
                main.Camp_Try_Build();
            }
            else
            {
                MessageBox.Show("Не хавтает 資源");
            }
        }
        private void B_Sawmill_Click(object sender, RoutedEventArgs e)
        {
            if (main.P1.Wood >= 20 && main.P1.Stone >= 50 && main.P1.Coin >= 5)
            {
                main.Interface_On();
                this.Close();
                main.Sawmill_Try_Build();
            }
            else
            {
                MessageBox.Show("Не хавтает 資源");
            }
        }

        private void B_Quarry_Click(object sender, RoutedEventArgs e)
        {
            if (main.P1.Wood >= 70 && main.P1.Stone >= 20 && main.P1.Coin >= 10)
            {
                main.Interface_On();
                this.Close();
                main.Quarry_Try_Build();
            }
            else
            {
                MessageBox.Show("Не хавтает 資源");
            }
        }

        private void B_Obelisk_Click(object sender, RoutedEventArgs e)
        {
            if (main.P1.Wood >= main.W_Ob_price &&
                main.P1.Stone >= main.S_Ob_price &&
                main.P1.Coin >= main.S_Ob_price)
            {
                main.Interface_On();
                this.Close();
                main.Obelisk_Try_Build();
            }
            else
            {
                MessageBox.Show("Не хавтает 資源");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            main.Interface_On();
            this.Close();
            main.Activate();
        }
    }
}
