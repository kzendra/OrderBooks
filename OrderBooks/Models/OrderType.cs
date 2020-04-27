namespace OrderBooks.Models
{
    public class OrderType
    {
        public OrderType(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
        public static OrderType Buy { get { return new OrderType("Buy"); } }
        public static OrderType Sell { get { return new OrderType("Sell"); } }
    }
}
