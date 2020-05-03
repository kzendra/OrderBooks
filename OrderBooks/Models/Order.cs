using System;

namespace OrderBooks.Models
{
    public class Order
    {
        public Order() { }
        public Order(Order order)
        {

            Id = order.Id;
            Time = order.Time;
            Type = order.Type;
            Kind = order.Kind;
            Amount = order.Amount;
            Price = order.Price;
            Completed = 0;
        }
        private Guid id;
        public Guid? Id
        {
            get { return id; }
            set
            {
                if (value == null)
                    id = Guid.NewGuid();
                else
                    id = (Guid)value;
            }
        }

        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string Kind { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Completed { get; set; }
        public decimal Remaining { get { return Amount - Completed; }}


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Order item = (Order)obj;
            return Id == item.Id;
        }

        public override int GetHashCode()
        {
            return (int)Math.Round(Amount * 13,0) + (int)Math.Round(Price * 17, 0);
        }

    }
}
