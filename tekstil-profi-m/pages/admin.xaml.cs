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
using System.Windows.Shapes;

namespace tekstil_profi_m.pages
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
        }

        private void productClick(object sender, RoutedEventArgs e)
        {
            product prod = new product();
            Visibility = Visibility.Hidden;
            prod.Show();
        }

        private void mainClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Visibility = Visibility.Hidden;
            main.Show();
        }

        private void nacklClick(object sender, RoutedEventArgs e)
        {
            nackladn nacl = new nackladn();
            Visibility = Visibility.Hidden;
            nacl.Show();
        }

        private void rabClick(object sender, RoutedEventArgs e)
        {
            rabochie rab = new rabochie();
            Visibility = Visibility.Hidden;
            rab.Show();
        }
    }
}
