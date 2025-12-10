package runnables;

import classes.Manager;
import classes.base.Employee;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;

public class WriteFile implements Runnable {

  private final String _content;
  private final String _fileName;

  public WriteFile(List<Employee> list, String fileName) {
    this._fileName = fileName;
    // String builder is used to be a string concatenation device better than a `+=`
    // Uses less memory as `+=` makes a new whole copy each time - so large lists can
    // take up a lot of memory
    StringBuilder sb = new StringBuilder();
    for (Employee item : list) {
      sb.append(item.GetInformation()).append("\n");
    }
    _content = sb.toString();
  }

  @Override
  public void run(){
    try (BufferedWriter writer = new BufferedWriter(new FileWriter(_fileName))) {
      System.out.println("Writing content to " + this._fileName);
      writer.write(_content);
    } catch (IOException e) {
      System.err.println("Error writing to file: " + e);
    }
  }
}
