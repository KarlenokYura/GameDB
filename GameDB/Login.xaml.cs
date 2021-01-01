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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;

namespace GameDB
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        public Login()
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.LOG_IN_USER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_USER_LOGIN", OracleDbType.Varchar2, 30).Value = userLogin.Text.Trim();
            cmd.Parameters.Add("P_USER_PASSWORD", OracleDbType.Varchar2, 30).Value = userPassword.Password.Trim();
            cmd.Parameters.Add("O_USER_LOGIN", OracleDbType.Varchar2, 30);
            cmd.Parameters["O_USER_LOGIN"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("O_USER_ROLE", OracleDbType.Varchar2, 30);
            cmd.Parameters["O_USER_ROLE"].Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                string user = Convert.ToString(cmd.Parameters["O_USER_LOGIN"].Value);
                string role = Convert.ToString(cmd.Parameters["O_USER_ROLE"].Value);
                if (role == "OWNER")
                {
                    connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBAdmin;PASSWORD=Pa$$w0rd";
                }
                Page page = new Page(user, role);
                page.Show();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Login/Password error");
            }
            con.Close();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
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

            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "GAMEDBADMIN.START_JOB";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Job error");
            }
            con.Close();
        }
    }
}
