namespace Inventory
{
    public static class Constants
    {
        public static String API_URL { get; private set; } = String.Empty;

        public static void SetAPI_URL(String url)
        {
            //Check if API_URL is empty to not set more than once
            if (!String.IsNullOrWhiteSpace(API_URL))
            {
                throw new InvalidOperationException("API_URL is already set.");
                //Dont allow API_URL to get set more than once.
            }

            API_URL = url;
        }
    }
}


