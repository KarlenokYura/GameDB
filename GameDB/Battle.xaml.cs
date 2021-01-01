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
using System.Threading;
using System.Threading.Tasks;

namespace GameDB
{
    /// <summary>
    /// Логика взаимодействия для Battle.xaml
    /// </summary>
    public partial class Battle : Window
    {
        OracleConnection con = new OracleConnection();
        string user, role, character = "ALASTOR", monster = "CUCOLD";
        Uri uri = null;

        public Battle()
        {
            con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

            InitializeComponent();
        }

        public Battle(string user, string role, string character, string monster, Uri uri)
        {
            if (role == "OWNER")
            {
                con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBAdmin;PASSWORD=Pa$$w0rd";
            }
            else
            {
                con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";
            }
            this.user = user;
            this.role = role;
            this.character = character;
            this.monster = monster;
            this.uri = uri;
            InitializeComponent();
        }

        #region Character

        int character_level, character_exp, character_health, character_max_health, character_mana, character_max_mana, character_power, character_speed, character_mind;
        bool character_miss = false;

        private void CharacterAttackClick(object sender, RoutedEventArgs e)
        {
            if (monster_miss == false)
            {
                monster_health = monster_health - character_power;
                monsterHealth.Text = "Health: " + (monster_health > 0 ? monster_health : 0) + " / " + monster_max_health;
                monsterProgressHealth.Value = monster_health;
                if (monster_health <= 0)
                {
                    MessageBox.Show("You kill monster");
                    character_exp = character_exp + monster_level;
                    con.Open();
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE GAMEDBADMIN.character_view SET character_exp = (:CHARACTER_EXP) WHERE character_name = '" + character + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("CHARACTER_EXP", OracleDbType.Int16, 10).Value = character_exp;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.DROP_ITEM";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character;
                    cmd.Parameters.Add("P_MONSTER_NAME", OracleDbType.Varchar2, 30).Value = monster;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SetHealthMana();

                    Thread.Sleep(1000);
                    Application.Current.Windows[0].Visibility = Visibility.Visible;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Monster is dodge");
                monster_miss = false;
            }
            characterPanel.IsEnabled = false;
            monsterPanel.IsEnabled = true;
        }

        private void CharacterRunClick(object sender, RoutedEventArgs e)
        {
            if (character_speed > monster_speed)
            {
                MessageBox.Show("You is run");

                SetHealthMana();

                Thread.Sleep(1000);
                Application.Current.Windows[0].Visibility = Visibility.Visible;
                this.Close();
            }
            else
            {
                MessageBox.Show("You is not run");
            }
            characterPanel.IsEnabled = false;
            monsterPanel.IsEnabled = true;
        }

        private void CharacterMissClick(object sender, RoutedEventArgs e)
        {
            if (character_mind > monster_mind)
            {
                character_miss = true;
            }
            characterPanel.IsEnabled = false;
            monsterPanel.IsEnabled = true;
        }

        private void CharacterSkill(int level)
        {
            bool monsterKill = false;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT skill_health, skill_mana, skill_type_name FROM GAMEDBADMIN.character_skill_info_view WHERE character_name = '" + character + "' ORDER BY skill_level ASC, skill_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            try
            {
                for (int i = 0; i < level; i++)
                {
                    reader.Read();
                }
                reader.Read();
                if (character_mana >= reader.GetInt32(1))
                {
                    character_mana = character_mana - reader.GetInt32(1);
                    characterMana.Text = "Mana: " + character_mana + " / " + character_max_mana;
                    characterProgressMana.Value = character_mana;
                    if (reader.GetString(2) == "DAMAGE")
                    {
                        if (monster_miss == false)
                        {
                            if (monster_health - reader.GetInt32(0) > 0)
                            {
                                monster_health = monster_health - reader.GetInt32(0);
                                monsterHealth.Text = "Health: " + monster_health + " / " + monster_max_health;
                                monsterProgressHealth.Value = monster_health;
                            }
                            else
                            {
                                monster_health = 0;
                                monsterHealth.Text = "Health: " + monster_health + " / " + monster_max_health;
                                monsterProgressHealth.Value = monster_health;
                                MessageBox.Show("Вы убили врага");
                                character_exp = character_exp + monster_level;
                                monsterKill = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Враг увернулся");
                            monster_miss = false;
                        }
                    }
                    else
                    {
                        if (character_health + reader.GetInt32(0) > character_max_health)
                        {
                            character_health = character_max_health;
                            characterHealth.Text = "Health: " + character_max_health + " / " + character_max_health;
                            characterProgressHealth.Value = character_max_health;
                        }
                        else
                        {
                            character_health = character_health + reader.GetInt32(0);
                            characterHealth.Text = "Health: " + character_health + " / " + character_max_health;
                            characterProgressHealth.Value = character_health;
                        }
                    }
                    characterPanel.IsEnabled = false;
                    monsterPanel.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Not enough mana");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Skill is not found");
            }
            con.Close();
            if (monsterKill)
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE GAMEDBADMIN.character_view SET character_exp = (:CHARACTER_EXP) WHERE character_name = '" + character + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("CHARACTER_EXP", OracleDbType.Int16, 10).Value = character_exp;
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.DROP_ITEM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character;
                cmd.Parameters.Add("P_MONSTER_NAME", OracleDbType.Varchar2, 30).Value = monster;
                cmd.ExecuteNonQuery();
                con.Close();

                SetHealthMana();

                Thread.Sleep(1000);
                Application.Current.Windows[0].Visibility = Visibility.Visible;
                this.Close();
            }
        }

        private void CharacterFirstClick(object sender, RoutedEventArgs e)
        {
            CharacterSkill(0);
        }

        private void CharacterSecondClick(object sender, RoutedEventArgs e)
        {
            CharacterSkill(1);
        }

        private void CharacterThirdClick(object sender, RoutedEventArgs e)
        {
            CharacterSkill(2);
        }

        #endregion

        #region Monster

        int monster_level, monster_health, monster_max_health, monster_mana, monster_max_mana, monster_power, monster_speed, monster_mind;
        bool monster_miss = false;

        private void MonsterAttackClick(object sender, RoutedEventArgs e)
        {
            if (character_miss == false)
            {
                character_health = character_health - monster_power;
                characterHealth.Text = "Health: " + (character_health > 0 ? character_health : 0) + " / " + character_max_health;
                characterProgressHealth.Value = character_health;
                if (character_health <= 0)
                {
                    MessageBox.Show("You is dead");

                    con.Open();
                    OracleCommand cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.DELETE_CHARACTER";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Character is not found");
                    }
                    con.Close();

                    Thread.Sleep(1000);
                    Application.Current.Windows[0].Visibility = Visibility.Visible;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You is dodge");
                character_miss = false;
            }
            characterPanel.IsEnabled = true;
            monsterPanel.IsEnabled = false;
        }

        private void MonsterRunClick(object sender, RoutedEventArgs e)
        {
            if (monster_speed >= character_speed)
            {
                MessageBox.Show("Monster is run");
                Thread.Sleep(1000);

                SetHealthMana();

                Application.Current.Windows[0].Visibility = Visibility.Visible;
                this.Close();
            }
            else
            {
                MessageBox.Show("Monster is not run");
            }
            characterPanel.IsEnabled = true;
            monsterPanel.IsEnabled = false;
        }

        private void MonsterMissClick(object sender, RoutedEventArgs e)
        {
            if (monster_mind >= character_mind)
            {
                monster_miss = true;
            }
            characterPanel.IsEnabled = true;
            monsterPanel.IsEnabled = false;
        }

        private void MonsterSkill(int level)
        {
            bool characterKill = false;
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT skill_health, skill_mana, skill_type_name FROM GAMEDBADMIN.monster_skill_info_view WHERE monster_name = '" + monster + "' ORDER BY skill_level ASC, skill_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            try
            {
                for (int i = 0; i < level; i++)
                {
                    reader.Read();
                }
                reader.Read();
                if (monster_mana >= reader.GetInt32(1))
                {
                    monster_mana = monster_mana - reader.GetInt32(1);
                    monsterMana.Text = "Mana: " + monster_mana + " / " + monster_max_mana;
                    monsterProgressMana.Value = monster_mana;
                    if (reader.GetString(2) == "DAMAGE")
                    {
                        if (character_miss == false)
                        {
                            if (character_health - reader.GetInt32(0) > 0)
                            {
                                character_health = character_health - reader.GetInt32(0);
                                characterHealth.Text = "Health: " + character_health + " / " + character_max_health;
                                characterProgressHealth.Value = character_health;
                            }
                            else
                            {
                                character_health = 0;
                                characterHealth.Text = "Health: " + character_health + " / " + character_max_health;
                                characterProgressHealth.Value = character_health;
                                MessageBox.Show("Враг убил вас");
                                characterKill = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы увернулись");
                            character_miss = false;
                        }
                    }
                    else
                    {
                        if (monster_health + reader.GetInt32(0) > monster_max_health)
                        {
                            monster_health = monster_max_health;
                            monsterHealth.Text = "Health: " + monster_max_health + " / " + monster_max_health;
                            monsterProgressHealth.Value = monster_max_health;
                        }
                        else
                        {
                            monster_health = monster_health + reader.GetInt32(0);
                            monsterHealth.Text = "Health: " + monster_health + " / " + monster_max_health;
                            monsterProgressHealth.Value = monster_health;
                        }
                    }
                    characterPanel.IsEnabled = true;
                    monsterPanel.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Not enough mana");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Skill is not found");
            }
            con.Close();
            if (characterKill)
            {
                MessageBox.Show("");

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.DELETE_CHARACTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Character is not found");
                }
                con.Close();

                Thread.Sleep(1000);
                Application.Current.Windows[0].Visibility = Visibility.Visible;
                this.Close();
            }
        }

        private void MonsterFirstClick(object sender, RoutedEventArgs e)
        {
            MonsterSkill(0);
        }

        private void MonsterSecondClick(object sender, RoutedEventArgs e)
        {
            MonsterSkill(1);
        }

        private void MonsterThirdClick(object sender, RoutedEventArgs e)
        {
            MonsterSkill(2);
        }

        #endregion

        public void updateCharacter()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT character_name, race_name, class_name, character_level, character_exp, character_health, character_max_health, character_mana, character_max_mana, " +
                "character_power, character_speed, character_mind FROM GAMEDBADMIN.character_info_view WHERE character_name = '" + character + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                characterIcon.Source = new BitmapImage(uri) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                characterName.Text = reader.GetString(0);
                characterRace.Text = "Race: " + reader.GetString(1);
                characterClass.Text = "Class: " + reader.GetString(2);
                characterLevel.Text = "Level: " + reader.GetInt16(3).ToString();
                character_level = reader.GetInt16(3);
                character_exp = reader.GetInt16(4);
                character_health = reader.GetInt32(5);
                character_max_health = reader.GetInt32(6);
                character_mana = reader.GetInt32(7);
                character_max_mana = reader.GetInt32(8);
                character_power = reader.GetInt32(9);
                character_speed = reader.GetInt32(10);
                character_mind = reader.GetInt32(11);
            }

            cmd.CommandText = "SELECT SUM(item_health), SUM(item_mana), SUM(item_power), SUM(item_speed), SUM(item_mind) FROM GAMEDBADMIN.character_item_info_view WHERE character_name = '" + character + "'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                character_health = character_health + (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                character_max_health = character_max_health + (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                characterProgressHealth.Value = character_health;
                characterProgressHealth.Maximum = character_max_health;
                characterHealth.Text = "Health: " + character_health + " / " + character_max_health;
                character_mana = character_mana + (reader.IsDBNull(1) ? 0 : reader.GetInt32(1));
                character_max_mana = character_max_mana + (reader.IsDBNull(1) ? 0 : reader.GetInt32(1));
                characterProgressMana.Value = character_mana;
                characterProgressMana.Maximum = character_max_mana;
                characterMana.Text = "Mana: " + character_mana + " / " + character_max_mana;
                character_power = character_power + (reader.IsDBNull(2) ? 0 : reader.GetInt32(2));
                characterPower.Text = "Power: " + character_power;
                character_speed = character_speed + (reader.IsDBNull(3) ? 0 : reader.GetInt32(3));
                characterSpeed.Text = "Speed: " + character_speed;
                character_mind = character_mind + (reader.IsDBNull(4) ? 0 : reader.GetInt32(4));
                characterMind.Text = "Mind: " + character_mind;
            }
            con.Close();

            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM GAMEDBADMIN.character_skill_info_view WHERE character_name = '" + character + "'";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetInt32(0) == 0)
                {
                    characterFirstButton.IsEnabled = false;
                    characterSecondButton.IsEnabled = false;
                    characterThirdButton.IsEnabled = false;
                }
                else if (reader.GetInt32(0) == 1)
                {
                    characterSecondButton.IsEnabled = false;
                    characterThirdButton.IsEnabled = false;
                }
                else if (reader.GetInt32(0) == 2)
                {
                    characterThirdButton.IsEnabled = false;
                }
            }
            con.Close();
        }

        public void updateMonster()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT monster_name, race_name, class_name, monster_level, monster_health, monster_max_health, monster_mana, monster_max_mana, " +
                "monster_power, monster_speed, monster_mind FROM GAMEDBADMIN.monster_info_view WHERE monster_name = '" + monster + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                monsterName.Text = reader.GetString(0);
                monsterRace.Text = "Race: " + reader.GetString(1);
                monsterClass.Text = "Class: " + reader.GetString(2);
                monsterLevel.Text = "Level: " + reader.GetInt16(3).ToString();
                monster_level = reader.GetInt16(3);
                monster_health = reader.GetInt32(4);
                monster_max_health = reader.GetInt32(5);
                monster_mana = reader.GetInt32(6);
                monster_max_mana = reader.GetInt32(7);
                monster_power = reader.GetInt32(8);
                monster_speed = reader.GetInt32(9);
                monster_mind = reader.GetInt32(10);
            }
            
            cmd.CommandText = "SELECT monster_blob FROM GameDBAdmin.monster_table WHERE monster_name = '" + monster + "'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new System.IO.MemoryStream(reader.GetValue(0) as byte[]);
                    image.EndInit();
                    monsterIcon.Source = image;
                }
                catch (Exception exc)
                {

                }
            }

            cmd.CommandText = "SELECT SUM(item_health), SUM(item_mana), SUM(item_power), SUM(item_speed), SUM(item_mind) FROM GAMEDBADMIN.monster_item_info_view WHERE monster_name = '" + monster + "'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                monster_health = monster_health + (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                monster_max_health = monster_max_health + (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
                monsterProgressHealth.Value = monster_health;
                monsterProgressHealth.Maximum = monster_max_health;
                monsterHealth.Text = "Health: " + monster_health + " / " + monster_max_health;
                monster_mana = monster_mana + (reader.IsDBNull(1) ? 0 : reader.GetInt32(1));
                monster_max_mana = monster_max_mana + (reader.IsDBNull(1) ? 0 : reader.GetInt32(1));
                monsterProgressMana.Value = monster_mana;
                monsterProgressMana.Maximum = monster_max_mana;
                monsterMana.Text = "Mana: " + monster_mana + " / " + monster_max_mana;
                monster_power = monster_power + (reader.IsDBNull(2) ? 0 : reader.GetInt32(2));
                monsterPower.Text = "Power: " + monster_power;
                monster_speed = monster_speed + (reader.IsDBNull(3) ? 0 : reader.GetInt32(3));
                monsterSpeed.Text = "Speed: " + monster_speed;
                monster_mind = monster_mind + (reader.IsDBNull(4) ? 0 : reader.GetInt32(4));
                monsterMind.Text = "Mind: " + monster_mind;
            }
            con.Close();

            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM GAMEDBADMIN.monster_skill_info_view WHERE monster_name = '" + monster + "'";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetInt32(0) == 0)
                {
                    monsterFirstButton.IsEnabled = false;
                    monsterSecondButton.IsEnabled = false;
                    monsterThirdButton.IsEnabled = false;
                }
                else if (reader.GetInt32(0) == 1)
                {
                    monsterSecondButton.IsEnabled = false;
                    monsterThirdButton.IsEnabled = false;
                }
                else if (reader.GetInt32(0) == 2)
                {
                    monsterThirdButton.IsEnabled = false;
                }
            }
            con.Close();
        }

        private void SetHealthMana()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.SET_HEALTH_MANA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_CHARACTER_HEALTH", OracleDbType.Int32, 10).Value = (character_health > 0 ? character_health : 0);
            cmd.Parameters.Add("P_CHARACTER_MANA", OracleDbType.Int32, 10).Value = (character_mana > 0 ? character_mana : 0);
            cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error");
            }
            con.Close();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateCharacter();
            updateMonster();

            if (character_speed > monster_speed)
            {
                characterRunButton.IsEnabled = true;
                monsterRunButton.IsEnabled = false;
            }
            else
            {
                characterRunButton.IsEnabled = false;
                monsterRunButton.IsEnabled = true;
            }

            if (character_mind > monster_mind)
            {
                characterMissButton.IsEnabled = true;
                monsterMissButton.IsEnabled = false;
            }
            else
            {
                characterMissButton.IsEnabled = false;
                monsterMissButton.IsEnabled = true;
            }
        }
    }
}
