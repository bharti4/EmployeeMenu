using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProgram
{
    internal class DepartmentInfo
    {
        public static string[] deparmentNames = new string[] { "Information Technology", "Marketing", "Engineering", "Finance", "Human Resources", "Operations" };
        // Prints list of Departments and asks for selection
        public static string getDepartmentNames()
        {
            Console.WriteLine("*****************************************");
            for (int i = 0; i < deparmentNames.Length; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, deparmentNames[i]);
            }

            Console.Write("Select Department Options from 1 to 6:");
            string userDeptInput = Console.ReadLine();

            return userDeptInput;
        }
        //Height value from data - based on index
        //Map user input to Department
        public static string getDepartmentName(string userDeptInput)
        {
            int departmentIndex = Convert.ToInt32(userDeptInput);
            if (departmentIndex >= 1 && departmentIndex <= 6)
            {
                return deparmentNames[departmentIndex - 1];
            }
            return "-1";
        }

    }
}
