namespace APLCAssignment3
{
    using APLCAssignment3.Classes;
    using APLCAssignment3.Classes.Base;
    using APLCAssignment3.Exceptions;
    using System.Collections.Generic; 
    using System;

    public class Program
    {
        public static List<Employee> SalesStaff = new List<Employee>();
        public static List<Employee> TempList = new List<Employee>();
        public static List<Manager> SalesManagers = new List<Manager>();

        public static void Main(string[] args)
        {
            Employee foundEmployee = null;

            List<Department> departments = new List<Department>();
            
            Department sales = new Department("Sales", SalesStaff); 
            departments.Add(sales);

            List<Position> positions = new List<Position>();
            Position payroll = new Position("pay roll", "Payroll");
            Position manager = new Position("manager", "Manager");
            Position associate = new Position("associate", "Associate");

            positions.Add(payroll);
            positions.Add(associate);
            positions.Add(manager);

            Manager vivek = new Manager("Vivek", "Patel", manager, "2000-05-12", sales, 59000.00);
            
            FullTimeEmployee justin = new FullTimeEmployee("Justin", "Shaw", associate, "2002-04-09",
                sales, vivek, 43250.39);
            PartTimeEmployee jason = new PartTimeEmployee("Jason", "Grant", associate, "2003-12-24",
                sales, vivek, 22.5, 15.75);
            PayrollEmployee dylane = new PayrollEmployee("Dylane", "Cunningham", payroll, "2001-08-11",
                sales, vivek, 78000.00);

            SalesManagers.Add(vivek);
            SalesStaff.Add(justin);
            SalesStaff.Add(jason);
            SalesStaff.Add(dylane);

            string mainMenuLoggedOut = @"
            ===========================
            1. Employee
            2. Manager Login
            3. Exit
            ===========================
            ";
            string payrollMenu = @"
            ===========================
            1. Add Employee
            2. Add Manager
            3. Remove Employee
            4. View all Employee's
            5. Exit
            ===========================
            ";
            string managerMenu = @"
            ==========================
            1. Evaluate Employee
            2. Assign Task
            3. Generate Report
            4. Report to manager
            5. Exit
            ==========================
            ";
            string associateMenu = @"
            ==========================
            1. Report to manager
            2. Clock in
            3. Clock out
            4. Exit
            ==========================
            ";

            bool running = true;

            while (running)
            {
                try
                {
                    Console.WriteLine(mainMenuLoggedOut);
                    string userInput = Console.ReadLine();

                    Validation.ValidateInt(userInput); 

                    switch (userInput)
                    {
                        case "1":
                            Console.Write("Please enter user ID to login: ");
                            string employeeId = Console.ReadLine();
                            Validation.ValidateInt(employeeId);
                            foundEmployee = FindEmployee(employeeId);

                            if (foundEmployee == null)
                            {
                                Console.WriteLine("Employee does not exist");
                                break;
                            }
                            
                            string nameInput; 
                            
                            switch (foundEmployee.GetPosition().GetRole())
                            {
                                case "Payroll":
                                    Console.WriteLine(payrollMenu);
                                    userInput = Console.ReadLine();
                                    Validation.ValidateInt(userInput);

                                    switch (userInput)
                                    {
                                        case "1":
                                            // add employee
                                            Console.WriteLine("Please enter First and last name of the new Employee");
                                            nameInput = Console.ReadLine();
                                            string employeeName = Validation.ValidateString(nameInput);

                                            string[] employeeNameParts = employeeName.Split(' ');

                                            // get position
                                            Console.WriteLine("Enter employees position");
                                            string positionInput = Console.ReadLine();
                                            string employeePosition = Validation.ValidateString(positionInput);

                                            Position foundPosition = null;
                                            foreach (Position p in positions)
                                            {
                                                if (p.GetTitle().Equals(employeePosition, StringComparison.OrdinalIgnoreCase)) 
                                                {
                                                    foundPosition = p;
                                                    break; // Found the position, exit loop
                                                }
                                            }
                                            
                                            // If position is not found, create and add it
                                            if (foundPosition == null)
                                            {
                                                foundPosition = new Position(employeePosition, employeePosition);
                                                positions.Add(foundPosition);
                                            }

                                            // dob
                                            Console.WriteLine("Please enter new employees date of birth");
                                            string employeeDob = Console.ReadLine();
                                            string employeeDobString = Validation.ValidateString(employeeDob);

                                            // department
                                            Console.WriteLine("Please enter a department for the new employee");
                                            string employeeDepartment = Console.ReadLine();

                                            Department foundDepartment = null;
                                            foreach (Department d in departments)
                                            {
                                                if (d.GetDepartmentName().Equals(employeeDepartment, StringComparison.OrdinalIgnoreCase))
                                                {
                                                    foundDepartment = d;
                                                    break; // Found the department, exit loop
                                                }
                                            }
                                            
                                            if (foundDepartment == null)
                                            {
                                                Console.Error.WriteLine($"Department {employeeDepartment} not found...");
                                                break;
                                            }

                                            // full-time or part-time
                                            Console.WriteLine("Is the employee part-time? (y/n)");
                                            string partTimeQ = Console.ReadLine();
                                            char answer = Validation.ValidateYesNo(partTimeQ);

                                            // create employee
                                            char yes = 'y';
                                            if (char.ToLower(answer) == yes)
                                            {
                                                // pay per hour
                                                Console.WriteLine("Please enter how much this employee will be paid per hour.");
                                                string employeePay = Console.ReadLine();
                                                double employeePayNum = Validation.ValidateDouble(employeePay);

                                                // hours per week
                                                Console.WriteLine("Please enter how many hours per week this employee will work.");
                                                string employeeHours = Console.ReadLine();
                                                double employeeHoursNum = Validation.ValidateDouble(employeeHours);

                                                PartTimeEmployee newPartTimer = new PartTimeEmployee(
                                                    employeeNameParts[0],
                                                    employeeNameParts[1],
                                                    foundPosition,
                                                    employeeDobString,
                                                    foundDepartment,
                                                    foundDepartment.GetManager(),
                                                    employeeHoursNum,
                                                    employeePayNum
                                                );
                                                TempList.Add(newPartTimer);
                                                Console.WriteLine($"Added new employee {newPartTimer.GetFullName()} to the system!"); // Use interpolation
                                            }
                                            else
                                            {
                                                Console.WriteLine("Please enter how much this employee will be paid per year.");
                                                string employeeSalary = Console.ReadLine();
                                                double employeeSalaryNum = Validation.ValidateDouble(employeeSalary);

                                                FullTimeEmployee newFullTimer = new FullTimeEmployee(
                                                    employeeNameParts[0],
                                                    employeeNameParts[1],
                                                    foundPosition,
                                                    employeeDobString,
                                                    foundDepartment,
                                                    foundDepartment.GetManager(),
                                                    employeeSalaryNum
                                                );
                                                TempList.Add(newFullTimer);
                                                Console.WriteLine($"Added new employee {newFullTimer.GetFullName()} to the system!");
                                            }

                                            break;
                                        case "2":
                                            // add manger logic
                                            Console.WriteLine("Please enter First and last name of the new manager");
                                            nameInput = Console.ReadLine();
                                            string managerName = Validation.ValidateString(nameInput);

                                            string[] managerNameParts = managerName.Split(' ');

                                            // get dob
                                            Console.WriteLine("Please enter new managers date of birth");
                                            string dobInput = Console.ReadLine();
                                            string managerDob = Validation.ValidateString(dobInput);

                                            // get department
                                            Console.WriteLine("Please enter a department for the new manager to manage");
                                            string departmentInput = Console.ReadLine();
                                            string departmentString = Validation.ValidateString(departmentInput);

                                            //get department
                                            Department newDepartment = new Department(departmentString, TempList); 
                                            departments.Add(newDepartment);

                                            // get salary
                                            Console.WriteLine("Please enter the salary of the new manager");
                                            string salaryInput = Console.ReadLine();
                                            double salary = Validation.ValidateDouble(salaryInput);

                                            // make manager
                                            Console.WriteLine("Creating new manager...");
                                            Manager newManager = new Manager(
                                                managerNameParts[0],
                                                managerNameParts[1],
                                                manager,
                                                managerDob,
                                                newDepartment,
                                                salary);
                                            SalesManagers.Add(newManager);
                                            Console.WriteLine(newManager.GetInformation());

                                            break;
                                        case "3":
                                            // removing employees
                                            Console.WriteLine("Please enter an Employee's ID to remove them");
                                            userInput = Console.ReadLine();
                                            Validation.ValidateInt(userInput);
                                            foundEmployee = FindEmployee(userInput);
                                            Validation.ValidateEmployee(foundEmployee); // Uses Validation method

                                            SalesStaff.Remove(foundEmployee);
                                            Console.WriteLine($"Removed {foundEmployee.GetFullName()} from the team");
                                            break;
                                        case "4":
                                            // viewing employees
                                            Console.WriteLine("Viewing all employee information");
                                            Console.WriteLine("================================");
                                            ViewAllEmployees(SalesStaff); // Calls the helper method below
                                            break;
                                        case "5":
                                            Console.WriteLine("Now Exiting - Have a wonderful day!");
                                            running = false;
                                            break;
                                        default:
                                            Console.WriteLine("Please enter a valid number (1-5)");
                                            break;
                                    }
                                    break;

                                case "Associate":
                                    // associate menu 
                                    Console.WriteLine(associateMenu);
                                    userInput = Console.ReadLine();
                                    Validation.ValidateInt(userInput);
                                    
                                    switch (userInput)
                                    {
                                        case "1":
                                            foundEmployee.ReportToManager();
                                            break;
                                        case "2":
                                            foundEmployee.ClockIn();
                                            break;
                                        case "3":
                                            foundEmployee.ClockOut();
                                            break;
                                        case "4":
                                            Console.WriteLine("Now Exiting - Have a wonderful day!");
                                            running = false;
                                            break;
                                        default:
                                            Console.WriteLine("Please enter a valid input (1-4)");
                                            break;
                                    }
                                    break;
                            }
                            break;

                        case "2": // manager login
                            Console.Write("Please enter user ID to login: ");
                            string managerId = Console.ReadLine();
                            Validation.ValidateInt(managerId);
                            Manager foundManager = FindManager(managerId);
                            Validation.ValidateManager(foundManager);

                            Console.WriteLine(managerMenu);
                            userInput = Console.ReadLine();
                            Validation.ValidateInt(userInput);

                            switch (userInput)
                            {
                                case "1":
                                    // evaluate employee
                                    Console.WriteLine("Please enter an employee ID to evaluate. ");
                                    userInput = Console.ReadLine();
                                    Validation.ValidateInt(userInput);
                                    foundEmployee = FindEmployee(userInput);
                                    Validation.ValidateEmployee(foundEmployee);

                                    foundManager.EvaluateEmployee(foundEmployee);
                                    break;
                                case "2":
                                    // assign to employee
                                    Console.WriteLine("Add a task name to assign to an Employee");
                                    string taskName = Console.ReadLine();

                                    Console.WriteLine("Enter an employee ID to assign this task to.");
                                    userInput = Console.ReadLine();
                                    Validation.ValidateInt(userInput);
                                    foundEmployee = FindEmployee(userInput);
                                    Validation.ValidateEmployee(foundEmployee);

                                    foundManager.AssignTask(foundEmployee, taskName);
                                    break;
                                case "3":
                                    // generate reprt
                                    Console.WriteLine("Generating a report - please wait....");
                                    foundManager.GenerateReport(SalesStaff);
                                    foundManager.GetReport();
                                    break;
                                case "4":
                                    // report to manager
                                    foundManager.ReportToManager();
                                    break;
                                case "5":
                                    Console.WriteLine("Now Exiting - Have a wonderful day!");
                                    running = false;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid number (1-5)");
                                    break;
                            }
                            break;

                        case "3": // exit
                            Console.WriteLine("Now Exiting - Have a wonderful day!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input (1-3)");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"\n*** Error: {ex.GetType().Name} - {ex.Message} ***\n");
                }
            }
        }

        public static Employee FindEmployee(string id)
        {
            foreach (Employee e in SalesStaff)
            {
                if (e.GetID().Equals(id))
                {
                    return e;
                }
            }
            return null;
        }

        public static Manager FindManager(string id)
        {
            foreach (Manager m in SalesManagers)
            {
                if (m.GetID().Equals(id))
                {
                    return m;
                }
            }
            return null;
        }

        public static void ViewAllEmployees(List<Employee> employees)
        {
            foreach (Employee item in employees)
            {
                Console.WriteLine(item.GetInformation());
            }
        }
    }
}