package classes;

public class PayrollEmployee extends FullTimeEmployee{

  public PayrollEmployee(String firstName, String lastName, Position position, String dob, Department department,
                         Manager manager, Double salary) {
    super(firstName, lastName, position, dob, department, manager, salary);
  }

  // METHODS
  public void processPayroll(){
    System.out.println("Processing payroll");
  }

  public void reportToManager() {
    System.out.println(GetFirstName() + " Is driving down to go visit " + GetFullName());
  }
}
