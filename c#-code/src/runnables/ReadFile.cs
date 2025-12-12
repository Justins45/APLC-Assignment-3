namespace APLCAssignment3.Runnables
{
    using System.IO;
    using System; 

    public class ReadFile
    {
        private readonly string _fileName;

        public ReadFile(string fileName)
        {
            this._fileName = fileName;
        }


        public void Run() 
        {
            try 
            {
                Console.WriteLine("Reading file: " + this._fileName);
                Console.WriteLine("==============================================================");

                foreach (string line in File.ReadLines(_fileName))
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine("==============================================================");
                Console.WriteLine("End of file");
            }
            catch (IOException e)
            {
                Console.Error.WriteLine($"Unable to read file {e.Message}");
            }
        }
    }
}