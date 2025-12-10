package classes;

import classes.base.Employee;

public class FullTimeEmployee extends Employee {

  private double _salary;

  public FullTimeEmployee(String firstName, String lastName, Position position, String dob,
                   Department department, Manager manager, Double salary) {
    super(firstName, lastName, position, dob, department, manager);
    this._salary = salary;
  }
  // Alternate constructor to initialize Full Time Employee without a manager (ex: used for creating a manager)
  public FullTimeEmployee(String firstName, String lastName, Position position, String dob,
                   Department department, Double salary) {
    super(firstName, lastName, position, dob, department);
    this._salary = salary;
  }

  // SETTERS
  public void SetSalary(Double newSalary) {
    this._salary = newSalary;
  }

  // GETTERS
  public Double GetSalary() {
    return this._salary;
  }

  public String GetInformation() {
    return "ID: " + this.GetID() +
            ", Name: " + this.GetFullName() +
            ", Position: " + this.GetPosition() +
            ", Salary: " + this.GetSalary();
  }

  // METHODS
  public void reportToManager() {
    System.out.println(GetFirstName() + " Is sending a ms Teams message to " + GetFullName());
  }

  @Override
  public void clockIn() {
    System.out.println(this.GetFirstName() + " Does not need to Clock in as they are Salaried" +
            "...");
  }

  @Override
  public void clockOut() {
    System.out.println(this.GetFirstName() + " does not need to Clock out...");
  }
}
