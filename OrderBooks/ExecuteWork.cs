using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderBooks
{
    public class ExecuteWork
    {
        public decimal totalBids;
        public decimal totalAsks;
        public decimal totalMatchesEUR;
        public decimal totalMatchesBTC;
        MatchingAlgorithm matchingAlgorithm;
        public void MatchDataFromFile(string fileName)
        {

            var dataFile = new ReadDataFile(fileName);
            dataFile.ReadFile();
            ReadJson jsonData = new ReadJson(dataFile.Rows);
            jsonData.Execute();
            matchingAlgorithm = new MatchingAlgorithm();
            matchingAlgorithm.Bids.AddRange(jsonData.GetBids());
            matchingAlgorithm.Asks.AddRange(jsonData.GetAsks());
            SetTotals();
            matchingAlgorithm.Execute();
        }

        public void SetTotals()
        {
            totalBids = matchingAlgorithm.Bids.Sum(x => x.Remaining);
            totalAsks = matchingAlgorithm.Asks.Sum(x => x.Remaining);
            totalMatchesEUR = matchingAlgorithm.OrderMatches.Sum(x => x.EUR);
            totalMatchesBTC = matchingAlgorithm.OrderMatches.Sum(x => x.BTC);
        }

    }
}
