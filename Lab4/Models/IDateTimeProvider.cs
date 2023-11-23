namespace Lab4.Models
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTime();
    }
    public class CurrentDataTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
