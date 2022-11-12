namespace CvBuilder.Core.Helpers
{
    public static class DateTimeHelper
    {
        ///https://stackoverflow.com/questions/14149346/what-value-should-i-pass-into-timezoneinfo-findsystemtimezonebyidstring
        private const string TIMEZONE_USAGE = "Argentina Standard Time";

        public static DateTime GetSystemDate()
            => TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById(TIMEZONE_USAGE)
                );

        //public static string GetDateDetail()
        //{
        //    var today = GetSystemDate();
        //    var day = today.Date.Day;
        //    var month = GetMonthName(today.Date.Month);
        //    var year = today.Date.Year;
        //    return $"{day} de {month} de {year}";
        //}

        //public static string GetMonthName(int month)
        //{
        //    string result = month switch
        //    {
        //        1 => "ENERO",
        //        2 => "FEBRERO",
        //        3 => "MARZO",
        //        4 => "ABRIL",
        //        5 => "MAYO",
        //        6 => "JUNIO",
        //        7 => "JULIO",
        //        8 => "AGOSTO",
        //        9 => "SEPTIEMBRE",
        //        10 => "OCTUBRE",
        //        11 => "NOVIEMBRE",
        //        12 => "DICIEMBRE",
        //        _ => string.Empty,
        //    };
        //    return result;
        //}

    }
}
