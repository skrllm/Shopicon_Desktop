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
    public class HeaderViewModel : INotifyPropertyChanged
    {
        private HeaderCache headerCache = new HeaderCache();

        MainCache data = new MainCache(); //класс в для определения активности аккаунта (вошел/не вошел)
        bool IsAccountEnter;    // вошел ли аккаунт

        string[] AccountData = new string[2]; // [0] = ID_Account,[1] = Name



        Parameters parameters = new Parameters(); //контейнер для получения параметров
        Frame AccountMenu;   //страница в MainWindow 
        MaterialDesignThemes.Wpf.Flipper AccountFlipper; //флиппер со страницами в MainWindow




        public ICommand OpenAccountPanelCommand { get; set; }  

        public HeaderViewModel()
        {
            OpenAccountPanelCommand = new Command(ExecuteMethod, canExecuteMethod);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool canExecuteMethod(object parameter)
        {
            return true;
        }
        private void ExecuteMethod(object parameter)
        {

           
            this.parameters = parameter as Parameters;    //прием параметров в контейнер

            AccountMenu = this.parameters.AccountMenu;    //присвоение страницам данных из контейнера
            AccountFlipper = this.parameters.AccountFlipper;
                
           
            ClickAccountPanel();  

        }



        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        public  string Name
        {
            get { return headerCache.NameText; }
        }
        void ClickAccountPanel()
        {


            AccountData = data.Information(); //прием ID_Account,Name 
            headerCache.NameText = AccountData[1];

            OnPropertyChange(headerCache.NameText);
            OnPropertyChange(headerCache.Name);


            IsAccountEnter = data.FunctionIsAccountEnter(); //проверка состояния аккаунта

            if (IsAccountEnter == false)
            {
                if (AccountFlipper.Visibility == Visibility.Collapsed)
                {
                    AccountFlipper.Visibility = Visibility.Visible;
                }
                else
                {
                    AccountFlipper.Visibility = Visibility.Collapsed;
                }
                AccountMenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                AccountFlipper.Visibility = Visibility.Collapsed;
                if (AccountMenu.Visibility == Visibility.Collapsed)
                {
                    AccountMenu.Visibility = Visibility.Visible;
                }
                else
                {
                    AccountMenu.Visibility = Visibility.Collapsed;
                }
            }
        }

    }
}
