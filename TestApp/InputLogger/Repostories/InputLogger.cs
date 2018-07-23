using InputLogger.Interfaces;
using System;
using System.IO;

namespace InputLogger.Repostories
{
    public class InputLogger : IInputLogger
    {
        private readonly string SubPath = @"..\logs.txt";
        private readonly string LoggerPath;

        public InputLogger()
        {
            this.LoggerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SubPath);
        }

        public void SaveWrongInput(string input)
        {
            using (StreamWriter sw = File.AppendText(LoggerPath))
            {
                sw.WriteLine(input);
            }
            
        }
    }
}
