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

namespace ResponseTeam.Pages
{
    /// <summary>
    /// Логика взаимодействия для CallPage.xaml
    /// </summary>
    public partial class CallPage : Page
    {
        public CallPage()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            var use = App.db.User.Where(x => x.Id == AccountUse.AuthUser.Id).FirstOrDefault();
            NameUseTb.Text = use.FullName;
            Patientlist.ItemsSource = App.db.VolunteerPatient.Where(x => x.StatusPatientId == 3).ToList();
        }
        private void HelpBt_Click(object sender, RoutedEventArgs e)
        {
            var PatientHelp = (sender as Button).DataContext as VolunteerPatient;
            PatientHelp.StatusPatientId = 1;

            App.db.SaveChanges();
            MessageBox.Show("изменено");
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
