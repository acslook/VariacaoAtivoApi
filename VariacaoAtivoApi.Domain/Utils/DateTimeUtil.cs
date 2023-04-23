namespace VariacaoAtivoApi.Domain.Utils
{
    public class DateTimeUtil
    {
        public static DateTime UnixTimeParaDateTime(long unixTime)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTime).ToLocalTime();
            return dateTime;
        }

        public static long DateTimeParaUnixTime(DateTime datetime)
        {
            var unixTime = (long)datetime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTime;
        }
    }   
}
