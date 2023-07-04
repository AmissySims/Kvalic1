using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Base.Models
{
    public partial class VolunteerPatient
    {
        public Visibility HelpDone
        {
            get
            {

                if (StatusPatientId == 4 )
                {
                    return Visibility.Visible;
                }
                else { return Visibility.Collapsed; }
            }
        }
        public Visibility HelpVolunteer
        {
            get
            {

                if (StatusPatientId == 2 )
                {
                    return Visibility.Visible;
                }
                else { return Visibility.Collapsed; }
            }
        }
        public Visibility NeedHelp
        {
            get
            {

                if (StatusPatientId == 3)
                {
                    return Visibility.Collapsed;
                }
                else { return Visibility.Visible; }
            }
        }

    }
}
