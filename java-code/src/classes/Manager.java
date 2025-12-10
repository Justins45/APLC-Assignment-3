package classes;

import java.util.List;
import classes.base.Employee;
import runnables.ReadFile;
import runnables.WriteFile;

public class Manager extends FullTimeEmployee {

  public Manager(String firstName, String lastName, Position position, String dob, Department department,
                 Double salary){
    super(firstName, lastName, position, dob, department, salary);
  }

  // METHODS
  public void evaluateEmployee(Employee employee) {
    System.out.println("Evaluating: " + employee.GetFirstName());
    // TODO: Write actual code here
  }

  public void assignTask(Employee employee, String task) {
    System.out.println("Giving task: " + task + " to: " + employee.GetFirstName());
  }

  public void generateReport(List<Employee> list) {
    System.out.println("Generating Report");
    WriteFile writeFile = new WriteFile(list, "report.txt");
    writeFile.run();
  }

  public void getReport() {
    ReadFile readFile = new ReadFile("report.txt");
    readFile.run();
  }

  public void reportToManager() {
    System.out.println(GetFirstName() + " has no manager to report to!");
  }
}
