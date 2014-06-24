
namespace Example.Common
{
    public static class Settings
    {
        public static void Edit(string property, object value)
        {
            Constants.AppSettings[property] = value;
            Constants.AppSettings.Save();
        }
        public static void Add(string property, object value)
        {
            if (Constants.AppSettings.Contains(property))
                return;

            Constants.AppSettings[property] = value;
            Constants.AppSettings.Save();
        }
        public static object Get(string property)
        {
            return Constants.AppSettings.Contains(property) ? Constants.AppSettings[property] : null;
        }
        public static bool Exist(string property)
        {
            return Constants.AppSettings.Contains(property);
        }

    }
}
