using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OrderBooks.Models
{
    public class OrderMatch : IEqualityComparer<OrderMatch>
    {

        public OrderMatch(Guid? askId, Guid? bidId)
        {
            
            AskId = (Guid)askId;
            BidId = (Guid)bidId;
        }

        public Guid AskId { get; set; }
        public Guid BidId { get; set; }
        public decimal BTC { get; set; }
        public decimal Price { get; set; }
        public decimal EUR { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            OrderMatch item = (OrderMatch)obj;
            return AskId == item.AskId && BidId == item.BidId && BTC == item.BTC && Price == item.Price && EUR == item.EUR;
        }

        public bool Equals([AllowNull] OrderMatch x, [AllowNull] OrderMatch y)
        {
            if (x == null && x == null)
                return true;
            if (x == null)
                return false;
            return x.Equals(y);
        }

        public override int GetHashCode()
        {
            return (int)Math.Round(BTC * 13, 0) + (int)Math.Round(Price * 17, 0) + (int)Math.Round(EUR * 17, 0);
        }

        public int GetHashCode(OrderMatch obj)
        {
            if (obj == null)
                return 0;
            OrderMatch item = (OrderMatch)obj;
            return item.GetHashCode();
        }
    }
}
