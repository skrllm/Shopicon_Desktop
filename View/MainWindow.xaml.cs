using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shopicon.View;
using Shopicon.ViewModel;

namespace Shopicon.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            AccountMenu.Navigate(new AccountMenu()); 
            Menu.Navigate(new Menu(AccountMenu,AccountFlipper/*,IsAccountEnter*/));
            Registration.Navigate(new Registration());
            Login.Navigate(new Login());
            

        }
      
        private void Flipper_OnIsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e) //переворачивание флиппера
        {
            System.Diagnostics.Debug.WriteLine("Card is flipped = " + e.NewValue);
        }
    }
}
