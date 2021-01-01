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
    public partial class Item : UserControl
    {
        OracleConnection con = new OracleConnection();
        String connectionString = "DATA SOURCE=localhost:1521/orcl;PERSIST SECURITY INFO=True;USER ID=GameDBUser;PASSWORD=Pa$$w0rd";

        String user, role, character;

        public Item()
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
        }

        public Item(string user, string role, string name, string item, string type, Int16 health, Int16 mana, Int16 power, Int16 speed, Int16 mind)
        {
            con.ConnectionString = connectionString;
            InitializeComponent();
            this.user = user;
            this.role = role;
            this.character = name;
            itemName.Text = item;
            itemType.Text = "Type: " + type;
            itemHealth.Text = "Health: " + health.ToString();
            itemMana.Text = "Mana: " + mana.ToString();
            itemPower.Text = "Power: " + power.ToString();
            itemSpeed.Text = "Speed: " + speed.ToString();
            itemMind.Text = "Mind: " + mind.ToString();

            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT item_blob FROM GameDBAdmin.item_table WHERE item_name = '" + item + "'";
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
                    itemIcon.Source = image;
                }
                catch (Exception exc)
                {

                }
            }
            con.Close();
        }

        private void ItemMouseEnter(object sender, MouseEventArgs e)
        {
            itemBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC8C8C8"));
        }

        private void ItemMouseLeave(object sender, MouseEventArgs e)
        {
            itemBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
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
