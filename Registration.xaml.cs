﻿using System;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ShopiconDBConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();


                command.CommandText = string.Format("INSERT [Accounts]([Name],[Login],[Password]) VALUES ('{0}', '{1}','{2}')", NameTextBox.Text, LoginTextBox.Text, PasswordTextBox.Password);
                command.ExecuteNonQuery();
                connection.Close();

            }
            LoginTextBox.Text = "";
            NameTextBox.Text = "";
            PasswordTextBox.Password = "";
            
        }
    }
}
