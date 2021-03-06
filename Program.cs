using System;
using System.IO;

namespace ElectricityAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            try
            {
                Electricity electricity = new Electricity();

                Console.WriteLine("Flat number without electricity costs: " + electricity.FlatNumberWithoutElectricityCosts()?? "none");
                Console.WriteLine("Owner surname with max debt: " + electricity.OwnerSurnameWithMaxDebt());

                Console.WriteLine(electricity.PrintReport());
            }
            catch(FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
