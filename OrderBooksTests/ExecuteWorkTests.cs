using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderBooks.Tests
{
    [TestClass()]
    public class ExecuteWorkTests
    {
        [TestMethod()]
        public void MatchDataFromFileTest()
        {
            var x = new ExecuteWork();
            x.MatchDataFromFile("..\\..\\..\\..\\OrderBooks\\order_books_data.json");
            decimal sumEUR1 = Math.Round(x.totalBids + x.totalMatchesEUR,8);
            decimal sumBTC1 = Math.Round(x.totalAsks + x.totalMatchesBTC, 8);
            x.SetTotals();
            decimal sumEUR2 = Math.Round(x.totalBids + x.totalMatchesEUR, 8);
            decimal sumBTC2 = Math.Round(x.totalAsks + x.totalMatchesBTC, 8);
            Console.Beep();
            Assert.IsTrue(sumEUR1 == sumEUR2);
            Assert.IsTrue(sumBTC1 == sumBTC2);
        }
    }
}