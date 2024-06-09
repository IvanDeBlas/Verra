using ConsoleAppFraudDetection.Helpers;
using ConsoleAppFraudDetection.Model;

namespace ConsoleAppFraudDetection.Validation
{
    internal static class FraudDetection
    {      
        internal static List<int> DetectFraudulentOrders(List<Order> orders)
        {
            Dictionary<string, HashSet<int>> emailDealMap = new Dictionary<string, HashSet<int>>();
            Dictionary<string, HashSet<int>> addressMap = new Dictionary<string, HashSet<int>>();

            foreach (var order in orders)
            {
                string normalizedEmail = NormalizeHelper.Email(order.Email);
                string normalizedAddress = NormalizeHelper.Address(order.Address, order.City, order.State, order.ZipCode);
                string normalizedCreditCard = NormalizeHelper.CreditCard(order.CreditCardNumber);

                // Check for fraud based on email and deal
                string emailDealKey = $"{normalizedEmail}_{order.DealId}";
                if (!emailDealMap.ContainsKey(emailDealKey))
                {
                    emailDealMap[emailDealKey] = new HashSet<int> { order.Id };
                }
                else
                {
                    // If the email and deal combination exists, check if the credit card information is different
                    foreach (var orderId in emailDealMap[emailDealKey])
                    {
                        if (orders.FirstOrDefault(o => o.Id == orderId)?.CreditCardNumber != normalizedCreditCard)
                        {
                            emailDealMap[emailDealKey].Add(order.Id);
                            break;
                        }
                    }
                }

                // Check for fraud based on address and deal
                string addressKey = $"{normalizedAddress}_{order.DealId}";
                if (!addressMap.ContainsKey(addressKey))
                {
                    addressMap[addressKey] = new HashSet<int> { order.Id };
                }
                else
                {
                    // If the address and deal combination exists, check if the credit card information is different
                    foreach (var orderId in addressMap[addressKey])
                    {
                        if (orders.FirstOrDefault(o => o.Id == orderId)?.CreditCardNumber != normalizedCreditCard)
                        {
                            addressMap[addressKey].Add(order.Id);
                            break;
                        }
                    }
                }
            }

            // Find fraudulent orders
            HashSet<int> fraudulentOrders = new HashSet<int>();
            foreach (var kvp in emailDealMap)
            {
                if (kvp.Value.Count > 1)
                {
                    fraudulentOrders.UnionWith(kvp.Value);
                    //Console.WriteLine($"emailDealMap: {kvp.Key}, Ids: {string.Join(",", kvp.Value.ToArray().OrderBy(p => p))}");
                }
            }

            foreach (var kvp in addressMap)
            {
                if (kvp.Value.Count > 1)
                {
                    fraudulentOrders.UnionWith(kvp.Value);
                    //Console.WriteLine($"addressMap: {kvp.Key}, Ids: {string.Join(",", kvp.Value.ToArray().OrderBy(p => p))}");
                }
            }

            return fraudulentOrders.OrderBy(id => id).ToList();
        }
    }
}
