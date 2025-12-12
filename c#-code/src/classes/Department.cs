namespace APLCAssignment3.Classes
{
    using APLCAssignment3.Classes.Base;
    using System.Collections.Generic;

    public class Department {
        private readonly string _departmentName;
        private Manager _manager;

        public List<Employee> _employees;

        public Department(string departmentName, Manager manager, List<Employee> employees)
        {
            this._departmentName = departmentName;
            this._manager = manager;
            this._employees = employees;
        }
        //chained constructor for simplicity
        public Department(string departmentName, List<Employee> employees)
            : this(departmentName, null, employees)
        {}

        //setter
        public void SetManager(Manager newManager)
        {
            this._manager = newManager;
        }

        //getter
        public Manager GetManager()
        {
            return this._manager;
        }
        public string GetDepartmentName()
        {
            return this._departmentName;
        }

        //methods
        public void AddEmployee(Employee employee)
        {
            this._employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            this._employees.Remove(employee);
        }

        public List<Employee> GetEmployees()
        {
            return this._employees;
        }
    }
}