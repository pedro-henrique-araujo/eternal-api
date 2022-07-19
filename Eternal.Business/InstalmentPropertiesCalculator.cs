namespace Eternal.Business
{
    public class InstalmentPropertiesCalculator
    {

        public static decimal CalculateInstalmentValue(decimal contractValue, int numberOfInstalments)
        {
            return Math.Round(contractValue / numberOfInstalments);
        }

        public static int CalculateNumberOfInstalments(DateTime expiration)
        {
            var interval = expiration - DateTime.Now;
            return Convert.ToInt32(Math.Floor(interval.Days / 30M));
        }
    }
}