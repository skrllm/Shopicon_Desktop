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
    public class RegistrationViewModel : INotifyPropertyChanged
    {

        private AuthentificationUserCache RegistrationChacheUser = new AuthentificationUserCache(); //контейнер кеша для Логина 

        public string FirstName  //работа с FirstNameTextBox
        {
            get { return RegistrationChacheUser.FirstName; }
            set
            {
                if (RegistrationChacheUser.FirstName != value)
                {
                    RegistrationChacheUser.FirstName = value;
                    OnPropertyChange(RegistrationChacheUser.FirstName);
                }
            }
        }
        public string Login  //работа с LoginTextBox
        {
            get { return RegistrationChacheUser.Login; }
            set
            {
                if (RegistrationChacheUser.Login != value)
                {
                    RegistrationChacheUser.Login = value;

                    OnPropertyChange(RegistrationChacheUser.Login);
                    OnPropertyChange(RegistrationChacheUser.Error);
                }
            }
        }

        
        public string Error
        {
            get { return RegistrationChacheUser.ErrorText; }
        }


        public ICommand RegisterCommand { get; set; }

        public RegistrationViewModel()
        {
            RegisterCommand = new Command(ExecuteMethod, canExecuteMethod);
            
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
            RegistrationChacheUser.Password = passwordBox.Password;

            #endregion

            RegistrationChacheUser.ErrorText = RegisterDataChecking(); //Проверка длинны пароля и логина
            OnPropertyChange(RegistrationChacheUser.ErrorText);
            OnPropertyChange(RegistrationChacheUser.Error);
            
            if (RegistrationChacheUser.ErrorText == null)
            {

                string CommandText = string.Format("INSERT [Accounts]([Name],[Login],[Password]) VALUES ('{0}', '{1}','{2}')", RegistrationChacheUser.FirstName, RegistrationChacheUser.Login, RegistrationChacheUser.Password);
                DataBase Add = new DataBase();   //создание экземпляра , в котором реализована работа с Базой Данных
                Add.DataAdd(CommandText);    //Вставка данных регистрации в Базу Даннных

                RegistrationChacheUser.ErrorText = "You Are Registered!";
                OnPropertyChange(RegistrationChacheUser.ErrorText);
                OnPropertyChange(RegistrationChacheUser.Error);
            }


        }

        

        protected void OnPropertyChange(string propertyName)
        {
           if (PropertyChanged != null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
               
           }
        }

        
        private string RegisterDataChecking()  //Проверка длинны пароля и логина
        {
            if ((RegistrationChacheUser.Login != null) || (RegistrationChacheUser.Password != null))
            {
                if ((RegistrationChacheUser.Login.Length < 8) || (RegistrationChacheUser.Password.Length < 8))
                { return "Логин и Пароль должны быть \n     не менее 8 символов"; }
                else return null;

            }
            else return "Логин или пароль \n пусты";

        }

    }
}