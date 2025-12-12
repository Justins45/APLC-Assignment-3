namespace APLCAssignment3.Runnables
{
    using APLCAssignment3.Classes;
    using APLCAssignment3.Classes.Base;  
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Text;

    public class WriteFile
    {
        private readonly string _content;
        private readonly string _fileName;

        public WriteFile(List<Employee> list, string fileName)
        {
            this._fileName = fileName;
            
            StringBuilder sb = new StringBuilder(); 
            
            foreach (Employee item in list) 
            {
                sb.Append(item.GetInformation()).Append(Environment.NewLine);
            }
            
            _content = sb.ToString();
        }

        public void Run()
        {
            try
            {
                Console.WriteLine($"Writing content to {this._fileName}");
            
                File.WriteAllText(_fileName, _content);

            }
            catch (IOException e)
            {
                Console.Error.WriteLine($"Error writing to file {e.Message}");
            }
        }
    }
}