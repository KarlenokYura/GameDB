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
    /// Логика взаимодействия для Page.xaml
    /// </summary>
    public partial class Page : Window
    {
        OracleConnection con = new OracleConnection();
        string user, role, character, location, monster;
        Uri uri = null;

        public Page()
        {
            InitializeComponent();
        }

        public Page(string user, string role)
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
            InitializeComponent();
        }

        public Page(string user, string role, string character)
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
            InitializeComponent();
        }

        public Page(string user, string role, string character, string location)
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
            this.location = location;
            InitializeComponent();
        }

        public Page(string user, string role, string character, string location, Uri uri)
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
            this.location = location;
            this.uri = uri;
            InitializeComponent();
        }

        public Page(string user, string role, string character, string location, string monster)
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
            this.location = location;
            this.monster = monster;
            InitializeComponent();
        }

        public Page(string user, string role, string character, string location, string monster, Uri uri)
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
            this.location = location;
            this.monster = monster;
            this.uri = uri;
            InitializeComponent();
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.CHARACTER_LIMIT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
            cmd.Parameters.Add("O_IS_FREE", OracleDbType.Varchar2, 30);
            cmd.Parameters["O_IS_FREE"].Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                String is_free = Convert.ToString(cmd.Parameters["O_IS_FREE"].Value);
                if (is_free.Trim() == "TRUE")
                {
                    CreateCharacter createCharacter = new CreateCharacter(user, role);
                    this.Close();
                    createCharacter.Show();
                }
                else
                {
                    MessageBox.Show("Limit of person is reached");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Limit of person is reached");
            }
            con.Close();
        }

        private void BackStatClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Visible;
            statGrid.Visibility = Visibility.Hidden;
            locationGrid.Visibility = Visibility.Hidden;
            skillGrid.Visibility = Visibility.Hidden;
            itemGrid.Visibility = Visibility.Hidden;
            monsterGrid.Visibility = Visibility.Hidden;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 0;
            updateCharacter();
        }

        private void BackLocationClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Visible;
            statGrid.Visibility = Visibility.Hidden;
            locationGrid.Visibility = Visibility.Hidden;
            skillGrid.Visibility = Visibility.Hidden;
            itemGrid.Visibility = Visibility.Hidden;
            monsterGrid.Visibility = Visibility.Hidden;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 0;
            updateCharacter();
        }

        private void BackSkillClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Visible;
            statGrid.Visibility = Visibility.Hidden;
            locationGrid.Visibility = Visibility.Hidden;
            skillGrid.Visibility = Visibility.Hidden;
            itemGrid.Visibility = Visibility.Hidden;
            monsterGrid.Visibility = Visibility.Hidden;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 0;
            updateCharacter();
        }

        private void BackItemClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Visible;
            statGrid.Visibility = Visibility.Hidden;
            locationGrid.Visibility = Visibility.Hidden;
            skillGrid.Visibility = Visibility.Hidden;
            itemGrid.Visibility = Visibility.Hidden;
            monsterGrid.Visibility = Visibility.Hidden;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 0;
            updateCharacter();
        }

        private void BackMonsterClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Hidden;
            statGrid.Visibility = Visibility.Visible;
            locationGrid.Visibility = Visibility.Visible;
            skillGrid.Visibility = Visibility.Visible;
            itemGrid.Visibility = Visibility.Visible;
            monsterGrid.Visibility = Visibility.Hidden;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 2;
            updateStat();
            updateLocation();
            updateSkill();
            updateItem();
        }

        private void BackMonsterSkillClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Hidden;
            statGrid.Visibility = Visibility.Hidden;
            locationGrid.Visibility = Visibility.Hidden;
            skillGrid.Visibility = Visibility.Hidden;
            itemGrid.Visibility = Visibility.Hidden;
            monsterGrid.Visibility = Visibility.Visible;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 5;
            updateMonster();
        }

        private void BackDropClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Hidden;
            statGrid.Visibility = Visibility.Hidden;
            locationGrid.Visibility = Visibility.Hidden;
            skillGrid.Visibility = Visibility.Hidden;
            itemGrid.Visibility = Visibility.Hidden;
            monsterGrid.Visibility = Visibility.Visible;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 5;
            updateMonster();
        }

        private void BackNPCClick(object sender, RoutedEventArgs e)
        {
            characterGrid.Visibility = Visibility.Hidden;
            statGrid.Visibility = Visibility.Visible;
            locationGrid.Visibility = Visibility.Visible;
            skillGrid.Visibility = Visibility.Visible;
            itemGrid.Visibility = Visibility.Visible;
            monsterGrid.Visibility = Visibility.Hidden;
            monsterSkillGrid.Visibility = Visibility.Hidden;
            dropGrid.Visibility = Visibility.Hidden;
            npcGrid.Visibility = Visibility.Hidden;
            tabControl.SelectedIndex = 2;
            updateStat();
            updateLocation();
            updateSkill();
            updateItem();
        }

        private void BackSettingClick(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Application.Current.Windows[0].Close();
        }

        public void updateCharacter()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT character_name, race_name, class_name, location_name, character_level FROM GAMEDBADMIN.character_info_view WHERE user_login = '" + user + "' ORDER BY character_level DESC, character_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            characterList.Children.Clear();
            while (reader.Read())
            {
                Character character = new Character(user, role, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt16(4));
                characterList.Children.Add(character);
            }
            con.Close();
        }

        public void updateStat()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT character_name, race_name, class_name, location_name, character_level, character_exp, character_health, character_max_health," +
                "character_mana, character_max_mana, character_power, character_speed, character_mind FROM GAMEDBADMIN.character_info_view WHERE character_name = '" + character + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                characterIcon.Source = new BitmapImage(uri) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                characterName.Text = reader.GetString(0);
                characterRace.Text = "Race: " + reader.GetString(1);
                characterClass.Text = "Class: " + reader.GetString(2);
                characterLocation.Text = "Location: " + reader.GetString(3);
                characterLevel.Text = "Level: " + reader.GetInt32(4).ToString() + " / 20";
                progressLevel.Value = reader.GetInt32(4);
                switch (reader.GetInt16(4))
                {
                    case 1: progressExp.Maximum = 4; break;
                    case 2: progressExp.Maximum = 8; break;
                    case 3: progressExp.Maximum = 16; break;
                    case 4: progressExp.Maximum = 32; break;
                    case 5: progressExp.Maximum = 64; break;
                    case 6: progressExp.Maximum = 128; break;
                    case 7: progressExp.Maximum = 256; break;
                    case 8: progressExp.Maximum = 512; break;
                    case 9: progressExp.Maximum = 1024; break;
                    case 10: progressExp.Maximum = 2048; break;
                    case 11: progressExp.Maximum = 4096; break;
                    case 12: progressExp.Maximum = 8192; break;
                    case 13: progressExp.Maximum = 16384; break;
                    case 14: progressExp.Maximum = 32768; break;
                    case 15: progressExp.Maximum = 65536; break;
                    case 16: progressExp.Maximum = 131072; break;
                    case 17: progressExp.Maximum = 262144; break;
                    case 18: progressExp.Maximum = 524288; break;
                    case 19: progressExp.Maximum = 1048576; break;
                    case 20: progressExp.Maximum = 2097152; break;
                }
                characterExp.Text = "Exp: " + reader.GetInt32(5).ToString() + " / " + progressExp.Maximum;
                progressExp.Value = reader.GetInt32(5);
                characterHealth.Text = "Health: " + reader.GetInt32(6).ToString() + " / " + reader.GetInt32(7).ToString();
                progressHealth.Value = reader.GetInt32(6);
                progressHealth.Maximum = reader.GetInt32(7);
                characterMana.Text = "Mana: " + reader.GetInt32(8).ToString() + " / " + reader.GetInt32(9).ToString();
                progressMana.Value = reader.GetInt32(8);
                progressMana.Maximum = reader.GetInt32(9);
                characterPower.Text = "Power: " + reader.GetInt32(10).ToString();
                characterSpeed.Text = "Speed: " + reader.GetInt32(11).ToString();
                characterMind.Text = "Mind: " + reader.GetInt32(12).ToString();
            }
            con.Close();
        }

        public void updateLocation()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT location_name, location_x, location_y, location_z, location_min_level, location_max_level FROM GAMEDBADMIN.location_table WHERE " +
                "(ABS(location_x - (SELECT location_x FROM GAMEDBADMIN.character_table LEFT JOIN GAMEDBADMIN.location_table ON character_table.character_location = location_table.location_id WHERE character_table.character_name = '" + character + "')) + " +
                "ABS(location_y - (SELECT location_y FROM GAMEDBADMIN.character_table LEFT JOIN GAMEDBADMIN.location_table ON character_table.character_location = location_table.location_id WHERE character_table.character_name = '" + character + "')) + " +
                "ABS(location_z - (SELECT location_z FROM GAMEDBADMIN.character_table LEFT JOIN GAMEDBADMIN.location_table ON character_table.character_location = location_table.location_id WHERE character_table.character_name = '" + character + "')) < 2) ORDER BY location_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            locationList.Children.Clear();
            while (reader.Read())
            {
                Location location = new Location(user, role, character, reader.GetString(0), uri);
                if (reader.GetString(0) == this.location)
                {
                    location.locateButton.IsEnabled = false;
                }
                else
                {
                    location.monstersButton.IsEnabled = false;
                    location.npcsButton.IsEnabled = false;
                }
                switch (reader.GetInt32(3))
                {
                    case 0: location.locationDimension.Text = "Dimension: Hell"; break;
                    case 1: location.locationDimension.Text = "Dimension: Earth"; break;
                    case 2: location.locationDimension.Text = "Dimension: Paradise"; break;
                }
                switch (3 * reader.GetInt32(1) + reader.GetInt32(2))
                {
                    case 0: location.locationWay.Text = "Way: North-West"; break;
                    case 1: location.locationWay.Text = "Way: North"; break;
                    case 2: location.locationWay.Text = "Way: North-East"; break;
                    case 3: location.locationWay.Text = "Way: West"; break;
                    case 4: location.locationWay.Text = "Way: Center"; break;
                    case 5: location.locationWay.Text = "Way: East"; break;
                    case 6: location.locationWay.Text = "Way: South-West"; break;
                    case 7: location.locationWay.Text = "Way: South"; break;
                    case 8: location.locationWay.Text = "Way: South-East"; break;
                }
                location.locationMinLevel.Text = "Min level: " + reader.GetInt32(4);
                location.locationMaxLevel.Text = "Max level: " + reader.GetInt32(5);
                locationList.Children.Add(location);
            }
            con.Close();
        }

        public void updateSkill()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT character_name, skill_name, race_name, class_name, skill_type_name, skill_health, skill_mana, skill_level FROM GAMEDBADMIN.character_skill_info_view WHERE character_name = '" + character + "' ORDER BY skill_level ASC, skill_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            characterList.Children.Clear();
            while (reader.Read())
            {
                Skill skill = new Skill(user, role, character, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt16(5), reader.GetInt16(6), reader.GetInt16(7));
                skillList.Children.Add(skill);
            }
            con.Close();
        }

        public void updateItem()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT item_name, item_type_name, item_health, item_mana, item_power, item_speed, item_mind FROM GAMEDBADMIN.character_item_info_view WHERE character_name = '" + character + "' ORDER BY item_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            itemList.Children.Clear();
            while (reader.Read())
            {
                Item item = new Item(user, role, character, reader.GetString(0), reader.GetString(1), reader.GetInt16(2), reader.GetInt16(3), reader.GetInt16(4), reader.GetInt16(5), reader.GetInt16(6));
                itemList.Children.Add(item);
            }
            con.Close();
        }

        public void updateMonster()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT monster_name, race_name, class_name, location_name, monster_level FROM GAMEDBADMIN.monster_info_view WHERE location_name = '" + location + "' ORDER BY monster_level ASC, monster_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            monsterList.Children.Clear();
            while (reader.Read())
            {
                Monster monster = new Monster(user, role, character, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt16(4), uri);
                monsterList.Children.Add(monster);
            }
            con.Close();
        }

        public void updateMonsterSkill()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT monster_name, skill_name, race_name, class_name, skill_type_name, skill_health, skill_mana, skill_level FROM GAMEDBADMIN.monster_skill_info_view WHERE monster_name = '" + monster + "' ORDER BY skill_level ASC, skill_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            monsterSkillList.Children.Clear();
            while (reader.Read())
            {
                MonsterSkill monsterSkill = new MonsterSkill(user, role, character, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt16(5), reader.GetInt16(6), reader.GetInt16(7));
                monsterSkillList.Children.Add(monsterSkill);
            }
            con.Close();
        }

        public void updateDrop()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT item_name, item_type_name, monster_item_chance, item_health, item_mana, item_power, item_speed, item_mind FROM GAMEDBADMIN.monster_item_info_view WHERE monster_name = '" + monster + "' ORDER BY item_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            dropList.Children.Clear();
            while (reader.Read())
            {
                Drop drop = new Drop(user, role, character, monster, reader.GetString(0), reader.GetString(1), reader.GetInt16(2), reader.GetInt16(3), reader.GetInt16(4), reader.GetInt16(5), reader.GetInt16(6), reader.GetInt16(7));
                dropList.Children.Add(drop);
            }
            con.Close();
        }

        public void updateNPC()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT npc_name, race_name, profession_name, location_name, npc_level FROM GAMEDBADMIN.npc_info_view WHERE location_name = '" + location + "' ORDER BY npc_level ASC, npc_name ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            npcList.Children.Clear();
            while (reader.Read())
            {
                NPC npc = new NPC(user, role, character, reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt16(4), uri);
                npcList.Children.Add(npc);
            }
            con.Close();
        }

        public void updateSetting()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.SEARCH_USER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
            cmd.Parameters.Add("O_USER_LOGIN", OracleDbType.Varchar2, 30);
            cmd.Parameters["O_USER_LOGIN"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("O_USER_PASSWORD", OracleDbType.Varchar2, 30);
            cmd.Parameters["O_USER_PASSWORD"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("O_USER_NAME", OracleDbType.Varchar2, 30);
            cmd.Parameters["O_USER_NAME"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("O_USER_SURNAME", OracleDbType.Varchar2, 30);
            cmd.Parameters["O_USER_SURNAME"].Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                settingUserLogin.Text = Convert.ToString(cmd.Parameters["O_USER_LOGIN"].Value);
                settingUserPassword.Text = Convert.ToString(cmd.Parameters["O_USER_PASSWORD"].Value);
                settingUserName.Text = Convert.ToString(cmd.Parameters["O_USER_NAME"].Value);
                settingUserSurname.Text = Convert.ToString(cmd.Parameters["O_USER_SURNAME"].Value);
            }
            catch (Exception exc)
            {
                MessageBox.Show("User is not found");
            }
            con.Close();
        }

        private void ChangeLoginClick(object sender, RoutedEventArgs e)
        {
            settingUserLogin.IsReadOnly = false;
            settingChangeLoginButton.IsEnabled = false;
            settingUpdateLoginButton.IsEnabled = true;
            settingCancelLoginButton.IsEnabled = true;
        }

        private void UpdateLoginClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you really want to update a user login?", "Update user login", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.UPDATE_USER_LOGIN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
                cmd.Parameters.Add("P_NEW_USER_LOGIN", OracleDbType.Varchar2, 30).Value = settingUserLogin.Text.Trim();
                try
                {
                    cmd.ExecuteNonQuery();
                    user = settingUserLogin.Text.Trim();
                    settingUserLogin.IsReadOnly = true;
                    settingChangeLoginButton.IsEnabled = true;
                    settingUpdateLoginButton.IsEnabled = false;
                    settingCancelLoginButton.IsEnabled = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("This user login using in system");
                }
                con.Close();
            }
            else
            {
                updateSetting();
            }
        }

        private void CancelLoginClick(object sender, RoutedEventArgs e)
        {
            settingUserLogin.IsReadOnly = true;
            settingChangeLoginButton.IsEnabled = true;
            settingUpdateLoginButton.IsEnabled = false;
            settingCancelLoginButton.IsEnabled = false;
            updateSetting();
        }

        private void ChangePasswordClick(object sender, RoutedEventArgs e)
        {
            settingUserPassword.IsReadOnly = false;
            settingChangePasswordButton.IsEnabled = false;
            settingUpdatePasswordButton.IsEnabled = true;
            settingCancelPasswordButton.IsEnabled = true;
        }

        private void UpdatePasswordClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you really want to update a user password?", "Update user password", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.UPDATE_USER_PASSWORD";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
                cmd.Parameters.Add("P_NEW_USER_PASSWORD", OracleDbType.Varchar2, 30).Value = settingUserPassword.Text.Trim();
                try
                {
                    cmd.ExecuteNonQuery();
                    settingUserPassword.IsReadOnly = true;
                    settingChangePasswordButton.IsEnabled = true;
                    settingUpdatePasswordButton.IsEnabled = false;
                    settingCancelPasswordButton.IsEnabled = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("User is not found");
                }
                con.Close();
            }
            else
            {
                updateSetting();
            }
        }

        private void CancelPasswordClick(object sender, RoutedEventArgs e)
        {
            settingUserPassword.IsReadOnly = true;
            settingChangePasswordButton.IsEnabled = true;
            settingUpdatePasswordButton.IsEnabled = false;
            settingCancelPasswordButton.IsEnabled = false;
            updateSetting();
        }

        private void ChangeNameClick(object sender, RoutedEventArgs e)
        {
            settingUserName.IsReadOnly = false;
            settingChangeNameButton.IsEnabled = false;
            settingUpdateNameButton.IsEnabled = true;
            settingCancelNameButton.IsEnabled = true;
        }

        private void UpdateNameClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you really want to update a user name?", "Update user name", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.UPDATE_USER_NAME";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
                cmd.Parameters.Add("P_NEW_USER_NAME", OracleDbType.Varchar2, 30).Value = settingUserName.Text.Trim();
                try
                {
                    cmd.ExecuteNonQuery();
                    settingUserName.IsReadOnly = true;
                    settingChangeNameButton.IsEnabled = true;
                    settingUpdateNameButton.IsEnabled = false;
                    settingCancelNameButton.IsEnabled = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("User is not found");
                }
                con.Close();
            }
            else
            {
                updateSetting();
            }
        }

        private void CancelNameClick(object sender, RoutedEventArgs e)
        {
            settingUserName.IsReadOnly = true;
            settingChangeNameButton.IsEnabled = true;
            settingUpdateNameButton.IsEnabled = false;
            settingCancelNameButton.IsEnabled = false;
            updateSetting();
        }

        private void ChangeSurnameClick(object sender, RoutedEventArgs e)
        {
            settingUserSurname.IsReadOnly = false;
            settingChangeSurnameButton.IsEnabled = false;
            settingUpdateSurnameButton.IsEnabled = true;
            settingCancelSurnameButton.IsEnabled = true;
        }

        private void UpdateSurnameClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you really want to update a user surname?", "Update user surname", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.UPDATE_USER_SURNAME";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
                cmd.Parameters.Add("P_NEW_USER_SURNAME", OracleDbType.Varchar2, 30).Value = settingUserSurname.Text.Trim();
                try
                {
                    cmd.ExecuteNonQuery();
                    settingUserSurname.IsReadOnly = true;
                    settingChangeSurnameButton.IsEnabled = true;
                    settingUpdateSurnameButton.IsEnabled = false;
                    settingCancelSurnameButton.IsEnabled = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("User is not found");
                }
                con.Close();
            }
            else
            {
                updateSetting();
            }
        }

        private void CancelSurnameClick(object sender, RoutedEventArgs e)
        {
            settingUserSurname.IsReadOnly = true;
            settingChangeSurnameButton.IsEnabled = true;
            settingUpdateSurnameButton.IsEnabled = false;
            settingCancelSurnameButton.IsEnabled = false;
            updateSetting();
        }

        private void DeleteUserClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you really want to delete a user?", "Delete user", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.DELETE_USER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
                try
                {
                    cmd.ExecuteNonQuery();
                    Login login = new Login();
                    login.Show();
                    Application.Current.Windows[0].Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("User is not found");
                }
                con.Close();
            }
        }

        private void GrantDonatClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.SET_DONAT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = donatUserLogin.Text.Trim();
            cmd.Parameters.Add("P_USER_DONAT", OracleDbType.Varchar2, 30).Value = "YES";
            try
            {
                cmd.ExecuteNonQuery();
                donatUserLogin.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("User is not found");
            }
            con.Close();
        }

        private void RevokeDonatClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.SET_DONAT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = donatUserLogin.Text.Trim();
            cmd.Parameters.Add("P_USER_DONAT", OracleDbType.Varchar2, 30).Value = "NO";
            try
            {
                cmd.ExecuteNonQuery();
                donatUserLogin.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("User is not found");
            }
            con.Close();
        }

        private void XMLExportClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.MONSTER_SKILL_EXPORT";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
                xmlExportButton.IsEnabled = false;
                insert100KButton.IsEnabled = true;
                xmlImportButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Export error");
            }
            con.Close();
        }

        private void Insert100KClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.INSERT_100K";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
                xmlExportButton.IsEnabled = false;
                insert100KButton.IsEnabled = false;
                xmlImportButton.IsEnabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Insert error");
            }
            con.Close();
        }

        private void XMLImportClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.MONSTER_SKILL_IMPORT";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
                xmlExportButton.IsEnabled = true;
                insert100KButton.IsEnabled = false;
                xmlImportButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Import error");
            }
            con.Close();
        }

        private void TableControlClick(object sender, RoutedEventArgs e)
        {
            TableControl tableControl = new TableControl();
            tableControl.Show();
            Application.Current.Windows[0].Visibility = Visibility.Hidden;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateCharacter();
            updateSetting();
            if (role == "OWNER")
            {
                deleteUserButton.IsEnabled = false;
                donatPanel.Visibility = Visibility.Visible;
                xmlPanel.Visibility = Visibility.Visible;
                tableControlButton.Visibility = Visibility.Visible;
            }
        }
    }
}
