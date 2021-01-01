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
    public partial class Location : UserControl
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        String user, role, character, location;
        Uri uri = null;

        public Location()
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
        }

        public Location(string user, string role, string name, string location, Uri uri)
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
            this.user = user;
            this.role = role;
            this.character = name;
            this.location = location;
            this.uri = uri;
            locationName.Text = location;

            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT location_blob FROM GameDBAdmin.location_table WHERE location_name = '" + location + "'";
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
                    locationIcon.Source = image;
                }
                catch (Exception exc)
                {
                    
                }
            }
            con.Close();
        }

        private void LocationMouseEnter(object sender, MouseEventArgs e)
        {
            locationBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC8C8C8"));
        }

        private void LocationMouseLeave(object sender, MouseEventArgs e)
        {
            locationBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        }

        private void LocateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.CHANGE_LOCATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character;
            cmd.Parameters.Add("P_LOCATION_NAME", OracleDbType.Varchar2, 30).Value = location;
            try
            {
                cmd.ExecuteNonQuery();
                Page page = new Page(user, role, character, location, uri);
                page.characterGrid.Visibility = Visibility.Hidden;
                page.statGrid.Visibility = Visibility.Visible;
                page.locationGrid.Visibility = Visibility.Visible;
                page.skillGrid.Visibility = Visibility.Visible;
                page.itemGrid.Visibility = Visibility.Visible;
                page.monsterGrid.Visibility = Visibility.Hidden;
                page.monsterSkillGrid.Visibility = Visibility.Hidden;
                page.dropGrid.Visibility = Visibility.Hidden;
                page.npcGrid.Visibility = Visibility.Hidden;
                page.tabControl.SelectedIndex = 2;
                page.updateStat();
                page.updateLocation();
                page.updateSkill();
                page.updateItem();
                page.Show();
                Application.Current.Windows[0].Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Location is not found");
            }
            con.Close();
        }

        private void MonstersClick(object sender, RoutedEventArgs e)
        {
            Page page = new Page(user, role, character, location, uri);
            page.characterItem.Visibility = Visibility.Hidden;
            page.statGrid.Visibility = Visibility.Hidden;
            page.locationGrid.Visibility = Visibility.Hidden;
            page.skillGrid.Visibility = Visibility.Hidden;
            page.itemGrid.Visibility = Visibility.Hidden;
            page.monsterGrid.Visibility = Visibility.Visible;
            page.monsterSkillGrid.Visibility = Visibility.Hidden;
            page.dropGrid.Visibility = Visibility.Hidden;
            page.npcGrid.Visibility = Visibility.Hidden;
            page.tabControl.SelectedIndex = 5;
            page.updateMonster();
            page.Show();
            Application.Current.Windows[0].Close();
        }

        private void NPCsClick(object sender, RoutedEventArgs e)
        {
            Page page = new Page(user, role, character, location, uri);
            page.characterItem.Visibility = Visibility.Hidden;
            page.statGrid.Visibility = Visibility.Hidden;
            page.locationGrid.Visibility = Visibility.Hidden;
            page.skillGrid.Visibility = Visibility.Hidden;
            page.itemGrid.Visibility = Visibility.Hidden;
            page.monsterGrid.Visibility = Visibility.Hidden;
            page.monsterSkillGrid.Visibility = Visibility.Hidden;
            page.dropGrid.Visibility = Visibility.Hidden;
            page.npcGrid.Visibility = Visibility.Visible;
            page.tabControl.SelectedIndex = 8;
            page.updateNPC();
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
