using Authorization.Models;
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

namespace Authorization.Windows.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private string _userName;
        private string _userSurname;
        private string _userPatronomic;
        private int _userRoleId;
        private string _userLogin;
        private string _userPassword;
        private string _userPasswordRepeat;

        public AddUserWindow()
        {
            InitializeComponent();

            
            CmbxRole.ItemsSource = Connecting.conn.Role.ToList();
            CmbxRole.DisplayMemberPath = "Name";
            CmbxRole.SelectedIndex = 0;

        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            GetDataObject();
            CheckDataForm(_userName, _userSurname, _userPatronomic, _userRoleId, _userLogin, _userPassword, _userPasswordRepeat);

            var user = new User()
            {
                Name = _userName,
                Surname = _userSurname,
                Patronomic = _userPatronomic,
                RoleId = _userRoleId,
                Login = _userLogin,
                Password = _userPassword,
            };

            Connecting.conn.User.Add(user);
            Connecting.conn.SaveChanges();
            var userId = user.Id;

            MessageBox.Show($"Пользователь успешно добавлен.\nId - {userId}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckDataForm(
            string _userName, 
            string _userSurname, 
            string _userPatronomic, 
            int _userRole, 
            string _userLogin, 
            string _userPassword,
            string _userPasswordRepeat)
        {

            if (string.IsNullOrEmpty(_userName))
            {
                MessageBox.Show("Поле имя не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(_userSurname))
            {
                MessageBox.Show("Поле фамилия не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(_userPatronomic))
            {
                MessageBox.Show("Поле отчество не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (_userRoleId == 0)
            {
                MessageBox.Show("Поле роль не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(_userLogin))
            {
                MessageBox.Show("Поле логин не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (string.IsNullOrEmpty(_userPassword))
            {
                MessageBox.Show("Поле пароль не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (_userPassword != _userPasswordRepeat)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetDataObject()
        {
            _userName = TxbNameuser.Text;
            _userSurname = TxbSurname.Text;
            _userPatronomic = TxbPatronomic.Text;
            _userRoleId = (CmbxRole.SelectedValue as Role).Id;
            _userLogin = TxbLogin.Text;
            _userPassword = TxbPassword.Text;
            _userPasswordRepeat = TxbPasswordRepeat.Text;
        }
    }
}
