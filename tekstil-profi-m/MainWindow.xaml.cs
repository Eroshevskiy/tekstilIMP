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
using tekstil_profi_m.classes;
using tekstil_profi_m.models;
using tekstil_profi_m.pages;

namespace tekstil_profi_m
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            dboconnect.modeldb = new dipEntitie();
            InitializeComponent();
        }

        private void logClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var userObj = dboconnect.modeldb.Users.FirstOrDefault(x =>
                x.login == Login.Text && x.password == Password.Password);

            if (userObj == null)
            {
                MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            else
            {
                MessageBox.Show($"Вы вошли как: {userObj.Role.role_n}", "Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Information);
                LogIn();
            }
        }

        private void LogIn()
        {
            try
            {
                var userObj = dboconnect.modeldb.Users.FirstOrDefault(x =>
                x.login == Login.Text && x.password == Password.Password);
                if (userObj != null)
                {
                    

                    dipEntitie.CurrentUser = userObj;
                    currentuser.UserRole = userObj.Role.role_n;
                    switch (userObj?.id_role)
                    {
                        case 1:
                            admin adm = new admin();
                            Visibility = Visibility.Hidden;
                            adm.Show();
                            break;
                        case 2:
                            rabotnick man = new rabotnick();
                            Visibility = Visibility.Hidden;
                            man.Show();
                            break;
                        
                            MessageBox.Show("Данные не обнаружены!", "Уведомление",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void closeClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение?", "Подтверждение закрытия", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
