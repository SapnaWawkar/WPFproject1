using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2HLogin.Entities
{
    public class CustomerPersonalInfo
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PackageName { get; set; }
        public string GroupName { get; set; }
        public string AreaName { get; set; }
    }
}
