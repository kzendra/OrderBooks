using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderBooks;
using OrderBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderBooks.Tests
{
    [TestClass()]
    public class MatchingAlgorithmTests
    {
        private List<Order> Bids;
        private List<Order> Asks;
        private List<OrderMatch> Matches;

        MatchingAlgorithm matchingAlgorithm;
        public MatchingAlgorithmTests()
        {
        }

        [TestMethod()]
        public void ExecuteTest1()
        {
            TestScenario1();
            RunTest();
        }

        [TestMethod()]
        public void ExecuteTest2()
        {
            TestScenario2();
            RunTest();
        }

        [TestMethod()]
        public void ExecuteTest3()
        {
            TestScenario3();
            RunTest();
        }

        private void RunTest() 
        {
            matchingAlgorithm = new MatchingAlgorithm();
            matchingAlgorithm.Bids.AddRange(Bids);
            matchingAlgorithm.Asks.AddRange(Asks);
            matchingAlgorithm.Execute();
            Assert.IsTrue(matchingAlgorithm.OrderMatches.SequenceEqual(Matches));
        }


        private void TestScenario1()
        {
            Asks = new List<Order>()
            {
                new Order(){Id = new Guid("00000000000000000000000000000001"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 2, Price = 2500}, //2
                new Order(){Id = new Guid("00000000000000000000000000000002"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 5, Price = 2000}, //5
                new Order(){Id = new Guid("00000000000000000000000000000003"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 20, Price = 1500}, //20
                new Order(){Id = new Guid("00000000000000000000000000000004"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 50, Price = 1000}, //50
            };
            Asks = Asks.OrderByDescending(x => x.Price).
                ThenBy(x => x.Time).
                ToList();

            Bids = new List<Order>()
            {
                new Order(){Id = new Guid("00000000000000000000000000000005"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 5000, Price = 2500}, //2
                new Order(){Id = new Guid("00000000000000000000000000000006"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 10000, Price = 2000}, //5
                new Order(){Id = new Guid("00000000000000000000000000000007"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 30000, Price = 1500}, //20
                new Order(){Id = new Guid("00000000000000000000000000000008"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 50000, Price = 1000}, //50
            };
            Bids = Bids.OrderByDescending(x => x.Price).
                ThenBy(x => x.Time).
                ToList();

            Matches = new List<OrderMatch>()
            {
                new OrderMatch(new Guid("00000000000000000000000000000001"),new Guid("00000000000000000000000000000005")) {BTC = 2, Price = 2500, EUR = 5000 },
                new OrderMatch(new Guid("00000000000000000000000000000002"),new Guid("00000000000000000000000000000006")) {BTC = 5, Price = 2000, EUR = 10000 },
                new OrderMatch(new Guid("00000000000000000000000000000003"),new Guid("00000000000000000000000000000007")) {BTC = 20, Price = 1500, EUR = 30000 },
                new OrderMatch(new Guid("00000000000000000000000000000004"),new Guid("00000000000000000000000000000008")) {BTC = 50, Price = 1000, EUR = 50000 },
            };
        }

        private void TestScenario2()
        {
            Asks = new List<Order>()
            {
                new Order(){Id = new Guid("00000000000000000000000000000001"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 1, Price = 2500}, 
                new Order(){Id = new Guid("00000000000000000000000000000002"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 3, Price = 2000}, 
                new Order(){Id = new Guid("00000000000000000000000000000003"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 10, Price = 1600},
                new Order(){Id = new Guid("00000000000000000000000000000004"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 60, Price = 1000},
            };
            Asks = Asks.OrderByDescending(x => x.Price).
                ThenBy(x => x.Time).
                ToList();

            Bids = new List<Order>()
            {
                new Order(){Id = new Guid("00000000000000000000000000000005"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 5000, Price = 2500},
                new Order(){Id = new Guid("00000000000000000000000000000006"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 10000, Price = 2000},
                new Order(){Id = new Guid("00000000000000000000000000000007"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 20000, Price = 1500},
                new Order(){Id = new Guid("00000000000000000000000000000008"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 50000, Price = 1000},
            };
            Bids = Bids.OrderByDescending(x => x.Price).
                ThenBy(x => x.Time).
                ToList();

            Matches = new List<OrderMatch>()
            {
                new OrderMatch(new Guid("00000000000000000000000000000001"),new Guid("00000000000000000000000000000005")) {BTC = 1, Price = 2500, EUR = 2500 },
                new OrderMatch(new Guid("00000000000000000000000000000002"),new Guid("00000000000000000000000000000005")) {BTC = 1.25m, Price = 2000, EUR = 2500 },
                new OrderMatch(new Guid("00000000000000000000000000000002"),new Guid("00000000000000000000000000000006")) {BTC = 1.75m, Price = 2000, EUR = 3500 },
                new OrderMatch(new Guid("00000000000000000000000000000003"),new Guid("00000000000000000000000000000006")) {BTC = 4.0625m, Price = 1600, EUR = 6500 },
                new OrderMatch(new Guid("00000000000000000000000000000004"),new Guid("00000000000000000000000000000007")) {BTC = 20, Price = 1000, EUR = 20000 },
                new OrderMatch(new Guid("00000000000000000000000000000004"),new Guid("00000000000000000000000000000008")) {BTC = 40, Price = 1000, EUR = 40000 },
            };
        }


        private void TestScenario3()
        {
            Asks = new List<Order>()
            {
                new Order(){Id = new Guid("00000000000000000000000000000001"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 2, Price = 4000}, //2
                new Order(){Id = new Guid("00000000000000000000000000000002"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 5, Price = 3500}, //5
                new Order(){Id = new Guid("00000000000000000000000000000003"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 20, Price = 3000}, //20
                new Order(){Id = new Guid("00000000000000000000000000000004"), Time = DateTime.Now, Type = "Sell", Kind = "Limit", Amount = 50, Price = 2800}, //50
            };
            Asks = Asks.OrderByDescending(x => x.Price).
                ThenBy(x => x.Time).
                ToList();

            Bids = new List<Order>()
            {
                new Order(){Id = new Guid("00000000000000000000000000000005"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 5000, Price = 2500}, //2
                new Order(){Id = new Guid("00000000000000000000000000000006"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 10000, Price = 2000}, //5
                new Order(){Id = new Guid("00000000000000000000000000000007"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 30000, Price = 1500}, //20
                new Order(){Id = new Guid("00000000000000000000000000000008"), Time = DateTime.Now, Type = "Buy", Kind = "Limit", Amount = 50000, Price = 1000}, //50
            };
            Bids = Bids.OrderByDescending(x => x.Price).
                ThenBy(x => x.Time).
                ToList();

            Matches = new List<OrderMatch>()
            {
                //new OrderMatch(new Guid("00000000000000000000000000000001"),new Guid("00000000000000000000000000000005")) {BTC = 2, Price = 2500, EUR = 5000 },
                //new OrderMatch(new Guid("00000000000000000000000000000002"),new Guid("00000000000000000000000000000006")) {BTC = 5, Price = 2000, EUR = 10000 },
                //new OrderMatch(new Guid("00000000000000000000000000000003"),new Guid("00000000000000000000000000000007")) {BTC = 20, Price = 1500, EUR = 30000 },
                //new OrderMatch(new Guid("00000000000000000000000000000004"),new Guid("00000000000000000000000000000008")) {BTC = 50, Price = 1000, EUR = 50000 },
            };
        }



    }
}