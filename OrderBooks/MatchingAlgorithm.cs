using OrderBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderBooks
{
    public class MatchingAlgorithm
    {
        public List<Order> Bids { get; private set; } //Buy
        public List<Order> Asks { get; private set; } //Sell

        public List<OrderMatch> OrderMatches { get; private set; }
        public MatchingAlgorithm()
        {
            OrderMatches = new List<OrderMatch>();
            Bids = new List<Order>();
            Asks = new List<Order>();
        }
        public void Execute() 
        {
            //Execute matching price
            int x = 0;
            var asks = Asks.ToList();
            List<Order> completedAsks = new List<Order>();

            foreach (var bid in Bids)
            {
                x++;
                
                //asks = asks.Where(x => x.Price <= bid.Price).Where(x => x.Remaining != 0).ToList();

                asks = asks.Where(x=> x.Remaining!=0).Where(x => x.Price <= bid.Price).ToList();
                if (asks.Count() == 0)
                    break;
                Console.WriteLine($"Working bid No. {x}, remaining asks: {asks.Count()}");
                for (int askIndex = 0; askIndex < Asks.Count(); askIndex++) 
                {
                    //if (askIndex >= asks.Count())
                    //    break;
                    var ask = Asks[askIndex];
                    if (ask.Remaining == 0)
                        continue;
                    if (bid.Price >= ask.Price)
                    {//match
                        decimal btcAmount = 0;
                        OrderMatch match = new OrderMatch(ask.Id, bid.Id);


                        if (bid.Remaining/ask.Price > ask.Remaining)
                            btcAmount = ask.Remaining;
                        else
                        {
                            btcAmount = bid.Remaining / ask.Price;
                        }
                        if (btcAmount > ask.Remaining)
                        {
                            var matches = OrderMatches.Where(x => x.AskId == ask.Id);
                            Console.WriteLine("WTF?");
                        }
                        //Add Match to list and fix ask and bid

                        ask.Completed += btcAmount;

                        bid.Completed += btcAmount * ask.Price;

                        match.BTC = btcAmount;
                        match.Price = ask.Price;
                        match.EUR = btcAmount * ask.Price;
                        OrderMatches.Add(match);
                        //Console.WriteLine($"Working bid No. {x}, ask No. {askIndex}, bid remaining: {bid.Remaining}, ask remaining: {ask.Remaining}");
                        if (ask.Remaining == 0)
                            completedAsks.Add(ask);

                        if (bid.Remaining == 0)
                            break;                       
                    }
                }
            }
            Console.WriteLine($"Completed {completedAsks.Count()} Asks");
            //foreach (var ask in removeAsks)
            //    Asks.Remove(ask);
        }
    }
}
