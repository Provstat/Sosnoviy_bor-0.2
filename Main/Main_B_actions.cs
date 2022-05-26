using System.Windows;

namespace Sosnoviy_bor
{
    public partial class MainWindow
    {
        private void B_Start_Action()
        {
            B_Start.IsEnabled = false;
            press_start = true;
            B_Start.Visibility = Visibility.Hidden;
            L_Controls.Visibility = Visibility.Hidden;
            B_Lore.Visibility = Visibility.Hidden;
            Im_Logo.Visibility = Visibility.Hidden;
            Im_HP.Visibility = Visibility.Visible;
            Im_Hunger.Visibility = Visibility.Visible;
            HP_BAR.Visibility = Visibility.Visible;
            Hunger_BAR.Visibility = Visibility.Visible;
            L_Wood.Visibility = Visibility.Visible;
            L_Stone.Visibility = Visibility.Visible;
            L_Coin.Visibility = Visibility.Visible;
            Im_Wood.Visibility = Visibility.Visible;
            Im_Stone.Visibility = Visibility.Visible;
            Im_Coin.Visibility = Visibility.Visible;
            B_Build.Visibility = Visibility.Visible;
            B_Mine.Visibility = Visibility.Visible;
            Progress.Visibility = Visibility.Visible;
            B_Remove.Visibility = Visibility.Visible;
            mS_timer.Start();
            FamNum = 0;
            P1.Initialize();
        }
        private void B_Lore_Action()
        {
            MessageBox.Show(this,
                "\tЖаркий летний полдень. Вокруг только природа, лес. " +
                "Впереди проложена дорога. Ее размер указывает на ее важность. " +
                "Справа от дороги стоит разрушенное каменного сооружение. " +
                "Слева между деревьев растут черничные кусты. " +
                "\n\tВы чуствуете прилив сил. " +
                "Однако оглянувшись, вы понимаете, что не помните как вы тут оказались. " +
                "Вы считаете себя человеком, однако не ощущаете своих конечностей. " +
                "Какие-то подобия рук из синего полупрозрачноко, как дерево твердого, материала. " +
                "Ни тропа, ни руины вам не знакомы.",
                "4000 лье в глубине леса (1 из 4)");
            MessageBox.Show(this,
                "\tПытаясь найти что-нибудь и следуя по дороге, вы по всем законам жанра " +
                "должны были заблудиться и вернуться назад, однако вы решили сыграть на зло " +
                "сценаристу, разработчику и богу этого мира в одном лице назло и вернуться назад самостоятельно." +
                "\n\tИз уроков ОБЖ, которых у вас возможно не было, вы помните несколько съедобных ягод." +
                "Однако из всех вам известных, здесь растет лишь черника, пищевая ценность которой, почему-то сравнима с стейком. " +
                "\n\tВы чуствуете, голод вместе с сильным приливом энергии. " +
                "Очевидно, это не к добру, ведь вы считаете, что эта энергия губит вас. " +
                "Вы можете смешать ресурсы и получить ауру, которая будет напоминать строения из возможного человеческого прошлого. " +
                "Установленная Аура может принять образ палатки, лесопилки и камненоломни, в зависимости от функционала." +
                "Однако образ обелиска не кажется иллюзией, хотя вряд-ли такой прочный монумент можно создать из обычных булыжников..." +
                "\n\tНельзя же???",
                "4000 лье в глубине леса (2 из 4)");
            MessageBox.Show(this,
                "\tВ голове (или в чем-то, что ее напоминает) у вас всплывают образы человека, " +
                "едущего на автомобиле по, казалось бы этой же дороге, только асфальтированной. " +
                "Вокруг нет деревьев, вокруг луга, однако вдали видно сосновый лес, как будто он переехал. " +
                "Вас переносит в лес, где вы видите знакомые руины, хотя они стоят у той дороги, или не той. " +
                "Вокруг развалин ходит знакомый человек, он кажется измотанным и раненым. " +
                "Он делает тщетные попытки согреться, но мерзнет еще сильнее. " +
                "В какой-то момент он падает от истощения на землю и больше не шевелится. " +
                "В какй-то момент руины начинают словно проваливаться под землю, как в зыбучих песках, пока от развалин не останется и следа.",
                "4000 лье в глубине леса (3 из 4)");
            MessageBox.Show(this,
                "\tВам все чаще кажутся похожие образы с разными людьми, но никого из них не щадит судьба. " +
                "Вас переполняет злость, горечь, жалость и грусть. Вы должны добраться до истины. " +
                "Под развалинами вы находите обломки обелиска. " +
                "Взяв в руки каждый обломок, вас посещает мысль связання с источником происходящего. " +
                "Вы научились метко швырять сгусток эктоплазмы, возможно он сможет нанести вред неприятелю. " +
                "Вас преследуют разные мысли, но одну вы четко осознаете: " +
                "\n\t-Нужно построить больше пило... обелисков...",
                "4000 лье в глубине леса (4 из 4)");
        }
        private void B_Build_Action()
        {
            progress = 0;
            Progress.Value = 0;
            Interface_Off();
            Build_List Wind = new Build_List(this);
            Wind.Owner = this;
            Wind.Show();
        }
        private void B_Remove_Camp_Action()
        {
            progress = 0;
            Progress.Value = 0;
            Interface_Off();
            processes = Processes.R_Camp;
            Progressing = true;
        }
        private void B_Remove_Sawmill_Action()
        {
            progress = 0;
            Progress.Value = 0;
            Interface_Off();
            processes = Processes.R_Sawmill;
            Progressing = true;
        }
        private void B_Remove_Quarry_Action()
        {
            progress = 0;
            Progress.Value = 0;
            Interface_Off();
            processes = Processes.R_Quarry;
            Progressing = true;
        }
        private void B_Remove_Obelisk_Action()
        {
            progress = 0;
            Progress.Value = 0;
            Interface_Off();
            processes = Processes.R_Obelisk;
            Progressing = true;
        }
        private void B_Mine_Action()
        {
            progress = 0;
            Progress.Value = 0;
            Interface_Off();
            processes = Processes.Mine;
            Progressing = true;
        }
    }
}
