using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitOfWorkApp.WebUI.Models.Employee
{
    public class IndexViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}