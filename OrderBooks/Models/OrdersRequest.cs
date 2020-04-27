using System;
using System.Collections.Generic;

namespace OrderBooks.Models
{
    public class OrdersRequest
    {
        public DateTime AcqTime { get; set; }
        public IList<Bid> Bids { get; set; }
        public IList<Ask> Asks { get; set; }
    }
}
