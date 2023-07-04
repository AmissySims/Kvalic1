using Base.Models;
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

namespace Coordinator.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var login = LoginTb.Text;
                var password = PasswordTb.Text;
                AccountUse.AuthUser = App.db.User.ToList().Find( x => x.Login == login && x.Password == password && x.RoleId == 1);
                var user = AccountUse.AuthUser;
                if(user == null)
                {
                    MessageBox.Show("такого пользователя нет ");
                    return;
                }
                if (string.IsNullOrEmpty(login))
                {
                    MessageBox.Show("введите логин");
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("введите пароль");
                    return;
                }
                else
                {
                    AccountUse.AuthUser = user;
                    AccountUse.isAuth = true;
                    MessageBox.Show("Вход выполнен");
                    NavigationService.Navigate(new MainPage());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
