using Newtonsoft.Json;
using OrderBooks.Models;
using System.Collections.Generic;

namespace OrderBooks
{
    public class ReadJsonData
    {
        private ReadData data;
        public List<OrdersRequest> OrdersRequests { get; private set; }

        public ReadJsonData(ReadData data)
        {
            this.data = data;
            OrdersRequests = new List<OrdersRequest>();
        }

        public void Execute()
        {
            foreach (var jsonLine in data.Rows)
            {
                var data = DeserializeJson(jsonLine);
                OrdersRequests.Add(data);
            }
        }
        public OrdersRequest DeserializeJson(string jsonLine)
        {
            var data = JsonConvert.DeserializeObject<OrdersRequest>(jsonLine);
            return data;
        }
    }
}
