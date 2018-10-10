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
            List<EmployeeDetails> EmployeeList = new List<EmployeeDetails>();
            int option;
            while(true)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine("------------------Menu----------------");
                Console.WriteLine("**************************************");
                Console.WriteLine("OPTION #1: ADD EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #2: VIEW EMPLOYEE DETAILS");
                Console.WriteLine("OPTION #3: CHANGE SCREEN SETTINGS");
                Console.WriteLine("OPTION #4: EXIT");
                option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        AddViewEmployeeDetails AddEmp = new AddViewEmployeeDetails();
                        AddEmp.NewEmployee(ref EmployeeList);
                        break;
                    case 2:
                        AddViewEmployeeDetails seachEmp = new AddViewEmployeeDetails();
                        seachEmp.SearchEmp(ref EmployeeList);
                        break;
                    case 3:
                        EmployeeDetails.ColorSet();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;

                }
                
            }
        }
    }
}
