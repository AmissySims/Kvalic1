using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public partial class Patient
    {
        public string FullName
        {
            get
            {
                return $"{FName} {LName}";
            }
        }
    }
}
