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
    /// Логика взаимодействия для GenPage.xaml
    /// </summary>
    public partial class VolunteerPage : Page
    {

        Random rnd = new Random();

        public VolunteerPage()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            VolunteerList.ItemsSource = App.db.User.Where(x => x.RoleId == 2).ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void GenerationPatientsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var SelUser = (sender as Button).DataContext as User;
                if (SelUser.StatusVolunteerId == 1)
                {
                    if (MessageBox.Show("Поставить подопечного?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        SelUser.StatusVolunteerId = 3;
                        VolunteerPatient NewVP = new VolunteerPatient()
                        {
                            PatientId = rnd.Next(1, 23),
                            UserId = SelUser.Id,
                            StatusPatientId = 2
                        };
                        App.db.VolunteerPatient.Add(NewVP);
                        App.db.SaveChanges();
                        Refresh();
                    }
                }
                else
                {

                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
