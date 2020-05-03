using Newtonsoft.Json;
using OrderBooks.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderBooks
{
    public class ReadJson
    {
        private List<string> rows;

        private OrdersRequest OrdersRequest { get; set; }

        public ReadJson(List<string> rows)
        {
            this.rows = rows;
            OrdersRequest = new OrdersRequest();
            OrdersRequest.Asks = new List<Ask>();
            OrdersRequest.Bids = new List<Bid>();
        }

        public void Execute()
        {
            foreach (var jsonLine in rows)
            {
                var data = DeserializeJson(jsonLine);
                OrdersRequest.Asks.AddRange(data.Asks);
                OrdersRequest.Bids.AddRange(data.Bids);
            }
        }
        public OrdersRequest DeserializeJson(string jsonLine)
        {
            var data = JsonConvert.DeserializeObject<OrdersRequest>(jsonLine);
            return data;
        }

        public List<Order> GetBids()
        {
            return OrdersRequest.Bids.AsQueryable().
                Select(x => new Order(x.Order)).
                OrderByDescending(x=> x.Price).
                ThenBy(x=> x.Time).
                ToList();
        }

        public List<Order> GetAsks()
        {
            return OrdersRequest.Asks.AsQueryable().
                Select(x => new Order(x.Order)).
                OrderByDescending(x => x.Price).
                ThenBy(x => x.Time).
                ToList();
        }
    }
}
