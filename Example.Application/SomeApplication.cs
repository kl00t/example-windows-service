using System.Globalization;

namespace Example.Application
{
    public class SomeApplication : ISomeApplication
    {
        public string OutputDateTime()
        {
            return System.DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}