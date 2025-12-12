namespace APLCAssignment3.Classes.Base
{
    using APLCAssignment3.Classes;

public abstract class Employee {

    private static int _nextEmployeeID = 0;

    private readonly int _id;
    private string _dateOfBirth;
    private string _firstName;
    private string _lastName;
    private Position _position;
    private Department _department;
    private Manager _manager;

    public Employee (string firstName, string lastName, Position position, string dob, Department department, Manager manager) {
        this._id = _nextEmployeeID++;
        SetFirstName(firstName);
        SetLastName(lastName);
        SetDOB(dob);
        SetPosition(position);
        SetDepartment(department);
        SetManager(manager);
    }
//Alternate constructor for creating employee w/o a manager, using a constructor chain 
    public Employee (string firstName, string lastName, Position position, string dob, Department department)
    : this (firstName, lastName, position, dob, department, null) {}

    //setters

    public void SetFirstName(string newFirstName) {
        this._firstName = newFirstName;
    }

    public void SetLastName(string newLastName) {
        this._lastName = newLastName;
    }

    public void SetDOB(string newDob){
        this._dateOfBirth = newDob;
    }

    public void SetPosition(Position newPosition) {
        this._position = newPosition;
    }

    public void SetDepartment (Department newDepartment) {
        this._department = newDepartment;
    }

    public void SetManager (Manager newManager) {
        this._manager = newManager;
    }

    //getters

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
        return this._id.ToString();
    }
    public Department GetDepartment() {
        return this._department;
    }
    public String GetManager() {
        return this._manager.GetFullName();
    }

    //methods

    public virtual void ClockIn() {
        Console.WriteLine(GetFirstName() + " has clocked in");
    }

    public virtual void ClockOut() {
        Console.WriteLine(GetLastName() + " has clocked out");
    }

    public virtual double GetPaid(double pay) {
        return pay/12;
    }

    public virtual double GetPaid(double pay, double hours) {
        return hours * pay;
    }

    public virtual int GetPaid(int hours, int pay) {
        return hours * pay;
    }

    public virtual void ReportToManager(){}
    public abstract string GetInformation();
}

}