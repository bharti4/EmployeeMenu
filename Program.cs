using EmployeeProgram;

internal class Program
{
    public static void Main(string[] args)
    {
        String fileLocation = @"C:\Users\bhart\source\repos\CsharpBasicConcepts\CsharpBasicConcepts\DATA\EmployeeDatabase.csv";
        Employee[] allEmplyoyeesDetail = EmployeeDataReader(fileLocation);
        do
        {
            Console.WriteLine("1 -  View Employees By Name and Detail for Selected Employee");
            Console.WriteLine("2 -  View All Employees Full Detail");
            Console.WriteLine("3 -  View Full Total Salary of Orgnization ");
            Console.WriteLine("4 -  View  Total Salary of Department ");
            Console.WriteLine("5 -  Add New Employee ");
            Console.WriteLine("6 -  Heighest Earning Employee ");
            Console.WriteLine("7 -  Lowest Earning Employee");
            Console.WriteLine("8 -  Longest Serving Employee");
            Console.WriteLine("9 -  Newest Employee ");
            Console.WriteLine("10 - All Departments Total Employee Salary Cost");

            Console.WriteLine("Q -  Quit");
            Console.Write("Select Menu Options :");
            string userInput = Console.ReadLine();
            //Console.WriteLine(userInput);

            switch (userInput)
            {
                case "1":
                    // print all employee names 
                    PrintEmplyoeeNames(allEmplyoyeesDetail);
                    Console.WriteLine("Select Number to view employee Information in Detail [-1] for goto Main Menu:");
                    string userSubInput = Console.ReadLine();
                    if (userSubInput != "-1")
                    {
                        int userSubInputint = int.Parse(userSubInput);
                        if (userSubInputint >= 1 && userSubInputint <= allEmplyoyeesDetail.Length)
                        {
                            allEmplyoyeesDetail[userSubInputint - 1].PrintDetail();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Selection");
                        }
                    }
                    break;
                case "2":
                    // prints all emplyoee details
                    printEmplyoeeFullDetail(allEmplyoyeesDetail);
                    break;
                case "3":
                    // Prints Organization Salary Cost
                    Console.WriteLine("Total Organzation Salary Cost is {0}", PrintTotalSalary(allEmplyoyeesDetail));
                    break;
                case "4":
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
                            // Select Emplyees Details for Department
                            Employee[] DepartmentEmployee = getDepartmentEmployeeData(allEmplyoyeesDetail, departmentName);
                            // prints total salary cost of Department
                            Console.WriteLine();
                            Console.WriteLine("{0} Salary Cost is : {1}", departmentName, PrintTotalSalary(DepartmentEmployee));
                            break;
                        }

                    } while (true);
                    break;
                case "5":
                    // Add New Employee 
                    Employee newEmployee = new Employee();
                    EmployeeDataWrite(newEmployee, fileLocation);
                    allEmplyoyeesDetail = EmployeeDataReader(fileLocation);
                    break;
                case "6":
                    // Heighest Earning Employee 
                    printHeighestEarningEmployee(allEmplyoyeesDetail);
                    break;
                case "7":
                    //Lowest Earning
                    printLowestEarningEmployee(allEmplyoyeesDetail);

                    break;
                case "8":
                    //Long serviced Employee
                    printOldestEmployee(allEmplyoyeesDetail);

                    break;
                case "9":
                    //Newest Employee
                    printNewJoiningEmployee(allEmplyoyeesDetail);
                    break;
                case "10":
                    //Department wise salary cost
                    foreach (string name in DepartmentInfo.deparmentNames)
                    {
                        // Select Emplyees Details for Deparment
                        Employee[] DepartmentEmployee = getDepartmentEmployeeData(allEmplyoyeesDetail, name);
                        // prints total salary cost of Department
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("{0} Salary Cost is : {1}", name, PrintTotalSalary(DepartmentEmployee));
                    }

                    break;
                case "Q":
                    Console.WriteLine("Good Bye !");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            Console.WriteLine("Press Any key to continue : ");
            Console.ReadLine();
            Console.Clear();
        } while (true);

    }
    //readEmplyeeDataFrom CSV file 
    public static Employee[] EmployeeDataReader(string EmployeeFileLocation)
    {

        string[] EmployeeData = File.ReadAllLines(EmployeeFileLocation);
        Employee[] employees = new Employee[EmployeeData.Length - 1];
        for (int i = 1; i < EmployeeData.Length; ++i)
        {
            String[] currentEmployee = EmployeeData[i].Split(',');
            employees[i - 1] = new Employee(currentEmployee[0], currentEmployee[1], Convert.ToInt32(currentEmployee[2]), Convert.ToInt32(currentEmployee[3]), Convert.ToInt32(currentEmployee[4]));
            //  Console.WriteLine(currentEmployee[0]);
        }
        return employees;
    }

    // Add Employee Detail to file
    public static void EmployeeDataWrite(Employee e, String fileLocation)
    {
        StreamWriter fileWriter = new StreamWriter(fileLocation, append: true);

        fileWriter.Write("\n" + e.EmployeeName + ',' + e.Department + ',' + e.Age + ',' + e.Salary + ',' + e.YearsOfService);
        fileWriter.Dispose();
    }
    // Prints Employee Names 
    public static void PrintEmplyoeeNames(Employee[] allEmplyoyeesDetail)
    {
        Console.WriteLine("** Employee Names **");
        int LineNo = 1;
        foreach (Employee employee in allEmplyoyeesDetail)
        {
            Console.WriteLine("{0}   {1}", LineNo++, employee.EmployeeName);
        }

    }
    // Full Detials of Employee
    public static void printEmplyoeeFullDetail(Employee[] allEmplyoyeesDetail)
    {
        Console.WriteLine("** All Employees  **");
        Console.WriteLine("Name      |     Department     |      Age      |      Salary    |      Year of Service");
        foreach (Employee employee in allEmplyoyeesDetail)
        {
            Console.WriteLine(employee.EmployeeName + "      " + employee.Department + "      " + employee.Age + "       " + employee.Salary + "   " + employee.YearsOfService);
        }

    }

    // Calulate Total based on index
    public static int PrintTotalSalary(Employee[] allEmplyoyeesDetail)
    {
        int totalSalary = 0;
        foreach (Employee employee in allEmplyoyeesDetail)
        {

            totalSalary += Convert.ToInt32(employee.Salary);
        }
        return totalSalary;
    }
    // Prints list of Departments and asks for selection
    public static string getDepartmentName()
    {
        Console.WriteLine("*****************************************");
        Console.WriteLine("1 - Information Technology");
        Console.WriteLine("2 - Marketing");
        Console.WriteLine("3 - Engineering ");
        Console.WriteLine("4 - Finance ");
        Console.WriteLine("5 - Human Resourcese ");
        Console.WriteLine("6 - Operations ");

        Console.Write("Select Department Options from 1 to 6:");
        string userDeptInput = Console.ReadLine();

        return userDeptInput;
    }

    // Filter Data based on Department
    public static Employee[] getDepartmentEmployeeData(Employee[] allEmplyoyeesDetail, string deptmentName)
    {
        List<Employee> employees = new List<Employee>();

        foreach (Employee employee in allEmplyoyeesDetail)
        {
            if (employee.Department == deptmentName)
                employees.Add(employee);
        }
        return employees.ToArray();
    }
    // Heighest Earning Employee
    public static void printHeighestEarningEmployee(Employee[] allEmplyoyeesDetail)
    {
        Employee HighEarnerEmployee = allEmplyoyeesDetail[0];
        foreach (Employee employee in allEmplyoyeesDetail)
        {
            if (employee.Salary > HighEarnerEmployee.Salary)
            {
                HighEarnerEmployee = employee;
            }

        }
        Console.WriteLine("Heighest Salary is :{0}", HighEarnerEmployee.Salary);
        HighEarnerEmployee.PrintDetail();


    }
    //Lowest Earning / Salary Employee
    public static void printLowestEarningEmployee(Employee[] allEmplyoyeesDetail)
    {
        Employee LowestEarnerEmployee = allEmplyoyeesDetail[0];
        foreach (Employee employee in allEmplyoyeesDetail)
        {
            if (employee.Salary < LowestEarnerEmployee.Salary)
            {
                LowestEarnerEmployee = employee;
            }
        }
        Console.WriteLine("Lowest Salary is :{0}", LowestEarnerEmployee.Salary);
        LowestEarnerEmployee.PrintDetail();

    }

    // //Long serviced Employee
    public static void printOldestEmployee(Employee[] allEmplyoyeesDetail)
    {
        Employee oldestEmployee = allEmplyoyeesDetail[0];
        foreach (Employee employee in allEmplyoyeesDetail)
        {
            if (employee.YearsOfService > oldestEmployee.YearsOfService)
            {
                oldestEmployee = employee;
            }
        }
        Console.WriteLine("Oldest Employee :");
        oldestEmployee.PrintDetail();
    }
    //Newest Employee
    public static void printNewJoiningEmployee(Employee[] allEmplyoyeesDetail)
    {
        Employee NewsetEmployee = allEmplyoyeesDetail[0];
        foreach (Employee employee in allEmplyoyeesDetail)
        {
            if (employee.YearsOfService < NewsetEmployee.YearsOfService)
            {
                NewsetEmployee = employee;
            }
        }
        Console.WriteLine("Newest Employee :");
        NewsetEmployee.PrintDetail();
    }
}
