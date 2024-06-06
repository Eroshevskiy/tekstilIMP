using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using tekstil_profi_m.models;

namespace tekstil_profi_m.pages
{
    /// <summary>
    /// Логика взаимодействия для planRab.xaml
    /// </summary>
    public partial class planRab : Window
    {
        private ObservableCollection<Plan> planCollection;
        public planRab()
        {
            InitializeComponent();
            planCollection = new ObservableCollection<Plan>(dipEntitie.GetContext().Plan.ToList());
            BDPlan.ItemsSource = planCollection;
        }

        private void nazClick(object sender, RoutedEventArgs e)
        {
            rabotnick rab = new rabotnick();
            Visibility = Visibility.Hidden;
            rab.Show();
        }
    }
}
