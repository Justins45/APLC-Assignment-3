import classes.*;
import classes.base.Employee;
import java.util.ArrayList;
import java.util.List;

import static exceptions.Exceptions.*;

// initialize default salesStaff array
public static List<Employee> salesStaff = new ArrayList<>();
public static List<Employee> tempList = new ArrayList<>();
public static List<Manager> salesManagers = new ArrayList<>();

void main() {

  // initialize default departments
  List<Department> departments = new ArrayList<>();
  Department sales = new Department("Sales", salesStaff);

  departments.add(sales);

  // initialize default positions
  List<Position> positions = new ArrayList<>();
  Position payroll = new Position("pay roll", "Payroll");
  Position manager = new Position("manager", "Manager");
  Position associate = new Position("associate", "Associate");

  positions.add(payroll);
  positions.add(associate);
  positions.add(manager);

  // initialize default profiles (Employees, Managers, Payroll Staff)
  Manager vivek = new Manager("Vivek", "Patel", manager, "2000-05-12", sales, 59000.00);
  FullTimeEmployee justin = new FullTimeEmployee("Justin", "Shaw", associate, "2002-04-09",
          sales, vivek, 43250.39);
  PartTimeEmployee jason = new PartTimeEmployee("Jason", "Grant", associate, "2003-12-24",
          sales, vivek, 22.5, 15.75);
  PayrollEmployee dylane = new PayrollEmployee("Dylane", "Cunningham", payroll, "2001-08-11",
          sales, vivek, 78000.00);

  // add default profiles to salesStaff array
  salesManagers.add(vivek);

  salesStaff.add(justin);
  salesStaff.add(jason);
  salesStaff.add(dylane);

  // used for finding ID numbers for staff
  // for (Employee e : salesStaff) {
  //  System.out.println(e.GetID() + " " + e.GetFirstName());
  // }

  // Set Menu layouts
  String mainMenuLoggedOut = """
          ===========================
          1. Employee
          2. Manager Login
          3. Exit
          ===========================
          """;
  String payrollMenu = """
          ===========================
          1. Add Employee
          2. Add Manager
          3. Remove Employee
          4. View all Employee's
          5. Exit
          ===========================
          """;
  String managerMenu = """
          ==========================
          1. Evaluate Employee
          2. Assign Task
          3. Generate Report
          4. Report to manager
          5. Exit
          ==========================
          """;
  String associateMenu = """
          ==========================
          1. Report to manager
          2. Clock in
          3. Clock out
          4. Exit
          ==========================
          """;

  Scanner scanner = new Scanner(System.in);
  boolean running = true;

  while (running) {
    // Display login options
    System.out.println(mainMenuLoggedOut);
    String userInput = scanner.nextLine();

    // validate input
    validateInt(userInput);

    // Initialize reused variables
    Employee foundEmployee;

    switch (userInput) {
      case "1":
        System.out.print("Please enter user ID to login: ");
        String employeeId = scanner.nextLine();
        validateInt(employeeId);
        foundEmployee = findEmployee(employeeId);

        if (foundEmployee == null) {
          // early exit
          System.out.println("Employee does not exist");
          break;
        }
          scanner.reset();
        String nameInput;
          switch (foundEmployee.GetPosition().GetRole()) {
            case "Payroll":
              System.out.println(payrollMenu);
              userInput = scanner.nextLine();
              validateInt(userInput);
              switch (userInput){
                case "1":
                  // add employee
                  System.out.println("Please enter First and last name of the new Employee");
                  nameInput = scanner.nextLine();
                  String employeeName = validateString(nameInput);

                  String[] employeeNameParts = employeeName.split(" "); // [0] => first name |
                  // [1] => Last name

                  // get position
                  System.out.println("Enter employees position");
                  String positionInput = scanner.nextLine();
                  String employeePosition = validateString(positionInput);

                  Position foundPosition = null;
                  for (Position p : positions) {
                    if (p.GetTitle().equals(employeePosition)) {
                      foundPosition = p;
                    }
                  }
                  if (!positions.contains(foundPosition)) {
                    Position newPosition = new Position(employeePosition, employeePosition);
                    positions.add(newPosition);
                  }

                  // dob
                  System.out.println("Please enter new employees date of birth");
                  String employeeDob = scanner.nextLine();
                  String employeeDobString = validateString(employeeDob);


                  // department
                  System.out.println("Please enter a department for the new employee");
                  String employeeDepartment = scanner.nextLine();

                  Department foundDepartment = null;
                  for (Department d : departments) {
                    if (d.GetDepartmentName().equals(employeeDepartment)) {
                      foundDepartment = d;
                    }
                  }
                  if (!departments.contains(foundDepartment)) {
                    System.err.println("Department " + employeeDepartment + " not found...");
                    break;
                  }

                  // full-time or part-time
                  System.out.println("Is the employee part-time? (y/n)");
                  String partTimeQ = scanner.nextLine();
                  char answer = validateYesNo(partTimeQ);

                  // create employee
                  char yes = 'y';
                  if (answer == yes) {
                    // pay per hour
                    System.out.println("Please enter how much this employee will be paid per " +
                            "hour.");
                    String employeePay = scanner.nextLine();
                    Double employeePayNum = validateDouble(employeePay);

                    // hours per week
                    System.out.println("Please enter how many hours per week this employee " +
                            "will work.");
                    String employeeHours = scanner.nextLine();
                    Double employeeHoursNum = validateDouble(employeeHours);

                    assert foundDepartment != null;
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
                    tempList.add(newPartTimer);
                    System.out.println("Added new employee " + newPartTimer + "to the system!");

                  } else {
                    System.out.println("Please enter how much this employee will be paid per " +
                            "year.");
                    String employeeSalary = scanner.nextLine();
                    Double employeeSalaryNum = validateDouble(employeeSalary);

                    assert foundDepartment != null;
                    FullTimeEmployee newFullTimer = new FullTimeEmployee(
                            employeeNameParts[0],
                            employeeNameParts[1],
                            foundPosition,
                            employeeDobString,
                            foundDepartment,
                            foundDepartment.GetManager(),
                            employeeSalaryNum
                    );
                    tempList.add(newFullTimer);
                    System.out.println("Added new employee " + newFullTimer + "to the system!");
                  }

                  break;
                case "2":
                  // add manager
                  // get first + last name
                  System.out.println("Please enter First and last name of the new manager");
                  nameInput = scanner.nextLine();
                  String managerName = validateString(nameInput);

                  // get first half - find separator " " and then get second half
                  String[] managerNameParts = managerName.split(" "); // [0] => first name | [1] =>
                  // Last name

                  // get position
                  // position => manager

                  // get dob
                  System.out.println("Please enter new managers date of birth");
                  String dobInput = scanner.nextLine();
                  String managerDob = validateString(dobInput);

                  // get department
                  System.out.println("Please enter a department for the new manager to manage");
                  String departmentInput = scanner.nextLine();
                  String departmentString = validateString(departmentInput);

                  Department newDepartment = new Department(departmentString, tempList);

                  // get salary
                  System.out.println("Please enter the salary of the new manager");
                  String salaryInput = scanner.nextLine();
                  Double salary = validateDouble(salaryInput);

                  // make manager
                  System.out.println("Creating new manager...");
                  Manager newManager = new Manager(
                          managerNameParts[0],
                          managerNameParts[1],
                          manager,
                          managerDob,
                          newDepartment,
                          salary);
                  salesManagers.add(newManager);
                  System.out.println(newManager.GetInformation());

                  break;
                case "3":
                  System.out.println("Please enter an Employee's ID to remove them");
                  userInput = scanner.nextLine();
                  validateInt(userInput);
                  foundEmployee = findEmployee(userInput);
                  validateEmployee(foundEmployee);

                  salesStaff.remove(foundEmployee);
                  System.out.println("Removed " + foundEmployee.GetFullName() + " from the " +
                          "team");
                  break;
                case "4":
                  System.out.println("Viewing all employee information");
                  System.out.println("================================");
                  viewAllEmployees(salesStaff);
                  break;
                case "5":
                  System.out.println("Now Exiting - Have a wonderful day!");
                  running = false;
                  break;
                default:
                  System.out.println("Please enter a valid number (1-5)");
                  break;
              }
              break;
            case "Associate":
              System.out.println(associateMenu);
              userInput = scanner.nextLine();
              validateInt(userInput);
              switch (userInput){
                case "1":
                  foundEmployee.reportToManager();
                  break;
                case "2":
                  foundEmployee.clockIn();
                  break;
                case "3":
                  foundEmployee.clockOut();
                  break;
                case "4":
                  System.out.println("Now Exiting - Have a wonderful day!");
                  running = false;
                  break;
                default:
                  System.out.println("Please enter a valid input (1-4)");
                  break;
              }
              break;
        }
        break;
      case "2":
        // get manager.
        System.out.print("Please enter user ID to login: ");
        String managerId = scanner.nextLine();
        validateInt(managerId);
        Manager foundManager = findManager(managerId);
        validateManager(foundManager);

          // Print manager menu
          System.out.println(managerMenu);
          userInput = scanner.nextLine();
          validateInt(userInput);
          switch (userInput){
            case "1":
              System.out.println("Please enter an employee ID to evaluate. ");
              userInput = scanner.nextLine();
              validateInt(userInput);
              foundEmployee = findEmployee(userInput);
              validateEmployee(foundEmployee);

              // evaluate employee
              foundManager.evaluateEmployee(foundEmployee);
              break;
            case "2":
              System.out.println("Add a task name to assign to an Employee");
              String taskName = scanner.nextLine();

              System.out.println("Enter an employee ID to assign this task to.");
              userInput = scanner.nextLine();
              validateInt(userInput);
              foundEmployee = findEmployee(userInput);
              validateEmployee(foundEmployee);

              // Assign task
              foundManager.assignTask(foundEmployee, taskName);
              break;
            case "3":
              System.out.println("Generating a report - please wait....");
              foundManager.generateReport(salesStaff);
              foundManager.getReport();
              break;
            case "4":
              foundManager.reportToManager();
              break;
            case "5":
              System.out.println("Now Exiting - Have a wonderful day!");
              running = false;
              break;
            default:
              System.out.println("Please enter a valid number (1-5)");
              break;
          }
          break;
      case "3":
        System.out.println("Now Exiting - Have a wonderful day!");
        running = false;
        break;
      default:
        System.out.println("Please enter a valid input (1-2)");
        running = false;
    }
  }
  scanner.close();
}

public Employee findEmployee(String id){
  for (Employee e : salesStaff) {
    if (e.GetID().equals(id)) {
      return e;
    }
  }
  return null;
}

public Manager findManager(String id){
  for (Manager m : salesManagers){
    if (m.GetID().equals(id)){
      return m;
    }
  }
  return null;
}

public void viewAllEmployees(List<Employee> employees) {
  for (Employee item : employees) {
      System.out.println(item.GetInformation());
  }
}
