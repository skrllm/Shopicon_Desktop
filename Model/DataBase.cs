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

namespace Shopicon.Model
{
    public class DataBase
    {
       // string Response;
        List<string> response = new List<string>();
        public List<string> DataRead(string CommandText)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ShopiconDBConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = CommandText;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        response.Add(Convert.ToString(reader[0])); //ID_Account
                        response.Add(Convert.ToString(reader[1])); //Name
                       
                        MainCache a = new MainCache();
                        a.FunctionIsAccountEnter(true); //присвоение состояния аккаунта
                        a.AccountEntered(response[0], response[1]); //передача данных аккаунта в статичные поля
                        
                       
                    }
                    else
                    {   response.Add(null); //ID_Account
                        response.Add(null); //Name

                    }
                }
                connection.Close();
            }
            return response;
        }

        public void DataAdd(string CommandText)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ShopiconDBConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = CommandText;
                command.ExecuteNonQuery();
                connection.Close();
            }
           
        }


    }
}
