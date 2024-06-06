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
    /// Логика взаимодействия для rabotnick.xaml
    /// </summary>
    public partial class rabotnick : Window
    {
        public rabotnick()
        {
            InitializeComponent();
        }

        

        private void planClick(object sender, RoutedEventArgs e)
        {
            planRab plan = new planRab();
            Visibility = Visibility.Hidden;
            plan.Show();
        }

        private void mainClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Visibility = Visibility.Hidden;
            main.Show();
        }

        private void eticsClick(object sender, RoutedEventArgs e)
        {
            eticsRab etics = new eticsRab();
            Visibility = Visibility.Hidden;
            etics.Show();
        }
    }
}
