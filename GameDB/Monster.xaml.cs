using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using System.IO;

namespace GameDB
{
    /// <summary>
    /// Логика взаимодействия для Character.xaml
    /// </summary>
    public partial class Monster : UserControl
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        String user, role, character, monster, location;
        Uri uri = null;

        public Monster()
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
        }

        public Monster(string user, string role, string name, string monster, string race, string clss, string location, Int16 level, Uri uri)
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
            this.user = user;
            this.role = role;
            this.character = name;
            this.monster = monster;
            this.location = location;
            this.uri = uri;
            monsterName.Text = monster;
            monsterRace.Text = "Race: " + race;
            monsterClass.Text = "Class: " + clss;
            monsterLocation.Text = "Location: " + location;
            monsterLevel.Text = "Level: " + level.ToString();

            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT monster_blob FROM GameDBAdmin.monster_table WHERE monster_name = '" + monster + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(reader.GetValue(0) as byte[]);
                    image.EndInit();
                    monsterIcon.Source = image;
                }
                catch (Exception exc)
                {

                }
            }
            con.Close();
        }

        private void MonsterMouseEnter(object sender, MouseEventArgs e)
        {
            monsterBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC8C8C8"));
        }

        private void MonsterMouseLeave(object sender, MouseEventArgs e)
        {
            monsterBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        }

        private void AttackClick(object sender, RoutedEventArgs e)
        {
            Battle battle = new Battle(user, role, character, monster, uri);
            battle.Show();
            Application.Current.Windows[0].Visibility = Visibility.Hidden;
        }

        private void SkillClick(object sender, RoutedEventArgs e)
        {
            Page page = new Page(user, role, character, location, monster, uri);
            page.characterItem.Visibility = Visibility.Hidden;
            page.statGrid.Visibility = Visibility.Hidden;
            page.locationGrid.Visibility = Visibility.Hidden;
            page.skillGrid.Visibility = Visibility.Hidden;
            page.itemGrid.Visibility = Visibility.Hidden;
            page.monsterGrid.Visibility = Visibility.Hidden;
            page.monsterSkillGrid.Visibility = Visibility.Visible;
            page.dropGrid.Visibility = Visibility.Hidden;
            page.npcGrid.Visibility = Visibility.Hidden;
            page.tabControl.SelectedIndex = 6;
            page.updateMonsterSkill();
            page.Show();
            Application.Current.Windows[0].Close();
        }

        private void DropClick(object sender, RoutedEventArgs e)
        {
            Page page = new Page(user, role, character, location, monster, uri);
            page.characterItem.Visibility = Visibility.Hidden;
            page.statGrid.Visibility = Visibility.Hidden;
            page.locationGrid.Visibility = Visibility.Hidden;
            page.skillGrid.Visibility = Visibility.Hidden;
            page.itemGrid.Visibility = Visibility.Hidden;
            page.monsterGrid.Visibility = Visibility.Hidden;
            page.monsterSkillGrid.Visibility = Visibility.Hidden;
            page.dropGrid.Visibility = Visibility.Visible;
            page.npcGrid.Visibility = Visibility.Hidden;
            page.tabControl.SelectedIndex = 7;
            page.updateDrop();
            page.Show();
            Application.Current.Windows[0].Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
