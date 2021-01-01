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

namespace GameDB
{
    /// <summary>
    /// Логика взаимодействия для Character.xaml
    /// </summary>
    public partial class Character : UserControl
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        String user, role, character, location;
        Uri uri = null;

        public Character()
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
        }

        public Character(string user, string role, string name, string race, string clss, string location, Int16 level)
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
            this.user = user;
            this.role = role;
            this.character = name;
            this.location = location;
            characterName.Text = name;
            characterRace.Text = "Race: " + race;
            characterClass.Text = "Class: " + clss;
            characterLocation.Text = "Location: " + location;
            characterLevel.Text = "Level: " + level.ToString();
            if (race == "ANGEL")
            {
                if (clss == "WARRIOR") uri = new Uri("D:/GameDB/Resources/Character/Angel_Warrior.png", UriKind.Absolute);
                if (clss == "KILLER") uri = new Uri("D:/GameDB/Resources/Character/Angel_Killer.png", UriKind.Absolute);
                if (clss == "MAGE") uri = new Uri("D:/GameDB/Resources/Character/Angel_Mage.png", UriKind.Absolute);
                if (clss == "SUPPORT") uri = new Uri("D:/GameDB/Resources/Character/Angel_Support.png", UriKind.Absolute);
            }
            else if (race == "DEMON")
            {
                if (clss == "WARRIOR") uri = new Uri("D:/GameDB/Resources/Character/Demon_Warrior.png", UriKind.Absolute);
                if (clss == "KILLER") uri = new Uri("D:/GameDB/Resources/Character/Demon_Killer.png", UriKind.Absolute);
                if (clss == "MAGE") uri = new Uri("D:/GameDB/Resources/Character/Demon_Mage.png", UriKind.Absolute);
                if (clss == "SUPPORT") uri = new Uri("D:/GameDB/Resources/Character/Demon_Support.png", UriKind.Absolute);
            }
            else if (race == "ELF")
            {
                if (clss == "WARRIOR") uri = new Uri("D:/GameDB/Resources/Character/Elf_Warrior.png", UriKind.Absolute);
                if (clss == "KILLER") uri = new Uri("D:/GameDB/Resources/Character/Elf_Killer.png", UriKind.Absolute);
                if (clss == "MAGE") uri = new Uri("D:/GameDB/Resources/Character/Elf_Mage.png", UriKind.Absolute);
                if (clss == "SUPPORT") uri = new Uri("D:/GameDB/Resources/Character/Elf_Support.png", UriKind.Absolute);
            }
            else if (race == "HUMAN")
            {
                if (clss == "WARRIOR") uri = new Uri("D:/GameDB/Resources/Character/Human_Warrior.png", UriKind.Absolute);
                if (clss == "KILLER") uri = new Uri("D:/GameDB/Resources/Character/Human_Killer.png", UriKind.Absolute);
                if (clss == "MAGE") uri = new Uri("D:/GameDB/Resources/Character/Human_Mage.png", UriKind.Absolute);
                if (clss == "SUPPORT") uri = new Uri("D:/GameDB/Resources/Character/Human_Support.png", UriKind.Absolute);
            }
            else if (race == "ORC")
            {
                if (clss == "WARRIOR") uri = new Uri("D:/GameDB/Resources/Character/Orc_Warrior.png", UriKind.Absolute);
                if (clss == "KILLER") uri = new Uri("D:/GameDB/Resources/Character/Orc_Killer.png", UriKind.Absolute);
                if (clss == "MAGE") uri = new Uri("D:/GameDB/Resources/Character/Orc_Mage.png", UriKind.Absolute);
                if (clss == "SUPPORT") uri = new Uri("D:/GameDB/Resources/Character/Orc_Support.png", UriKind.Absolute);
            }
            else if (race == "UNDEAD")
            {
                if (clss == "WARRIOR") uri = new Uri("D:/GameDB/Resources/Character/Undead_Warrior.png", UriKind.Absolute);
                if (clss == "KILLER") uri = new Uri("D:/GameDB/Resources/Character/Undead_Killer.png", UriKind.Absolute);
                if (clss == "MAGE") uri = new Uri("D:/GameDB/Resources/Character/Undead_Mage.png", UriKind.Absolute);
                if (clss == "SUPPORT") uri = new Uri("D:/GameDB/Resources/Character/Undead_Support.png", UriKind.Absolute);
            }
            else uri = new Uri("D:/GameDB/Resources/Character/Something.png", UriKind.Absolute);
            characterIcon.Source = new BitmapImage(uri) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
        }

        private void CharacterMouseEnter(object sender, MouseEventArgs e)
        {
            characterBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC8C8C8"));
        }

        private void CharacterMouseLeave(object sender, MouseEventArgs e)
        {
            characterBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
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

        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            ChangeCharacter createCharacter = new ChangeCharacter(user, role, characterName.Text.Trim());
            createCharacter.Show();
            Application.Current.Windows[0].Close();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you really want to delete a character?", "Delete character", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.DELETE_CHARACTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = characterName.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                    ((WrapPanel)this.Parent).Children.Remove(this);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Character is not found");
                }
                con.Close();
            }
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