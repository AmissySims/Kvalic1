using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Base.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Volunteer.VolunteerPages
{
    /// <summary>
    /// Логика взаимодействия для HelpPage.xaml
    /// </summary>
    public partial class HelpPage : Page
    {
     
        public HelpPage()
        {
            InitializeComponent();
            var Timer = new DispatcherTimer();
          
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 30);
            Timer.Start();
            UpdateDatabase();
            
            Refresh();
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Baseapp.Text = $" сохранено в {DateTime.Now.ToLongTimeString()}";

            UpdateDatabase();
            CommandManager.InvalidateRequerySuggested();
        }

        private void UpdateDatabase()
        {
            
            App.db.SaveChanges();
        }
        public void Refresh()
        {
            var SelUse = App.db.User.FirstOrDefault(x => x.Id == AccountUse.AuthUser.Id);
            NameUseTb.Text = SelUse.FullName;
            StatTb.Text = SelUse.StatusVolunteer.Title.ToString();
            
            Patientlist.ItemsSource = App.db.VolunteerPatient.Where(x => x.UserId == AccountUse.AuthUser.Id).ToList();
            if(SelUse.StatusVolunteerId == 3)
                Patientlist.Visibility = Visibility.Visible;
            else Patientlist.Visibility = Visibility.Collapsed;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void StatusRelaxBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var use = App.db.User.Where(x => x.Id == AccountUse.AuthUser.Id).FirstOrDefault();
                use.StatusVolunteerId = 2;
                MessageBox.Show("изменено");
                App.db.SaveChanges();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void StatusReadyBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var use = App.db.User.Where(x => x.Id == AccountUse.AuthUser.Id).FirstOrDefault();
                use.StatusVolunteerId = 1;
                MessageBox.Show("изменено");
                App.db.SaveChanges();
                Refresh();
            }
            catch ( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
      
           
        }

        

        private void HelpBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var patientHelp = (sender as Button).DataContext as VolunteerPatient;
                patientHelp.StatusPatientId = 4;
                App.db.SaveChanges();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void NeedHelpBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var patientHelp = (sender as Button).DataContext as VolunteerPatient;
                patientHelp.StatusPatientId = 3;
                App.db.SaveChanges();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void HelpDoneBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var patientHelp = (sender as Button).DataContext as VolunteerPatient;
                patientHelp.StatusPatientId = 1;
                var SelUse = App.db.User.FirstOrDefault(x => x.Id == AccountUse.AuthUser.Id);

                App.db.SaveChanges();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           
        }
    }
}
