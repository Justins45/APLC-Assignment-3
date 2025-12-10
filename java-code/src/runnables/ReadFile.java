package runnables;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class ReadFile implements Runnable {

  private final String _fileName;

  public ReadFile(String fileName) {
    this._fileName = fileName;
  }

  @Override
  public void run() {
    try (BufferedReader reader = new BufferedReader(new FileReader(_fileName))) {
      String line;
      System.out.println("Reading file: " + this._fileName);
      System.out.println("==============================================================");
      while ((line = reader.readLine()) != null) {
        System.out.println(line);
      }
      System.out.println("==============================================================");
      System.out.println("End of file!");
    } catch (IOException e) {
      System.err.println("Error reading file: " + e.getMessage());
    }
  }
}
