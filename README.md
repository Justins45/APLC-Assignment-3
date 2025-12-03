# APLC-Assignment-3

## Scenario

SAIT requires a new employee management program. Your task is to develop a prototype program to manage employee information efficiently.

In this prototype, employees can be either part-time or full-time. For instance, instructors may be part-time or full-time employees, whereas payroll employees are exclusively full-time.

Each employee must have the following information:

- First name and last name
- Date of birth
- ID
- Current position
- Department (Payroll, Staff, Administration, IT)

Positions vary by department. For example, staff could be senior instructors, junior instructors, or adjunct instructors. For other departments, create your own hierarchy of positions.

Each employee must report to their manager. Implement a method for each employee to report to their manager using dynamic binding. Additionally, demonstrate static binding with at least one or two methods, such as the getPaid() method.

The program should include classes for exception handling to cover all possible exceptions (invalid data, math exceptions, etc.). It should also persist data to files and be capable of running other threads while reading or writing files.