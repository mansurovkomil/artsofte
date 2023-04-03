using ProductsMarket.Domain.Constants;

namespace ProductsMarket.Service.Common.Helpers
{
    public class TimeHelper
    {
        public static DateTime GetCurrentServerTime()
        {
            var date = DateTime.UtcNow;
            return date.AddHours(TimeConstants.UTC);
        }
    }
}
