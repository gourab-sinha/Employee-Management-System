using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    class AddViewEmployeeDetails
    {
        public void NewEmployee(ref List<EmployeeDetails> list)
        {
            EmployeeDetails EmpAdd = new EmployeeDetails();
            EmpAdd.CreateEmployee();
            list.Add(EmpAdd);
        }
    }
}
