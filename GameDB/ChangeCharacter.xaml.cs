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
    /// Логика взаимодействия для ChangeCharacter.xaml
    /// </summary>
    public partial class ChangeCharacter : Window
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        String user, role, character;

        public ChangeCharacter()
        {
            InitializeComponent();
        }

        public ChangeCharacter(string user, string role, string character)
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
            this.user = user;
            this.role = role;
            this.character = character;
            if (role == "OWNER")
            {
                con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBAdmin;PASSWORD=Pa$$w0rd";
            }
            else
            {
                con.ConnectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";
            }
        }

        private void ChangeClick(object sender, RoutedEventArgs e)
        {
            if (characterName.Text != String.Empty)
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "GAMEDBADMIN.CHANGE_CHARACTER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = character;
                cmd.Parameters.Add("P_CHANGE_CHARACTER_NAME", OracleDbType.Varchar2, 30).Value = characterName.Text.Trim();
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
                MessageBox.Show("Fill name field");
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
        }
    }
}
