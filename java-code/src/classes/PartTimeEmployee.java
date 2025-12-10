package classes;

import classes.base.Employee;

public class PartTimeEmployee extends Employee {

  private Double _hoursPerWeek;
  private Double _hourlyRate;

  public PartTimeEmployee(String firstName, String lastName, Position position, String dob,
                          Department department, Manager manager, Double hoursPerWeek,
                          Double hourlyRate) {
    super(firstName, lastName, position, dob, department, manager);
    this._hoursPerWeek = hoursPerWeek;
    this._hourlyRate = hourlyRate;
  }

  // SETTERS
  public void SetHoursPerWeek(Double newHoursPerWeek) {
    this._hoursPerWeek = newHoursPerWeek;
  }
  public void SetHourlyRate(Double newHourlyRate) {
    this._hourlyRate = newHourlyRate;
  }

  // GETTERS
  public Double GetHoursPerWeek() {
    return this._hoursPerWeek;
  }
  public Double GetHourlyRate() {
    return this._hourlyRate;
  }

  public String GetInformation() {
    return "ID: " + this.GetID() +
            ", Name: " + this.GetFullName() +
            ", Position: " + this.GetPosition() +
            ", Hourly Rate: " + this.GetHourlyRate() +
            ", Hours per Week: " + this.GetHoursPerWeek();
  }

  // METHODS
  public void reportToManager() {
    System.out.println(GetFirstName() + " Is going to the office of " + GetFullName());
  }

  @Override
  public void clockIn() {
    System.out.println(this.GetFirstName() + " has clocked in.");
  }

  @Override
  public void clockOut() {
    System.out.println(this.GetFirstName() + " has clocked out.");
  }

}
