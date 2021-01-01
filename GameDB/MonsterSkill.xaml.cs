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
    public partial class MonsterSkill : UserControl
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        String user, role, character, monster, location;

        public MonsterSkill()
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
        }

        public MonsterSkill(string user, string role, string name, string monster, string skill, string race, string clss, string type, Int16 health, Int16 mana, Int16 level)
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
            this.user = user;
            this.role = role;
            this.character = name;
            this.monster = monster;
            monsterSkillName.Text = skill;
            monsterSkillRace.Text = "Race: " + race;
            monsterSkillClass.Text = "Class: " + clss;
            monsterSkillType.Text = "Type: " + type;
            monsterSkillHealth.Text = "Health: " + health.ToString();
            monsterSkillMana.Text = "Mana: " + mana.ToString();
            monsterSkillLevel.Text = "Level: " + level.ToString();

            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT skill_blob FROM GameDBAdmin.skill_table WHERE skill_name = '" + skill + "'";
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
                    monsterSkillIcon.Source = image;
                }
                catch (Exception exc)
                {

                }
            }
            con.Close();
        }

        private void MonsterSkillMouseEnter(object sender, MouseEventArgs e)
        {
            monsterSkillBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC8C8C8"));
        }

        private void MonsterSkillMouseLeave(object sender, MouseEventArgs e)
        {
            monsterSkillBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        }

        private void FirstClick(object sender, RoutedEventArgs e)
        {

        }

        private void SecondClick(object sender, RoutedEventArgs e)
        {

        }

        private void ThirdClick(object sender, RoutedEventArgs e)
        {

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
