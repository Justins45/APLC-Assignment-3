package exceptions;

import classes.Manager;
import classes.base.Employee;

public class Exceptions {
  public static int validateInt(String string) throws NumberFormatException {
    try {
      int number = Integer.parseInt(string);

      if (number < 0) {
        throw new NumberFormatException();
      }
      return number;
    } catch (NumberFormatException e) {
      System.err.println("Invalid Number inputted - Please input a valid positive number - " +
              "ex/ 5");
      throw new NumberFormatException("Invalid number inputted: " + e);
    }
  }
  public static double validateDouble(String string) throws NumberFormatException {
    try {
      double number = Double.parseDouble(string);

      if (number < 0.0) {
        throw new NumberFormatException();
      }
      return number;
    } catch (NumberFormatException e) {
      System.err.println("Invalid Number inputted - Please input a valid positive number - " +
              "ex/ 5.6");
      throw new NumberFormatException("Invalid number inputted: " + e);
    }
  }

  public static String validateString(String string) throws RuntimeException {
    try {
      if (string == null || string.isEmpty()) {
        throw new RuntimeException();
      }
      return string;
    } catch (RuntimeException e) {
      System.err.println("One or more string is empty..");
      throw new RuntimeException("Empty String " + e);
    }
  }

  public static char validateYesNo(String string) throws RuntimeException {
    try {
      if (!string.equalsIgnoreCase("y") || !string.equalsIgnoreCase("n")) {
        throw new RuntimeException();
      }
      return string.charAt(0);
    } catch (RuntimeException e) {
      System.err.println("Invalid input detected");
      throw new RuntimeException("Invalid input " + e);
    }
  }

  public static void validateEmployee(Employee employee) throws NullPointerException {
    try {
      if (employee == null) {
        throw new NullPointerException();
      }
    } catch (NullPointerException e) {
      System.err.println("Employee does not exist");
      throw new NullPointerException("Employee does not exist " + e);
    }
  }

  public static void validateManager(Manager manager) throws NullPointerException {
    try {
      if (manager == null) {
        throw new NullPointerException();
      }
    } catch (NullPointerException e) {
      System.err.println("Manager does not exist");
      throw new NullPointerException("Manager does not exist " + e);
    }
  }
}
