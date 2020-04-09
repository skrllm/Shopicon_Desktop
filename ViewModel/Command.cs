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

namespace Shopicon.ViewModel
{
    class Command : ICommand
    {
        Action<object> executeMethod;
        Func<object, bool> canexecuteMethod;
        

        public Command(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canexecuteMethod = canexecuteMethod;
            
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //  throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
            //throw new NotImplementedException();
        }
    }
}
