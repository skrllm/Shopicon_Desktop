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
    public class AccountMenuViewModel : INotifyPropertyChanged
    {
        MainCache data = new MainCache();


        public ICommand ExitAccountCommand { get; set; }

        public AccountMenuViewModel()
        {
            ExitAccountCommand = new Command(ExecuteMethod, canExecuteMethod);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool canExecuteMethod(object parameter)
        {
            return true;
        }
        private void ExecuteMethod(object parameter)
        {
            data.FunctionIsAccountEnter(false);

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
