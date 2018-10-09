using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Employee_Management_System
{
    class EmployeeDetails
    {
        private string employeeId;
        private string employeeFirstName;
        private string employeeLastName;
        private string employeeAddress1;
        private string employeeAddress2;
        private string age;
        private long employeeSalary;
        private string employeeMobileNo;
        private string employeeDOJ;
        private string GetId(string employeeId)
        {
            int Flag = 0;
            if (employeeId[0] == 'E' && employeeId.Length == 4)
            {
                for (int i = 1; i < employeeId.Length; i++)
                {
                    if ((int)employeeId[i] < 48 || (int)employeeId[i] > 57)
                    {
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 0)
                    return employeeId;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Wrong ID Format!!\nPlease Enter Employee ID (e.g E100):");
            Console.ResetColor();
            return GetId(Console.ReadLine());
        }
        private string GetNames(string names) // Take Names and validate
        {
            int Flag = 0;
            if ((names.Length <= 30) && (names.All(char.IsLetter) == true) && (names[0] >= 65 && names[0] <= 90))
            {
                if (names.Length == 1)
                    Flag = 1;
                for (int i = 1; i < names.Length; i++)
                {
                    if (names[i] >= 97 && names[i] <= 122)
                    {
                        Flag = 1;
                    }
                }
            }
            if (Flag == 1)
            {
                return names;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please Enter name. Name length should be less than 30 and Pascal case (e.g: Gourab)");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ResetColor();
            return GetNames(Console.ReadLine());
        }
        private string GetAge(string employeeDOB) // Calculate age and verify age is above 18 or not
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime parsedDateTime;
            bool correctDateFormat = DateTime.TryParseExact(employeeDOB, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
            if (correctDateFormat == true)
            {
                string[] dob = (parsedDateTime.ToString("MM/dd/yyyy")).Split('-');
                int mm = Convert.ToInt32(dob[0]);
                int dd = Convert.ToInt32(dob[1]);
                int yyyy = Convert.ToInt32(dob[2]);
                DateTime today = DateTime.Today;
                string[] currDate = (today.ToString("MM/dd/yyyy")).Split('-');
                int currMM = Convert.ToInt32(currDate[0]);
                int currDD = Convert.ToInt32(currDate[1]);
                int currYYYY = Convert.ToInt32(currDate[2]);
                if (currDD - dd < 0)
                {
                    dd = currDD + 30 - dd;
                    currMM -= 1;
                }
                else
                {
                    dd = currDD - dd;
                }
                if (currMM - mm < 0)
                {
                    mm = currMM + 12 - mm;
                    currYYYY -= 1;
                }
                else
                {
                    mm = currMM - mm;
                }
                yyyy = currYYYY - yyyy;
                if (yyyy >= 18)
                {
                    return (yyyy + " years " + mm + " months " + dd + " days");
                }
                else
                {
                    Console.WriteLine("Employee Age should be greater than or equal to 18");
                    return GetAge(Console.ReadLine());

                }
            }
            Console.WriteLine("Date format not matched\n" +
                "Possible Cases: 1. Beyond days in a month\n2. DD/MM/YYYY\n" +
                "Please enter DOB in MM/DD/YYYY Format");
            return GetAge(Console.ReadLine());
        }
        private long GetSalary(long salary) // Salary check
        {
            if (salary < 0 || salary > 100000)
            {
                Console.WriteLine("Salary must be greater than zero or less than 1 Lakh\nPlease enter salary:");
                return GetSalary(Convert.ToInt32(Console.ReadLine()));
            }
            return salary;
        }
        private string GetMobileNo(string employeeMobileNo) // Mobile number validation
        {
            string pattern = @"^\+[1-9][0-9]\s[1-9][0-9]{9}$";
            Match result = Regex.Match(employeeMobileNo, pattern);
            if (result.Success)
            {
                return employeeMobileNo;
            }
            Console.WriteLine("Wrong Mobile No format!!");
            Console.WriteLine("Please Enter Mobile No (e.g +91 8946065442)");
            return GetMobileNo(Console.ReadLine());
        }
        private string GetDOJ(string employeeDOJ)
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime parsedDateTime;
            bool correctDateFormat = DateTime.TryParseExact(employeeDOJ, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
            if(correctDateFormat == true)
            {
                return employeeDOJ + ", " + parsedDateTime.DayOfWeek.ToString();
            }
            Console.WriteLine("Please enter valid DOJ(e.g MM/DD/YYYY)");
            return GetDOJ(Console.ReadLine());
        }
        public void CreateEmployee() // Create New Employee
        {
            Console.WriteLine("Please Enter Employee ID (e.g E104):");
            employeeId = GetId(Console.ReadLine());
            Console.WriteLine("Please Enter Employee First Name:");
            employeeFirstName = GetNames(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Last Name:");
            employeeLastName = GetNames(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Address1:");
            employeeAddress1 = Console.ReadLine();
            Console.WriteLine("Please Enter Employee Address2:");
            employeeAddress2 = Console.ReadLine();
            Console.WriteLine("Please Enter Employee DOB in MM/DD/YYYY format:");
            age = GetAge(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Salary:");
            employeeSalary = GetSalary(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Please Enter Employee Mobile No(e.g +91 8946065442):");
            employeeMobileNo = GetMobileNo(Console.ReadLine());
            Console.WriteLine("Please Enter Employee DOJ in MM/DD/YYYY:");
            employeeDOJ = GetDOJ(Console.ReadLine());
        }
        public void showEmployeeDetails() // Show Details of employee
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(employeeId + ":" + employeeFirstName + " " + employeeLastName);
            Console.WriteLine(employeeAddress1);
            Console.WriteLine(age);
            Console.WriteLine("Salary INR " + employeeSalary);
            Console.WriteLine(employeeMobileNo);
            Console.WriteLine("Joined: " + employeeDOJ);
            Console.ResetColor();
        }
        public string searchEmployee(string empID)
        {
            return GetId(empID);
        }
        public string MatchEmployee()
        {
            return employeeId;
        }
    }
}
