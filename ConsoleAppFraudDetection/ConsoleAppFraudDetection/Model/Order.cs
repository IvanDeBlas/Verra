namespace ConsoleAppFraudDetection.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string CreditCardNumber { get; set; } = null!;
    }
}
