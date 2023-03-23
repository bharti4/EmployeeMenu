using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProgram
{
    internal class Employee
    {
            public string EmployeeName { get; set; }
            public string Department { get; set; }
            public int Age { get; set; }
            public int Salary { get; set; }
            public int YearsOfService { get; set; }


            public Employee(string EmployeeName, string Department, int Age, int Salary, int YearsOfService)
            {
                this.EmployeeName = EmployeeName;
                this.Department = Department;
                this.Age = Age;
                this.Salary = Salary;
                this.YearsOfService = YearsOfService;
            }

            public Employee()
            {
                do
                {
                    // Print salary by Department
                    Console.WriteLine();
                    String userDeptInput = DepartmentInfo.getDepartmentNames();
                    String departmentName = DepartmentInfo.getDepartmentName(userDeptInput);
                    if (departmentName == "-1")
                    {
                        Console.WriteLine("Invlalid Option Press any key to select Again :)");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Department = departmentName;
                        Console.WriteLine("Entere Employee Name :");
                        EmployeeName = Console.ReadLine();
                        Console.WriteLine("Enter Age :");
                        Age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Salary :");
                        Salary = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Year Of Service : ");
                        YearsOfService = Convert.ToInt32(Console.ReadLine());

                        break;
                    }

                } while (true);
            }

            // Print Detail
            public void PrintDetail()
            {
                Console.WriteLine("Employee Name  :{0}", EmployeeName);
                Console.WriteLine("Department      :{0}", Department);
                Console.WriteLine("Age            :{0}", Age);
                Console.WriteLine("Salary         :{0}", Salary);
                Console.WriteLine("YearsOfService :{0}", YearsOfService);
            }

        }
    }

