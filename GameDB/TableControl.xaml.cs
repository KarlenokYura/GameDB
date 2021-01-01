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
    public partial class TableControl : Window
    {
        OracleConnection con = new OracleConnection();

        public TableControl()
        {
            con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBAdmin;PASSWORD=Pa$$w0rd";
            InitializeComponent();
        }

        #region selectTables

        public void selectRole()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.role_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            roleTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectUser()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT user_id, user_login, decryption_password(user_password), user_name, user_surname, user_donat, user_role FROM GAMEDBADMIN.user_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            userTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectRace()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.race_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            raceTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectClass()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.class_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            classTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectLocation()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.location_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            locationTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectCharacter()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.character_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            characterTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectMonster()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.monster_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            monsterTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectProfession()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.profession_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            professionTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectNPC()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.npc_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            npcTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectSkill_Type()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.skill_type_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            skill_TypeTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectSkill()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.skill_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            skillTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectCharacter_Skill()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.character_skill_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            character_SkillTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectMonster_Skill()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.monster_skill_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            monster_SkillTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectItem_Type()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.item_type_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            item_TypeTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectItem()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.item_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            itemTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectCharacter_Item()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.character_item_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            character_ItemTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        public void selectMonster_Item()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GAMEDBADMIN.monster_item_table";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            monster_ItemTable.ItemsSource = table.DefaultView;
            con.Close();
        }

        #endregion

        #region roleTable

        private void RoleInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO role_table (role_name) VALUES (UPPER(:ROLE_NAME))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("ROLE_NAME", OracleDbType.Varchar2, 30).Value = role_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                role_id.Clear();
                role_name.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectRole();
        }

        private void RoleUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE role_table SET role_name = UPPER(:ROLE_NAME) WHERE role_id = " + role_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("ROLE_NAME", OracleDbType.Varchar2, 30).Value = role_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                role_id.Clear();
                role_name.Clear();
                roleInsertButton.IsEnabled = true;
                roleUpdateButton.IsEnabled = false;
                roleDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectRole();
        }

        private void RoleDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM role_table WHERE role_id = " + role_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                role_id.Clear();
                role_name.Clear();
                roleInsertButton.IsEnabled = true;
                roleUpdateButton.IsEnabled = false;
                roleDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectRole();
        }

        private void RoleTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                role_id.Text = rowView["ROLE_ID"].ToString();
                role_name.Text = rowView["ROLE_NAME"].ToString();
                roleInsertButton.IsEnabled = false;
                roleUpdateButton.IsEnabled = true;
                roleDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region userTable

        private void UserInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO user_table (user_login, user_password, user_name, user_surname, user_donat, user_role) " +
                    "VALUES (UPPER(:USER_LOGIN), encryption_password(UPPER(:USER_PASSWORD)), UPPER(:USER_NAME), UPPER(:USER_SURNAME), UPPER(:USER_DONAT), UPPER(:USER_ROLE))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("USER_LOGIN", OracleDbType.Varchar2, 30).Value = user_login.Text.Trim();
                cmd.Parameters.Add("USER_PASSWORD", OracleDbType.Varchar2, 2000).Value = user_password.Text.Trim();
                cmd.Parameters.Add("USER_NAME", OracleDbType.Varchar2, 30).Value = user_name.Text.Trim();
                cmd.Parameters.Add("USER_SURNAME", OracleDbType.Varchar2, 30).Value = user_surname.Text.Trim();
                cmd.Parameters.Add("USER_DONAT", OracleDbType.Varchar2, 30).Value = user_donat.Text.Trim();
                int test = Convert.ToInt32(user_role.Text.Trim());
                cmd.Parameters.Add("USER_ROLE", OracleDbType.Int32, 10).Value = Convert.ToInt32(user_role.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    user_id.Clear();
                    user_login.Clear();
                    user_password.Clear();
                    user_name.Clear();
                    user_surname.Clear();
                    user_donat.Clear();
                    user_role.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectUser();
        }

        private void UserUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE user_table SET user_login = UPPER(:USER_LOGIN), user_password = encryption_password(UPPER(:USER_PASSWORD))," +
                "user_name = UPPER(:USER_NAME), user_surname = UPPER(:USER_SURNAME), user_donat = UPPER(:USER_DONAT)," +
                "user_role = UPPER(:USER_ROLE) WHERE user_id = " + user_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("USER_LOGIN", OracleDbType.Varchar2, 30).Value = user_login.Text.Trim();
            cmd.Parameters.Add("USER_PASSWORD", OracleDbType.Varchar2, 2000).Value = user_password.Text.Trim();
            cmd.Parameters.Add("USER_NAME", OracleDbType.Varchar2, 30).Value = user_name.Text.Trim();
            cmd.Parameters.Add("USER_SURNAME", OracleDbType.Varchar2, 30).Value = user_surname.Text.Trim();
            cmd.Parameters.Add("USER_DONAT", OracleDbType.Varchar2, 30).Value = user_donat.Text.Trim();
            cmd.Parameters.Add("USER_ROLE", OracleDbType.Int32, 10).Value = Convert.ToInt32(user_role.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                user_id.Clear();
                user_login.Clear();
                user_password.Clear();
                user_name.Clear();
                user_surname.Clear();
                user_donat.Clear();
                user_role.Clear();
                userInsertButton.IsEnabled = true;
                userUpdateButton.IsEnabled = false;
                userDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectUser();
        }

        private void UserDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM user_table WHERE user_id = " + user_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                user_id.Clear();
                user_login.Clear();
                user_password.Clear();
                user_name.Clear();
                user_surname.Clear();
                user_donat.Clear();
                user_role.Clear();
                userInsertButton.IsEnabled = true;
                userUpdateButton.IsEnabled = false;
                userDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectUser();
        }

        private void UserTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                user_id.Text = rowView["USER_ID"].ToString();
                user_login.Text = rowView["USER_LOGIN"].ToString();
                user_password.Text = rowView["decryption_password(USER_PASSWORD)"].ToString();
                user_name.Text = rowView["USER_NAME"].ToString();
                user_surname.Text = rowView["USER_SURNAME"].ToString();
                user_donat.Text = rowView["USER_DONAT"].ToString();
                user_role.Text = rowView["USER_ROLE"].ToString();
                userInsertButton.IsEnabled = false;
                userUpdateButton.IsEnabled = true;
                userDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region raceTable

        private void RaceInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO race_table (race_name, race_location) VALUES (UPPER(:RACE_NAME), UPPER(:RACE_LOCATION))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("RACE_NAME", OracleDbType.Varchar2, 30).Value = race_name.Text.Trim();
                cmd.Parameters.Add("RACE_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(race_location.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    race_id.Clear();
                    race_name.Clear();
                    race_location.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectRace();
        }

        private void RaceUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE race_table SET race_name = UPPER(:RACE_NAME), race_location = UPPER(:RACE_LOCATION) WHERE race_id = " + race_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("RACE_NAME", OracleDbType.Varchar2, 30).Value = race_name.Text.Trim();
            cmd.Parameters.Add("RACE_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(race_location.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                race_id.Clear();
                race_name.Clear();
                race_location.Clear();
                raceInsertButton.IsEnabled = true;
                raceUpdateButton.IsEnabled = false;
                raceDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectRace();
        }

        private void RaceDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM race_table WHERE race_id = " + race_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                race_id.Clear();
                race_name.Clear();
                race_location.Clear();
                raceInsertButton.IsEnabled = true;
                raceUpdateButton.IsEnabled = false;
                raceDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectRace();
        }

        private void RaceTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                race_id.Text = rowView["RACE_ID"].ToString();
                race_name.Text = rowView["RACE_NAME"].ToString();
                race_location.Text = rowView["RACE_LOCATION"].ToString();
                raceInsertButton.IsEnabled = false;
                raceUpdateButton.IsEnabled = true;
                raceDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region classTable

        private void ClassInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO class_table (class_name) VALUES (UPPER(:CLASS_NAME))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("CLASS_NAME", OracleDbType.Varchar2, 30).Value = class_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                class_id.Clear();
                class_name.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectClass();
        }

        private void ClassUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE class_table SET class_name = UPPER(:CLASS_NAME) WHERE class_id = " + class_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("CLASS_NAME", OracleDbType.Varchar2, 30).Value = class_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                class_id.Clear();
                class_name.Clear();
                classInsertButton.IsEnabled = true;
                classUpdateButton.IsEnabled = false;
                classDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectClass();
        }

        private void ClassDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM class_table WHERE class_id = " + class_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                class_id.Clear();
                class_name.Clear();
                classInsertButton.IsEnabled = true;
                classUpdateButton.IsEnabled = false;
                classDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectClass();
        }

        private void ClassTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                class_id.Text = rowView["CLASS_ID"].ToString();
                class_name.Text = rowView["CLASS_NAME"].ToString();
                classInsertButton.IsEnabled = false;
                classUpdateButton.IsEnabled = true;
                classDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region locationTable

        private void LocationInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO location_table (location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES " +
                    "(UPPER(:LOCATION_NAME), UPPER(:LOCATION_X), UPPER(:LOCATION_Y), UPPER(:LOCATION_Z), UPPER(:LOCATION_MIN_LEVEL), UPPER(:LOCATION_MAX_LEVEL))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("LOCATION_NAME", OracleDbType.Varchar2, 30).Value = location_name.Text.Trim();
                cmd.Parameters.Add("LOCATION_X", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_x.Text.Trim());
                cmd.Parameters.Add("LOCATION_Y", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_y.Text.Trim());
                cmd.Parameters.Add("LOCATION_Z", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_z.Text.Trim());
                cmd.Parameters.Add("LOCATION_MIN_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_min_level.Text.Trim());
                cmd.Parameters.Add("LOCATION_MAX_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_max_level.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.LOCATION_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_LOCATION_NAME", OracleDbType.Varchar2, 30).Value = location_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(location_blob.Text.Trim()) ? null : location_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }

                    location_id.Clear();
                    location_name.Clear();
                    location_x.Clear();
                    location_y.Clear();
                    location_z.Clear();
                    location_min_level.Clear();
                    location_max_level.Clear();
                    location_blob.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectLocation();
        }

        private void LocationUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE location_table SET location_name = UPPER(:LOCATION_NAME), location_x = UPPER(:LOCATION_X), location_y = UPPER(:LOCATION_Y), location_z = UPPER(:LOCATION_Z), " +
                "location_min_level = UPPER(:LOCATION_MIN_LEVEL), location_max_level = UPPER(:LOCATION_MAX_LEVEL) WHERE location_id = " + location_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("LOCATION_NAME", OracleDbType.Varchar2, 30).Value = location_name.Text.Trim();
            cmd.Parameters.Add("LOCATION_X", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_x.Text.Trim());
            cmd.Parameters.Add("LOCATION_Y", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_y.Text.Trim());
            cmd.Parameters.Add("LOCATION_Z", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_z.Text.Trim());
            cmd.Parameters.Add("LOCATION_MIN_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_min_level.Text.Trim());
            cmd.Parameters.Add("LOCATION_MAX_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(location_max_level.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();

                if (!String.IsNullOrEmpty(location_blob.Text.Trim()))
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.LOCATION_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_LOCATION_NAME", OracleDbType.Varchar2, 30).Value = location_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(location_blob.Text.Trim()) ? null : location_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }
                }

                location_id.Clear();
                location_name.Clear();
                location_x.Clear();
                location_y.Clear();
                location_z.Clear();
                location_min_level.Clear();
                location_max_level.Clear();
                location_blob.Clear();
                locationInsertButton.IsEnabled = true;
                locationUpdateButton.IsEnabled = false;
                locationDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectLocation();
        }

        private void LocationDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM location_table WHERE location_id = " + location_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                location_id.Clear();
                location_name.Clear();
                location_x.Clear();
                location_y.Clear();
                location_z.Clear();
                location_min_level.Clear();
                location_max_level.Clear();
                location_blob.Clear();
                locationInsertButton.IsEnabled = true;
                locationUpdateButton.IsEnabled = false;
                locationDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectLocation();
        }

        private void LocationTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                location_id.Text = rowView["LOCATION_ID"].ToString();
                location_name.Text = rowView["LOCATION_NAME"].ToString();
                location_x.Text = rowView["LOCATION_X"].ToString();
                location_y.Text = rowView["LOCATION_Y"].ToString();
                location_z.Text = rowView["LOCATION_Z"].ToString();
                location_min_level.Text = rowView["LOCATION_MIN_LEVEL"].ToString();
                location_max_level.Text = rowView["LOCATION_MAX_LEVEL"].ToString();
                location_blob.Text = rowView["LOCATION_NAME"].ToString() + ".PNG";
                locationInsertButton.IsEnabled = false;
                locationUpdateButton.IsEnabled = true;
                locationDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region characterTable

        private void CharacterInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO character_table (character_user, character_name, character_race, character_class, character_location, character_level, character_exp, " +
                    "character_health, character_max_health, character_mana, character_max_mana, character_power, character_speed, character_mind) VALUES " +
                    "(UPPER(:CHARACTER_USER), UPPER(:CHARACTER_NAME), UPPER(:CHARACTER_RACE), UPPER(:CHARACTER_CLASS), UPPER(:CHARACTER_LOCATION), UPPER(:CHARACTER_LEVEL), UPPER(:CHARACTER_EXP), " +
                    "UPPER(:CHARACTER_HEALTH), UPPER(:CHARACTER_MAX_HEALTH), UPPER(:CHARACTER_MANA), UPPER(:CHARACTER_MAX_MANA), UPPER(:CHARACTER_POWER), UPPER(:CHARACTER_SPEED), UPPER(:CHARACTER_MIND))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("CHARACTER_USER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_user.Text.Trim());
                cmd.Parameters.Add("CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character_name.Text.Trim();
                cmd.Parameters.Add("CHARACTER_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_race.Text.Trim());
                cmd.Parameters.Add("CHARACTER_CLASS", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_class.Text.Trim());
                cmd.Parameters.Add("CHARACTER_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_location.Text.Trim());
                cmd.Parameters.Add("CHARACTER_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_level.Text.Trim());
                cmd.Parameters.Add("CHARACTER_EXP", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_exp.Text.Trim());
                cmd.Parameters.Add("CHARACTER_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_health.Text.Trim());
                cmd.Parameters.Add("CHARACTER_MAX_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_max_health.Text.Trim());
                cmd.Parameters.Add("CHARACTER_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_mana.Text.Trim());
                cmd.Parameters.Add("CHARACTER_MAX_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_max_mana.Text.Trim());
                cmd.Parameters.Add("CHARACTER_POWER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_power.Text.Trim());
                cmd.Parameters.Add("CHARACTER_SPEED", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_speed.Text.Trim());
                cmd.Parameters.Add("CHARACTER_MIND", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_mind.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    character_id.Clear();
                    character_user.Clear();
                    character_name.Clear();
                    character_race.Clear();
                    character_class.Clear();
                    character_location.Clear();
                    character_level.Clear();
                    character_exp.Clear();
                    character_health.Clear();
                    character_max_health.Clear();
                    character_mana.Clear();
                    character_max_mana.Clear();
                    character_power.Clear();
                    character_speed.Clear();
                    character_mind.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectCharacter();
        }

        private void CharacterUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE character_table SET character_user = UPPER(:CHARACTER_USER), character_name = UPPER(:CHARACTER_NAME), character_race = UPPER(:CHARACTER_RACE), " +
                "character_class = UPPER(:CHARACTER_CLASS), character_location = UPPER(:CHARACTER_LOCATION), character_level = UPPER(:CHARACTER_LEVEL), character_exp = UPPER(:CHARACTER_EXP), " +
                "character_health = UPPER(:CHARACTER_HEALTH), character_max_health = UPPER(:CHARACTER_MAX_HEALTH), character_mana = UPPER(:CHARACTER_MANA), character_max_mana = UPPER(:CHARACTER_MAX_MANA), " +
                "character_power = UPPER(:CHARACTER_POWER), character_speed = UPPER(:CHARACTER_SPEED), character_mind = UPPER(:CHARACTER_MIND) WHERE character_id = " + character_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("CHARACTER_USER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_user.Text.Trim());
            cmd.Parameters.Add("CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character_name.Text.Trim();
            cmd.Parameters.Add("CHARACTER_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_race.Text.Trim());
            cmd.Parameters.Add("CHARACTER_CLASS", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_class.Text.Trim());
            cmd.Parameters.Add("CHARACTER_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_location.Text.Trim());
            cmd.Parameters.Add("CHARACTER_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_level.Text.Trim());
            cmd.Parameters.Add("CHARACTER_EXP", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_exp.Text.Trim());
            cmd.Parameters.Add("CHARACTER_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_health.Text.Trim());
            cmd.Parameters.Add("CHARACTER_MAX_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_max_health.Text.Trim());
            cmd.Parameters.Add("CHARACTER_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_mana.Text.Trim());
            cmd.Parameters.Add("CHARACTER_MAX_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_max_mana.Text.Trim());
            cmd.Parameters.Add("CHARACTER_POWER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_power.Text.Trim());
            cmd.Parameters.Add("CHARACTER_SPEED", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_speed.Text.Trim());
            cmd.Parameters.Add("CHARACTER_MIND", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_mind.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                character_id.Clear();
                character_user.Clear();
                character_name.Clear();
                character_race.Clear();
                character_class.Clear();
                character_location.Clear();
                character_level.Clear();
                character_exp.Clear();
                character_health.Clear();
                character_max_health.Clear();
                character_mana.Clear();
                character_max_mana.Clear();
                character_power.Clear();
                character_speed.Clear();
                character_mind.Clear();
                characterInsertButton.IsEnabled = true;
                characterUpdateButton.IsEnabled = false;
                characterDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectCharacter();
        }

        private void CharacterDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM character_table WHERE character_id = " + character_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                character_id.Clear();
                character_user.Clear();
                character_name.Clear();
                character_race.Clear();
                character_class.Clear();
                character_location.Clear();
                character_level.Clear();
                character_exp.Clear();
                character_health.Clear();
                character_max_health.Clear();
                character_mana.Clear();
                character_max_mana.Clear();
                character_power.Clear();
                character_speed.Clear();
                character_mind.Clear();
                characterInsertButton.IsEnabled = true;
                characterUpdateButton.IsEnabled = false;
                characterDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectCharacter();
        }

        private void CharacterTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                character_id.Text = rowView["CHARACTER_ID"].ToString();
                character_user.Text = rowView["CHARACTER_USER"].ToString();
                character_name.Text = rowView["CHARACTER_NAME"].ToString();
                character_race.Text = rowView["CHARACTER_RACE"].ToString();
                character_class.Text = rowView["CHARACTER_CLASS"].ToString();
                character_location.Text = rowView["CHARACTER_LOCATION"].ToString();
                character_level.Text = rowView["CHARACTER_LEVEL"].ToString();
                character_exp.Text = rowView["CHARACTER_EXP"].ToString();
                character_health.Text = rowView["CHARACTER_HEALTH"].ToString();
                character_max_health.Text = rowView["CHARACTER_MAX_HEALTH"].ToString();
                character_mana.Text = rowView["CHARACTER_MANA"].ToString();
                character_max_mana.Text = rowView["CHARACTER_MAX_MANA"].ToString();
                character_power.Text = rowView["CHARACTER_POWER"].ToString();
                character_speed.Text = rowView["CHARACTER_SPEED"].ToString();
                character_mind.Text = rowView["CHARACTER_MIND"].ToString();
                characterInsertButton.IsEnabled = false;
                characterUpdateButton.IsEnabled = true;
                characterDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region monsterTable

        private void MonsterInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO monster_table (monster_name, monster_race, monster_class, monster_location, monster_level, " +
                    "monster_health, monster_max_health, monster_mana, monster_max_mana, monster_power, monster_speed, monster_mind) VALUES " +
                    "(UPPER(:MONSTER_NAME), UPPER(:MONSTER_RACE), UPPER(:MONSTER_CLASS), UPPER(:MONSTER_LOCATION), UPPER(:MONSTER_LEVEL), " +
                    "UPPER(:MONSTER_HEALTH), UPPER(:MONSTER_MAX_HEALTH), UPPER(:MONSTER_MANA), UPPER(:MONSTER_MAX_MANA), UPPER(:MONSTER_POWER), UPPER(:MONSTER_SPEED), UPPER(:MONSTER_MIND))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("MONSTER_NAME", OracleDbType.Varchar2, 30).Value = monster_name.Text.Trim();
                cmd.Parameters.Add("MONSTER_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_race.Text.Trim());
                cmd.Parameters.Add("MONSTER_CLASS", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_class.Text.Trim());
                cmd.Parameters.Add("MONSTER_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_location.Text.Trim());
                cmd.Parameters.Add("MONSTER_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_level.Text.Trim());
                cmd.Parameters.Add("MONSTER_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_health.Text.Trim());
                cmd.Parameters.Add("MONSTER_MAX_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_max_health.Text.Trim());
                cmd.Parameters.Add("MONSTER_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_mana.Text.Trim());
                cmd.Parameters.Add("MONSTER_MAX_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_max_mana.Text.Trim());
                cmd.Parameters.Add("MONSTER_POWER", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_power.Text.Trim());
                cmd.Parameters.Add("MONSTER_SPEED", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_speed.Text.Trim());
                cmd.Parameters.Add("MONSTER_MIND", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_mind.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.MONSTER_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_MONSTER_NAME", OracleDbType.Varchar2, 30).Value = monster_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(monster_blob.Text.Trim()) ? null : monster_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }

                    monster_id.Clear();
                    monster_name.Clear();
                    monster_race.Clear();
                    monster_class.Clear();
                    monster_location.Clear();
                    monster_level.Clear();
                    monster_health.Clear();
                    monster_max_health.Clear();
                    monster_mana.Clear();
                    monster_max_mana.Clear();
                    monster_power.Clear();
                    monster_speed.Clear();
                    monster_mind.Clear();
                    monster_blob.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectMonster();
        }

        private void MonsterUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE monster_table SET monster_name = UPPER(:MONSTER_NAME), monster_race = UPPER(:MONSTER_RACE), " +
                "monster_class = UPPER(:MONSTER_CLASS), monster_location = UPPER(:MONSTER_LOCATION), monster_level = UPPER(:MONSTER_LEVEL), " +
                "monster_health = UPPER(:MONSTER_HEALTH), monster_max_health = UPPER(:MONSTER_MAX_HEALTH), monster_mana = UPPER(:MONSTER_MANA), monster_max_mana = UPPER(:MONSTER_MAX_MANA), " +
                "monster_power = UPPER(:MONSTER_POWER), monster_speed = UPPER(:MONSTER_SPEED), monster_mind = UPPER(:MONSTER_MIND) WHERE monster_id = " + monster_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("MONSTER_NAME", OracleDbType.Varchar2, 30).Value = monster_name.Text.Trim();
            cmd.Parameters.Add("MONSTER_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_race.Text.Trim());
            cmd.Parameters.Add("MONSTER_CLASS", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_class.Text.Trim());
            cmd.Parameters.Add("MONSTER_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_location.Text.Trim());
            cmd.Parameters.Add("MONSTER_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_level.Text.Trim());
            cmd.Parameters.Add("MONSTER_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_health.Text.Trim());
            cmd.Parameters.Add("MONSTER_MAX_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_max_health.Text.Trim());
            cmd.Parameters.Add("MONSTER_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_mana.Text.Trim());
            cmd.Parameters.Add("MONSTER_MAX_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_max_mana.Text.Trim());
            cmd.Parameters.Add("MONSTER_POWER", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_power.Text.Trim());
            cmd.Parameters.Add("MONSTER_SPEED", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_speed.Text.Trim());
            cmd.Parameters.Add("MONSTER_MIND", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_mind.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();

                if (!String.IsNullOrEmpty(location_blob.Text.Trim()))
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.MONSTER_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_MONSTER_NAME", OracleDbType.Varchar2, 30).Value = monster_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(monster_blob.Text.Trim()) ? null : monster_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }
                }

                monster_id.Clear();
                monster_name.Clear();
                monster_race.Clear();
                monster_class.Clear();
                monster_location.Clear();
                monster_level.Clear();
                monster_health.Clear();
                monster_max_health.Clear();
                monster_mana.Clear();
                monster_max_mana.Clear();
                monster_power.Clear();
                monster_speed.Clear();
                monster_mind.Clear();
                monster_blob.Clear();
                monsterInsertButton.IsEnabled = true;
                monsterUpdateButton.IsEnabled = false;
                monsterDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectMonster();
        }

        private void MonsterDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM monster_table WHERE monster_id = " + monster_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                monster_id.Clear();
                monster_name.Clear();
                monster_race.Clear();
                monster_class.Clear();
                monster_location.Clear();
                monster_level.Clear();
                monster_health.Clear();
                monster_max_health.Clear();
                monster_mana.Clear();
                monster_max_mana.Clear();
                monster_power.Clear();
                monster_speed.Clear();
                monster_mind.Clear();
                monster_blob.Clear();
                monsterInsertButton.IsEnabled = true;
                monsterUpdateButton.IsEnabled = false;
                monsterDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectMonster();
        }

        private void MonsterTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                monster_id.Text = rowView["MONSTER_ID"].ToString();
                monster_name.Text = rowView["MONSTER_NAME"].ToString();
                monster_race.Text = rowView["MONSTER_RACE"].ToString();
                monster_class.Text = rowView["MONSTER_CLASS"].ToString();
                monster_location.Text = rowView["MONSTER_LOCATION"].ToString();
                monster_level.Text = rowView["MONSTER_LEVEL"].ToString();
                monster_health.Text = rowView["MONSTER_HEALTH"].ToString();
                monster_max_health.Text = rowView["MONSTER_MAX_HEALTH"].ToString();
                monster_mana.Text = rowView["MONSTER_MANA"].ToString();
                monster_max_mana.Text = rowView["MONSTER_MAX_MANA"].ToString();
                monster_power.Text = rowView["MONSTER_POWER"].ToString();
                monster_speed.Text = rowView["MONSTER_SPEED"].ToString();
                monster_mind.Text = rowView["MONSTER_MIND"].ToString();
                monster_blob.Text = rowView["MONSTER_NAME"].ToString() + ".PNG";
                monsterInsertButton.IsEnabled = false;
                monsterUpdateButton.IsEnabled = true;
                monsterDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region professionTable

        private void ProfessionInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO profession_table (profession_name) VALUES (UPPER(:PROFESSION_NAME))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("PROFESSION_NAME", OracleDbType.Varchar2, 30).Value = profession_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                profession_id.Clear();
                profession_name.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectProfession();
        }

        private void ProfessionUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE profession_table SET profession_name = UPPER(:PROFESSION_NAME) WHERE profession_id = " + profession_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("PROFESSION_NAME", OracleDbType.Varchar2, 30).Value = profession_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                profession_id.Clear();
                profession_name.Clear();
                professionInsertButton.IsEnabled = true;
                professionUpdateButton.IsEnabled = false;
                professionDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectProfession();
        }

        private void ProfessionDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM profession_table WHERE profession_id = " + profession_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                profession_id.Clear();
                profession_name.Clear();
                professionInsertButton.IsEnabled = true;
                professionUpdateButton.IsEnabled = false;
                professionDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectProfession();
        }

        private void ProfessionTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                profession_id.Text = rowView["PROFESSION_ID"].ToString();
                profession_name.Text = rowView["PROFESSION_NAME"].ToString();
                professionInsertButton.IsEnabled = false;
                professionUpdateButton.IsEnabled = true;
                professionDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region npcTable

        private void NPCInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO npc_table (npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES " +
                    "(UPPER(:NPC_NAME), UPPER(:NPC_RACE), UPPER(:NPC_PROFESSION), UPPER(:NPC_LOCATION), UPPER(:NPC_LEVEL))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("NPC_NAME", OracleDbType.Varchar2, 30).Value = npc_name.Text.Trim();
                cmd.Parameters.Add("NPC_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_race.Text.Trim());
                cmd.Parameters.Add("NPC_PROFESSION", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_profession.Text.Trim());
                cmd.Parameters.Add("NPC_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_location.Text.Trim());
                cmd.Parameters.Add("NPC_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_level.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.NPC_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_NPC_NAME", OracleDbType.Varchar2, 30).Value = npc_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(npc_blob.Text.Trim()) ? null : npc_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }

                    npc_id.Clear();
                    npc_name.Clear();
                    npc_race.Clear();
                    npc_profession.Clear();
                    npc_location.Clear();
                    npc_level.Clear();
                    npc_blob.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectNPC();
        }

        private void NPCUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE npc_table SET npc_name = UPPER(:NPC_NAME), npc_race = UPPER(:NPC_RACE), " +
                "npc_profession = UPPER(:NPC_PROFESSION), npc_location = UPPER(:NPC_LOCATION), npc_level = UPPER(:NPC_LEVEL) WHERE npc_id = " + npc_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("NPC_NAME", OracleDbType.Varchar2, 30).Value = npc_name.Text.Trim();
            cmd.Parameters.Add("NPC_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_race.Text.Trim());
            cmd.Parameters.Add("NPC_PROFESSION", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_profession.Text.Trim());
            cmd.Parameters.Add("NPC_LOCATION", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_location.Text.Trim());
            cmd.Parameters.Add("NPC_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(npc_level.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();

                if (!String.IsNullOrEmpty(npc_blob.Text.Trim()))
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.NPC_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_NPC_NAME", OracleDbType.Varchar2, 30).Value = npc_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(npc_blob.Text.Trim()) ? null : npc_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }
                }

                npc_id.Clear();
                npc_name.Clear();
                npc_race.Clear();
                npc_profession.Clear();
                npc_location.Clear();
                npc_level.Clear();
                npc_blob.Clear();
                npcInsertButton.IsEnabled = true;
                npcUpdateButton.IsEnabled = false;
                npcDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectNPC();
        }

        private void NPCDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM npc_table WHERE npc_id = " + npc_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                npc_id.Clear();
                npc_name.Clear();
                npc_race.Clear();
                npc_profession.Clear();
                npc_location.Clear();
                npc_level.Clear();
                npc_blob.Clear();
                npcInsertButton.IsEnabled = true;
                npcUpdateButton.IsEnabled = false;
                npcDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectNPC();
        }

        private void NPCTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                npc_id.Text = rowView["NPC_ID"].ToString();
                npc_name.Text = rowView["NPC_NAME"].ToString();
                npc_race.Text = rowView["NPC_RACE"].ToString();
                npc_profession.Text = rowView["NPC_PROFESSION"].ToString();
                npc_location.Text = rowView["NPC_LOCATION"].ToString();
                npc_level.Text = rowView["NPC_LEVEL"].ToString();
                npc_blob.Text = rowView["NPC_NAME"].ToString() + ".PNG";
                npcInsertButton.IsEnabled = false;
                npcUpdateButton.IsEnabled = true;
                npcDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region skill_TypeTable

        private void Skill_TypeInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO skill_type_table (skill_type_name) VALUES (UPPER(:SKILL_TYPE_NAME))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("SKILL_TYPE_NAME", OracleDbType.Varchar2, 30).Value = skill_type_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                skill_type_id.Clear();
                skill_type_name.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectSkill_Type();
        }

        private void Skill_TypeUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE skill_type_table SET skill_type_name = UPPER(:SKILL_TYPE_NAME) WHERE skill_type_id = " + skill_type_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("SKILL_TYPE_NAME", OracleDbType.Varchar2, 30).Value = skill_type_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                skill_type_id.Clear();
                skill_type_name.Clear();
                skill_TypeInsertButton.IsEnabled = true;
                skill_TypeUpdateButton.IsEnabled = false;
                skill_TypeDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectSkill_Type();
        }

        private void Skill_TypeDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM skill_type_table WHERE skill_type_id = " + skill_type_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                skill_type_id.Clear();
                skill_type_name.Clear();
                skill_TypeInsertButton.IsEnabled = true;
                skill_TypeUpdateButton.IsEnabled = false;
                skill_TypeDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectSkill_Type();
        }

        private void Skill_TypeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                skill_type_id.Text = rowView["SKILL_TYPE_ID"].ToString();
                skill_type_name.Text = rowView["SKILL_TYPE_NAME"].ToString();
                skill_TypeInsertButton.IsEnabled = false;
                skill_TypeUpdateButton.IsEnabled = true;
                skill_TypeDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region skillTable

        private void SkillInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO skill_table (skill_name, skill_race, skill_class, skill_type, skill_health, skill_mana, skill_level) VALUES " +
                    "(UPPER(:SKILL_NAME), UPPER(:SKILL_RACE), UPPER(:SKILL_CLASS), UPPER(:SKILL_TYPE), UPPER(:SKILL_HEALTH), UPPER(:SKILL_MANA), UPPER(:SKILL_LEVEL))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("SKILL_NAME", OracleDbType.Varchar2, 30).Value = skill_name.Text.Trim();
                cmd.Parameters.Add("SKILL_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_race.Text.Trim());
                cmd.Parameters.Add("SKILL_CLASS", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_class.Text.Trim());
                cmd.Parameters.Add("SKILL_TYPE", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_type.Text.Trim());
                cmd.Parameters.Add("SKILL_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_health.Text.Trim());
                cmd.Parameters.Add("SKILL_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_mana.Text.Trim());
                cmd.Parameters.Add("SKILL_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_level.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.SKILL_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_SKILL_NAME", OracleDbType.Varchar2, 30).Value = skill_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(skill_blob.Text.Trim()) ? null : skill_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }

                    skill_id.Clear();
                    skill_name.Clear();
                    skill_race.Clear();
                    skill_class.Clear();
                    skill_type.Clear();
                    skill_health.Clear();
                    skill_mana.Clear();
                    skill_level.Clear();
                    skill_blob.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectSkill();
        }

        private void SkillUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE skill_table SET skill_name = UPPER(:SKILL_NAME), skill_race = UPPER(:SKILL_RACE), skill_class = UPPER(:SKILL_CLASS), " +
                "skill_type = UPPER(:SKILL_TYPE), skill_health = UPPER(:SKILL_HEALTH), skill_mana = UPPER(:SKILL_MANA), skill_level = UPPER(:SKILL_LEVEL) WHERE skill_id = " + skill_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("SKILL_NAME", OracleDbType.Varchar2, 30).Value = skill_name.Text.Trim();
            cmd.Parameters.Add("SKILL_RACE", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_race.Text.Trim());
            cmd.Parameters.Add("SKILL_CLASS", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_class.Text.Trim());
            cmd.Parameters.Add("SKILL_TYPE", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_type.Text.Trim());
            cmd.Parameters.Add("SKILL_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_health.Text.Trim());
            cmd.Parameters.Add("SKILL_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_mana.Text.Trim());
            cmd.Parameters.Add("SKILL_LEVEL", OracleDbType.Int32, 10).Value = Convert.ToInt32(skill_level.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();

                if (!String.IsNullOrEmpty(skill_blob.Text.Trim()))
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.SKILL_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_SKILL_NAME", OracleDbType.Varchar2, 30).Value = skill_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(skill_blob.Text.Trim()) ? null : skill_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }
                }

                skill_id.Clear();
                skill_name.Clear();
                skill_race.Clear();
                skill_class.Clear();
                skill_type.Clear();
                skill_health.Clear();
                skill_mana.Clear();
                skill_level.Clear();
                skill_blob.Clear();
                skillInsertButton.IsEnabled = true;
                skillUpdateButton.IsEnabled = false;
                skillDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectSkill();
        }

        private void SkillDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM skill_table WHERE skill_id = " + skill_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                skill_id.Clear();
                skill_name.Clear();
                skill_race.Clear();
                skill_class.Clear();
                skill_type.Clear();
                skill_health.Clear();
                skill_mana.Clear();
                skill_level.Clear();
                skill_blob.Clear();
                skillInsertButton.IsEnabled = true;
                skillUpdateButton.IsEnabled = false;
                skillDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectSkill();
        }

        private void SkillTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                skill_id.Text = rowView["SKILL_ID"].ToString();
                skill_name.Text = rowView["SKILL_NAME"].ToString();
                skill_race.Text = rowView["SKILL_RACE"].ToString();
                skill_class.Text = rowView["SKILL_CLASS"].ToString();
                skill_type.Text = rowView["SKILL_TYPE"].ToString();
                skill_health.Text = rowView["SKILL_HEALTH"].ToString();
                skill_mana.Text = rowView["SKILL_MANA"].ToString();
                skill_level.Text = rowView["SKILL_LEVEL"].ToString();
                skill_blob.Text = rowView["SKILL_NAME"].ToString() + ".PNG";
                skillInsertButton.IsEnabled = false;
                skillUpdateButton.IsEnabled = true;
                skillDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region character_SkillTable

        private void Character_SkillInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO character_skill_table (character_skill_character, character_skill_skill) VALUES (UPPER(:CHARACTER_SKILL_CHARACTER), UPPER(:CHARACTER_SKILL_SKILL))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("CHARACTER_SKILL_CHARACTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_skill_character.Text.Trim());
            cmd.Parameters.Add("CHARACRER_SKILL_SKILL", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_skill_skill.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                character_skill_id.Clear();
                character_skill_character.Clear();
                character_skill_skill.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectCharacter_Skill();
        }

        private void Character_SkillUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE character_skill_table SET character_skill_character = UPPER(:CHARACTER_SKILL_CHARACTER), character_skill_skill = UPPER(:CHARACTER_SKILL_SKILL) WHERE character_skill_id = " + character_skill_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("CHARACTER_SKILL_CHARACTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_skill_character.Text.Trim());
            cmd.Parameters.Add("CHARACRER_SKILL_SKILL", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_skill_skill.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                character_skill_id.Clear();
                character_skill_character.Clear();
                character_skill_skill.Clear();
                character_SkillInsertButton.IsEnabled = true;
                character_SkillUpdateButton.IsEnabled = false;
                character_SkillDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectCharacter_Skill();
        }

        private void Character_SkillDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM character_skill_table WHERE character_skill_id = " + character_skill_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                character_skill_id.Clear();
                character_skill_character.Clear();
                character_skill_skill.Clear();
                character_SkillInsertButton.IsEnabled = true;
                character_SkillUpdateButton.IsEnabled = false;
                character_SkillDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectCharacter_Skill();
        }

        private void Character_SkillTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                character_skill_id.Text = rowView["CHARACTER_SKILL_ID"].ToString();
                character_skill_character.Text = rowView["CHARACTER_SKILL_CHARACTER"].ToString();
                character_skill_skill.Text = rowView["CHARACTER_SKILL_SKILL"].ToString();
                character_SkillInsertButton.IsEnabled = false;
                character_SkillUpdateButton.IsEnabled = true;
                character_SkillDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region monster_SkillTable

        private void Monster_SkillInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO monster_skill_table (monster_skill_monster, monster_skill_skill) VALUES (UPPER(:MONSTER_SKILL_MONSTER), UPPER(:MONSTER_SKILL_SKILL))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("MONSTER_SKILL_MONSTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_skill_monster.Text.Trim());
            cmd.Parameters.Add("MONSTER_SKILL_SKILL", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_skill_skill.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                monster_skill_id.Clear();
                monster_skill_monster.Clear();
                monster_skill_skill.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectMonster_Skill();
        }

        private void Monster_SkillUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE monster_skill_table SET monster_skill_monster = UPPER(:MONSTER_SKILL_MONSTER), monster_skill_skill = UPPER(:MONSTER_SKILL_SKILL) WHERE monster_skill_id = " + monster_skill_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("MONSTER_SKILL_MONSTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_skill_monster.Text.Trim());
            cmd.Parameters.Add("MONSTER_SKILL_SKILL", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_skill_skill.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                monster_skill_id.Clear();
                monster_skill_monster.Clear();
                monster_skill_skill.Clear();
                monster_SkillInsertButton.IsEnabled = true;
                monster_SkillUpdateButton.IsEnabled = false;
                monster_SkillDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectMonster_Skill();
        }

        private void Monster_SkillDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM monster_skill_table WHERE monster_skill_id = " + monster_skill_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                monster_skill_id.Clear();
                monster_skill_monster.Clear();
                monster_skill_skill.Clear();
                monster_SkillInsertButton.IsEnabled = true;
                monster_SkillUpdateButton.IsEnabled = false;
                monster_SkillDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectMonster_Skill();
        }

        private void Monster_SkillTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                monster_skill_id.Text = rowView["MONSTER_SKILL_ID"].ToString();
                monster_skill_monster.Text = rowView["MONSTER_SKILL_MONSTER"].ToString();
                monster_skill_skill.Text = rowView["MONSTER_SKILL_SKILL"].ToString();
                monster_SkillInsertButton.IsEnabled = false;
                monster_SkillUpdateButton.IsEnabled = true;
                monster_SkillDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region item_TypeTable

        private void Item_TypeInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO item_type_table (item_type_name) VALUES (UPPER(:ITEM_TYPE_NAME))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("ITEM_TYPE_NAME", OracleDbType.Varchar2, 30).Value = item_type_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                item_type_id.Clear();
                item_type_name.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectItem_Type();
        }

        private void Item_TypeUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE item_type_table SET item_type_name = UPPER(:ITEM_TYPE_NAME) WHERE item_type_id = " + item_type_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("ITEM_TYPE_NAME", OracleDbType.Varchar2, 30).Value = item_type_name.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                item_type_id.Clear();
                item_type_name.Clear();
                item_TypeInsertButton.IsEnabled = true;
                item_TypeUpdateButton.IsEnabled = false;
                item_TypeDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectItem_Type();
        }

        private void Item_TypeDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM item_type_table WHERE item_type_id = " + item_type_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                item_type_id.Clear();
                item_type_name.Clear();
                item_TypeInsertButton.IsEnabled = true;
                item_TypeUpdateButton.IsEnabled = false;
                item_TypeDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectItem_Type();
        }

        private void Item_TypeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                item_type_id.Text = rowView["ITEM_TYPE_ID"].ToString();
                item_type_name.Text = rowView["ITEM_TYPE_NAME"].ToString();
                item_TypeInsertButton.IsEnabled = false;
                item_TypeUpdateButton.IsEnabled = true;
                item_TypeDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region itemTable

        private void ItemInsertClick(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO item_table (item_name, item_type, item_health, item_mana, item_power, item_speed, item_mind) VALUES " +
                    "(UPPER(:ITEM_NAME), UPPER(:ITEM_TYPE), UPPER(:ITEM_HEALTH), UPPER(:ITEM_MANA), UPPER(:ITEM_POWER), UPPER(:ITEM_SPEED), UPPER(:ITEM_MIND))";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("ITEM_NAME", OracleDbType.Varchar2, 30).Value = item_name.Text.Trim();
                cmd.Parameters.Add("ITEM_TYPE", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_type.Text.Trim());
                cmd.Parameters.Add("ITEM_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_health.Text.Trim());
                cmd.Parameters.Add("ITEM_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_mana.Text.Trim());
                cmd.Parameters.Add("ITEM_POWER", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_power.Text.Trim());
                cmd.Parameters.Add("ITEM_SPEED", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_speed.Text.Trim());
                cmd.Parameters.Add("ITEM_MIND", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_mind.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.ITEM_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_ITEM_NAME", OracleDbType.Varchar2, 30).Value = item_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(item_blob.Text.Trim()) ? null : item_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }

                    item_id.Clear();
                    item_name.Clear();
                    item_type.Clear();
                    item_health.Clear();
                    item_mana.Clear();
                    item_power.Clear();
                    item_speed.Clear();
                    item_mind.Clear();
                    item_blob.Clear();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Data is not found");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectItem();
        }

        private void ItemUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE item_table SET item_name = UPPER(:ITEM_NAME), item_type = UPPER(:ITEM_TYPE), item_health = UPPER(:ITEM_HEALTH), " +
                "item_mana = UPPER(:ITEM_MANA), item_power = UPPER(:ITEM_POWER), item_speed = UPPER(:ITEM_SPEED), item_mind = UPPER(:ITEM_MIND) WHERE item_id = " + item_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("ITEM_NAME", OracleDbType.Varchar2, 30).Value = item_name.Text.Trim();
            cmd.Parameters.Add("ITEM_TYPE", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_type.Text.Trim());
            cmd.Parameters.Add("ITEM_HEALTH", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_health.Text.Trim());
            cmd.Parameters.Add("ITEM_MANA", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_mana.Text.Trim());
            cmd.Parameters.Add("ITEM_POWER", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_power.Text.Trim());
            cmd.Parameters.Add("ITEM_SPEED", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_speed.Text.Trim());
            cmd.Parameters.Add("ITEM_MIND", OracleDbType.Int32, 10).Value = Convert.ToInt32(item_mind.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();

                if (!String.IsNullOrEmpty(item_blob.Text.Trim()))
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "GAMEDBADMIN.ITEM_IMAGE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_ITEM_NAME", OracleDbType.Varchar2, 30).Value = item_name.Text.Trim();
                    cmd.Parameters.Add("P_IMAGE_NAME", OracleDbType.Varchar2, 30).Value = String.IsNullOrEmpty(item_blob.Text.Trim()) ? null : item_blob.Text.Trim();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Image error");
                    }
                }

                item_id.Clear();
                item_name.Clear();
                item_type.Clear();
                item_health.Clear();
                item_mana.Clear();
                item_power.Clear();
                item_speed.Clear();
                item_mind.Clear();
                item_blob.Clear();
                itemInsertButton.IsEnabled = true;
                itemUpdateButton.IsEnabled = false;
                itemDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectItem();
        }

        private void ItemDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM item_table WHERE item_id = " + item_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                item_id.Clear();
                item_name.Clear();
                item_type.Clear();
                item_health.Clear();
                item_mana.Clear();
                item_power.Clear();
                item_speed.Clear();
                item_mind.Clear();
                item_blob.Clear();
                itemInsertButton.IsEnabled = true;
                itemUpdateButton.IsEnabled = false;
                itemDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectItem();
        }

        private void ItemTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                item_id.Text = rowView["ITEM_ID"].ToString();
                item_name.Text = rowView["ITEM_NAME"].ToString();
                item_type.Text = rowView["ITEM_TYPE"].ToString();
                item_health.Text = rowView["ITEM_HEALTH"].ToString();
                item_mana.Text = rowView["ITEM_MANA"].ToString();
                item_power.Text = rowView["ITEM_POWER"].ToString();
                item_speed.Text = rowView["ITEM_SPEED"].ToString();
                item_mind.Text = rowView["ITEM_MIND"].ToString();
                item_blob.Text = rowView["ITEM_NAME"].ToString() + ".PNG";
                itemInsertButton.IsEnabled = false;
                itemUpdateButton.IsEnabled = true;
                itemDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region character_ItemTable

        private void Character_ItemInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO character_item_table (character_item_character, character_item_item) VALUES (UPPER(:CHARACTER_ITEM_CHARACTER), UPPER(:CHARACTER_ITEM_ITEM))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("CHARACTER_ITEM_CHARACTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_item_character.Text.Trim());
            cmd.Parameters.Add("CHARACRER_ITEM_ITEM", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_item_item.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                character_item_id.Clear();
                character_item_character.Clear();
                character_item_item.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectCharacter_Item();
        }

        private void Character_ItemUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE character_item_table SET character_item_character = UPPER(:CHARACTER_ITEM_CHARACTER), character_item_item = UPPER(:CHARACTER_ITEM_ITEM) WHERE character_item_id = " + character_item_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("CHARACTER_ITEM_CHARACTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_item_character.Text.Trim());
            cmd.Parameters.Add("CHARACRER_ITEM_ITEM", OracleDbType.Int32, 10).Value = Convert.ToInt32(character_item_item.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                character_item_id.Clear();
                character_item_character.Clear();
                character_item_item.Clear();
                character_ItemInsertButton.IsEnabled = true;
                character_ItemUpdateButton.IsEnabled = false;
                character_ItemDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectCharacter_Item();
        }

        private void Character_ItemDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM character_item_table WHERE character_item_id = " + character_item_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                character_item_id.Clear();
                character_item_character.Clear();
                character_item_item.Clear();
                character_ItemInsertButton.IsEnabled = true;
                character_ItemUpdateButton.IsEnabled = false;
                character_ItemDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectCharacter_Item();
        }

        private void Character_ItemTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                character_item_id.Text = rowView["CHARACTER_ITEM_ID"].ToString();
                character_item_character.Text = rowView["CHARACTER_ITEM_CHARACTER"].ToString();
                character_item_item.Text = rowView["CHARACTER_ITEM_ITEM"].ToString();
                character_ItemInsertButton.IsEnabled = false;
                character_ItemUpdateButton.IsEnabled = true;
                character_ItemDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        #region monster_ItemTable

        private void Monster_ItemInsertClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO monster_item_table (monster_item_monster, monster_item_item, monster_item_chance) VALUES (UPPER(:MONSTER_ITEM_MONSTER), UPPER(:MONSTER_ITEM_ITEM), UPPER(:MONSTER_ITEM_CHANCE))";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("MONSTER_ITEM_MONSTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_item_monster.Text.Trim());
            cmd.Parameters.Add("MONSTER_ITEM_ITEM", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_item_item.Text.Trim());
            cmd.Parameters.Add("MONSTER_ITEM_CHANCE", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_item_chance.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                monster_item_id.Clear();
                monster_item_monster.Clear();
                monster_item_item.Clear();
                monster_item_chance.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill all field");
            }
            con.Close();

            selectMonster_Item();
        }

        private void Monster_ItemUpdateClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE monster_item_table SET monster_item_monster = UPPER(:MONSTER_ITEM_MONSTER), monster_item_item = UPPER(:MONSTER_ITEM_ITEM), monster_item_chance = UPPER(:MONSTER_ITEM_CHANCE) WHERE monster_item_id = " + monster_item_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("MONSTER_ITEM_MONSTER", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_item_monster.Text.Trim());
            cmd.Parameters.Add("MONSTER_ITEM_ITEM", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_item_item.Text.Trim());
            cmd.Parameters.Add("MONSTER_ITEM_CHANCE", OracleDbType.Int32, 10).Value = Convert.ToInt32(monster_item_chance.Text.Trim());
            try
            {
                cmd.ExecuteNonQuery();
                monster_item_id.Clear();
                monster_item_monster.Clear();
                monster_item_item.Clear();
                monster_item_chance.Clear();
                monster_ItemInsertButton.IsEnabled = true;
                monster_ItemUpdateButton.IsEnabled = false;
                monster_ItemDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is not found");
            }
            con.Close();

            selectMonster_Item();
        }

        private void Monster_ItemDeleteClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM monster_item_table WHERE monster_item_id = " + monster_item_id.Text.Trim();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                monster_item_id.Clear();
                monster_item_monster.Clear();
                monster_item_item.Clear();
                monster_item_chance.Clear();
                monster_ItemInsertButton.IsEnabled = true;
                monster_ItemUpdateButton.IsEnabled = false;
                monster_ItemDeleteButton.IsEnabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data is used");
            }
            con.Close();

            selectMonster_Item();
        }

        private void Monster_ItemTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            DataRowView rowView = grid.SelectedItem as DataRowView;
            if (rowView != null)
            {
                monster_item_id.Text = rowView["MONSTER_ITEM_ID"].ToString();
                monster_item_monster.Text = rowView["MONSTER_ITEM_MONSTER"].ToString();
                monster_item_item.Text = rowView["MONSTER_ITEM_ITEM"].ToString();
                monster_item_chance.Text = rowView["MONSTER_ITEM_CHANCE"].ToString();
                monster_ItemInsertButton.IsEnabled = false;
                monster_ItemUpdateButton.IsEnabled = true;
                monster_ItemDeleteButton.IsEnabled = true;
            }
        }

        #endregion

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Visibility = Visibility.Visible;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();

            selectRole();
            selectUser();
            selectRace();
            selectClass();
            selectLocation();
            selectCharacter();
            selectMonster();
            selectProfession();
            selectNPC();
            selectSkill_Type();
            selectSkill();
            selectCharacter_Skill();
            selectMonster_Skill();
            selectItem_Type();
            selectItem();
            selectCharacter_Item();
            selectMonster_Item();
        }
    }
}
