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

namespace Shopicon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool IsAccountEnter = false; 
        public MainWindow()
        {
            InitializeComponent();



            //Registration.Navigate(new Registration());
            //Login.Navigate(new Login(IsAccountEnter));

            AccountMenu.Navigate(new AccountMenu());
            AccountMenu.Visibility = Visibility.Hidden;
            AccountFlipper.Visibility = Visibility.Hidden;

            Menu.Navigate(new Menu(AccountMenu,AccountFlipper));

            Registration.Navigate(new Registration());
            Login.Navigate(new Login(IsAccountEnter,Menu));
        }
        private void Flipper_OnIsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            System.Diagnostics.Debug.WriteLine("Card is flipped = " + e.NewValue);
        }
    }
}
