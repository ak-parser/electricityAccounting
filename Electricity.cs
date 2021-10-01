using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElectricityAccounting
{
    class Electricity
    {
        public int CountFlat { get; set; }

        public List<FlatAccount> flatAccountList = new List<FlatAccount>();
        public List<FlatAccount> FlatAccountList
        {
            get
            {
                return flatAccountList;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Flat account list account cannot be NULL");
                else
                    flatAccountList = value;
            }
        }

        public FlatAccount this[int index]
        {
            get
            {
                return flatAccountList[index];
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Flat account account cannot be NULL");
                else
                    flatAccountList[index] = value;
            }
        }

        //Summary
        //    Reads data about electricity accounting
        public Electricity()
        {
            StringReader inputReader = new StringReader(ElectricityInput.FileInput());

            string[] inputList = inputReader.ReadLine().Split(" ");
            CountFlat = Convert.ToInt32(inputList[0]);
            if (CountFlat <= 0)
                throw new ArgumentException("Flat count cannot be <= 0");

            int quarter = Convert.ToInt32(inputList[1]);
            if (quarter < 1 || quarter > 4)
                throw new ArgumentException("Invalid quarter");

            for (int i = 0; i < CountFlat; i++)
            {
                inputList = inputReader.ReadLine().Split(" ");

                List<int> meterReadings = new List<int>();

                string[] meterReading = inputReader.ReadLine().Split(" ");
                meterReadings.Add(Convert.ToInt32(meterReading[0]));
                meterReadings.Add(Convert.ToInt32(meterReading[1]));
                
                for (int j = 1; j < FlatAccount.MONTH_COUNT; j++)
                {
                    meterReading = inputReader.ReadLine().Split(" ");
                    meterReadings.Add(Convert.ToInt32(meterReading[1]));
                }

                FlatAccountList.Add(new FlatAccount(Convert.ToInt32(inputList[0]), inputList[1], meterReadings, Enum.Parse<FlatAccount.Quarter>(quarter.ToString()) ));
            }
        }

        public string PrintReport()
        {
            string output = "\nReport:\n";

            foreach (var elem in flatAccountList)
                output += elem.ToString() + "\n";

            return output;
        }

        public string OwnerSurnameWithMaxDebt()
        {
            int max = 0;
            string surname = "none";

            foreach (var elem in FlatAccountList)
                if (max < elem.MeterReadingList[FlatAccount.MONTH_COUNT - 1] - elem.MeterReadingList[0])
                {
                    max = elem.MeterReadingList[FlatAccount.MONTH_COUNT - 1] - elem.MeterReadingList[0];
                    surname = elem.Surname;
                }

            return surname;
        }

        public int? FlatNumberWithoutElectricityCosts()
        {
            foreach (var elem in FlatAccountList)
                if (elem.MeterReadingList[FlatAccount.MONTH_COUNT - 1] == elem.MeterReadingList[0])
                    return elem.FlatNumber;

            return null;
        }
    }
}
