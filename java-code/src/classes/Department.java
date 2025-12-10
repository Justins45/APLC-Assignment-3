package classes;
import classes.base.Employee;
import java.util.List;

public class Department {

  private final String _departmentName;
  private Manager _manager;
  public List<Employee> _employees;

  public Department(String departmentName, Manager manager, List<Employee> employees) {
    this._departmentName = departmentName;
    this._manager = manager;
    this._employees = employees;
  }
  public Department(String departmentName, List<Employee> employees) {
    this._departmentName = departmentName;
    this._employees = employees;
  }

  //SETTERS
  public void SetManager(Manager newManager) {
    this._manager = newManager;
  }

  //GETTERS
  public Manager GetManager() {
    return this._manager;
  }
  public String GetDepartmentName() {
    return this._departmentName;
  }

  // METHODS
  public void addEmployee(Employee employee) {
    this._employees.add(employee);
  }

  public void removeEmployee(Employee employee) {
    this._employees.remove(employee);
  }

  public List<Employee> GetEmployees() {
    return this._employees;
  }
}
