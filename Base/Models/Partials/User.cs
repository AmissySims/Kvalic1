using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Base.Models
{
    public partial class User
    {
        public string FullName
        {
            get
            {
                return $"{FName} {LName}";
            }
        }
        public Visibility HelpVisible
        {
            get
            {
                if(StatusVolunteerId == 1)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
    }
}
