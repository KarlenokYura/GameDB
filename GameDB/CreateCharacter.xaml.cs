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
    /// Логика взаимодействия для CreateCharacter.xaml
    /// </summary>
    public partial class CreateCharacter : Window
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        String user, role;

        public CreateCharacter()
        {
            InitializeComponent();
        }

        public CreateCharacter(string user, string role)
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
            this.user = user;
            this.role = role;
            if (role == "OWNER")
            {
                con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBAdmin;PASSWORD=Pa$$w0rd";
            }
            else
            {
                con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";
            }
        }

        public void RaceComboBox()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT race_name FROM GAMEDBADMIN.race_table WHERE rownum <= 6 ORDER BY race_name";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                characterRace.Items.Add(reader.GetString(0));
            }
            con.Close();
        }

        public void ClassComboBox()
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT class_name FROM GAMEDBADMIN.class_table WHERE rownum <= 4 ORDER BY class_name";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                characterClass.Items.Add(reader.GetString(0));
            }
            con.Close();
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            if (characterName.Text != String.Empty && characterRace.Text != String.Empty && characterClass.Text != String.Empty)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.CREATE_CHARACTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = user;
                cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = characterName.Text.Trim();
                cmd.Parameters.Add("P_RACE_NAME", OracleDbType.Varchar2, 30).Value = characterRace.Text.Trim();
                cmd.Parameters.Add("P_CLASS_NAME", OracleDbType.Varchar2, 30).Value = characterClass.Text.Trim();
                try
                {
                    cmd.ExecuteNonQuery();
                    Page page = new Page(user, role);
                    this.Close();
                    page.Show();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("This character name using in system");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Fill all fields");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Page page = new Page(user, role);
            this.Close();
            page.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();

            RaceComboBox();
            ClassComboBox();
        }
    }
}
