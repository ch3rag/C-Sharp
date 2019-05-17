// SYSTEM.DATETIME & SYSTEM.TIMESPAN

using System;

namespace Time {
    class Program {
        public static void Main(String[] args) {

            // YEAR, MONTH, DAY
            DateTime dt = new DateTime(2018, 8, 29);

            // WHAT DAY OF THE MONTH IS THIS
            Console.WriteLine("The Day of {0} is {1}.", dt.Date, dt.DayOfWeek);

            Console.WriteLine("It was {0}st day of the year.", dt.DayOfYear);

            // ADDING MONTHS

            dt.AddMonths(2);
            Console.WriteLine("Daylight Saving Time: {0}", dt.IsDaylightSavingTime());

            // HOURS MINUTES SECONDS
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);

            // SUBTRACT 45 MINUTES 

            TimeSpan newTime = ts.Subtract(new TimeSpan(0, 45, 0));
            Console.WriteLine(newTime);

            Console.ReadKey();
        }
    }
}