package classes;

public class Position {

  private String _title;
  private String _role;

  public Position(String title, String role) {
    this._title = title;
    this._role = role;
  }

  // SETTERS
  public void SetTitle(String newTitle) {
    this._title = newTitle;
  }
  public void SetRole(String newRole) {
    this._role = newRole;
  }

  // GETTERS
  public String GetTitle() {
    return this._title;
  }
  public String GetRole() {
    return this._role;
  }
}
