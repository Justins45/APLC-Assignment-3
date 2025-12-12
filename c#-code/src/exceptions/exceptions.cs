namespace APLCAssignment3.Exceptions
{
    using APLCAssignment3.Classes; 
    using APLCAssignment3.Classes.Base; 
    using System;

    public static class Validation
    {
        public static int ValidateInt(string input)
        {
            try
            {
                int number = int.Parse(input);

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(input), "Must be a positive number.");
                }
                return number;
            }
            catch (FormatException e)
            {
                Console.Error.WriteLine("Invalid Number inputted - Please input a valid positive number - ex/ 5");
                throw new FormatException($"Invalid number inputted: {e.Message}", e); 
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Error.WriteLine("Invalid Number inputted - Please input a valid positive number - ex/ 5");
                throw new ArgumentOutOfRangeException($"Invalid number inputted: {e.Message}", e);
            }
        }

        public static double ValidateDouble(string input)
        {
            try
            {
                double number = double.Parse(input);

                if (number < 0.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(input), "Must be a positive number.");
                }
                return number;
            }
            catch (FormatException e)
            {
                Console.Error.WriteLine("Invalid Number inputted - Please input a valid positive number - ex/ 5.6");
                throw new FormatException($"Invalid number inputted: {e.Message}", e);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Error.WriteLine("Invalid Number inputted - Please input a valid positive number - ex/ 5.6");
                throw new ArgumentOutOfRangeException($"Invalid number inputted: {e.Message}", e);
            }
        }

        public static string ValidateString(string input) 
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentException("String cannot be null or empty."); 
                }
                return input;
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine("One or more string is empty..");
                throw new ArgumentException($"Empty String: {e.Message}", e);
            }
        }

        public static char ValidateYesNo(string input) 
        {
            try
            {
                if (!input.Equals("y", StringComparison.OrdinalIgnoreCase) && 
                    !input.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Input must be 'y' or 'n'.");
                }
                return input[0]; 
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine("Invalid input detected");
                throw new ArgumentException($"Invalid input: {e.Message}", e);
            }
        }

        public static void ValidateEmployee(Employee employee) 
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }
            }
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine("Employee does not exist");
                throw new ArgumentNullException($"Employee does not exist: {e.Message}", e);
            }
        }

        public static void ValidateManager(Manager manager) 
        {
            try
            {
                if (manager == null)
                {
                    throw new ArgumentNullException(nameof(manager));
                }
            }
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine("Manager does not exist");
                throw new ArgumentNullException($"Manager does not exist: {e.Message}", e);
            }
        }
    }
}