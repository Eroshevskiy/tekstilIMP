using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для EditMerch.xaml
    /// </summary>
    public partial class EditMerch : Window
    {
        private Merch currentmerch = new Merch();
        public OpenFileDialog ofd = new OpenFileDialog();
        private string newsourthpath = string.Empty;
        private bool flag = false;
        public EditMerch(Merch sellectedmer)
        {
            InitializeComponent();
            if (sellectedmer != null)
            {
                currentmerch = sellectedmer;
            }
            DataContext = currentmerch;
        }

        private void Foto(object sender, RoutedEventArgs e)
        {
            string source = Environment.CurrentDirectory;
            if (ofd.ShowDialog() == true)
            {
                flag = true;
                string sourthpath = ofd.SafeFileName;
                newsourthpath = System.IO.Path.Combine(source.Replace("/bin/Debug", "/photo/"), sourthpath);
                // Проверка на null перед установкой изображения
                if (ofd.FileName != null)
                {
                    PreviewImage.Source = new BitmapImage(new Uri(ofd.FileName));
                }
                currentmerch.photo = $"/photo/{ofd.SafeFileName}";
            }
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            if (currentmerch.id == 0)
            {
                dipEntitie.GetContext().Merch.Add(currentmerch);
            }

            DbContextTransaction dbContextTransaction = null;

            try
            {
                if (currentmerch.id == 0)
                {
                    dipEntitie.GetContext().Merch.Add(currentmerch);
                }

                dbContextTransaction = dipEntitie.GetContext().Database.BeginTransaction();

                dipEntitie.GetContext().SaveChanges();

                MessageBox.Show("Информация сохранена!");
                dbContextTransaction.Commit();

            }
            catch (DbUpdateException ex)
            {
                if (dbContextTransaction != null)
                {
                    dbContextTransaction.Rollback();
                }

                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    MessageBox.Show($"Внутреннее исключение: {innerException.Message}");
                    innerException = innerException.InnerException;
                }

                MessageBox.Show("Ошибка при сохранении изменений. Дополнительные сведения в внутреннем исключении.");
            }
            catch (Exception ex)
            {
                if (dbContextTransaction != null)
                {
                    dbContextTransaction.Rollback();
                }

                MessageBox.Show($"Ошибка при обновлении записей. Дополнительные сведения: {ex.Message}");
            }
            finally
            {
                dbContextTransaction?.Dispose();
            }
        }

        private void nazClick(object sender, RoutedEventArgs e)
        {
            admin adm = new admin();
            Visibility = Visibility.Hidden;
            adm.Show();
        }
    }
}
