namespace APLCAssignment3.Classes
{
    using APLCAssignment3.Classes.Base; 

    public class PayrollEmployee : FullTimeEmployee
    {
        public PayrollEmployee(string firstName, string lastName, Position position, string dob, 
                               Department department, Manager manager, double salary)
            : base(firstName, lastName, position, dob, department, manager, salary)
        {}

        //methods
        public void ProcessPayroll()
        {
            Console.WriteLine("Processing payroll");
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"{GetFirstName()} Is driving down to go visit {GetFullName()}");
        }
    }
}