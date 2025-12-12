namespace APLCAssignment3.Classes
{
    using APLCAssignment3.Classes.Base;
    using APLCAssignment3.Runnables;
    using System.Collections.Generic;
    
    public class Manager : FullTimeEmployee
    {

        public Manager(string firstName, string lastName, Position position, string dob, 
                       Department department, double salary)
            : base(firstName, lastName, position, dob, department, salary)
        {}

        public void EvaluateEmployee(Employee employee)
        {
            Console.WriteLine($"Evaluating: {employee.GetFirstName()}");
        }

        public void AssignTask(Employee employee, string task)
        {
            Console.WriteLine($"Giving task: {task} to: {employee.GetFirstName()}");
        }

        public void GenerateReport(List<Employee> list)
        {
            Console.WriteLine("Generating Report");
            WriteFile writeFile = new WriteFile(list, "report.txt");
            writeFile.Run();
        }

        public void GetReport()
        {
            ReadFile readFile = new ReadFile("report.txt");
            readFile.Run();
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"{GetFirstName()} has no manager to report to!");
        }
    }
}