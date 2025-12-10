package classes.base;

import classes.Department;
import classes.Manager;
import classes.Position;

public abstract class Employee {

  // Employee ID counter
  private static int _nextEmployeeID = 0;

  private final int _id;
  private String _dateOfBirth;
  private String _firstName;
  private String _lastName;
  private Position _position;
  private Department _department;
  private Manager _manager;


  public Employee(String firstName, String lastName, Position position, String dob, Department department,
                  Manager manager) {
    this._id = _nextEmployeeID++;
    SetFirstName(firstName);
    SetLastName(lastName);
    SetPosition(position);
    SetDOB(dob);
    SetDepartment(department);
    SetManager(manager);
  }
  // Alternate constructor to initialize an Employee without a manager (ex: used for creating a manager)
  public Employee(String firstName, String lastName, Position position, String dob, Department department) {
    this._id = _nextEmployeeID++;
    SetFirstName(firstName);
    SetLastName(lastName);
    SetPosition(position);
    SetDOB(dob);
    SetDepartment(department);
  }

  // SETTERS
  public void SetFirstName(String newFirstName) {
    this._firstName = newFirstName;
  }
  public void SetLastName(String newLastName) {
    this._lastName = newLastName;
  }
  public void SetPosition(Position newPosition) {
    this._position = newPosition;
  }
  public void SetDOB(String newDOB){
    this._dateOfBirth = newDOB;
  }
  public void SetDepartment(Department newDepartment) {
    this._department = newDepartment;
  }
  public void SetManager(Manager newManager) {
    this._manager = newManager;
  }

  // GETTERS
  public String GetFirstName() {
    return this._firstName;
  }
  public String GetLastName() {
    return this._lastName;
  }
  public String GetFullName() {
    return GetFirstName() + " " + GetLastName();
  }
  public Position GetPosition() {
    return this._position;
  }
  public String GetDOB() {
    return this._dateOfBirth;
  }
  public String GetID() {
    return String.valueOf(this._id);
  }
  public Department GetDepartment() {
    return this._department;
  }
  public String GetManager() {
    return this._manager.GetFullName();
  }

  // METHODS
  public void clockIn() {
    System.out.println(GetFirstName() + " clocked in!");
  }
  public void clockOut() {
    System.out.println(GetFirstName() + " clocked out!");
  }

  public Double getPaid(Double pay) {
    return pay / 12;
  }
  public Double getPaid(Double hours, Double pay) {
    return hours * pay;
  }
  public int getPaid(int hours, int pay) {
    return hours * pay;
  }

  public void reportToManager(){};
  public abstract String GetInformation();
}
