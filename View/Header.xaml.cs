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
using Shopicon.Model;
using Shopicon.ViewModel;


namespace Shopicon.View
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    
    public partial class Menu : Page
    {

        Parameters parameters = new Parameters(); //койнтейнер для передачи параметров в HeaderViewModel
        
        public Menu(Frame AccountMenu,MaterialDesignThemes.Wpf.Flipper AccountFlipper)
        {

            parameters.AccountMenu = AccountMenu;   //передача в контейнер параметров
            parameters.AccountFlipper = AccountFlipper;
           

            InitializeComponent();


            AccountButton.CommandParameter = this.parameters; // передача контейнера после !инициализации страницы!

        }       

    }

    class Parameters
    {
       public  Frame AccountMenu;
       public MaterialDesignThemes.Wpf.Flipper AccountFlipper;
    }
}
