using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ElectricityAccounting
{
    static class ElectricityInput
    {
        static public string FileInput()
        {
            string output = "";

            StreamReader streamReader = new StreamReader("../../../input.txt");
            
            output = streamReader.ReadToEnd();

            return output;
        }
    }
}
