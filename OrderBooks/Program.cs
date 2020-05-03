using System;

namespace OrderBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new ExecuteWork();
            x.MatchDataFromFile("..\\..\\..\\..\\OrderBooks\\order_books_data.json");
        }

    }
}
