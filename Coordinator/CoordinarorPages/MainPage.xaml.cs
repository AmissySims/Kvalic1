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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            
            InitializeComponent();
            var Use = App.db.User.FirstOrDefault(x => x.Id == AccountUse.AuthUser.Id);
            NameUseTb.Text = Use.FullName;

        }

        private void VolunteersBtn_Click(object sender, RoutedEventArgs e)
        {

            MainCoordinatorFrame.Navigate(new VolunteerPage());
        }

        private void PatientsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainCoordinatorFrame.Navigate(new PatientsPage());
        }
    }
}
