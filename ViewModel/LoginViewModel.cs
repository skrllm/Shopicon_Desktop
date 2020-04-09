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
using Shopicon.Model;
using Shopicon.View;
using System.ComponentModel;

namespace Shopicon.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        private AuthentificationUserCache LoginChacheUser = new AuthentificationUserCache();  //контейнер кеша для регистрации 
        List<string> Response = new List<string>();
      
        public string Login //работа с LoginTextBox
        {
            get { return LoginChacheUser.Login; }
            set
            {
                if (LoginChacheUser.Login != value)
                {
                    LoginChacheUser.Login = value;

                    OnPropertyChange(LoginChacheUser.Login);
                    OnPropertyChange(LoginChacheUser.Error);
                }
            }
        }


        public string Error
        {
            get { return LoginChacheUser.ErrorText; }
        }


        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
           LoginCommand = new Command(ExecuteMethod, canExecuteMethod);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool canExecuteMethod(object parameter)
        {
            return true;
        }
        private void ExecuteMethod(object parameter)
        {

            #region Передача Пароля из Registration.xaml в ViewModel
            var passwordBox = parameter as PasswordBox;
            if (passwordBox == null)
                return;
            LoginChacheUser.Password = passwordBox.Password;

            #endregion


            string CommandText = string.Format("Select * from [Accounts] WHERE ( [Login] = '{0}' ) and [Password] = '{1}' ", LoginChacheUser.Login, LoginChacheUser.Password);
            DataBase Read = new DataBase();  //создание экземпляра , в котором реализована работа с базой 

            this.Response = Read.DataRead(CommandText);  //чтение базы данных, проверка ошибок авторизации

            if (Response[0] == null || Response[1] == null)
            { LoginChacheUser.ErrorText = "Неправильный Логин или Пароль"; } else
            {
                LoginChacheUser.ErrorText = "=)";
            }

            

            OnPropertyChange(LoginChacheUser.ErrorText);
            OnPropertyChange(LoginChacheUser.Error);

            


        }



        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

    }
}
