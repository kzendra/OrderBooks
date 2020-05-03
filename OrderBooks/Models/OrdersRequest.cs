using System;
using System.Collections.Generic;

namespace OrderBooks.Models
{
    public class OrdersRequest
    {
        public DateTime AcqTime { get; set; }
        public List<Bid> Bids { get; set; }
        public List<Ask> Asks { get; set; }
    }
}
