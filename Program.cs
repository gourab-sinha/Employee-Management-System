using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Employee_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeDetails> list = new List<EmployeeDetails>();
            int option;
            while(true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("------------------Menu----------------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: ADD EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #2: VIEW EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #3: CHANGE MENU STYLE");
                Console.WriteLine("OPTION #3: CHANGE MENU STYLE");
                option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        AddViewEmployeeDetails AddEmp = new AddViewEmployeeDetails();
                        AddEmp.NewEmployee(ref list);
                        break;
                    case 2:
                        EmployeeDetails searchEmp = new EmployeeDetails();
                        Console.WriteLine("Please Enter Employee ID whose details you want to see");
                        string empID = searchEmp.searchEmployee(Console.ReadLine());
                        if (list.Capacity >= 1)
                        {
                            int EmployeePresent = 0; 
                            foreach (var item in list)
                            {
                                if (empID == item.MatchEmployee())
                                {
                                    item.showEmployeeDetails();
                                    EmployeePresent = 1;
                                }
                            }
                            if( EmployeePresent == 0)
                            {
                                Console.WriteLine("Employee does not exist");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employee exists");
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;

                }
                
            }
            Console.ReadKey();
        }
    }
}
