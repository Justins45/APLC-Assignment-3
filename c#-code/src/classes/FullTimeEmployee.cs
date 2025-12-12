namespace APLCAssignment3.Classes
{
    using APLCAssignment3.Classes.Base;

    public class FullTimeEmployee : Employee
    {
        private double _salary;

        public FullTimeEmployee(string firstName, string lastName, Position position, string dob,
                                Department department, Manager manager, double salary)
            : base(firstName, lastName, position, dob, department, manager)
        {
            this._salary = salary;
        }

        public FullTimeEmployee(string firstName, string lastName, Position position, string dob,
                                Department department, double salary)
            : base(firstName, lastName, position, dob, department)
        {
            this._salary = salary;
        }

        public void SetSalary(double newSalary)
        {
            this._salary = newSalary;
        }

        public double GetSalary()
        {
            return this._salary;
        }


        public override string GetInformation()
        {
            return $"ID: {this.GetID()}, Name: {this.GetFullName()}, Position: {this.GetPosition()}, Salary: {this.GetSalary()}";
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"{GetFirstName()} Is sending a ms Teams message to {GetFullName()}");
        }

        public override void ClockIn()
        {
            Console.WriteLine(this.GetFirstName() + " Does not need to Clock in as they are Salaried" +
                              "...");
        }

        public override void ClockOut()
        {
            Console.WriteLine(this.GetFirstName() + " does not need to Clock out...");
        }
    }
}