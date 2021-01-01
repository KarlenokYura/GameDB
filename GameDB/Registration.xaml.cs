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
using System.Windows.Navigation;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;

namespace GameDB
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        public Registration()
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.REGISTER_USER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = userLogin.Text.Trim();
            cmd.Parameters.Add("P_USER_PASSWORD", OracleDbType.Varchar2, 30).Value = userPassword.Password.Trim();
            cmd.Parameters.Add("P_USER_NAME", OracleDbType.Varchar2, 30).Value = userName.Text.Trim();
            cmd.Parameters.Add("P_USER_SURNAME", OracleDbType.Varchar2, 30).Value = userSurname.Text.Trim();
            try
            {
                cmd.ExecuteNonQuery();
                Login login = new Login();
                this.Close();
                login.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show("This user login using in system");
            }
            con.Close();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
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
