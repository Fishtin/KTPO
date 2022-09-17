using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4317.SafyanovAA.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }
        public bool IsValidLogFileName(string fileName) 
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName)) 
            {
                throw new ArgumentException("имя фаила должно быть задано");
            }
            if (!fileName.EndsWith(".SAA", StringComparison.CurrentCultureIgnoreCase)) 
            {
                return false;
            }

            WasLastFileNameValid = true;

            return true;
            
        }

    }
}
