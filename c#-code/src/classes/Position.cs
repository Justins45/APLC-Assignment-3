namespace APLCAssignment3.Classes
{
    public class Position
    {
        private string _title;
        private string _role;

        public Position(string title, string role)
        {
            this._title = title;
            this._role = role;
        }

        //setters
        public void SetTitle(string newTitle)
        {
            this._title = newTitle;
        }
        public void SetRole(string newRole)
        {
            this._role = newRole;
        }

        //getters
        public string GetTitle()
        {
            return this._title;
        }
        public string GetRole()
        {
            return this._role;
        }
    }
}