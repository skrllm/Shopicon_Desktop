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
using System.Data.SqlClient;

namespace Shopicon
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        bool IsAccountEnter;
        Frame Menu;
        public Login(bool IsAccountEnter, Frame Menu)
        {
            this.Menu = Menu;
            this.IsAccountEnter = IsAccountEnter;
            InitializeComponent();
        }

        private void EnterLoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ShopiconDBConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format("Select * from [Accounts] WHERE ( [Login] = '{0}' ) and [Password] = '{1}' ", LoginTextBox.Text, PasswordTextBox.Password);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        Data a = new Data();
                        a.FunctionIsAccountEnter(true);
                       
                    }
                    else
                    {
                        LoginErrorTextBox.Text = "Invalid Login or Password";
                    }
                }
                connection.Close();
            }
        }
    }
}
