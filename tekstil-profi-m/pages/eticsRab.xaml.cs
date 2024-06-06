using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для eticsRab.xaml
    /// </summary>
    public partial class eticsRab : Window
    {
        private ObservableCollection<Merch> merchCollection;
        public eticsRab()
        {
            InitializeComponent();
            merchCollection = new ObservableCollection<Merch>(dipEntitie.GetContext().Merch.ToList());
            BDWorkers.ItemsSource = merchCollection;
        }

        private void nazClick(object sender, RoutedEventArgs e)
        {
            rabotnick rab = new rabotnick();
            Visibility = Visibility.Hidden;
            rab.Show();
        }

        private void EticPech(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Получаем выбранный объект из DataGrid
                var selectedMerch = BDWorkers.SelectedItem as dynamic;
                if (selectedMerch != null)
                {
                    // Получаем путь к файлу из выбранного объекта
                    string filePath = selectedMerch.filePath;

                    // Проверяем, существует ли файл по указанному пути
                    if (File.Exists(filePath))
                    {
                        // Открываем файл
                        Process.Start(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Файл не найден.");
                    }
                }
            }
        }
    }
}
