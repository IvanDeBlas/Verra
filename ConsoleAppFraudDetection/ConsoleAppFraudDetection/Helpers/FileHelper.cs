using ConsoleAppFraudDetection.Model;

namespace ConsoleAppFraudDetection.Helpers
{
    internal static class FileHelper
    {
        internal static List<Order> GetOrders(List<string> inputLines)
        {
            if (!Int32.TryParse(inputLines[0], out int numberOfLines))
                throw new ArgumentException("First line will contain a integer N denoting the number of records.");

            List<Order> orders = new List<Order>();
            foreach (string line in inputLines.Skip(1))
            {
                string[] orderInfo = line.Split(',');
                Order order = new Order
                {
                    Id = int.Parse(orderInfo[0]),
                    DealId = int.Parse(orderInfo[1]),
                    Email = orderInfo[2],
                    Address = orderInfo[3],
                    City = orderInfo[4],
                    State = orderInfo[5],
                    ZipCode = orderInfo[6],
                    CreditCardNumber = orderInfo[7]
                };
                orders.Add(order);
            }

            var check = numberOfLines == orders.Count;
            if(!check)
                throw new ArgumentException("Number of records incorrect.");

            return orders;
        }
    }
}
