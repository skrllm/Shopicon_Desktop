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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        Frame AccountMenu;
        MaterialDesignThemes.Wpf.Flipper AccountFlipper;
        public bool IsAccountEnter = false;
        public Menu(Frame AccountMenu,MaterialDesignThemes.Wpf.Flipper AccountFlipper/*,bool IsAccountEnter*/)
        {
            this.AccountMenu = AccountMenu;
            this.AccountFlipper = AccountFlipper;
            //this.IsAccountEnter = IsAccountEnter;
            InitializeComponent();

        }

        private void OpenAccountMenu(object sender, RoutedEventArgs e)
        {

            if (IsAccountEnter == false)
            {
                if (AccountFlipper.Visibility == Visibility.Hidden)
                {
                    AccountFlipper.Visibility = Visibility.Visible;
                }
                else
                {
                    AccountFlipper.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (AccountMenu.Visibility == Visibility.Hidden)
                {
                    AccountMenu.Visibility = Visibility.Visible;
                }
                else
                {
                    AccountMenu.Visibility = Visibility.Hidden;
                }
            }
            
            
        }
    }
}
