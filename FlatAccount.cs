using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityAccounting
{
    class FlatAccount
    {
        public const int MONTH_COUNT = 3;

        public enum Quarter
        {
            Winter = 1,
            String = 2,
            Summer = 3,
            Autumn = 4
        }
        public Quarter QuarterField { get; set; }

        private int flatNumber;
        public int FlatNumber
        {
            get
            {
                return flatNumber;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Flat number cannot be <= 0");
                else
                    flatNumber = value;
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Surname not set");
                else
                    surname = value;
            }
        }
        
        private List<int> meterReadingList;
        public List<int> MeterReadingList
        {
            get
            {
                return meterReadingList;
            }
            set
            {
                if (value.Count != MONTH_COUNT + 1)
                    throw new ArgumentException("Invalid list size");

                for (int i = 0; i < MONTH_COUNT; i++)
                    if (value[i] > value[i + 1])
                        throw new ArgumentException("Value of next meter reading cannot be less than previous");

                meterReadingList = value;
            }
        }

        public FlatAccount(int flatnumber, string surname, List<int> meterReadingList, Quarter quarter)
        {
            FlatNumber = flatnumber;
            Surname = surname;
            MeterReadingList = meterReadingList;
            QuarterField = quarter;
        }

        public override string ToString()
        {
            string output = $"Number: {FlatNumber} Surname: {Surname}\n";

            string[] tempMonth = new string[3];
            switch ((int)QuarterField)
            {
                case 1:
                    tempMonth[0] = "March"; tempMonth[1] = "April"; tempMonth[2] = "May";
                    break;
                case 2:
                    tempMonth[0] = "June"; tempMonth[1] = "July"; tempMonth[2] = "August";
                    break;
                case 3:
                    tempMonth[0] = "September"; tempMonth[1] = "October"; tempMonth[2] = "November";
                    break;
                case 4:
                    tempMonth[0] = "December"; tempMonth[1] = "January"; tempMonth[2] = "February";
                    break;
            }
            output += $"{tempMonth[0]}:\tFirst: {meterReadingList[0]} End: {meterReadingList[1]}\n" +
                $"{tempMonth[1]}:\tFirst: {meterReadingList[1]} End: {meterReadingList[2]}\n" +
                $"{tempMonth[2]}:\tFirst: {meterReadingList[2]} End: {meterReadingList[3]}\n";

            return output;
        }
    }
}
