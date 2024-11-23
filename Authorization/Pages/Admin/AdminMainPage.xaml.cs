using Authorization.Models;
using Authorization.Windows.Admin;
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

namespace Authorization.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();

            LoadDataUserList();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var windowAddUser = new AddUserWindow();
            windowAddUser.ShowDialog();
        }

        private void LoadDataUserList()
        {
            try
            {
                var data = Connecting.conn.User.ToList();

                if (data == null)
                {
                    MessageBox.Show("Уведомление", "Данные ", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                DgUserList.ItemsSource = data;
            }
            catch (Exception ex)   
            {
                MessageBox.Show("Ошибка", $"Ошибка в обработке данных {ex}", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
