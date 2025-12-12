namespace APLCAssignment3.Classes
{
    using APLCAssignment3.Classes.Base;

    public class PartTimeEmployee : Employee
    {

        private double _hoursPerWeek;
        private double _hourlyRate;

        public PartTimeEmployee(string firstName, string lastName, Position position, string dob,
                                Department department, Manager manager, double hoursPerWeek,
                                double hourlyRate)
            : base(firstName, lastName, position, dob, department, manager)
        {
            this._hoursPerWeek = hoursPerWeek;
            this._hourlyRate = hourlyRate;
        }

        //setters
        public void SetHoursPerWeek(double newHoursPerWeek)
        {
            this._hoursPerWeek = newHoursPerWeek;
        }
        public void SetHourlyRate(double newHourlyRate)
        {
            this._hourlyRate = newHourlyRate;
        }

        //getters
        public double GetHoursPerWeek()
        {
            return this._hoursPerWeek;
        }
        public double GetHourlyRate()
        {
            return this._hourlyRate;
        }


        public override string GetInformation()
        {

            return $"ID: {this.GetID()}, Name: {this.GetFullName()}, Position: {this.GetPosition()}, Hourly Rate: {this.GetHourlyRate()}, Hours per Week: {this.GetHoursPerWeek()}";
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"{GetFirstName()} Is reporting to {GetFullName()}");
        }

        public override void ClockIn()
        {
            Console.WriteLine(this.GetFirstName() + " has clocked in.");
        }

        public override void ClockOut()
        {
            Console.WriteLine(this.GetFirstName() + " has clocked out.");
        }
    }
}