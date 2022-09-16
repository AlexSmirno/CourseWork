namespace Blazor.Data
{
    public class Date
    {
        public int AmountOfDayInMonth { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public readonly int EndOfDay = 21;
        public readonly int StartOfDay = 9;

        public Date()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            Day = DateTime.Now.Day;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;

            AmountOfDayInMonth = DateTime.DaysInMonth(Year, Month);
        }

        public void GetAmountOfDay()
        {
            AmountOfDayInMonth = DateTime.DaysInMonth(Year, Month);
        }
    }
}
