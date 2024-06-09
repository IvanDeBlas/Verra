namespace ConsoleAppFraudDetection.Helpers
{
    internal static class NormalizeHelper
    {
        internal static string Email(string email)
        {
            string[] parts = email.Split('@');

            string username = parts[0];
            if (username.Contains("+"))
            {
                string[] user = username.Split('+');
                username = user[0];
            }

            return username.Replace(".", "") + "@" + parts[1].ToLower();
        }

        internal static string Address(string streetAddress, string city, string state, string zipCode)
        {
            string normalizedStreet = streetAddress.ToLower().Replace("street", "st.").Replace("road", "rd.");
            string normalizedState = state.ToLower().Replace("illinois", "il").Replace("california", "ca").Replace("new york", "ny");
            return $"{normalizedStreet}_{city.ToLower()}_{normalizedState}_{zipCode}";
        }

        internal static string CreditCard(string creditCardNumber)
        {
            return creditCardNumber.Replace(" ", "");
        }
    }
}
